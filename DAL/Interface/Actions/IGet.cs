using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Actions
{
    public interface IGet<TEntity> where TEntity : BaseEntity
    {
        TEntity GetBy<T>(T query);
        List<TEntity> GetAll();
    }
}
