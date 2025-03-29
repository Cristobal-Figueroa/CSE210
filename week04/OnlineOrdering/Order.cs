using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private const decimal USA_SHIPPING_COST = 5.0m;
    private const decimal INTERNATIONAL_SHIPPING_COST = 35.0m;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        
        foreach (Product product in _products)
        {
            totalCost += product.CalculateTotalCost();
        }
        
        if (_customer.IsInUSA())
        {
            totalCost += USA_SHIPPING_COST;
        }
        else
        {
            totalCost += INTERNATIONAL_SHIPPING_COST;
        }
        
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "PACKING LABEL\n";
        
        foreach (Product product in _products)
        {
            packingLabel += $"Product: {product.GetName()}, ID: {product.GetProductId()}\n";
        }
        
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        string shippingLabel = "SHIPPING LABEL\n";
        shippingLabel += $"Customer: {_customer.GetName()}\n";
        shippingLabel += $"Address:\n{_customer.GetAddress().GetFullAddress()}";
        
        return shippingLabel;
    }
}
