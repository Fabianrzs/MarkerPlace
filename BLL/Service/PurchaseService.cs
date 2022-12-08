using BLL.Interface;
using BLL.Response;
using BLL.Service;
using DAL.Interface;
using DAL.Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _categoryRepository;
        private readonly IConnectionManager _connectionManager;

        public PurchaseService(IPurchaseRepository categoryRepository, IConnectionManager connectionManager)
        {
            _categoryRepository = categoryRepository;
            _connectionManager = connectionManager;
        }
        public EntityResponse<Purchase> ChangeState(int id, int state)
        {
            try
            {
                _connectionManager.Open();

                var status = _categoryRepository.ChangeState(state, id);

                if (status == 0)
                {
                    return new EntityResponse<Purchase>($"No se puedo eliminar la compra");
                }

                return new EntityResponse<Purchase>("compra Eliminada con exito", false);

            }
            catch (Exception e)
            {
                return new EntityResponse<Purchase>($"Se presento el siguiente problema al eliminar {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<Purchase> Create(Purchase category)
        {
            try
            {
                _connectionManager.Open();

                Purchase categoryFind = _categoryRepository.GetBy<int>(category.Id);

                if (categoryFind != null)
                {
                    return new EntityResponse<Purchase>($"No se puede crear la compra, {category.Id} ya se encuentra en uso");
                }

                _categoryRepository.Create(category);

                return new EntityResponse<Purchase>(category);

            }
            catch (Exception e)
            {
                return new EntityResponse<Purchase>($"Se presento el siguiente problema al crear la compra {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<Purchase> Edit<T>(Purchase category, T id)
        {
            try
            {
                _connectionManager.Open();

                Purchase categoryFind = _categoryRepository.GetBy<int>(category.Id);

                if (categoryFind == null)
                {
                    return new EntityResponse<Purchase>($"No se puede editar la compra, {category.Id} es invalido");
                }

                _categoryRepository.Update(category);


                return new EntityResponse<Purchase>(category);

            }
            catch (Exception e)
            {
                return new EntityResponse<Purchase>($"Se presento el siguiente problema al editar la compra {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<Purchase> GetAll()
        {
            try
            {
                _connectionManager.Open();

                List<Purchase> categories = new List<Purchase>();
                categories = _categoryRepository.GetAll();

                if (categories == null || categories.Count == 0)
                {
                    return new EntityResponse<Purchase>($"No se encontraron compras registradas");
                }

                return new EntityResponse<Purchase>(categories);

            }
            catch (Exception e)
            {
                return new EntityResponse<Purchase>($"Se presento el siguiente problema al consultar {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<Purchase> GetById(int id)
        {
            try
            {
                _connectionManager.Open();

                Purchase categoryFind = _categoryRepository.GetBy<int>(id);

                if (categoryFind == null)
                {
                    return new EntityResponse<Purchase>($"No se puedo encontrar la compra solicitada");
                }

                return new EntityResponse<Purchase>(categoryFind);

            }
            catch (Exception e)
            {
                return new EntityResponse<Purchase>($"Se presento el siguiente problema al buscar {id} {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }
    }
}
