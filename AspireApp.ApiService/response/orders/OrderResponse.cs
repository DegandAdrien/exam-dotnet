namespace AspireApp.ApiService.response;

public class OrderResponse
{
    public List<ProductResult> products { get; set; }
    public List<DiscountResult> discounts { get; set; }
    public double total { get; set; }
    public bool? success { get; set; }
    
    public List<string> errors { get; set; }

    public OrderResponse()
    {
    }

    public OrderResponse(List<ProductResult> products, List<DiscountResult> discounts, double total, bool success)
    {
        this.products = products;
        this.discounts = discounts;
        this.total = total;
        this.success = success;
        this.errors = new List<string>();
    }
}