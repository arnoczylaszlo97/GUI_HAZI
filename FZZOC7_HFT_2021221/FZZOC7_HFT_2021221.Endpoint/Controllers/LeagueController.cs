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
    public class LeagueController : ControllerBase
    {
        ILeagueLogic LeagueLogic;
        IHubContext<SignalRHub> Hub;

        public LeagueController(ILeagueLogic leagueLogic, IHubContext<SignalRHub> hub)
        {
            LeagueLogic = leagueLogic;
            Hub = hub;
        }

        // GET: api/<LeagueController>
        [HttpGet]
        public IEnumerable<League> Get()
        {
            return LeagueLogic.ReadAll();
        }

        // GET api/<LeagueController>/5
        [HttpGet("{id}")]
        public League Get(int id)
        {
            return LeagueLogic.Read(id);
        }

        // POST api/<LeagueController>
        [HttpPost]
        public void Post([FromBody] League value)
        {
            LeagueLogic.Create(value);
            Hub.Clients.All.SendAsync("LeagueCreated", value);
        }

        // PUT api/<LeagueController>/5
        [HttpPut]
        public void Put([FromBody] League value)
        {
            LeagueLogic.Update(value);
            Hub.Clients.All.SendAsync("LeagueUpdated", value);
        }

        // DELETE api/<LeagueController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var leagueToDelete = LeagueLogic.Read(id);
            LeagueLogic.Delete(id);
            Hub.Clients.All.SendAsync("LeagueDeleted", leagueToDelete);
        }
    }
}
