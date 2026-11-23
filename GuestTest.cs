using HostelManager;

namespace HotelManagmentTest
{
    [TestClass]
    public sealed class GuestTest
    {
        [TestMethod]
        public void Deposit_ValidAmount_ReturnsTrue()
        {
            Guest guest = new Guest("BarnaVendi",50,false);
            bool result = guest.Deposit(10000);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Deposit_ValidAmount_IncreaseBalance()
        {
            Guest guest = new Guest("MegBarnabbVendi", 60, false);
            guest.Deposit(10000);
            Assert.AreEqual(10000, guest.Balance);
        }
        [TestMethod]
        public void Deposit_InValidAmount_ReturnsFalse()
        {
            Guest guest = new Guest("MegBarnabbVendi", 60, false);
            bool result = guest.Deposit(-20);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Deposit_InValidAmount_BalanceUnchanged()
        {
            Guest guest = new Guest("MegBarnabbVendi", 60, false);
            guest.Deposit(-20);
            Assert.AreEqual(0,guest.Balance);
        }
        [TestMethod]
        public void Stay_EnoughBalance_DeductsFee()
        {
            Guest guest = new Guest("NagyonBarnaVendel", 99, false);
            guest.Deposit(10000);

            guest.Stay(1);
            Assert.AreEqual(4000, guest.Balance);
        }
        [TestMethod]
        public void Stay_EnoughBalance_IncreasesNight()
        {
            Guest guest = new Guest("NagyonBarnaVendel", 99, false);
            guest.Deposit(10000);

            guest.Stay(1);
            Assert.AreEqual(1, guest.NightsStayed);
        }
        [TestMethod]
        public void Stay_EnoughBalance_ReturnsFalse()
        {
            Guest guest = new Guest("NagyonBarnaVendel", 99, false);
            guest.Deposit(1);

            bool result =guest.Stay(1);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Stay_ZeroNights_BalanceUnchanged()
        {
            Guest guest = new Guest("NagyonBarnaVendel", 99, false);
            guest.Deposit(10000);

            guest.Stay(0);
            Assert.AreEqual(10000,guest.Balance);
        }



        [TestMethod]
        [DataRow(12,0)]
        [DataRow(16, 16)]
        [DataRow(98, 98)]
        [DataRow(100, 0)]
        public void Age_BoundarValues_Returns_Expected(int age, int expected)
        {
            Guest guest = new Guest("NagyonBarnaVendel", age, false);
            Assert.AreEqual(expected, guest.Age);
        }

        [TestMethod]
        [DataRow(0,false,0)]
        [DataRow(1,true,4000)]
        [DataRow(1,false,6000)]
        [DataRow(6,false,36000)]
        [DataRow(7,false,35700)]
        public void a()
        {

        }
    }
}
