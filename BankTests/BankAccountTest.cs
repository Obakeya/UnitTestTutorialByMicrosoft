using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankTests
    {
        /// <summary>
        /// 最初のテストメソッドを作成する
        /// </summary>
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
        /// <summary>
        /// 単体テストを使用してコードを改良する...スローの確認
        /// 例外をキャッチしてメッセージを確認する
        /// </summary>
        [TestMethod]
        public void DebitWhenAmountIsLessThanZeroShouldThrowArgumetOutOfRange()
        {
            //準備
            double beginningBalance = 11.99;
            double debitAmount = 20.00;
            BankAccount account = new BankAccount("ブライアン　ウォールトン", beginningBalance);

            //実行
            try
            {
                account.Debit(debitAmount);
            }
            catch(System.ArgumentOutOfRangeException e)
            {
                //アサート
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("予定していた例外がスローされませんでした。");
        }

    }
}
