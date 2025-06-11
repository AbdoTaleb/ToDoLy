using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoLy.Models;

namespace ToDoLy.Services
{
    public class TaskManager
    {
        public List<TaskItem> Tasks { get; set; } = new();
        public void AddTask(TaskItem task)
        {
            Tasks.Add(task);
        }
        public void RemoveTask(int index)
        {
            if(index >= 0 && index < Tasks.Count)
                Tasks.RemoveAt(index);
        }
        public void EditTask(int index, TaskItem updatedTask)
        {
            if(index >= 0 && index < Tasks.Count)
            {
                Tasks[index] = updatedTask;
            }
        }

        public void MarkTaskAsDone(int index)
        {
            if(index >= 0 && index < Tasks.Count)
            {
                Tasks[index].MarkAsDone();
            }
        }

        public List<TaskItem> GetTasksSortedByDate()
        {
            return Tasks.OrderBy(t => t.DueDate).ToList();  
        }

        public List<TaskItem> GetTasksSortedByProject()
        {
            return Tasks.OrderBy(t=> t.Project).ToList();   
        }

        public int CountDone() => Tasks.Count(t => t.IsDone);
        public int CountTodo() => Tasks.Count(t => !t.IsDone);
    }
}
