create database ToDoList;

use ToDoList;

create table Task(
	Id int not null primary key,
    Task nvarchar(255) not null
);
