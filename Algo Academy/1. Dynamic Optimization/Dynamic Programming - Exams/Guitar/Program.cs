namespace Guitar
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static int numberOfSongs;
        static int maxVolume;

        public static void Main(string[] args)
        {
            string stepsInput = Console.ReadLine();
            string[] stepsAsStrings = stepsInput.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            numberOfSongs = stepsAsStrings.Length;
            int startVolume = int.Parse(Console.ReadLine());
            maxVolume = int.Parse(Console.ReadLine());

            //if (stepsAsStrings.Length == 1)
            //{
            //    int song = int.Parse(stepsAsStrings[0]);
            //    if (song <= maxVolume && song >=0)
            //    {
            //        Console.WriteLine(song);
            //        return;
            //    }
            //    else
            //    {
            //        Console.WriteLine("-1");
            //        return ;
            //    }
            //}

            int[,] volumesInt = new int[numberOfSongs + 1, maxVolume + 1];

            volumesInt[0, startVolume] = 1;

            for (int col = 0; col < numberOfSongs; col++)
            {
                for (int row = 0; row < maxVolume + 1; row++)
                {
                    if (volumesInt[col, row] == 1)
                    {
                        volumesInt[col, row] = 0;
                        int currentSongVol = int.Parse(stepsAsStrings[col]);
                        int nextVol = currentSongVol + row;
                        int prevVol = row - currentSongVol;

                        if (IsValid(nextVol))
                        {
                            volumesInt[col + 1, nextVol] = 1;
                        }

                        if (IsValid(prevVol))
                        {
                            volumesInt[col + 1, prevVol] = 1;
                        }
                    }
                }
            }

            for (int i = volumesInt.GetLength(1) - 1; i >= 0; i--)
            {
                if (volumesInt[volumesInt.GetLength(0) - 1, i] == 1)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine("-1");
        }

        public static bool IsValid(int pos)
        {
            if (pos >= 0 && pos <= maxVolume)
            {
                return true;
            }

            return false;
        }
    }
}
