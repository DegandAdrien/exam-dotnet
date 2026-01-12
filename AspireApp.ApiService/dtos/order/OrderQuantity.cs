namespace AspireApp.ApiService.dtos;

public class OrderQuantity
{
    public int id { get; set; }
    public int quantity { get; set; }

    public OrderQuantity()
    {
    }
    
    public OrderQuantity(int id, int quantity)
    {
        this.id = id;
        this.quantity = quantity;
    }
}