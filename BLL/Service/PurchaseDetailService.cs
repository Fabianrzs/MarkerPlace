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
    public class PurchaseDetailService : IPurchaseDetailService
    {
        private readonly IPurchaseDetailRepository _categoryRepository;
        private readonly IConnectionManager _connectionManager;

        public PurchaseDetailService(IPurchaseDetailRepository userRepository, IConnectionManager connectionManager)
        {
            _categoryRepository = userRepository;
            _connectionManager = connectionManager;
        }
        public EntityResponse<PurchaseDetails> ChangeState(int id, int state)
        {
            try
            {
                _connectionManager.Open();

                var status = _categoryRepository.ChangeState(state, id);

                if (status == 0)
                {
                    return new EntityResponse<PurchaseDetails>($"No se pudo eliminar");
                }

                return new EntityResponse<PurchaseDetails>("Categoria Eliminada con exito", false);

            }
            catch (Exception e)
            {
                return new EntityResponse<PurchaseDetails>($"Se presento el siguiente problema al eliminar {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<PurchaseDetails> Create(PurchaseDetails category)
        {
            try
            {
                _connectionManager.Open();

                PurchaseDetails categoryFind = _categoryRepository.GetBy<int>(category.Id);

                if (categoryFind != null)
                {
                    return new EntityResponse<PurchaseDetails>($"No se puede crear, {category.Id} ya se encuentra en uso");
                }

                _categoryRepository.Create(category);

                return new EntityResponse<PurchaseDetails>(category);

            }
            catch (Exception e)
            {
                return new EntityResponse<PurchaseDetails>($"Se presento el siguiente problema al crear {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<PurchaseDetails> Edit<T>(PurchaseDetails category, T id)
        {
            try
            {
                _connectionManager.Open();

                PurchaseDetails categoryFind = _categoryRepository.GetBy<int>(category.Id);

                if (categoryFind == null)
                {
                    return new EntityResponse<PurchaseDetails>($"No se puede editar , {category.Id} es invalido");
                }

                _categoryRepository.Update(category);


                return new EntityResponse<PurchaseDetails>(category);

            }
            catch (Exception e)
            {
                return new EntityResponse<PurchaseDetails>($"Se presento el siguiente problema al editar {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<PurchaseDetails> GetAll()
        {
            try
            {
                _connectionManager.Open();

                List<PurchaseDetails> categories = new List<PurchaseDetails>();
                categories = _categoryRepository.GetAll();

                if (categories == null || categories.Count == 0)
                {
                    return new EntityResponse<PurchaseDetails>($"No se encontraron registros");
                }

                return new EntityResponse<PurchaseDetails>(categories);

            }
            catch (Exception e)
            {
                return new EntityResponse<PurchaseDetails>($"Se presento el siguiente problema al consultar {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<PurchaseDetails> GetById(int id)
        {
            try
            {
                _connectionManager.Open();

                PurchaseDetails categoryFind = _categoryRepository.GetBy<int>(id);

                if (categoryFind == null)
                {
                    return new EntityResponse<PurchaseDetails>($"No se puedo encontrar el registro");
                }

                return new EntityResponse<PurchaseDetails>(categoryFind);

            }
            catch (Exception e)
            {
                return new EntityResponse<PurchaseDetails>($"Se presento el siguiente problema al buscar {id} {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }
    }
}
