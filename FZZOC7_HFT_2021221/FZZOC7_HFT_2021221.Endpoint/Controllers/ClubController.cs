using FZZOC7_HFT_2021221.Endpoint.Services;
using FZZOC7_HFT_2021221.Logic;
using FZZOC7_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FZZOC7_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        IClubLogic ClubLogic;
        IHubContext<SignalRHub> Hub;

        public ClubController(IClubLogic clubLogic, IHubContext<SignalRHub> hub)
        {
            ClubLogic = clubLogic;
            Hub = hub;
        }

        // GET: api/<ClubController>
        [HttpGet]
        public IEnumerable<Club> Get()
        {
            return ClubLogic.ReadAll();
        }

        // GET api/<ClubController>/5
        [HttpGet("{id}")]
        public Club Get(int id)
        {
            return ClubLogic.Read(id);
        }

        // POST api/<ClubController>
        [HttpPost]
        public void Post([FromBody] Club value)
        {
            ClubLogic.Create(value);
            Hub.Clients.All.SendAsync("ClubCreated", value);
        }

        // PUT api/<ClubController>/5
        [HttpPut]
        public void Put([FromBody] Club value)
        {
            ClubLogic.Update(value);
            Hub.Clients.All.SendAsync("ClubUpdated", value);
        }

        // DELETE api/<ClubController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var clubToDelete = ClubLogic.Read(id);
            ClubLogic.Delete(id);
            Hub.Clients.All.SendAsync("ClubDeleted", clubToDelete);
        }
    }
}
