using System.Net.Http.Headers;

namespace Webshop;

public class ShoppingCart
{
    List<Product> _productsInCart;
    IPricingService _pricingService;

    public ShoppingCart(IPricingService pricingService)
    {
        _productsInCart = new List<Product>();
        _pricingService = pricingService;
    }

    public bool AddProduct(string name, int quantity)
    {
        float price = _pricingService.GetPrice(name);
        Product product = new Product(name, price, quantity);
        _productsInCart.Add(product);
        return true;
    }

    public bool RemoveProduct(string name, int quantity) 
    {
        return false;
    }

    public List<Product> GetAllProductsInCart() 
    {
        return _productsInCart;
    }
}
