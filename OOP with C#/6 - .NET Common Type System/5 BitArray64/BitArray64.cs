using System;
using System.Collections.Generic;

public class BitArray64 : IEnumerable<int>
{
    private ulong Bits { get; set; }

    public override bool Equals(object obj)
    {
        return this.GetHashCode().Equals(obj.GetHashCode());
    }

    public override int GetHashCode()
    {
        return this.Bits.GetHashCode();
    }

    public object this[int index]
    {
        get { return (this.Bits >> index) & 1; }
        set { this.Bits = (ulong)value; }
    }

    public static bool operator ==(BitArray64 firstArray, BitArray64 secondArray)
    {
        return firstArray.GetHashCode().Equals(secondArray.GetHashCode());
    }

    public static bool operator !=(BitArray64 firstArray, BitArray64 secondArray)
    {
        return !firstArray.GetHashCode().Equals(secondArray.GetHashCode());
    }


    public IEnumerator<int> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}