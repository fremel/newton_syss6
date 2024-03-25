public class OrderProcessor
{
    private const decimal TaxRate = 0.07m; // 7% tax
    private const decimal ShippingCostPerItem = 5.00m;

    public decimal CalculateTotalCost(int numberOfItems, decimal pricePerItem)
    {
        decimal baseCost = numberOfItems * pricePerItem;
        decimal taxAmount = CalculateTaxAmount(baseCost);
        decimal shippingCost = CalculateShippingCost(numberOfItems);
        decimal totalCost = baseCost + taxAmount + shippingCost;
        return totalCost;
    }

    private static decimal CalculateTaxAmount(decimal baseCost)
    {
        return baseCost * TaxRate;
    }

    private static decimal CalculateShippingCost(int numberOfItems)
    {
        return numberOfItems * ShippingCostPerItem;
    }
}
