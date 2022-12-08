using BLL.Interface;
using BLL.Response;
using DAL.Interface;
using DAL.Interface.Actions;
using DAL.Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class GenericService<TEntity, TRespository> : IGenericService<TEntity, TRespository>  where TEntity : BaseEntity 
        where TRespository: ICreate<TEntity>, IGet<TEntity>
    {
        private readonly TRespository _categoryRepository;
        private readonly IConnectionManager _connectionManager;
        public GenericService(TRespository respository, IConnectionManager connectionManager)
        {
            _categoryRepository = respository;
            _connectionManager=connectionManager;
        }
        public EntityResponse<TEntity> ChangeState(int id, int state)
        {
            try
            {
                _connectionManager.Open();

                var status = _categoryRepository.ChangeState(state, id);

                if (status == 0)
                {
                    return new EntityResponse<TEntity>($"No se puedo eliminar la entidad");
                }

                return new EntityResponse<TEntity>("Entidad Eliminada con exito", false);

            }
            catch (Exception e)
            {
                return new EntityResponse<TEntity>($"Se presento el siguiente problema al eliminar {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<TEntity> Create(TEntity category)
        {
            try
            {
                _connectionManager.Open();

                TEntity categoryFind = _categoryRepository.GetBy<int>(category.Id);

                if (categoryFind != null)
                {
                    return new EntityResponse<TEntity>($"No se puede crear la entidad, {category.Id} ya se encuentra en uso");
                }

                _categoryRepository.Create(category);

                return new EntityResponse<TEntity>(category);

            }
            catch (Exception e)
            {
                return new EntityResponse<TEntity>($"Se presento el siguiente problema al crear la entidad {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<TEntity> Edit<T>(TEntity category, T id)
        {
            try
            {
                _connectionManager.Open();

                TEntity categoryFind = _categoryRepository.GetBy<int>(category.Id);

                if (categoryFind == null)
                {
                    return new EntityResponse<TEntity>($"No se puede editar la entidad, {category.Id} es invalido");
                }

                _categoryRepository.Update(category);


                return new EntityResponse<TEntity>(category);

            }
            catch (Exception e)
            {
                return new EntityResponse<TEntity>($"Se presento el siguiente problema al editar la entidad {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<TEntity> GetAll()
        {
            try
            {
                _connectionManager.Open();

                List<TEntity> categories = new List<TEntity>();
                categories = _categoryRepository.GetAll();

                if (categories == null || categories.Count == 0)
                {
                    return new EntityResponse<TEntity>($"No se encontraron entidades registradas");
                }

                return new EntityResponse<TEntity>(categories);

            }
            catch (Exception e)
            {
                return new EntityResponse<TEntity>($"Se presento el siguiente problema al consultar {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<TEntity> GetById(int id)
        {
            try
            {
                _connectionManager.Open();

                TEntity categoryFind = _categoryRepository.GetBy<int>(id);

                if (categoryFind == null)
                {
                    return new EntityResponse<TEntity>($"No se puedo encontrar la entidad solicitada");
                }

                return new EntityResponse<TEntity>(categoryFind);

            }
            catch (Exception e)
            {
                return new EntityResponse<TEntity>($"Se presento el siguiente problema al buscar {id} {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }
    }
}
