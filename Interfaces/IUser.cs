using Interfaces.DTO;
using Orleans;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// Orleans grain communication interface
    /// </summary>
    public interface IUser : IGrainWithStringKey
    {
        Task<string> GetName();
     
        Task SetName(string name);

        Task<bool> CheckPassword(string password);

        Task<string> GetSurName();

        Task SetSurName(string surname);

        Task<string> GetPosition();

        /// <summary>
        /// Returnes current profile picture for current user
        /// </summary>
        /// <returns>Byte array</returns>
        Task<byte[]> GetProfileImage();
        
        Task SetProfileImage(byte[] data);

        Task<bool> IsAdmin();

        Task<double> GetSalary();
        
        Task<UserDTO> Get();
        Task Update(UserLoginDTO user);
    }
}