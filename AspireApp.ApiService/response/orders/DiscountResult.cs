namespace AspireApp.ApiService.response;

public class DiscountResult
{
    public string type { get; set; }
    public double value { get; set; }

    public DiscountResult(string type, double value)
    {
        this.type = type;
        this.value = value;
    }
}