namespace eCommerce.ProductMicroService.API.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string ProductName { get; set; }
        public  int QtyInStock { get; set; }
        public string? Category { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
