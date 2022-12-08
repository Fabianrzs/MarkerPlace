using BLL.Response;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Actions
{
    public interface ICreate<TEntity> where TEntity : BaseEntity
    {

        EntityResponse<TEntity> Create(TEntity entity);
        EntityResponse<TEntity> ChangeState(int id, int state);
        EntityResponse<TEntity> Edit(TEntity entity);
    }
}
