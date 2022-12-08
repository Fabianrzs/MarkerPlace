namespace Site.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Value { get; set; }

        //Forenkey
        public int IdCategory { get; set; }
        public Category Category { get; set; }
    }
}
