using Interfaces;
using Interfaces.DTO;
using Orleans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grains
{
    public class User : Grain<UserArchive>, IUser
    {
        public Task<bool> CheckPassword(string password) => Task.FromResult(this.State.Password == password);

        public Task<string> GetName() => Task.FromResult(this.State.Name);

        public Task<string> GetSurName() => Task.FromResult(this.State.SurName);

        public Task<string> GetPosition() => Task.FromResult(this.State.Position);

        public Task<byte[]> GetProfileImage() => Task.FromResult(this.State.ProfileImage);

        public Task<double> GetSalary() => Task.FromResult(this.State.Sallary);

        public Task<bool> IsAdmin() => Task.FromResult(this.State.IsAdmin);

        public async Task SetName(string name)
        {
            this.State.Name = name;
            await this.WriteStateAsync();
        }

        public async Task SetProfileImage(byte[] data)
        {
            this.State.ProfileImage = data;
            await this.WriteStateAsync();
        }

        public async Task SetSurName(string surname)
        {
            this.State.SurName = surname;
            await this.WriteStateAsync();
        }

        public Task<UserDTO> Get() => Task.FromResult(new UserDTO(this.IdentityString,
                                                                  this.State.Name,
                                                                  this.State.SurName,
                                                                  this.State.Position,
                                                                  this.State.ProfileImage,
                                                                  this.State.IsAdmin,
                                                                  this.State.Sallary,
                                                                  this.State.Criterias));

        public async Task Update(UserDTO user)
        {
            this.State.Name = user.Name;
            this.State.SurName = user.SurName;
            this.State.ProfileImage = user.ProfileImage;
            this.State.Sallary = user.Sallary;
            this.State.Position = user.Position;
            this.State.IsAdmin = user.IsAdmin;

            this.State.Criterias.Clear();
            foreach (var item in user.Criterias)
            {
                this.State.Criterias.Add(item);
            }

            await this.WriteStateAsync();
        }
    }

    public class UserArchive
    {
        public string Password { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Position { get; set; }
        public byte[] ProfileImage { get; set; }
        public double Sallary { get; internal set; }
        public bool IsAdmin { get; internal set; }
        public List<CriteriaDTO> Criterias { get; } = new List<CriteriaDTO>();
    }
}