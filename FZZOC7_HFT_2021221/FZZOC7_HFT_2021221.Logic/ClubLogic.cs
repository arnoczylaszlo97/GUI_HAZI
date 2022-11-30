using FZZOC7_HFT_2021221.Models;
using FZZOC7_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FZZOC7_HFT_2021221.Logic
{
    public class ClubLogic : IClubLogic
    {
        IClubRepository ClubRepo;

        public ClubLogic(IClubRepository clubRepo)
        {
            ClubRepo = clubRepo;
        }

        public void Create(Club club)
        {
            //if (club.Club_ID == 0)
            //{
            //    throw new NotImplementedException("Can't create club without ID!");
            //}
            /*else*/ if (club.Club_Name == null)
            {
                throw new NotImplementedException("Can't create club without name!");
            }
            else if (club.League_ID == 0)
            {
                throw new NotImplementedException("Can't create club without league!");
            }
            ClubRepo.Create(club);
        }

        public void Delete(int id)
        {
            ClubRepo.Delete(id);
        }

        public Club Read(int id)
        {
            return ClubRepo.Read(id);
        }

        public IQueryable<Club> ReadAll()
        {
            return ClubRepo.ReadAll();
        }

        public void Update(Club club)
        {
            ClubRepo.Update(club);
        }

        public IEnumerable<KeyValuePair<string, long>> LeagueValues()
        {
            var q = ReadAll()
               .GroupBy(c => c.League.League_Name)
               .Select(c => new KeyValuePair<string, long>(c.Key, c.Sum(l => l.Value)));

            return q;         
        }

        public IEnumerable<KeyValuePair<string, Player>> BestPaidPlayersByClubs()
        {
            var q = ReadAll()
                .Select(x => new KeyValuePair<string, Player>(x.Club_Name, x.Players
                .OrderByDescending(x => x.Wage)
                .FirstOrDefault()));

            return q;
        }

        public IEnumerable<KeyValuePair<string, IEnumerable<Player>>> StrikersByClubs()
        {
            var q = ReadAll()
                .Select(x => new KeyValuePair<string, IEnumerable<Player>>(x.Club_Name, x.Players
                .Where(x => x.Position == "Striker")));

            return q;
        }
    }
}
