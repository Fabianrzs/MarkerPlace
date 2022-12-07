using System.ComponentModel;

namespace Entity
{
    public class User: BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }


        public void Encript()
        {
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(Password);
            Password = Convert.ToBase64String(encryted);
        }
        public void DesEncript()
        {
            byte[] decryted = Convert.FromBase64String(Password);
            Password = System.Text.Encoding.Unicode.GetString(decryted);
        }

    }
}