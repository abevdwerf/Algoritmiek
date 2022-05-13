using System.Collections.Generic;
using Xunit;

namespace SimpelAlgoritme.Tests
{
    public class OrderTests
    {
        private Order order;

        public OrderTests()
        {
            List<Product> productList = new List<Product>();

            productList.Add(new Product("product1", 6.00));
            productList.Add(new Product("product2", 2.10));
            productList.Add(new Product("product3", 4.25));
            productList.Add(new Product("product4", 3.15));

            this.order = new Order(productList);
        }

        [Fact]
        public void Order_GiveMaximumPrice()
        {
            //Arrange
            //methoden aanmaken
            //Act
            double result = order.GiveMaximumPrice();

            //Assert
            Assert.Equal(6.00, result);
        }

        [Fact]
        public void Order_GiveAveragePrice()
        {
            //Arrange

            //Act
            double result = order.GiveAveragePrice();

            //Assert
            Assert.Equal(3.88, result);
        }

        [Theory]
        [InlineData(4, 2.00)]
        [InlineData(3, 3.00)]
        [InlineData(2, 4.00)]
        [InlineData(1, 5.00)]
        [InlineData(0, 7.00)]
        public void Order_GetAllProducts(int expected, double minimumPrice)
        {
            //Arrange

            //Act
            int result = order.GetAllProducts(minimumPrice).Count;

            //Assert
            Assert.Equal(expected, result);
        }
    }
}