using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;

        [TestInitialize] // run code before each test
        public void Initialize()
        {
            acc = new Account();
        }

        //---------------------------------------Deposit--------------------------------------

        [TestMethod]
        [TestCategory("Deposit")]
        [DataRow(10_000)]
        [DataRow(10_000.01)]
        [DataRow(double.MaxValue)]
        public void Deposit_ToLarge_ThrowsArgException(double tooLargeDeposit)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Deposit(tooLargeDeposit));
        }

        [TestMethod()]
        [TestCategory("Deposit")]
        [DataRow(100)]
        [DataRow(9999.99)]
        [DataRow(.01)]
        public void Deposit_PositiveAmount_AddsToBalance(double initialDeposit)
        {
            // AAA - Arrange Act Assert
            // Arrange - Create variabls and objects
            const double startBalance = 0;

            // Act - Execute method under test
            acc.Deposit(initialDeposit);

            // Assert - check condition
            Assert.AreEqual(startBalance + initialDeposit, acc.Balance);
        }

        [TestMethod()]
        [TestCategory("Deposit")]
        public void Deposit_PositiveAmount_ReturnsUpdatedBalance()
        {
            // Arrange
            double startBalance = 0;
            double depositAmount = 10.55;

            // Act
            double newBalance = acc.Deposit(depositAmount);

            // Assert
            double expectedBalance = startBalance + depositAmount;
            Assert.AreEqual(expectedBalance, newBalance);
        }

        // Tests
        // Multiple deposits
        [TestMethod]
        [TestCategory("Deposit")]
        public void Deposit_MultipleAmounts_ReturnsAccumulatedBalance()
        {
            // Arrange
            double dep1 = 10;
            double dep2 = 25;
            double expectedBalance = dep1 + dep2;

            // Act
            double intermediateBalance = acc.Deposit(dep1);
            double finalBalance = acc.Deposit(dep2);

            // Assert
            Assert.AreEqual(dep1, intermediateBalance);
            Assert.AreEqual(expectedBalance, finalBalance);

        }

        // Neg Deposits
        [TestMethod]
        [TestCategory("Deposit")]
        public void Deposit_NegAmount_ThrowsArgumentException()
        {
            // Arrange
            double negDeposit = -1;

            // Assert & Act
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (
                    // Act
                    () => acc.Deposit(negDeposit)
                );
        }

        //---------------------------------------Withdraw-------------------------------------

        [TestMethod]
        [TestCategory("Withdraw")]
        [DataRow(100, 50)]
        [DataRow(50, 50)]
        [DataRow(9.99, 9.99)]
        public void Withdraw_PositiveAmt_SubtractsFromBalance(double initialDeposit, double withdrawAmount)
        {
            double expectedBalance = initialDeposit - withdrawAmount;

            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawAmount);

            Assert.AreEqual(expectedBalance, acc.Balance);
        }

        [TestMethod]
        [TestCategory("Withdraw")] // Make this data driven!
        public void Withdraw_MoreThanBalance_TrowsArgumentException()
        {
            Account myAccount = new Account();
            double withdrawAmount = 1000;
            Assert.ThrowsException<ArgumentException>(() => myAccount.Withdraw(withdrawAmount));
        }

        [TestMethod]
        [TestCategory("Withdraw")]
        public void Withdraw_NegAmt_ThrowsArgumentException()
        {
            double negWithdraw = -1;

            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(negWithdraw));
        }

    }

}