namespace eCommerce.ProductMicroService.API.Dtos.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public required string ProductName { get; set; }
        public int QtyInStock { get; set; }
        public string? Category { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
