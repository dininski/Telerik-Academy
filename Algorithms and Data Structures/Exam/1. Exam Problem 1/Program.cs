using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Frames
{
    public class Program
    {
        static Frame[] frames;
        static OrderedSet<string> combinations;
        static bool[] used;

        static void Main(string[] args)
        {
            int numberOfFrames = int.Parse(Console.ReadLine());

            used = new bool[numberOfFrames];

            combinations = new OrderedSet<string>();

            frames = new Frame[numberOfFrames];

            for (int i = 0; i < numberOfFrames; i++)
            {
                string inputString = Console.ReadLine();
                
                frames[i] = new Frame(inputString[0], inputString[2]);
            }

            Recursive(0, new Frame[numberOfFrames], 0);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(combinations.Count.ToString());

            foreach (var item in combinations)
            {
                sb.AppendLine(item.ToString());
            }

            Console.Write(sb.ToString());
        }

        public static void Recursive(int index, Frame[] result, int start)
        {
            if (index == result.Length)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < result.Length - 1; i++)
                {
                    sb.Append(result[i].ToString());
                    sb.Append(" | ");
                }

                sb.Append(result[result.Length - 1].ToString());

                if (!combinations.Contains(sb.ToString()))
                {
                    combinations.Add(sb.ToString());
                }
            }
            else
            {
                for (int i = start; i < frames.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        result[index] = frames[i];
                        Recursive(index + 1, result, start);
                        result[index] = new Frame(frames[i].Height, frames[i].Width);
                        Recursive(index + 1, result, start);
                        used[i] = false;
                    }
                }
            }
        }
    }

    public class Frame
    {
        public Frame(char width, char height)
        {
            this.Width = width;
            this.Height = height;
        }

        public char Width { get; set; }
        public char Height { get; set; }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.Width, this.Height);
        }
    }
}