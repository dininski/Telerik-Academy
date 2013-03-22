using System;
using System.Collections;
using System.Collections.Generic;

//Define a class BitArray64 to hold 64 bit values inside an ulong value. 
//Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.

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

    public int this[int index]
    {
        get { return (int)(this.Bits >> index) & 1; }
        set
        {
            if (value == 1)
            {
                this.Bits |= ((ulong)1 << index);
            }
            else if (value == 0)
            {
                this.Bits |= this.Bits & (~((ulong)1 << index));
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid bit value");
            }
        }
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
        for (int i = 0; i < 63; i++)
        {
            yield return this[i];
        }
    }

    private class BitArray64Enumerator : IEnumerator
    {
        private int index = -1;
        private ulong bits;

        public BitArray64Enumerator(ulong bits)
        {
            this.bits = bits;
        }

        public object Current
        {
            get
            {
                if (((ulong)1 << index) == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        public bool MoveNext()
        {
            index++;
            return index <= 63;
        }

        public void Reset()
        {
            this.index = -1;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new BitArray64Enumerator(this.Bits);
    }

    public override string ToString()
    {
        return this.Bits.ToString();
    }
}