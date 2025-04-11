using System;

class Order
{
    private List<Product> _products;

    public Order()
    {
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public List<Product> GetProducts()
    {
        return _products;
    }

    public float CalculateTotalOrderPrice()
    {
        float totalOrderPrice = 0;
        foreach (var product in _products)
        {
            totalOrderPrice += product.TotalProductPrice;
        }
        return totalOrderPrice;
    }

    public float CalculateShippingCost(Address address)
    {
        return address.Country == "United States" ? 5.0f : 35.0f;
    }

    public float CalculateGrandTotal(Address address)
    {
        return CalculateTotalOrderPrice() + CalculateShippingCost(address);
    }

    public string GetSummary(Address address)
    {
        string summary = $"Total Order Price: {CalculateTotalOrderPrice()}\n";
        summary += $"Shipping Cost: {CalculateShippingCost(address)}\n";
        summary += $"Grand Total: {CalculateGrandTotal(address)}";
        return summary;
    }
}

class Product
{
    public string ProductName { get; set; }
    public int ProductID { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
    public float TotalProductPrice => Price * Quantity;
    

    public Product(string productName, int productID, float price, int quantity)
    {
        ProductName = productName;
        ProductID = productID;
        Price = price;
        Quantity = quantity;
    }
}

class Customer
{
    public string CustomerName { get; set; }
    public Address Address { get; set; }

    public Customer(string customerName)
    {
        CustomerName = customerName;
    }
}

class Address
{
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    

    public Address(string streetAddress, string city, string state, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        State = state;
        Country = country;
    }

}