using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTaskList
{
    class Task
    {
        private static List<Task> _tasks = new List<Task>
        {
            new Task("Harry Potter", "Sweeps the floor", DateTime.Parse("10/28/19")),
            new Task("Ron Weasley", "Washes the windows", DateTime.Parse("10/29/19")),
            new Task("Hermione Granger", "Walks the dragon", DateTime.Parse("10/30/19")),
            new Task("Hagrid", "Bakes cookies", DateTime.Parse("10/31/19"))
        };

        #region fields
        private string _name;
        private string _description;
        private DateTime _dueDate;
        private bool _complete;
        #endregion

        #region properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public DateTime DueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }
        public bool Complete
        {
            get { return _complete; }
            set { _complete = value; }
        }

        #endregion

        #region constructors
        public Task()
        {

        }

        public Task(string name, string description, DateTime dueDate, bool complete = false)
        {
            Name = name;
            Description = description;
            DueDate = dueDate;
            Complete = complete;
        }

        public static void DisplayTasks()
        {
            for (int i = 0; i < _tasks.Count; i++)
            {
                Console.WriteLine($"\n\t{i + 1}. {_tasks[i].Name}");
                Console.WriteLine($"\tDescription {_tasks[i].Description}");
                Console.WriteLine($"\tDue Date: {_tasks[i].DueDate.ToShortDateString()}");
                Console.WriteLine($"\tCompleted? {_tasks[i].Complete}\n");
            }
        }

        public static void AddTask(Task task)
        {
            _tasks.Add(task);
        }

        public static void RemoveTask(int userInput)
        {
            _tasks.RemoveAt(userInput);
        }

        public static void MarkCompleted(int userInput)
        {
            Task foundTask = _tasks[userInput];
            foundTask.Complete = true;

        }
        #endregion
    }
}
