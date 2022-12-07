using DAL.Base;
using DAL.Interface;
using DAL.Repository;
using Entity;
using Entity.Enum;

namespace TestDAL
{
    [TestClass]
    public class TestCategoryRepository
    {

        private string connectionString = "Server=DKP-FABIAN\\SQLEXPRESS;Database=MarkerPlace;Trusted_Connection = True; MultipleActiveResultSets = true";

        private ICategoryRepository _repository;

        public TestCategoryRepository()
        {
            var connectionManager = new ConnectionManager(connectionString);
            _repository = new CategoryRepository(connectionManager);
            connectionManager.Open();
        }


        [TestMethod]
        public void InstanceRepository()
        {
            Assert.IsNotNull(_repository);
        }

        [TestMethod]
        public void InserCategory()
        {
           var category = new Category()
            {
               Name = "Test",
            };

            var request = _repository.Create(category);

            Assert.AreEqual(request, 1);
        }

        [TestMethod]
        public void UpdateCategory()
        {
            var user = new Category()
            {
                Id = 1,
                Name = "TestChange",
            };


            var request = _repository.Update(user);

            Assert.AreEqual(request, 1);
        }

        [TestMethod]
        public void ConsultCategory()
        {
            var request = _repository.GetAll();

            Assert.IsNotNull(request);
        }

        [TestMethod]
        public void ConsultCategoryById()
        {
            var id = 1;

            var request = _repository.GetBy<int>(id);

            Assert.AreEqual(request.Id, id);
        }

        [TestMethod]
        public void ChangeStateCategory()
        {
            var state = (int)EntitiesState.ACTIVE;
            var id = 1;

            var request = _repository.ChangeState(state, id);

            Assert.AreEqual(request,1);
        }
    }
}