using System;

namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class.
    /// [Walkthrough: Create and run unit tests for managed code]
    /// (https://docs.microsoft.com/ja-jp/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019)
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;
        public const string DebitAmountExceedsBalanceMessage = "引き出し額が残額を超えています。";
        public const string DebitAmountLessThanZeroMessage = "引き出し額が0より小さいです。";

        private BankAccount() { }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void Debit(double amount)
        {   //エラーの内容によってエラーメッセージを分岐させる
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount",amount,DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount;         }

        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);

            ba.Credit(5.77);
            ba.Debit(-10);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }
    }
}