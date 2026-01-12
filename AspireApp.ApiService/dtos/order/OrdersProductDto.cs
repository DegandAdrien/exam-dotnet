using System.Text.Json.Serialization;

namespace AspireApp.ApiService.dtos;

public class OrdersProductDto
{
    public List<OrderQuantity> products { get; set; }
    
    [JsonPropertyName("promo_code")]
    public string? promoCode { get; set; }

    public OrdersProductDto()
    {
    }
    
    public OrdersProductDto(List<OrderQuantity> products, string promoCode)
    {
        this.products = products;
        this.promoCode = promoCode;
    }
    
    public OrdersProductDto(List<OrderQuantity> products)
    {
        this.products = products;
    }
}