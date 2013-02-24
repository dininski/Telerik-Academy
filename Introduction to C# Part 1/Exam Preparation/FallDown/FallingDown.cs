using System;

class FallingDown
{
    static void Main()
    {
        byte[] n = new byte[8];
        byte[] result = new byte[8];
        for (byte i = 0; i < 8; i++)
        {
            byte.TryParse(Console.ReadLine(), out n[i]);
        }
        for (int a = 0; a < 8; a++)
        {
            byte mask = (byte)(1 << a);
            for (int bottomRow = 7; bottomRow > 0; bottomRow--)
            {
                if ((mask & n[bottomRow]) > 0)
                {
                    continue;
                }
                for (int swapRow = bottomRow - 1; swapRow >= 0; swapRow--)
                {
                    if ((mask & n[swapRow]) > 0)
                    {
                        n[bottomRow] |= mask;
                        n[swapRow] &= (byte)~mask;
                        break;
                    }
                }
            }
        }
        foreach (byte test in n)
        {
            Console.WriteLine(test);
        }
    }
}
