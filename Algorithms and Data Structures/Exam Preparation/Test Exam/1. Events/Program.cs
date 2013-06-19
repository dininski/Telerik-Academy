namespace _1.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main(string[] args)
        {
            Command currentCommand = Command.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            EventCalendar calendar = new EventCalendar();

            while (currentCommand.Type != "End")
            {
                Event ev;
                switch (currentCommand.Type)
                {
                    case "AddEvent":
                        ev = new Event(currentCommand.Arguments);
                        result.AppendLine(calendar.AddEvent(ev));
                        break;
                    case "DeleteEvents":
                        result.AppendLine(calendar.DeleteEvents(currentCommand.Arguments[0].ToLower()));
                        break;
                    case "ListEvents":
                        DateTime startDate = DateTime.Parse(currentCommand.Arguments[0]);
                        int count = int.Parse(currentCommand.Arguments[1]);
                        var evList = calendar.ListEvents(startDate, count);
                        if (evList.Count() != 0)
                        {
                            foreach (var item in evList)
                            {
                                result.AppendLine(item.ToString());
                            }
                        }
                        else
                        {
                            result.AppendLine("No events found");
                        }

                        break;
                    default:
                        break;
                }

                currentCommand = Command.Parse(Console.ReadLine());
            }
            Console.WriteLine(result.ToString());
        }
    }

    public class Event : IComparable<Event>
    {
        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public Event(string[] args)
        {
            this.Date = DateTime.Parse(args[0]);
            this.Title = args[1];
            if (args.Length == 3)
            {
                this.Location = args[2];
            }
            else
            {
                this.Location = "";
            }
        }

        public Event(string time, string title, string location)
        {
            this.Date = DateTime.Parse(time);
            this.Title = title;
            this.Location = location;
        }

        public int CompareTo(Event other)
        {
            int dateComparison = this.Date.CompareTo(other.Date);

            if (dateComparison == 0)
            {
                int titleComparison = this.Title.CompareTo(other.Title);

                if (titleComparison == 0)
                {
                    return this.Location.CompareTo(other.Location);
                }
                else
                {
                    return titleComparison;
                }
            }
            else
            {
                return dateComparison;
            }
        }

        public override string ToString()
        {
            if (this.Location != "")
            {
                return string.Format("{0} | {1} | {2}", this.Date.ToString("s"), this.Title, this.Location);
            }
            else
            {
                return string.Format("{0} | {1}", this.Date.ToString("s"), this.Title);
            }
        }
    }

    public class Command
    {
        public Command(string type, string[] args)
        {
            this.Type = type;
            this.Arguments = args;
        }

        public Command(string type)
        {
            this.Type = type;
        }

        public string Type { get; set; }

        public string[] Arguments { get; set; }

        public static Command Parse(string inputString)
        {
            int firstSpacePos = inputString.IndexOf(' ');
            string type;
            string[] arguments;
            if (firstSpacePos != -1)
            {
                type = inputString.Substring(0, firstSpacePos);
                arguments = inputString.Substring(firstSpacePos).Split('|');
            }
            else
            {
                type = inputString;
                return new Command(type);
            }

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = arguments[i].Trim();
            }

            return new Command(type, arguments);
        }
    }

    public class EventCalendar
    {
        OrderedMultiDictionary<DateTime, Event> allEvents;
        MultiDictionary<string, Event> eventsByTitle;

        public EventCalendar()
        {
            this.allEvents = new OrderedMultiDictionary<DateTime, Event>(true);
            this.eventsByTitle = new MultiDictionary<string, Event>(true);
        }

        public string AddEvent(Event ev)
        {
            this.allEvents.Add(ev.Date, ev);
            this.eventsByTitle.Add(ev.Title.ToLower(), ev);
            return "Event added";
        }

        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            var inRange = this.allEvents.RangeFrom(date, true).Values.Take(count);
            return inRange;
        }

        public string DeleteEvents(string title)
        {
            if (this.eventsByTitle.ContainsKey(title))
            {
                ICollection<Event> eventsToDelete = this.eventsByTitle[title];

                var deletedCount = eventsToDelete.Count;

                foreach (var ev in eventsToDelete)
                {
                    this.allEvents.Remove(ev.Date, ev);
                }

                this.eventsByTitle.Remove(title);

                return string.Format("{0} events deleted", deletedCount);
            }
            else
            {
                return "No events found";
            }
        }
    }
}
