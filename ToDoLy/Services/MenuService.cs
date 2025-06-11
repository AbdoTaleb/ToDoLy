using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoLy.Models;

namespace ToDoLy.Services
{
    public class MenuService
    {
        private readonly TaskManager _manager;
        public MenuService(TaskManager manager)
        {
            _manager = manager;
        }
        public void ShowMainMenu()
        {
            Console.WriteLine("Welcome to ToDoLy!");
            Console.WriteLine("You have {0} tasks (Todo: {1}, Done: {2})\n",
                _manager.Tasks.Count, _manager.CountTodo(), _manager.CountDone());

            bool running = true;
            while (running)
            {
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("(1) Show Task List (by date or project)");
                Console.WriteLine("(2) Add New Task");
                Console.WriteLine("(3) Edit Task (update, mark as done, remove)");
                Console.WriteLine("(4) Save and Quit");
                Console.Write("> ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowTasksMenu();
                        break;
                    case "2":
                        AddNewTask();
                        break;
                    case "3":
                        EditTaskMenu();
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Saving... (not implemented yet)");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Goodbye!");
        }
        public void AddNewTask()
        {
            Console.WriteLine("\n --- Add New Task ---");
            Console.Write("Enter task title: ");
            string title = Console.ReadLine();

            Console.Write("Enter task date (yyyy-mm-dd): ");
            DateTime dueDate;
            while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
            {
                Console.Write("Invalid date format. Please enter again (yyyy-mm-dd): ");
            }

            Console.WriteLine("Enter Project Name: ");
            string project = Console.ReadLine();

            TaskItem newTask = new TaskItem(title, dueDate, project);
            _manager.AddTask(newTask);

            Console.WriteLine("Task added successfully!");
        }
        private void ShowTasksMenu()
        {
            Console.WriteLine("\n --- Show Task List ---");
            Console.WriteLine("Choose sorting option:");
            Console.WriteLine("(1) By Due Date");
            Console.WriteLine("(2) By Project Name");
            Console.Write("> ");

            
            string choice = Console.ReadLine();
            List<TaskItem> sortedTasks;
            if (choice == "1")
            {
                sortedTasks = _manager.GetTasksSortedByDate();
                Console.WriteLine("\n--- Tasks Sorted by Due Date ---");
            }
            else if (choice == "2")
            {
                sortedTasks = _manager.GetTasksSortedByProject();
                Console.WriteLine("\n--- Tasks Sorted by Project ---");
            }
            else
            {
                Console.WriteLine("Invalid choice. Returning to main menu.");
                return;
            }

            if (sortedTasks.Count == 0)
            {
                Console.WriteLine("No tasks to show.");
                return;
            }

            for (int i = 0; i < sortedTasks.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {sortedTasks[i]}");
            }
        }
        private void EditTaskMenu()
        {
            Console.WriteLine("\n --- Edit Task ---");
            if (_manager.Tasks.Count == 0)
            {
                Console.WriteLine("No tasks to edit.");
                return;
            }
            for (int i = 0; i < _manager.Tasks.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {_manager.Tasks[i]}");
            }
            Console.Write("Enter task number to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int userIndex) || userIndex < 1 || userIndex > _manager.Tasks.Count)
            {
                Console.WriteLine("Invalid index.");
                return;
            }

            int index = userIndex - 1;

            Console.WriteLine("Choose action: (1) Update  |  (2) Mark as Done  |  (3) Remove");
            Console.Write("> ");
            string action = Console.ReadLine();

            switch (action)
            {
                case "1":
                    UpdateTask(index);
                    break;
                case "2":
                    _manager.MarkTaskAsDone(index);
                    Console.WriteLine("Task marked as done.");
                    break;
                case "3":
                    _manager.RemoveTask(index);
                    Console.WriteLine("Task removed.");
                    break;
                default:
                    Console.WriteLine("Invalid action. Returning to main menu.");
                    break;
            }


        }
        private void UpdateTask(int index) { 
            var oldTask = _manager.Tasks[index];

            Console.WriteLine("\n--- Update Task ---");

            Console.WriteLine($"Title: {oldTask.Title}");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTitle))
            {
                oldTask.Title = newTitle;
            }

            Console.Write($"Due Date ({oldTask.DueDate:yyyy-MM-dd}): ");
            string dateInput = Console.ReadLine();
            DateTime newDueDate = oldTask.DueDate;
            if (!string.IsNullOrWhiteSpace(dateInput))
            {
                if (!DateTime.TryParse(dateInput, out newDueDate))
                {
                    Console.WriteLine("Invalid date format. Keeping old date.");
                    newDueDate = oldTask.DueDate;
                }
            }

            Console.Write($"Project ({oldTask.Project}): ");
            string newProject = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(newProject)) newProject = oldTask.Project;

            TaskItem updatedTask = new TaskItem(newTitle, newDueDate, newProject)
            {
                IsDone = oldTask.IsDone // Keep the done status
            };
            _manager.EditTask(index, updatedTask);
            Console.WriteLine("Task updated successfully!");
        }
            
    }
}
