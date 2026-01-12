namespace AspireApp.Persistence.discount;

public class Discount
{
    public string code { get; set; }
    public double value { get; set; }
    
    public Discount(string code, double value)
    {
        this.code = code;
        this.value = value;
    }
    
}