using FZZOC7_HFT_2021221.Data;
using FZZOC7_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FZZOC7_HFT_2021221.Repository
{
    public class LeagueRepository : ILeagueRepository
    {
        FootballDbContext Context;

        public LeagueRepository(FootballDbContext context)
        {
            Context = context;
        }

        public void Create(League league)
        {
            Context.Leagues.Add(league);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            League league = Context.Leagues.FirstOrDefault(l => l.League_ID == id);
            Context.Leagues.Remove(league);
            Context.SaveChanges();
        }

        public IQueryable<League> ReadAll()
        {
            return Context.Leagues;
        }

        public League Read(int id)
        {
            return Context.Leagues.FirstOrDefault(l => l.League_ID == id);
        }

        public void Update(League league)
        {
            League old = Read(league.League_ID);
            ;
            old.Clubs = league.Clubs;
            old.CL_Places = league.CL_Places;
            old.League_ID = league.League_ID;
            old.Nation = league.Nation;
            Context.SaveChanges();
        }
    }
}
