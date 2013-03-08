using System;

namespace Bank
{
    public class DepositAccount : Account, IWithdrawable, IDepositable
    {

        public DepositAccount(decimal initialBalance, decimal interestRate, Customer client)
            : base(initialBalance, interestRate, client)
        {
        }

        public void Withdraw(decimal withdrawalAmount)
        {
            if (withdrawalAmount > Balance)
            {
                Console.WriteLine("Cannot withdraw more that the current balance");
            }
            else
            {
                this.Balance -= withdrawalAmount;
                Console.WriteLine("{0} withdrawn, current balance: {1}", withdrawalAmount, Balance);
            }
        }

        public void Deposit(decimal depositAmount)
        {
            Balance += depositAmount;
        }

        public override decimal CalculateMonthlyInterest(int numberOfMonths)
        {
            if (Balance > 1000)
            {
                return 0;
            }
            else
            {
                return base.CalculateMonthlyInterest(numberOfMonths);
            }
        }
    }
}
