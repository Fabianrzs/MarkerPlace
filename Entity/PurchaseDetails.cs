using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PurchaseDetails: BaseEntity
    {
        public int Amount { get; set; }
        public decimal Value { get; set; }
        public int IdProduct { get; set; }
        public Product Product { get; set; }
        public int IdPurchase { get; set; }
        public Purchase Purchase { get; set; }

        public void CaculateValue(decimal value)
        {
            Value = value* Amount;
        }
        
    }
}
