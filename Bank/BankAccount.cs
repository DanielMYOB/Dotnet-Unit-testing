﻿using System;

namespace Bank
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount
    {
        private readonly string _customerName;
        private double _balance;

        public const string DebitAmountExceedsBalanceMessage =
            "Debit amount exceeds balance";

        public const string DebitAmountLessThanZeroMessage =
            "Debit amount is less than zero";

        private BankAccount()
        {
        }

        public BankAccount(string customerName, double balance)
        {
            _customerName = customerName;
            _balance = balance;
        }

        public string CustomerName
        {
            get { return _customerName; }
        }

        public double Balance
        {
            get { return _balance; }
        }

        public void Debit(double amount)
        {
            if (amount > _balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount,
                    DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount,
                    DebitAmountLessThanZeroMessage);
            }

            _balance -= amount; // intentionally incorrect code
        }

        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            _balance += amount;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }
    }
}