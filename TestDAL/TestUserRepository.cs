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

        private UserRepository userRepository;

        public TestUserRepository()
        {
            var connectionManager = new ConnectionManager(connectionString);
            userRepository = new UserRepository(connectionManager);
            connectionManager.Open();
        }


        [TestMethod]
        public void InstanceRepository()
        {
            Assert.IsNotNull(userRepository);
        }

        [TestMethod]
        public void InsertUsers()
        {
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
            var request = userRepository.GetAll();

            Assert.IsNotNull(request);
        }

        [TestMethod]
        public void ConsultUsersByUserName()
        {
            var userName = "UserName";

            var request = userRepository.GetBy<string>(userName);

            Assert.AreEqual(request.UserName, userName);
        }

        [TestMethod]
        public void ChangeStateUser()
        {
            var state = (int)EntitiesState.ACTIVE;
            var id = 5;

            var request = userRepository.ChangeState(state, id);

            Assert.AreEqual(request,1);
        }
    }
}