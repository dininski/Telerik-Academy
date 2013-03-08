using System;

namespace Bank
{
    public interface IWithdrawable
    {
        void Withdraw(decimal withdrawalAmount);
    }
}
