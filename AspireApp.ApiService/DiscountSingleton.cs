using AspireApp.Persistence.discount;

namespace AspireApp.ApiService;

public class DiscountSingleton
{
    private DiscountSingleton() { }

    private static DiscountSingleton _instance;
    
    public static DiscountSingleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new DiscountSingleton();
        }
        return _instance;
    }
    
    public static List<Discount> discountCodes = new List<Discount>(
        [
            new Discount("DISCOUNT20", 20),
            new Discount("DISCOUNT10", 10)
        ]);
    
    public static List<Discount> orderDiscounts = new List<Discount>(
        [
            new Discount("quantity", 10),
            new Discount("price", 5)
        ]);

    public Discount? GetDiscount(string discountCode)
    {
        return discountCodes.FirstOrDefault(d => d.code == discountCode);
    }
    
    public double CalculateDiscount(string discountCode, double value)
    {
        var discount = discountCodes.FirstOrDefault(d => d.code == discountCode);
        if (discount == null)
        {
            return value;
        }
        return value * (1 - discount.value / 100);
    }
}