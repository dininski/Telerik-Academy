using System;
using Bank;

namespace BankTest
{
    class BankOfMe
    {
        static void Main(string[] args)
        {
            LoanAccount myLoanAccount = new LoanAccount(10.6M, 4.5M, new Individual());
            Console.WriteLine(myLoanAccount.CalculateMonthlyInterest(12));
            MortgageAccount myMortgageAccount = new MortgageAccount(1000M, 2.7M, new Company());
            Console.WriteLine(myMortgageAccount.CalculateMonthlyInterest(14));
        }
    }
}
