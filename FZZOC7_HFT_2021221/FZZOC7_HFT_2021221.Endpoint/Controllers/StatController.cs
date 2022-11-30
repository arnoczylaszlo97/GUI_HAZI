using FZZOC7_HFT_2021221.Logic;
using FZZOC7_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FZZOC7_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IPlayerLogic PlayerLogic;
        IClubLogic ClubLogic;

        public StatController(IPlayerLogic playerLogic, IClubLogic clubLogic)
        {
            PlayerLogic = playerLogic;
            ClubLogic = clubLogic;
        }

        // GET: stat/PLPlayers
        [HttpGet]
        public IEnumerable<Player> PLPlayers()
        {
            return PlayerLogic.PLPlayers();
        }

        // GET: stat/NationLoyalPlayers
        [HttpGet]
        public IEnumerable<Player> NationLoyalPlayers()
        {
            return PlayerLogic.NationLoyalPlayers();
        }

        // GET: stat/LeagueValues
        [HttpGet]
        public IEnumerable<KeyValuePair<string, long>> LeagueValues()
        {
            return ClubLogic.LeagueValues();
        }

        // GET: stat/BestPaidPlayersByClubs
        [HttpGet]
        public IEnumerable<KeyValuePair<string, Player>> BestPaidPlayersByClubs()
        {
            return ClubLogic.BestPaidPlayersByClubs();
        }

        // GET: stat/StrikersByClubs
        [HttpGet]
        public IEnumerable<KeyValuePair<string, IEnumerable<Player>>> StrikersByClubs()
        {
            return ClubLogic.StrikersByClubs();
        }
    }
}
