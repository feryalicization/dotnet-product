namespace ProductApi.Dtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
