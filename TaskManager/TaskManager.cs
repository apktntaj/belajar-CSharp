using System;
using System.Collections.Generic;
using System.IO;

class TaskManager
{
    private static readonly List<Task> tasks = new();
    private const string filePath = "tasks.txt";

    public static void Run()
    {
        LoadTasks();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Task Manager");
            Console.WriteLine("C => Add Task");
            Console.WriteLine("R => View Tasks");
            Console.WriteLine("U => Mark Task as Completed");
            Console.WriteLine("D => Remove Task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "C":
                    AddTask();
                    break;
                case "D":
                    RemoveTask();
                    break;
                case "U":
                    MarkTaskAsCompleted();
                    break;
                case "R":
                    ViewTasks();
                    break;
                case "5":
                    SaveTasks();
                    return;
                default:
                    Console.WriteLine("Invalid option! Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void AddTask()
    {
        Console.Write("Enter task name: ");
        string name = Console.ReadLine() ?? string.Empty;
        tasks.Add(new Task { Name = name, IsCompleted = false });
        Console.WriteLine("Task added! Press any key to return.");
        Console.ReadKey();
    }

    private static void RemoveTask()
    {
        ViewTasks();
        Console.Write("Enter task number to remove: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            tasks.RemoveAt(index - 1);
            Console.WriteLine("Task removed! Press any key to return.");
        }
        else
        {
            Console.WriteLine("Invalid task number! Press any key to return.");
        }
        Console.ReadKey();
    }

    private static void MarkTaskAsCompleted()
    {
        ViewTasks();
        Console.Write("Enter task number to mark as completed: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            tasks[index - 1].IsCompleted = true;
            Console.WriteLine("Task marked as completed! Press any key to return.");
        }
        else
        {
            Console.WriteLine("Invalid task number! Press any key to return.");
        }
        Console.ReadKey();
    }

    private static void ViewTasks()
    {
        Console.Clear();
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                var task = tasks[i];
                Console.WriteLine($"{i + 1}. {task.Name} {(task.IsCompleted ? "(Completed)" : "")}");
            }
        }
        Console.WriteLine("\nPress any key to return.");
        Console.ReadKey();
    }

    private static void SaveTasks()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var task in tasks)
            {
                writer.WriteLine($"{task.Name}|{task.IsCompleted}");
            }
        }
    }

    private static void LoadTasks()
    {
        Console.WriteLine("Loading tasks...");
        if (!File.Exists(filePath)) return;

        StreamReader reader = new(filePath);
        string? task;
        while ((task = reader.ReadLine()) is not null)
        {
            var parts = task.Split('|');
            tasks.Add(new Task { Name = parts[0], IsCompleted = bool.Parse(parts[1]) });
        }
    }
}

class Task
{
    required public string Name { get; set; }
    public bool IsCompleted { get; set; }
}
