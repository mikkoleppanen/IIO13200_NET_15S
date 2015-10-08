using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForWinLottoBL
{
    [TestClass]
    public class UnitTestLotto
    {
        [TestMethod]
        public void TestGetWeek()
        {
            //viittaus oikeaan luokkaan ja sen metodiin
            JAMK.IT.WinLotto.Lotto lotto = new JAMK.IT.WinLotto.Lotto();
            //Kutsutaan testattavaa metodia
            String vk = lotto.GetWeekUnfinished();
            Assert.AreEqual("41/2015", vk);
        }

        [TestMethod]
        public void TestGetWeek2()
        {
            //viittaus oikeaan luokkaan ja sen metodiin
            JAMK.IT.WinLotto.Lotto lotto = new JAMK.IT.WinLotto.Lotto();
            //Kutsutaan testattavaa metodia
            String vk = lotto.GetWeekFixed();
            Assert.AreEqual("41/2015", vk);
        }
    }
}
