# ToDoLy – Simple Console Task Manager 📝

ToDoLy is a lightweight command-line To-Do list manager built with C#.  
It allows users to add, view, update, mark as done, and remove tasks. Tasks are saved to a file for persistence between sessions.

---

## 💡 Features

- ✅ Add new tasks with title, due date, and project
- 📅 View tasks sorted by **due date** or **project**
- ✏️ Edit existing tasks (update, mark as done, or remove)
- 💾 Tasks are saved to a local file (`tasks.txt`)
- 🧠 Clean and user-friendly menu interface

---

## 🛠 Project Structure

ToDoLy/
├── Models/
│ └── TaskItem.cs # Represents a task
│
├── Services/
│ ├── TaskManager.cs # Manages the task list
│ └── MenuService.cs # Handles menu UI and user input
│
├── Persistence/
│ └── FileService.cs # Handles saving/loading from a file
│
├── Program.cs # Entry point
└── tasks.txt # Saved task list (auto-generated)

---

## ▶️ How to Run

1. Open the solution in **Visual Studio**.
2. Build and run the project.
3. Use the menu to manage your tasks via terminal.

---

## 💾 Data Format

Tasks are saved as lines in `tasks.txt` like this:
Buy groceries|2025-06-12|Not Done|Home


Each task contains:  
**Title | Due Date | Status (Done / Not Done) | Project**

---

## 📌 Requirements

- .NET 6.0 or newer
- Visual Studio or `dotnet` CLI

---

## 🙋 Author

Made with 💻 by Abdo Taleb  
Feel free to fork, improve, or suggest features.

