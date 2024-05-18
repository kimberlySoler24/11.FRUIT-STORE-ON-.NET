namespace TiendaDeFrutas.Dto
{
    public class UpdateFruitDto
    {
        public int Id { get; set; }
        public required string type { get; set; } = string.Empty;

        public double price { get; set; }
        public int quantity { get; set; }
    }
}
