using FZZOC7_HFT_2021221.Models;
using FZZOC7_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FZZOC7_HFT_2021221.Logic
{
    public class LeagueLogic : ILeagueLogic
    {
        ILeagueRepository LeagueRepo;

        public LeagueLogic(ILeagueRepository leagueRepo)
        {
            LeagueRepo = leagueRepo;
        }

        public void Create(League league)
        {
            //if (league.League_ID == 0)
            //{
            //    throw new NotImplementedException("Can't create league without ID!");
            //}
            /*else */
            if (league.League_Name == null)
            {
                throw new NotImplementedException("Can't create league without name!");
            }
            else if (league.Nation == null)
            {
                throw new NotImplementedException("Can't create league without nation!");
            }
            LeagueRepo.Create(league);
        }

        public void Delete(int id)
        {
            LeagueRepo.Delete(id);
        }

        public League Read(int id)
        {
            return LeagueRepo.Read(id);
        }

        public IQueryable<League> ReadAll()
        {
            return LeagueRepo.ReadAll();
        }

        public void Update(League league)
        {
            LeagueRepo.Update(league);
        }

    }
}
