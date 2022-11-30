using FZZOC7_HFT_2021221.Models;
using FZZOC7_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FZZOC7_HFT_2021221.Logic
{
    public class PlayerLogic : IPlayerLogic
    {
        IPlayerRepository PlayerRepo;

        public PlayerLogic(IPlayerRepository playerRepo)
        {
            PlayerRepo = playerRepo;
        }

        public void Create(Player player)
        {
            if (player.Player_Name == null)
            {
                throw new NotImplementedException("Can't create player without name!");
            }
            else if (player.Nationality == null)
            {
                throw new NotImplementedException("Can't create player without nationality!");
            }
            PlayerRepo.Create(player);
        }

        public void Delete(int id)
        {
            PlayerRepo.Delete(id);
        }

        public Player Read(int id)
        {
            return PlayerRepo.Read(id);
        }

        public IQueryable<Player> ReadAll()
        {
            return PlayerRepo.ReadAll();
        }

        public void Update(Player player)
        {
            PlayerRepo.Update(player);
        }

        public IEnumerable<Player> PLPlayers()
        {
            var q = ReadAll()
                .Select(p => p)
                .Where(p => p.Club.League_ID == 1)
                .OrderBy(p =>p.Player_Name)
                .ToList();

            return q;
        }

        public IEnumerable<Player> NationLoyalPlayers()
        {
            var q = ReadAll()
                .Select(p => p)
                .Where(p => p.Nationality == p.Club.League.Nation);

            return q;
        }

    }
}
