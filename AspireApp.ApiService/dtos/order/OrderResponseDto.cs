using AspireApp.ApiService.response;

namespace AspireApp.ApiService.dtos;

public class OrderResponseDto
{
    public List<ProductResult> products { get; set; }
    public List<DiscountResult> discounts { get; set; }
    public double total { get; set; }

    public OrderResponseDto(OrderResponse orderResponse)
    {
        this.products = orderResponse.products;
        this.discounts = orderResponse.discounts;
        this.total = orderResponse.total;
    }
}