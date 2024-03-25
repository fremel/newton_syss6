[TestClass]
public class UnitTest1
{
    [DataRow(0, 1000.0, 0.0)]
    [DataRow(2, 10.0, 31.4)]
    [DataRow(2, 0.0, 10.0)]
    [DataTestMethod]
    public void CalculateTotalCost_Should(int numberOfItems, double pricePerItem, double expectedTotalCost)
    {
        OrderProcessor orderProcessor = new OrderProcessor();

        var actualTotalCost = orderProcessor.CalculateTotalCost(numberOfItems, (decimal)pricePerItem);

        Assert.AreEqual((decimal)expectedTotalCost, actualTotalCost);
    }
}