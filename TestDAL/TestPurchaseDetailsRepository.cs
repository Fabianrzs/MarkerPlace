using DAL.Base;
using DAL.Interface;
using DAL.Repository;
using Entity;
using Entity.Enum;

namespace TestDAL
{
    [TestClass]
    public class TestPurchaseDetailsRepository
    {

        private string connectionString = "Server=DKP-FABIAN\\SQLEXPRESS;Database=MarkerPlace;Trusted_Connection = True; MultipleActiveResultSets = true";

        private IPurchaseDetailRepository _repository;

        public TestPurchaseDetailsRepository()
        {
            var connectionManager = new ConnectionManager(connectionString);
            _repository = new PurchaseDetailRepository(connectionManager);
            connectionManager.Open();
        }


        [TestMethod]
        public void InstanceRepository()
        {
            Assert.IsNotNull(_repository);
        }

        [TestMethod]
        public void InsertPurchaseDetails()
        {
           var purchaseDetails = new PurchaseDetails()
           {
                IdProduct= 1,
                IdPurchase= 1,
                Value= 2999,
           };

            var request = _repository.Create(purchaseDetails);

            Assert.AreEqual(request, 1);
        }

        [TestMethod]
        public void UpdatePurchaseDetails()
        {
            var purchaseDetails = new PurchaseDetails()
            {
                IdProduct = 1,
                IdPurchase = 1,
                Value = 2999,
            };

            var request = _repository.Create(purchaseDetails);

            Assert.AreEqual(request, 1);
        }

        [TestMethod]
        public void ConsultPurchaseDetails()
        {
            var request = _repository.GetAll();

            Assert.IsNotNull(request);
        }

        [TestMethod]
        public void ConsultPurchaseDetailsById()
        {
            var id = 1;

            var request = _repository.GetBy<int>(id);

            Assert.AreEqual(request.Id, id);
        }

        [TestMethod]
        public void ChangeStatePurchaseDetails()
        {
            var state = (int)EntitiesState.ACTIVE;
            var id = 1;

            var request = _repository.ChangeState(state, id);

            Assert.AreEqual(request,1);
        }
    }
}