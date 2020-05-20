using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankTests
    {
        [TestMethod]
        public void DebitWithValidAmontUpdatesBalance()
        {
            // Arrange
            double beginningBalnace = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;

            var account = new BankAccount("ブライアン　ウォールトン", beginningBalnace);

            //実行
            account.Debit(debitAmount);

            //Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "口座の引き出し額に誤りがあります");
        }
    }
}
