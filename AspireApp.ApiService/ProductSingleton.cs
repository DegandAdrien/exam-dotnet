using AspireApp.Persistence.product;

namespace AspireApp.ApiService;

public sealed class ProductSingleton
{
    private ProductSingleton() { }

    private static ProductSingleton _instance;
    
    public static ProductSingleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ProductSingleton();
        }
        return _instance;
    }

    private static List<Product> _products = new List<Product>(
        [
            new Product(1, "Product 1", 10, 10),
            new Product(2, "Product 2", 2.99, 5),
            new Product(3, "Product 3", 9.99, 2),
            new Product(4, "Product 4", 20, 11),
            new Product(5, "Product 5", 100, 50)
        ]);
    
    public List<Product> GetProducts()
    {
        return _products;
    }
    
    public Product GetProduct(int id)
    {
        return _products.FirstOrDefault(p => p.id == id);
    }

    public void SetProduct(Product product)
    {
        _products.FirstOrDefault(p => p.id == product.id).stock = product.stock;
    }
}