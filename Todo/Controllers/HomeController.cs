using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Todo.Controllers
{
    public class HomeController : Controller
    {
        ToDoListDB db = new ToDoListDB();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ShowTask(string id)
        {
            List<Task> task = new List<Task>();
            task = db.Tasks.ToList();
            return Json(task, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateTask(string t)
        {
            //SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);    
            Task tsk = new Task();
            tsk.title = t;
            db.Tasks.Add(tsk);
            db.SaveChanges();
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult DeleteTask(string id)
        {
            var deleted = db.Tasks.FirstOrDefault(x => x.id.ToString() == id);
            if(deleted != null)
            {
                db.Tasks.Remove(deleted);
                db.SaveChanges();
            }           
            return Json(JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult EditTask(Task t)
        //{
        //    var edited = db.Tasks.FirstOrDefault(x => x.id.ToString() == t.id.ToString());
        //    if (edited != null)
        //    {
        //        edited.id = t.id;
        //        edited.title = t.title;
        //        db.SaveChanges();
        //    }

        //    return Json(JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public JsonResult EditTask(string id, string t)
        {
            var edited = db.Tasks.FirstOrDefault(x => x.id.ToString() == id);
            if (edited != null)
            {
                edited.title = t;
                db.SaveChanges();
            }

            return Json(JsonRequestBehavior.AllowGet);
        }
    }//end class
}