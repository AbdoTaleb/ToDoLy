using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ToDoLy.Models;
namespace ToDoLy.Persistence
{
    public static class FileService
    {
        private const string FilePath = "tasks.txt";

        public static void Save(List<TaskItem> task)
        {
            var lines = task.Select(t => $"{t.Title}|{t.DueDate:yyyy-MM-dd}|{(t.IsDone ? "Done" : "Not Done")}|{t.Project}").ToList();
            File.WriteAllLines(FilePath, lines);
        }

        public static List<TaskItem> Load()
        {
            var tasks = new List<TaskItem>();
            if (!File.Exists(FilePath))
            {
                return tasks;
            }

            var lines = File.ReadAllLines(FilePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length != 4) continue;

                string title = parts[0];
                DateTime dueDate = DateTime.TryParse(parts[1], out var parsedDate) ? parsedDate : DateTime.Now;
                bool isDone = parts[2].Trim().ToLower() == "done";
                string project = parts[3];

                tasks.Add(new TaskItem(title, dueDate, project) { IsDone = isDone });

            }
            return tasks;
        }
    }
}
