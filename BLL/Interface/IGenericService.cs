using BLL.Interface.Actions;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IGenericService<TEntity, TRespository> : ICreate<TEntity>,
        IGet<TEntity> where TEntity : BaseEntity where TRespository : ICreate<TEntity>, IGet<TEntity>
    {
    }
}
