using FZZOC7_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FZZOC7_HFT_2021221.Repository
{
    public interface ILeagueRepository
    {
        void Create(League league);
        League Read(int id);
        IQueryable<League> ReadAll();
        void Update(League league);
        void Delete(int id);
    }
}
