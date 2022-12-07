using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Actions
{
    public interface ICreate<TEntity> where TEntity : BaseEntity
    {
        int Create(TEntity entity);
        int ChangeState(int state, int id);
        int Update(TEntity entity);
    }
}
