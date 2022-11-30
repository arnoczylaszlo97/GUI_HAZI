using FZZOC7_HFT_2021221.Data;
using FZZOC7_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FZZOC7_HFT_2021221.Repository
{
    public class ClubRepository : IClubRepository
    {
        FootballDbContext Context;

        public ClubRepository(FootballDbContext context)
        {
            Context = context;
        }

        public void Create(Club club)
        {
            Context.Clubs.Add(club);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Club club = Context.Clubs.FirstOrDefault(c => c.Club_ID == id);
            Context.Clubs.Remove(club);
            Context.SaveChanges();
        }

        public Club Read(int id)
        {
            return Context.Clubs.FirstOrDefault(c => c.Club_ID == id);
        }

        public IQueryable<Club> ReadAll()
        {
            return Context.Clubs;
        }

        public void Update(Club club)
        {
            Club old = Read(club.Club_ID);
            old.Club_Name = club.Club_Name;
            old.League_ID = club.League_ID;
            old.Manager = club.Manager;
            old.Owner = club.Owner;
            old.Players = club.Players;
            old.Value = club.Value;
            Context.SaveChanges();
        }
    }
}
