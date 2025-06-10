using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoLy.Models
{
    public class TaskItem
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
        public string Project { get; set; } 

        public TaskItem(string title, DateTime dueDate, string project)
        {
            Title = title;
            DueDate = dueDate;
            IsDone = false;
            Project = project;
        }

        public void MarkAsDone()
        {
            IsDone = true;
        }

        public override string ToString()
        {
            return $"{Title} | Due: {DueDate.ToShortDateString()} | Project: {Project} | Done: {IsDone}";
        }
    }
}
