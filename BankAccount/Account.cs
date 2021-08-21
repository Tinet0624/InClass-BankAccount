using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a single checking account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Get the current balance. Read only property!
        /// </summary>
        public double Balance { get; private set; }

        /// <summary>
        /// Deposits the amount in the bank account and returns new balance.
        /// </summary>
        /// <param name="amt">The amount to deposit</param>
        public double Deposit(double amt)
        {
            if (amt >= 10000)
            {
                throw new ArgumentException($"{nameof(amt)} must be smaller than 10,000.");
            }
            if (amt <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(amt)} is not a valid deposit amount.");
            }
            Balance += amt;
            return Balance;
        }

        public void Withdraw(double amt)
        {
            if (amt > Balance)
            {
                throw new ArgumentException($"You can not withdraw more thatn the current balance.");
            }
            if (amt < 0)
            {
                throw new ArgumentException($"You can not withdraw a negative amount.");
            }
            Balance -= amt;
        }
    }
}
