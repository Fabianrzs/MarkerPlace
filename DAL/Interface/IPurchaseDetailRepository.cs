using DAL.Interface.Actions;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IPurchaseDetailRepository : ICreate<PurchaseDetails>, IGet<PurchaseDetails>
    {

    }
}
