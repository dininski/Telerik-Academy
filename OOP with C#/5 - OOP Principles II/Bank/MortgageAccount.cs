using System;

namespace Bank
{
    public class MortgageAccount : Account, IDepositable
    {
        public MortgageAccount(decimal initialBalance, decimal interestRate, Customer customer)
            : base(initialBalance, interestRate, customer)
        {
        }

        public void Deposit(decimal depositAmount)
        {
            Balance += depositAmount;
        }

        public override decimal CalculateMonthlyInterest(int numberOfMonths)
        {
            if (accountCustomer is Company)
            {
                if (numberOfMonths < 12)
                {
                    return base.CalculateMonthlyInterest(numberOfMonths) / 2;
                }
                else
                {
                    return base.CalculateMonthlyInterest(12) / 2 + base.CalculateMonthlyInterest(numberOfMonths - 12);
                }
            }
            else if (accountCustomer is Individual)
            {
                return base.CalculateMonthlyInterest(numberOfMonths - 6);
            }
            else
            {
                throw new Exception("Invalid customer type!");
            }
        }
    }
}
