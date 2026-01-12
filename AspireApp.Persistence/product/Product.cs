namespace AspireApp.Persistence.product;

public class Product
{
    public int id { get; set; }
    public string name { get; set; }
    public double price { get; set; }
    public int stock { get; set; }

    public Product(int id, string name, double price, int stock)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.stock = stock;
    }

    public Product()
    {
    }
}