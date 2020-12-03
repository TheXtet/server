using Interfaces;
using Interfaces.DTO;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagerController : ControllerBase
    {
        private readonly IGrainFactory _client;
        private readonly ICriteria _grain;

        public UserManagerController(IGrainFactory client)
        {
            _client = client;
            _grain = _client.GetGrain<ICriteria>(0);
        }


        // GET: api/criterias
        [HttpGet]
        public async Task<string> Get()
        {
            string login = "username5";

            var user = _client.GetGrain<IUser>(login);
            await user.SetPassword("55555");

            //await _client.GetGrain<IUsers>(0).Add(login);

            //List<CriteriaDTO> criterias = new List<CriteriaDTO>();
            //foreach (var item in await _grain.Get())
            //{
            //    criterias.Add(new CriteriaDTO(item.Name, item.Abbreviation, item.IsEnabled, new Random().Next(45)));
            //}

            //await user.Update(new UserDTO(login,
            //                              "Егор",
            //                              "Андреев",
            //                              "Администратор",
            //                               new WebClient().DownloadData("https://www.pngfind.com/pngs/m/317-3177131_636682202684372240-user-profile-photo-round-hd-png-download.png"),
            //                               true,
            //                               16500,
            //                               criterias));



            return await Task.FromResult("Completed");
        }
    }
}