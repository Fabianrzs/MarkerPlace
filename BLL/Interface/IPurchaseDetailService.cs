using BLL.Interface.Actions;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IPurchaseDetailService : ICreate<PurchaseDetails>, IGet<PurchaseDetails>
    {
    }
}
