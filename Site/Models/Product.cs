namespace Site.Models
{
    public class ProductInputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Availble { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Value { get; set; }
        public int IdCategory { get; set; }
    }
}
