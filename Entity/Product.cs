using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Value { get; set; }
        public int Availble { get; set; }
        //Forenkey
        public int IdCategory { get; set; }
        public Category Category { get; set; }

        public void Descount(int available)
        {
            Availble -= available;
            if(Availble < 0)
            {
                throw new InvalidOperationException("Cantidades Invalidas");
            }
        }
    }
}
