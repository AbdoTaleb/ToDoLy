using ToDoLy.Services;
using ToDoLy.Models;


class Program
{
    
    static void Main(string[] args)
    {
        TaskManager manager = new();
        MenuService menu = new(manager);
        menu.ShowMainMenu();

    }
    
}