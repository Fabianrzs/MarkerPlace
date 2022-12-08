using Entity;

namespace Site.Models
{
    public class Purchase
    {
        public DateTime Date { get; } = DateTime.Now;
        public decimal Value { get; set; }
        public int StatePurchase { get; set; }
        public int IdPurchaseDetails { get; set; }
        public ICollection<PurchaseDetails> PurchaseDetails { get; set; }

        public void CalculateFullValue(ICollection<PurchaseDetails> purchaseDetails)
        {
            foreach(var purchase in purchaseDetails)
            {
                Value += purchase.Value;
            }
        }
    }
}
