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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IConnectionManager _connectionManager;

        public CategoryService(ICategoryRepository categoryRepository, IConnectionManager connectionManager)
        {
            _categoryRepository = categoryRepository;
            _connectionManager = connectionManager;
        }
        public EntityResponse<Category> ChangeState(int id, int state)
        {
            try
            {
                _connectionManager.Open();

                var status = _categoryRepository.ChangeState(state, id);

                if (status == 0)
                {
                    return new EntityResponse<Category>($"No se puedo eliminar la categoria");
                }

                return new EntityResponse<Category>("Categoria Eliminada con exito", false);

            }
            catch (Exception e)
            {
                return new EntityResponse<Category>($"Se presento el siguiente problema al eliminar {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<Category> Create(Category category)
        {
            try
            {
                _connectionManager.Open();

                Category categoryFind = _categoryRepository.GetBy<int>(category.Id);

                if (categoryFind != null)
                {
                    return new EntityResponse<Category>($"No se puede crear la categoria, {category.Id} ya se encuentra en uso");
                }

                _categoryRepository.Create(category);

                return new EntityResponse<Category>(category);

            }
            catch (Exception e)
            {
                return new EntityResponse<Category>($"Se presento el siguiente problema al crear la categoria {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<Category> Edit<T>(Category category, T id)
        {
            try
            {
                _connectionManager.Open();

                Category categoryFind = _categoryRepository.GetBy<int>(category.Id);

                if (categoryFind == null)
                {
                    return new EntityResponse<Category>($"No se puede editar la categoria, {category.Id} es invalido");
                }

                _categoryRepository.Update(category);


                return new EntityResponse<Category>(category);

            }
            catch (Exception e)
            {
                return new EntityResponse<Category>($"Se presento el siguiente problema al editar la categoria {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<Category> GetAll()
        {
            try
            {
                _connectionManager.Open();

                List<Category> categories = new List<Category>();
                categories = _categoryRepository.GetAll();

                if (categories == null || categories.Count == 0)
                {
                    return new EntityResponse<Category>($"No se encontraron categorias registradas");
                }

                return new EntityResponse<Category>(categories);

            }
            catch (Exception e)
            {
                return new EntityResponse<Category>($"Se presento el siguiente problema al consultar {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<Category> GetById(int id)
        {
            try
            {
                _connectionManager.Open();

                Category categoryFind = _categoryRepository.GetBy<int>(id);

                if (categoryFind == null)
                {
                    return new EntityResponse<Category>($"No se puedo encontrar la categoria solicitada");
                }

                return new EntityResponse<Category>(categoryFind);

            }
            catch (Exception e)
            {
                return new EntityResponse<Category>($"Se presento el siguiente problema al buscar {id} {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }
    }
}
