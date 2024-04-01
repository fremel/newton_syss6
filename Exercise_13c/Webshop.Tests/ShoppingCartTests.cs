using Moq;

namespace Webshop.Tests;

[TestClass]
public class ShoppingCartTests
{
    [TestMethod]
    public void AddProdct_ShouldAddProductToList()
    {
        // Arrange
        string product1Name = "Product 1";
        float product1Price = 1.7f;
        var pricingServiceMock = new Mock<IPricingService>();
        pricingServiceMock.Setup(ps => ps.GetPrice(product1Name)).Returns(product1Price);
        ShoppingCart shoppingCart = new ShoppingCart(pricingServiceMock.Object);

        // Act
        bool productAdded = shoppingCart.AddProduct("Product 1", 4);

        //Assert
        Assert.IsTrue(productAdded);
        Assert.AreEqual(1, shoppingCart.GetAllProductsInCart().Count);
    }
}