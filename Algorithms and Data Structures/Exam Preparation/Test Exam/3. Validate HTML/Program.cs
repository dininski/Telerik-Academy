namespace _3.Validate_HTML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                Console.WriteLine(CheckIfValidHTML(Console.ReadLine()));
            }

            // Console.WriteLine(CheckIfValidHTML("<html><head></head><body><b><i></i></b></body></html>"));
            // Console.WriteLine(CheckIfValidHTML("<html>"));
        }

        public static string CheckIfValidHTML(string html)
        {
            Stack<string> tags = new Stack<string>();

            bool tagOpen = false;
            bool endingTag = false;

            StringBuilder sb = new StringBuilder();
            foreach (var character in html)
            {
                if (character == '<')
                {
                    tagOpen = true;
                    continue;
                }

                if (character == '>')
                {
                    if (sb.Length != 0)
                    {
                        tags.Push(sb.ToString());
                        sb.Clear();
                    }

                    tagOpen = false;
                }

                if (character == '/' && tagOpen)
                {
                    endingTag = true;
                    continue;
                }

                if (tagOpen)
                {
                    sb.Append(character);
                }

                if (!tagOpen)
                {
                    if (endingTag)
                    {
                        try
                        {
                            var lastTag = tags.Pop();
                            var secondToLastTag = tags.Pop();
                            if (lastTag.CompareTo(secondToLastTag) != 0)
                            {
                                return "INVALID";
                            }

                            endingTag = false;
                        }
                        catch
                        {
                            return "INVALID";
                        }
                    }
                }
            }

            return tags.Count == 0 ? "VALID" : "INVALID";
        }
    }
}
