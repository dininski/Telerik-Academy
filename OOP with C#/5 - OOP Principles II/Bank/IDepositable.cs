using System;

namespace Bank
{
    public interface IDepositable
    {
        void Deposit(decimal depositAmount);
    }
}
