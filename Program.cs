using System;

namespace CapstoneTaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                PrintOptions();
                string userInput = GetUserInput("\nPlease choose one of the 5 options: ");
                SelectMenuOptions(userInput);
            }

        }

        public static string GetUserInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public static void CreateTask()
        {
            Task task = new Task();

            task.Name = GetUserInput("\nEnter Name: ");
            task.Description = GetUserInput("Enter Description: ");
            task.DueDate = ValiDate("Enter Due Date: ");

            Task.AddTask(task);
        }

        public static void RemoveTask()
        {
            Task.DisplayTasks();

            string userInput = GetUserInput("\nEnter the number of the task you want to delete: ");
            int input = int.Parse(userInput);

            string confirm = GetUserInput("\nAre you sure you want to delete this task? (y/n) ").ToLower();
            if (confirm == "y" || confirm == "yes")
            {
                Task.RemoveTask(input-1);
            }
        }

        public static void MarkComplete()
        {
            Task.DisplayTasks();

            string userInput = GetUserInput("\nEnter Task Number to be marked complete: ");
            int input = int.Parse(userInput);

            string confirm = GetUserInput("\nAre you sure you want to mark this task completed? (y/n) ").ToLower();
            if (confirm == "y" || confirm == "yes")
            {
                Task.MarkCompleted(input-1);
            }

           
        }

        public static DateTime ValiDate(string message)
        {
            try
            {
                return DateTime.Parse(GetUserInput(message));
            }
            catch
            {
                Console.WriteLine("Not a valid date");
                return ValiDate(message);
            }
        }

        public static void PrintOptions()
        {
            Console.WriteLine("1. List tasks");
            Console.WriteLine("2. Add task");
            Console.WriteLine("3. Delete task");
            Console.WriteLine("4. Mark task complete");
            Console.WriteLine("5. Quit");
        }

        public static void SelectMenuOptions(string userInput)
        {
            switch (userInput)
            {
                case "1":
                case "List tasks":
                    Task.DisplayTasks();
                    break;
                case "2":
                case "Add task":
                    CreateTask();
                    break;
                case "3":
                case "Delete tasks":
                    RemoveTask();
                    break;
                case "4":
                case "Mark task complete":
                    MarkComplete();
                    break;
                case "5":
                case "Quit":
                    Console.WriteLine("\nGoodbye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
        }
    }
}
