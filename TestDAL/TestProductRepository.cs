using DAL.Base;
using DAL.Interface;
using DAL.Repository;
using Entity;
using Entity.Enum;

namespace TestDAL
{
    [TestClass]
    public class TestProductRepository
    {

        private string connectionString = "Server=DKP-FABIAN\\SQLEXPRESS;Database=MarkerPlace;Trusted_Connection = True; MultipleActiveResultSets = true";

        private IProductRepository _repository;

        public TestProductRepository()
        {
            var connectionManager = new ConnectionManager(connectionString);
            _repository = new ProductRepository(connectionManager);
            connectionManager.Open();
        }


        [TestMethod]
        public void InstanceRepository()
        {
            Assert.IsNotNull(_repository);
        }

        [TestMethod]
        public void InsertProduct()
        {
           var product = new Product()
            {
                Description= "Test_description",
                Name = "Name",
                Image = "Image",
                Value = 5000,
                IdCategory = 1
            };

            var request = _repository.Create(product);

            Assert.AreEqual(request, 1);
        }

        [TestMethod]
        public void UpdateProduct()
        {
            var product = new Product()
            {
                Id = 1,
                Description = "Test_description",
                Name = "Name",
                Image = "Image",
                Value = 5000,
                IdCategory = 1
            };

            var request = _repository.Update(product);

            Assert.AreEqual(request, 1);
        }

        [TestMethod]
        public void ConsultProduct()
        {
            var request = _repository.GetAll();

            Assert.IsNotNull(request);
        }

        [TestMethod]
        public void ConsultProductById()
        {
            var id = 1;

            var request = _repository.GetBy<int>(id);

            Assert.AreEqual(request.Id, id);
        }

        [TestMethod]
        public void ChangeStateProduct()
        {
            var state = (int)EntitiesState.ACTIVE;
            var id = 1;

            var request = _repository.ChangeState(state, id);

            Assert.AreEqual(request,1);
        }
    }
}