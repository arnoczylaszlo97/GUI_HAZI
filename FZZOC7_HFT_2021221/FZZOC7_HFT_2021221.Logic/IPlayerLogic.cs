using FZZOC7_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FZZOC7_HFT_2021221.Logic
{
    public interface IPlayerLogic
    {
        void Create(Player player);
        Player Read(int id);
        IQueryable<Player> ReadAll();
        void Update(Player player);
        void Delete(int id);
        IEnumerable<Player> PLPlayers();
        IEnumerable<Player> NationLoyalPlayers();

    }
}
