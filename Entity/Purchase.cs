using Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Purchase : BaseEntity
    {
        public DateTime Date { get; } = DateTime.Now;
        public decimal Value { get; set; }
        public int StatePurchase { get; set; } = (int)PurchaseState.CAR;
        public int IdUser { get; set; }
        public ICollection<PurchaseDetails> PurchaseDetails { get; set; }

        public void CalculateFullValue()
        {
            foreach(var purchase in PurchaseDetails)
            {
                Value += purchase.Value;
            }
        }

        public void Buy()
        {
            StatePurchase = (int) PurchaseState.BUY;
        }
    }
}
