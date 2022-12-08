using BLL.Response;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Actions
{
    public interface IGet<TEntity> where TEntity : BaseEntity
    {

        EntityResponse<TEntity> GetById(int id);
        EntityResponse<TEntity> GetAll();
    }
}

