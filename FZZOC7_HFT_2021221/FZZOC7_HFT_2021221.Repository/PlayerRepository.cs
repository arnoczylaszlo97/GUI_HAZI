using FZZOC7_HFT_2021221.Data;
using FZZOC7_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FZZOC7_HFT_2021221.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        FootballDbContext Context;

        public PlayerRepository(FootballDbContext context)
        {
            Context = context;
        }

        public void Create(Player player)
        {
            Context.Players.Add(player);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Player player = Context.Players.FirstOrDefault(p => p.Player_ID == id);
            Context.Players.Remove(player);
            Context.SaveChanges();
        }

        public Player Read(int id)
        {
            return Context.Players.FirstOrDefault(p => p.Player_ID == id);
        }

        public IQueryable<Player> ReadAll()
        {
            return Context.Players;
        }

        public void Update(Player player)
        {
            Player old = Read(player.Player_ID);
            old.Club_ID = player.Club_ID;
            old.Nationality = player.Nationality;
            old.Player_Name = player.Player_Name;
            old.Position = player.Position;
            old.Wage = player.Wage;
            Context.SaveChanges();
        }
    }
}
