using ToDoLy.Models;
using ToDoLy.Persistence;
using ToDoLy.Services;


class Program
{
    
    static void Main(string[] args)
    {
        var manager = new TaskManager();
        manager.Tasks = FileService.Load(); 

        var menu = new MenuService(manager);
        menu.ShowMainMenu();

        FileService.Save(manager.Tasks);

    }
    
}