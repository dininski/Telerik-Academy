namespace Carrying
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int backpackVolume = int.Parse(Console.ReadLine());
            int visitedRoomsCount = 0;

            Console.ReadLine();

            string rooms = Console.ReadLine();

            string[] roomValues = rooms.Split(' ');

            for (int i = 0; i < roomValues.Length; i++)
            {
                int currentRoomValue = int.Parse(roomValues[i]);
                backpackVolume -= currentRoomValue;
                if (backpackVolume < 0)
                {
                    Console.WriteLine(visitedRoomsCount);
                    return;
                }
                else
                {
                    visitedRoomsCount++;
                }
            }
            Console.WriteLine(visitedRoomsCount);
        }
    }
}
