namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    class Program
    {
        static OrderedBag<Task> priorityQueue = new OrderedBag<Task>(QueueComparator);

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            int numberOfComands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfComands; i++)
            {
                string command = Console.ReadLine();
                result.Append(ProcessCommand(command));
            }

            Console.WriteLine(result.ToString().Trim());
        }

        private static string ProcessCommand(string command)
        {
            string result;
            if (command == "Solve")
            {
                if (priorityQueue.Count == 0)
                {
                    result = "Rest\r\n";
                }
                else
                {
                    result = priorityQueue.First().TaskString + "\r\n";
                    priorityQueue.Remove(priorityQueue.First());
                }
            }
            else
            {
                string[] commandParameters = command.Split(new char[] { ' ' }, 3);
                int priority = int.Parse(commandParameters[1]);
                string task = commandParameters[2];
                priorityQueue.Add(new Task(priority, task));
                result = string.Empty;
            }

            return result;
        }

        private static int QueueComparator(Task firstTask, Task secondTask)
        {
            int compareResult = firstTask.Priority.CompareTo(secondTask.Priority);

            if (compareResult == 0)
            {
                compareResult = firstTask.TaskString.CompareTo(secondTask.TaskString);
            }

            return compareResult;
        }

        private class Task
        {
            public int Priority { get; private set; }
            public string TaskString { get; private set; }

            public Task(int priority, string task)
            {
                this.Priority = priority;
                this.TaskString = task;
            }

            public override string ToString()
            {
                return this.TaskString;
            }
        }
    }
}