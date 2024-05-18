namespace TiendaDeFrutas.Entities
{
    public class Fruit
    {
        public int Id { get; set; }
        public required string type { get; set; } = string.Empty;
        public int quantity { get; set; }
        public double price { get; set; }
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set;}
    }
}
