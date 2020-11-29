namespace Interfaces.DTO
{
    public class UserLoginDTO : UserDTO
    {
        public UserLoginDTO(string name, string surName, string position, byte[] profileImage, bool isAdmin, double sallary) : base(name, surName, position, profileImage, isAdmin, sallary)
        {
        }

        public UserLoginDTO(string username, string name, string surName, string position, byte[] profileImage, bool isAdmin, double sallary) : base(name, surName, position, profileImage, isAdmin, sallary)
        {
            UserName = username;
        }

        public string UserName { get; set; }
    }
}