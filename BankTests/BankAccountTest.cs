using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankTests
    {
        /// <summary>
        /// �ŏ��̃e�X�g���\�b�h���쐬����
        /// </summary>
        [TestMethod]
        public void DebitWithValidAmontUpdatesBalance()
        {
            // Arrange
            double beginningBalnace = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;

            var account = new BankAccount("�u���C�A���@�E�H�[���g��", beginningBalnace);

            //���s
            account.Debit(debitAmount);

            //Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "�����̈����o���z�Ɍ�肪����܂�");
        }
        /// <summary>
        /// �P�̃e�X�g���g�p���ăR�[�h�����ǂ���...�X���[�̊m�F
        /// ��O���L���b�`���ă��b�Z�[�W���m�F����
        /// </summary>
        [TestMethod]
        public void DebitWhenAmountIsLessThanZeroShouldThrowArgumetOutOfRange()
        {
            //����
            double beginningBalance = 11.99;
            double debitAmount = 20.00;
            BankAccount account = new BankAccount("�u���C�A���@�E�H�[���g��", beginningBalance);

            //���s
            try
            {
                account.Debit(debitAmount);
            }
            catch(System.ArgumentOutOfRangeException e)
            {
                //�A�T�[�g
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("�\�肵�Ă�����O���X���[����܂���ł����B");
        }

    }
}
