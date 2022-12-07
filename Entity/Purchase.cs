using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Purchase: BaseEntity
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
