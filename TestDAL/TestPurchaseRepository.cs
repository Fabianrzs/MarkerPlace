using DAL.Base;
using DAL.Interface;
using DAL.Repository;
using Entity;
using Entity.Enum;

namespace TestDAL
{
    [TestClass]
    public class TestPurchaseRepository
    {

        private string connectionString = "Server=DKP-FABIAN\\SQLEXPRESS;Database=MarkerPlace;Trusted_Connection = True; MultipleActiveResultSets = true";

        private IPurchaseRepository _repository;

        public TestPurchaseRepository()
        {
            var connectionManager = new ConnectionManager(connectionString);
            _repository = new PurchaseRepository(connectionManager);
            connectionManager.Open();
        }


        [TestMethod]
        public void InstanceRepository()
        {
            Assert.IsNotNull(_repository);
        }

        [TestMethod]
        public void InsertPurchase()
        {
           var purchase = new Purchase()
            {
                IdUser = 1,
                StatePurchase = (int)PurchaseState.BUY,
                Value= 1000000,
            };

            var request = _repository.Create(purchase);

            Assert.AreEqual(request, 1);
        }

        [TestMethod]
        public void UpdatePurchase()
        {
            var purchase = new Purchase()
            {
                Id = 1,
                StatePurchase = (int)PurchaseState.CANCEL,
                Value = 1000000,
            };

            var request = _repository.Create(purchase);

            Assert.AreEqual(request, 1);
        }

        [TestMethod]
        public void ConsultPurchase()
        {
            var request = _repository.GetAll();

            Assert.IsNotNull(request);
        }

        [TestMethod]
        public void ConsultPurchaseById()
        {
            var id = 1;

            var request = _repository.GetBy<int>(id);

            Assert.AreEqual(request.Id, id);
        }

        [TestMethod]
        public void ChangeStatePurchase()
        {
            var state = (int)EntitiesState.ACTIVE;
            var id = 1;

            var request = _repository.ChangeState(state, id);

            Assert.AreEqual(request,1);
        }
    }
}