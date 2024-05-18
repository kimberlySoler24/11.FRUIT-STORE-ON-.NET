namespace TiendaDeFrutas.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public required String fruit_list { get; set; } = string.Empty;
        public double total_value { get; set; }
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
    }
}
