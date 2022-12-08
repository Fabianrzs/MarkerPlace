namespace Site.Models
{
    public class PurchaseDetails
    {
        public int Amount { get; set; }
        public decimal Value { get; set; }
        public int IdProducto { get; set; }
        public Product Product { get; set; }
        public int IdPurchase { get; set; }
        public Purchase Purchase { get; set; }

        public void CaculateValue(decimal value)
        {
            Value = value* Amount;
        }
        
    }
}
