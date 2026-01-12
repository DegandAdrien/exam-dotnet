using AspireApp.ApiService.dtos;
using AspireApp.ApiService.response;
using AspireApp.Persistence.discount;
using AspireApp.Persistence.product;

namespace AspireApp.ApiService;

public class OrderSingleton
{
    private OrderSingleton() { }

    private static OrderSingleton _instance;
    
    public static OrderSingleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new OrderSingleton();
        }
        return _instance;
    }

    public OrderResponse OrderProducts(OrdersProductDto ordersProductDto)
    {
        ProductSingleton productSingleton = ProductSingleton.GetInstance();
        DiscountSingleton discountSingleton = DiscountSingleton.GetInstance();
        
        OrderResponse orderResponse = new OrderResponse();
        
        List<ProductResult> productsResult = new List<ProductResult>();
        List<DiscountResult> discountsResult = new List<DiscountResult>();
        List<string> errors = new List<string>();

        ordersProductDto.products.ForEach(orderQuantity =>
        {
            try
            {
                Product product = productSingleton.GetProduct(orderQuantity.id);
                if (product.stock < orderQuantity.quantity)
                {
                    errors.Add("Le produit: " + product.name + " n'est plus disponible");
                    orderResponse.success = false;
                }

                var productResult = new ProductResult(product.id, product.name, product.price, orderQuantity.quantity);
                if (productResult.quantity > 5)
                {
                    productResult.total = discountSingleton.CalculateDiscount("quantity", productResult.total);
                }
                
                productsResult.Add(productResult);
                
                product.stock -= orderQuantity.quantity;
                productSingleton.SetProduct(product);
            }
            catch (Exception e)
            {
                errors.Add("Le produit n'existe pas");
                orderResponse.success = false;
            }
        });
        
        double total = productsResult.Sum(product => product.total);
        
        if (ordersProductDto.promoCode != null)
        {
            try
            {
                Discount discount = discountSingleton.GetDiscount(ordersProductDto.promoCode);
                if (total < 50)
                {
                    errors.Add("Les code promo ne sont valides que sur un total de 50€ minimum");
                    orderResponse.success = false;
                }
                else
                {
                    total = discountSingleton.CalculateDiscount(discount.code, total);
                    discountsResult.Add(new DiscountResult("promo", discount.value));
                }
                
            }
            catch (Exception e)
            {
                errors.Add("Le code promo n'est pas valide");
                orderResponse.success = false;
            }
            
        }

        if (total > 100)
        {
            total = discountSingleton.CalculateDiscount("price", total);
            discountsResult.Add(new DiscountResult("order", 5));
        }
        orderResponse.products = productsResult;
        orderResponse.total = total;
        orderResponse.discounts = discountsResult;

        orderResponse.errors = errors;

        if (orderResponse.success == null)
        {
            orderResponse.success = true;
        }
        
        return orderResponse; 
    }
}