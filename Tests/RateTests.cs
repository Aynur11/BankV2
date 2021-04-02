using Bank.Bll;
using Bank.Dal.Clients;
using NUnit.Framework;

namespace Tests
{
    public class RateTests
    {
        [Test]
        public void CalcPhysicalPersonDepositRateUsualClientTest()
        {
            var rate = new Rate();
            decimal actualRate = rate.CalcPhysicalPersonDepositRate(ClientType.Usual);
            Assert.AreEqual(3.15m, actualRate, "Ставка не является ожидаемой.");
        }

        [Test]
        public void CalcPhysicalPersonDepositRateVipClientTest()
        {
            var rate = new Rate();
            decimal actualRate = rate.CalcPhysicalPersonDepositRate(ClientType.Vip);
            Assert.AreEqual(4.5m, actualRate, "Ставка не является ожидаемой.");
        }

        [Test]
        public void CalcPhysicalPersonCreditRateUsualClientTest()
        {
            var rate = new Rate();
            decimal actualRate = rate.CalcPhysicalPersonCreditRate(ClientType.Usual);
            Assert.AreEqual(20.05m, actualRate, "Ставка не является ожидаемой.");
        }

        [Test]
        public void CalcPhysicalPersonCreditRateVipClientTest()
        {
            var rate = new Rate();
            decimal actualRate = rate.CalcPhysicalPersonCreditRate(ClientType.Vip);
            Assert.AreEqual(15.25m, actualRate, "Ставка не является ожидаемой.");
        }

        [Test]
        public void CalcLegalPersonDepositRateUsualClientTest()
        {
            var rate = new Rate();
            decimal actualRate = rate.CalcLegalPersonDepositRate(ClientType.Usual);
            Assert.AreEqual(2.05m, actualRate, "Ставка не является ожидаемой.");
        }

        [Test]
        public void CalcLegalPersonDepositRateVipClientTest()
        {
            var rate = new Rate();
            decimal actualRate = rate.CalcLegalPersonDepositRate(ClientType.Vip);
            Assert.AreEqual(3.55m, actualRate, "Ставка не является ожидаемой.");
        }

        [Test]
        public void CalcLegalPersonCreditRateUsualClientTest()
        {
            var rate = new Rate();
            decimal actualRate = rate.CalcLegalPersonCreditRate(ClientType.Usual);
            Assert.AreEqual(18.05m, actualRate, "Ставка не является ожидаемой.");
        }

        [Test]
        public void CalcLegalPersonCreditRateVipClientTest()
        {
            var rate = new Rate();
            decimal actualRate = rate.CalcLegalPersonCreditRate(ClientType.Vip);
            Assert.AreEqual(14.65m, actualRate, "Ставка не является ожидаемой.");
        }
    }
}
