using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Todo.Models
{
    public partial class ToDoListDB : DbContext
    {
        public ToDoListDB()
            : base("name=ToDoListDB")
        {
        }

        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
