using Checkout_Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Checkout_Logic_Test
{
    [TestClass]
    public class CheckoutTest
    {
        [TestMethod]
        public void ScanningOneItemAddsToTotalTest()
        {
            //Arrange
            Checkout checkout = new Checkout();
            Item item1 = new Item("A", 10.00m, "None", 0, 00.00m, 0.00m);

            //Act
            checkout.Scan(item1);

            //Assert
            Assert.AreEqual(10.00m, checkout.Total);
        }

        [TestMethod]
        public void ScanningTwoItemsAddsToTotalTest()
        {
            //Arrange
            Checkout checkout = new Checkout();
            Item item1 = new Item("A", 10.00m, "None", 0, 00.00m, 0.00m);

            //Act
            checkout.Scan(item1);
            checkout.Scan(item1);

            //Assert
            Assert.AreEqual(20.00m, checkout.Total);
        }

        [TestMethod]
        public void ScanningMultipleTotalOfferItemsAppliesDiscountTest()
        {
            //Arrange
            Checkout checkout = new Checkout();
            Item item2 = new Item("B", 15.00m, "Total", 3, 40.00m, 0.00m);

            //Act
            checkout.Scan(item2);
            checkout.Scan(item2);
            checkout.Scan(item2);

            //Assert
            Assert.AreEqual(40.00m, checkout.Total);
        }

        [TestMethod]
        public void ScanningMultipleTotalOfferItemsAppliesDiscountAndAddsRegularItemsTooTest()
        {
            //Arrange
            Checkout checkout = new Checkout();
            Item item1 = new Item("A", 10.00m, "None", 0, 00.00m, 0.00m);
            Item item2 = new Item("B", 15.00m, "Total", 3, 40.00m, 0.00m);
            Item item3 = new Item("C", 40.00m, "None", 0, 00.00m, 0.00m);

            //Act
            checkout.Scan(item1);
            checkout.Scan(item2);
            checkout.Scan(item2);
            checkout.Scan(item2);
            checkout.Scan(item3);

            //Assert
            Assert.AreEqual(90.00m, checkout.Total);
        }

        [TestMethod]
        public void ScanningSingleTriggerPercentOfferItemsAppliesDiscountTest()
        {
            //Arrange
            Checkout checkout = new Checkout();
            Item item4 = new Item("D", 55.00m, "Percentage", 2, 00.00m, 0.25m);

            //Act
            checkout.Scan(item4);
            checkout.Scan(item4);

            //Assert
            Assert.AreEqual(82.50m, checkout.Total);
        }

        [TestMethod]
        public void ScanningMultipleTriggerPercentOfferItemsAppliesDiscountButAddsSingleTest()
        {
            //Arrange
            Checkout checkout = new Checkout();
            Item item4 = new Item("D", 55.00m, "Percentage", 2, 00.00m, 0.25m);

            //Act
            checkout.Scan(item4);
            checkout.Scan(item4);
            checkout.Scan(item4);
            checkout.Scan(item4);
            checkout.Scan(item4);

            //Assert
            Assert.AreEqual(220.00m, checkout.Total);
        }

        [TestMethod]
        public void ScanningMultipleDiscountsTest()
        {
            //Arrange
            Checkout checkout = new Checkout();
            Item item2 = new Item("B", 15.00m, "Total", 3, 40.00m, 0.00m);
            Item item4 = new Item("D", 55.00m, "Percentage", 2, 00.00m, 0.25m);

            //Act
            checkout.Scan(item2);
            checkout.Scan(item2);
            checkout.Scan(item2);
            checkout.Scan(item4);
            checkout.Scan(item4);
            checkout.Scan(item4);
            checkout.Scan(item4);

            //Assert
            Assert.AreEqual(205.00m, checkout.Total);
        }

        [TestMethod]
        public void ScanningMultipleDiscountsAndNoneDiscountsTest()
        {
            //Arrange
            Checkout checkout = new Checkout();
            Item item1 = new Item("A", 10.00m, "None", 0, 00.00m, 0.00m);
            Item item2 = new Item("B", 15.00m, "Total", 3, 40.00m, 0.00m);
            Item item3 = new Item("C", 40.00m, "None", 0, 00.00m, 0.00m);
            Item item4 = new Item("D", 55.00m, "Percentage", 2, 00.00m, 0.25m);

            //Act
            checkout.Scan(item1);
            checkout.Scan(item1);
            checkout.Scan(item2);
            checkout.Scan(item2);
            checkout.Scan(item2);
            checkout.Scan(item3);
            checkout.Scan(item3);
            checkout.Scan(item4);
            checkout.Scan(item4);
            checkout.Scan(item4);
            checkout.Scan(item4);

            //Assert
            Assert.AreEqual(305.00m, checkout.Total);
        }
    }
}