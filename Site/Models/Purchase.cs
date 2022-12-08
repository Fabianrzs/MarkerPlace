using Entity;
using System.Text.Json.Serialization;

namespace Site.Models
{
    public class PurchaseInputModel
    {
        public decimal Value { get; set; }
        public int IdUser { get; set; }
        [JsonIgnore]
        public List<PurchaseDetails> PurchaseDetails { get; set; }
    }
}
