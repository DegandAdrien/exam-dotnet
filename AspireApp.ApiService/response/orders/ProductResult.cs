namespace AspireApp.ApiService.response;

public class ProductResult
{
    public int id { get; set; }
    public string name { get; set; }
    public double pricePerUnit { get; set; }
    public int quantity { get; set; }
    public double total { get; set; }

    public ProductResult(int id, string name, double pricePerUnit, int quantity)
    {
        this.id = id;
        this.name = name;
        this.pricePerUnit = pricePerUnit;
        this.quantity = quantity;
        this.total = pricePerUnit * quantity;;
    }
    
    public ProductResult()
    {
    }
}