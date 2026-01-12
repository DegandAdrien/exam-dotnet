using AspireApp.Persistence.product;

namespace AspireApp.ApiService;

public sealed class ProductSingleton
{
    private ProductSingleton() { }

    private static ProductSingleton _instance;

    private static List<Product> _products = new List<Product>(
        [
            new Product(1, "Product 1", 10, 10),
            new Product(2, "Product 2", 2.99, 5),
            new Product(3, "Product 3", 9.99, 2),
            new Product(4, "Product 4", 5, 0),
            new Product(5, "Product 5", 1, 50)
        ]);

    public static ProductSingleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ProductSingleton();
        }
        return _instance;
    }
    
    public List<Product> GetProducts()
    {
        return _products;
    }
}