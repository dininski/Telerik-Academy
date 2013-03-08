using System;

namespace Bank
{
    public abstract class Account
    {
        protected Customer accountCustomer;
        public decimal Balance { get; protected set; }
        public decimal MonthlyInterestRate { get; protected set; }

        public Account(decimal initialBalance, decimal interestRate, Customer customer)
        {
            Balance = initialBalance;
            accountCustomer = customer;
            MonthlyInterestRate = interestRate;
        }

        public virtual decimal CalculateMonthlyInterest(int numberOfMonths)
        {
            return numberOfMonths > 0 ? numberOfMonths * MonthlyInterestRate : 0;
        }
    }
}
