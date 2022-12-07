using DAL.Base;
using DAL.Interface;
using DAL.Repository;
using Entity;
using Entity.Enum;

namespace TestDAL
{
    [TestClass]
    public class TestUserRepository
    {

        private string connectionString = "Server=DKP-FABIAN\\SQLEXPRESS;Database=MarkerPlace;Trusted_Connection = True; MultipleActiveResultSets = true";

        [TestMethod]
        public void InstanceRepository()
        {
            var connectionManager = new ConnectionManager(connectionString);

            var userRepository = new UserRepository(connectionManager);

            Assert.IsNotNull(userRepository);
        }

        [TestMethod]
        public void InsertUsers()
        {
            var connectionManager = new ConnectionManager(connectionString);

            connectionManager.Open();

            var userRepository = new UserRepository(connectionManager);

            var user = new User()
            {
                Password= "password123",
                UserName = "UserName",
            };

            user.Encript();

            var request = userRepository.Create(user);

            Assert.AreEqual(request, 1);
        }

        [TestMethod]
        public void UpdateUsers()
        {
            var connectionManager = new ConnectionManager(connectionString);

            connectionManager.Open();

            var userRepository = new UserRepository(connectionManager);

            var user = new User()
            {
                Id = 5,
                Password = "password12345",
                UserName = "UserName",
            };

            user.Encript();

            var request = userRepository.Create(user);

            Assert.AreEqual(request, 1);
        }

        [TestMethod]
        public void ConsultUsers()
        {
            var connectionManager = new ConnectionManager(connectionString);

            connectionManager.Open();

            var userRepository = new UserRepository(connectionManager);

            var request = userRepository.GetAll();

            Assert.IsNotNull(request);
        }

        [TestMethod]
        public void ConsultUsersByUserName()
        {
            var connectionManager = new ConnectionManager(connectionString);

            connectionManager.Open();

            var userName = "UserName";

            var userRepository = new UserRepository(connectionManager);

            var request = userRepository.GetBy<string>(userName);

            Assert.AreEqual(request.UserName, userName);
        }

        [TestMethod]
        public void ChangeStateUser()
        {
            var connectionManager = new ConnectionManager(connectionString);

            connectionManager.Open();

            var state = (int)EntitiesState.ACTIVE;
            var id = 5;

            var userRepository = new UserRepository(connectionManager);

            var request = userRepository.ChangeState(state, id);

            Assert.AreEqual(request,1);
        }
    }
}