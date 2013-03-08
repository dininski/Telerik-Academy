using System;

namespace Bank
{
    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(decimal initialBalance, decimal interestRate, Customer customer)
            : base(initialBalance, interestRate, customer)
        {
        }

        public void Deposit(decimal withdrawalAmount)
        {
            Balance += withdrawalAmount;
        }

        public override decimal CalculateMonthlyInterest(int numberOfMonths)
        {
            if (accountCustomer is Individual)
            {
                return base.CalculateMonthlyInterest(numberOfMonths - 3);
            }
            else if (accountCustomer is Company)
            {
                return base.CalculateMonthlyInterest(numberOfMonths - 2);
            }
            else
            {
                throw new Exception("Invalid customer type!");
            }
        }
    }
}
