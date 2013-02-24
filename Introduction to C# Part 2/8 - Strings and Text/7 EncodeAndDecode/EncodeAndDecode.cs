using System;
using System.Text;

class EncodeAndDecode
{
    public static string Encode(string message, string cipher)
    {
        StringBuilder encodedMessage = new StringBuilder();
        for (int i = 0; i < message.Length; i++)
        {
            encodedMessage.Append((char)((int)message[i] ^ (int)cipher[i % cipher.Length]));
        }
        return encodedMessage.ToString();
    }

    public static string Decode(string message, string cipher)
    {
        return Encode(message, cipher);
    }

    static void Main(string[] args)
    {
        string cipher = "god";
        Console.WriteLine("Please enter a string:");
        string userInput = Console.ReadLine();
        Console.WriteLine("The encoded message is: ");
        Console.WriteLine(Encode(userInput,cipher));
        Console.WriteLine("The decoded message is:");
        Console.WriteLine(Decode(Encode(userInput, cipher),cipher));
    }
}