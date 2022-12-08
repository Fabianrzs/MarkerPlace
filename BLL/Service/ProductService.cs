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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IConnectionManager _connectionManager;

        public ProductService(IProductRepository productRepository, IConnectionManager connectionManager)
        {
            _productRepository = productRepository;
            _connectionManager = connectionManager;
        }
        public EntityResponse<Product> ChangeState(int id, int state)
        {
            try
            {
                _connectionManager.Open();

                var status = _productRepository.ChangeState(state, id);

                if (status == 0)
                {
                    return new EntityResponse<Product>($"No se puedo eliminar el producto");
                }

                return new EntityResponse<Product>("Producto Eliminado con exito", false);

            }
            catch (Exception e)
            {
                return new EntityResponse<Product>($"Se presento el siguiente problema al eliminar {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<Product> Create(Product category)
        {
            try
            {
                _connectionManager.Open();

                Product productFind = _productRepository.GetBy<int>(category.Id);

                if (productFind != null)
                {
                    return new EntityResponse<Product>($"No se puede crear el producto, {category.Id} ya se encuentra en uso");
                }

                _productRepository.Create(category);

                return new EntityResponse<Product>(category);

            }
            catch (Exception e)
            {
                return new EntityResponse<Product>($"Se presento el siguiente problema al crear el producto {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<Product> Edit<T>(Product category, T id)
        {
            try
            {
                _connectionManager.Open();

                Product productFind = _productRepository.GetBy<int>(category.Id);

                if (productFind == null)
                {
                    return new EntityResponse<Product>($"No se puede editar el producto, {category.Id} es invalido");
                }

                _productRepository.Update(category);


                return new EntityResponse<Product>(category);

            }
            catch (Exception e)
            {
                return new EntityResponse<Product>($"Se presento el siguiente problema al editar el producto {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<Product> GetAll()
        {
            try
            {
                _connectionManager.Open();

                List<Product> products = new List<Product>();
                products = _productRepository.GetAll();

                if (products == null || products.Count == 0)
                {
                    return new EntityResponse<Product>($"No se encontraron productos registrados");
                }

                return new EntityResponse<Product>(products);

            }
            catch (Exception e)
            {
                return new EntityResponse<Product>($"Se presento el siguiente problema al consultar {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<Product> GetById(int id)
        {
            try
            {
                _connectionManager.Open();

                Product productFind = _productRepository.GetBy<int>(id);

                if (productFind == null)
                {
                    return new EntityResponse<Product>($"No se puedo encontrar el producto solicitada");
                }

                return new EntityResponse<Product>(productFind);

            }
            catch (Exception e)
            {
                return new EntityResponse<Product>($"Se presento el siguiente problema al buscar {id} {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }
    }
}
