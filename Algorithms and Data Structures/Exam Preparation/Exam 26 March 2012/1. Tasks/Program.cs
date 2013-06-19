namespace Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    class Program
    {
        static PriorityQueue<Task> pq;

        static void Main(string[] args)
        {
            pq = new PriorityQueue<Task>();
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
                if (pq.Count == 0)
                {
                    result = "Rest\r\n";
                }
                else
                {
                    result = pq.GetTop().TaskString + "\r\n";
                }
            }
            else
            {
                string[] commandParameters = command.Split(new char[] { ' ' }, 3);
                int priority = int.Parse(commandParameters[1]);
                string task = commandParameters[2];
                pq.Add(new Task(priority, task));
                result = string.Empty;
            }

            return result;
        }

        private class Task : IComparable<Task>
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

            public int CompareTo(Task other)
            {
                int priorityComparison = this.Priority.CompareTo(other.Priority);

                if (priorityComparison == 0)
                {
                    return this.TaskString.CompareTo(other.TaskString);
                }

                return priorityComparison;
            }
        }
    }

    public class PriorityQueue<T> where T : IComparable<T>
    {
        public PriorityQueue()
        {
            elements = new List<T>();
            nextElementPosition = 0;
        }

        private readonly List<T> elements;

        private int nextElementPosition;

        public int Count
        {
            get
            {
                return this.nextElementPosition;
            }
        }

        public void Add(T element)
        {
            if (nextElementPosition < this.elements.Count)
            {
                this.elements[nextElementPosition] = element;
            }
            else
            {
                this.elements.Add(element);
            }

            this.nextElementPosition++;
            this.Float(this.Count - 1);
        }

        public T GetTop()
        {
            var result = elements[0];
            this.SwapElements(0, this.Count - 1);
            this.elements.RemoveAt(this.Count - 1);
            this.nextElementPosition--;
            this.Sink(0);
            return result;
        }

        private void Float(int element)
        {
            int currentElementPos = element;
            int parent = (currentElementPos - 1) / 2;
            while (currentElementPos > 0 &&
                this.elements[parent].CompareTo(this.elements[currentElementPos]) > 0)
            {
                this.SwapElements(parent, currentElementPos);
                currentElementPos = parent;
                parent = (currentElementPos - 1) / 2;
            }
        }

        private void Sink(int pos)
        {
            int elementPos = pos;

            while (2 * elementPos < this.Count - 1)
            {
                int childPos = 2 * elementPos + 1;

                if (childPos < this.Count - 1 && this.elements[childPos].CompareTo(this.elements[childPos + 1]) > 0)
                {
                    childPos++;
                }

                if (this.elements[elementPos].CompareTo(this.elements[childPos]) < 0)
                {
                    break;
                }

                SwapElements(elementPos, childPos);
                elementPos = childPos;
            }
        }

        private void SwapElements(int parent, int child)
        {
            T holder = elements[parent];
            elements[parent] = elements[child];
            elements[child] = holder;
        }
    }
}