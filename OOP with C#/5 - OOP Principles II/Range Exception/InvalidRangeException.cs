using System;

//Define a class InvalidRangeException<T> that holds information about an error 
//condition related to invalid range. It should hold error message and a range 
//definition [start … end].
//Write a sample application that demonstrates the InvalidRangeException<int> and 
//InvalidRangeException<DateTime> by entering numbers in the range [1..100] and 
//dates in the range [1.1.1980 … 31.12.2013].



public class InvalidRangeException<T> : Exception
{
    public T Min { get; private set; }
    public T Max { get; private set; }

    public InvalidRangeException(string message, T min, T max) : base(message)
    {
        this.Min = min;
        this.Max = max;
    }
}
