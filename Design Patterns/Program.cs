using System;

// Class representing the final product
class Product
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public void Display()
    {
        Console.WriteLine($"Product: {Name}, Type: {Type}, Quantity: {Quantity}, Price: {Price}");
    }
}

// Builder interface
interface IBuilder
{
    void SetName(string name);
    void SetType(string type);
    void SetQuantity(int quantity);
    void SetPrice(double price);
    Product Build();
}

// Concrete Builder
class ProductBuilder : IBuilder
{
    private Product product = new Product();

    public void SetName(string name)
    {
        product.Name = name;
    }

    public void SetType(string type)
    {
        product.Type = type;
    }

    public void SetQuantity(int quantity)
    {
        product.Quantity = quantity;
    }

    public void SetPrice(double price)
    {
        product.Price = price;
    }

    public Product Build()
    {
        return product;
    }
}

// Director
class Manufacturer
{
    private IBuilder builder;

    public Manufacturer(IBuilder builder)
    {
        this.builder = builder;
    }

    public void ConstructProduct(string name, string type, int quantity, double price)
    {
        builder.SetName(name);
        builder.SetType(type);
        builder.SetQuantity(quantity);
        builder.SetPrice(price);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating the Builder
        IBuilder builder = new ProductBuilder();

        // Creating the Director and passing the Builder
        Manufacturer manufacturer = new Manufacturer(builder);

        // Constructing the product step by step
        manufacturer.ConstructProduct("Product A", "Type X", 10, 100.00);

        // Getting the final product
        Product finalProduct = builder.Build();

        // Displaying the final product
        finalProduct.Display();

        Console.ReadKey();
    }
}
