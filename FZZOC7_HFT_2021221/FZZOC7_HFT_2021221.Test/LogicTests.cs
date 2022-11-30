using FZZOC7_HFT_2021221.Logic;
using FZZOC7_HFT_2021221.Models;
using FZZOC7_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;

namespace FZZOC7_HFT_2021221.Test
{
    [TestFixture]
    public class LogicTests
    {
        private PlayerLogic PlayerLogic { get; set; }
        private ClubLogic ClubLogic { get; set; }
        private LeagueLogic LeagueLogic { get; set; }

        [SetUp]
        public void Setup()
        {
            Mock<IPlayerRepository> mockedPlayerRepo = new Mock<IPlayerRepository>();
            Mock<IClubRepository> mockedClubRepo = new Mock<IClubRepository>();
            Mock<ILeagueRepository> mockedLeagueRepo = new Mock<ILeagueRepository>();


            mockedPlayerRepo.Setup(x => x.Create(It.IsAny<Player>()));
            mockedClubRepo.Setup(x => x.Create(It.IsAny<Club>()));
            mockedLeagueRepo.Setup(x => x.Create(It.IsAny<League>()));


            mockedPlayerRepo.Setup(x => x.ReadAll()).Returns(FakePlayerObjects);
            mockedClubRepo.Setup(x => x.ReadAll()).Returns(FakeClubObjects);
            mockedLeagueRepo.Setup(x => x.ReadAll()).Returns(FakeLeagueObjects);

            mockedPlayerRepo.Setup(x => x.Update(It.IsAny<Player>()));

            mockedPlayerRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(new Player()
            {
                Player_ID = 1,
                Player_Name = "Moussa Dembélé",
                Wage = 55000,
                Nationality = "France",
                Position = "Striker"
            });

            PlayerLogic = new PlayerLogic(mockedPlayerRepo.Object);
            ClubLogic = new ClubLogic(mockedClubRepo.Object);
            LeagueLogic = new LeagueLogic(mockedLeagueRepo.Object);
        }

        [Test]
        public void LeagueValuesTest()
        {
            var res = ClubLogic.LeagueValues();
            Assert.That(res.First().Value == 1340000000 && res.Count() == 2);
        }

        [Test]
        public void BestPaidPlayersByClubsTest()
        {
            var res = ClubLogic.BestPaidPlayersByClubs();
            Assert.That(res.First().Value.Player_Name == "Mohamed Salah" && res.Count() == 2);
        }

        [Test]
        public void StrikersByClubsTest()
        {
            var res = ClubLogic.StrikersByClubs();
            Assert.That(res.FirstOrDefault().Value.FirstOrDefault().Player_Name == "Mohamed Salah" && res.Count() == 2);
        }

        [Test]
        public void PLPlayersTest()
        {
            var res = PlayerLogic.PLPlayers();
            Assert.That(res.First().Player_Name == "Mohamed Salah" && res.Count() == 2);
        }

        [Test]
        public void NationLoyalPlayersTest()
        {
            var res = PlayerLogic.NationLoyalPlayers();
            Assert.That(res.First().Player_Name == "Trent-Alexander Arnold" && res.Count() == 2);
        }

        [Test]
        [TestCase(1, null, 15, "Brazil", "Hátvéd", 80, 1)]
        [TestCase(2, "Közepes Csaba", 10, null, "Kapus", 81, 2)]
        [TestCase(3, "Nagy Csaba", 20, "Magyar", "Középpályás", 82, 3)]
        public void PlayerCreateTest(int player_ID, string player_Name, int wage, string nationality, string position, int club_ID, int testnum)
        {
            if (testnum == 0)
            {
                Assert.That(() => PlayerLogic.Create(new Player()
                {
                    Player_ID = player_ID,
                    Player_Name = player_Name,
                    Wage = wage,
                    Nationality = nationality,
                    Position = position,
                    Club_ID = club_ID,
                }), Throws.Exception);
            }

            else if (testnum == 1)
            {
                Assert.That(() => PlayerLogic.Create(new Player()
                {
                    Player_ID = player_ID,
                    Player_Name = player_Name,
                    Wage = wage,
                    Nationality = nationality,
                    Position = position,
                    Club_ID = club_ID,
                }), Throws.Exception);
            }

            else if (testnum == 2)
            {
                Assert.That(() => PlayerLogic.Create(new Player()
                {
                    Player_ID = player_ID,
                    Player_Name = player_Name,
                    Wage = wage,
                    Nationality = nationality,
                    Position = position,
                    Club_ID = club_ID,
                }), Throws.Exception);
            }

            else if (testnum == 3)
            {
                Assert.That(() => PlayerLogic.Create(new Player()
                {
                    Player_ID = player_ID,
                    Player_Name = player_Name,
                    Wage = wage,
                    Nationality = nationality,
                    Position = position,
                    Club_ID = club_ID,
                }), Throws.Nothing);
            }
        }

        [Test]
        [TestCase(103, "Gyirmót FC", 100, "Horváth Ferenc", "Csertői Aurél", 10, 0)]
        [TestCase(100, null, 10000, "Kubatov Gábor", "Peter Ströger", 10, 1)]
        [TestCase(101, "Újpest FC", 500, "Roderick Duchatelet", "Michael Oenning", 0, 2)]
        [TestCase(102, "Debreceni VSC", 40, "Szima Gábor", "Tímár Krisztián", 11, 3)]
        public void ClubCreateTest(int club_ID, string club_Name, int value, string owner, string manager, int league_ID, int testnum)
        {
            if (testnum == 0)
            {
                Assert.That((TestDelegate)(() => ClubLogic.Create(new Club()
                {
                    Club_ID = club_ID,
                    Club_Name = club_Name,
                    Value = (uint)value,
                    Owner = owner,
                    Manager = manager,
                    League_ID = league_ID,
                })), Throws.Exception);
            }

            else if (testnum == 1)
            {
                Assert.That((TestDelegate)(() => ClubLogic.Create(new Club()
                {
                    Club_ID = club_ID,
                    Club_Name = club_Name,
                    Value = (uint)value,
                    Owner = owner,
                    Manager = manager,
                    League_ID = league_ID,
                })), Throws.Exception);
            }

            else if (testnum == 2)
            {
                Assert.That((TestDelegate)(() => ClubLogic.Create(new Club()
                {
                    Club_ID = club_ID,
                    Club_Name = club_Name,
                    Value = (uint)value,
                    Owner = owner,
                    Manager = manager,
                    League_ID = league_ID,
                })), Throws.Exception);
            }

            else if(testnum == 3)
            {
                Assert.That((TestDelegate)(() => ClubLogic.Create(new Club()
                {
                    Club_ID = club_ID,
                    Club_Name = club_Name,
                    Value = (uint)value,
                    Owner = owner,
                    Manager = manager,
                    League_ID = league_ID,
                })), Throws.Nothing);
            }
        }

        [Test]
        [TestCase(10, "Merkantil Bank Liga", null, 0, 0)]
        [TestCase(13, null, "Magyar", 0, 1)]
        [TestCase(16, "Megye 2", "Magyar", 0, 2)]
        [TestCase(10, "OTP Bank Liga", "Magyar", 1, 3)]
        public void LeagueCreateTest(int league_ID, string league_Name, string nation, int cl_places, int testnum)
        {
            if (testnum == 0)
            {
                Assert.That(() => LeagueLogic.Create(new League()
                {
                    League_ID = league_ID,
                    League_Name = league_Name,
                    Nation = nation,
                    CL_Places = cl_places,
                }), Throws.Exception);
            }

            else if (testnum == 1)
            {
                Assert.That(() => LeagueLogic.Create(new League()
                {
                    League_ID = league_ID,
                    League_Name = league_Name,
                    Nation = nation,
                    CL_Places = cl_places,
                }), Throws.Exception);
            }

            else if (testnum == 2)
            {
                Assert.That(() => LeagueLogic.Create(new League()
                {
                    League_ID = league_ID,
                    League_Name = league_Name,
                    Nation = nation,
                    CL_Places = cl_places,
                }), Throws.Exception);
            }

            else if (testnum == 3)
            {
                Assert.That(() => LeagueLogic.Create(new League()
                {
                    League_ID = league_ID,
                    League_Name = league_Name,
                    Nation = nation,
                    CL_Places = cl_places,
                }), Throws.Nothing);
            }
        }

        [Test]
        public void PlayerReadTest()
        {
            var res = PlayerLogic.ReadAll();
            Assert.That(res.Last().Player_Name == "Pau López" && res.Count() == 3);
        }

        [Test]
        public void PlayerUpdateTest()
        {
            Player p = new Player()
            { Player_ID = 1,
              Player_Name = "Moussa Dembélé",
              Wage = 55000, 
              Nationality = "France", 
              Position = "Striker" 
            };

            PlayerLogic.Update(p);
            Assert.That(PlayerLogic.Read(p.Player_ID).Player_Name == "Moussa Dembélé");
        }

        private IQueryable<League> FakeLeagueObjects()
        {
            League l1 = new League()
            {
                League_ID = 1,
                League_Name = "Premier League",
                CL_Places = 3,
                Nation = "England",
                Clubs = new List<Club>()
            };

            Club c1 = new Club()
            {
                Club_ID = 1,
                Club_Name = "Liverpool",
                League_ID = l1.League_ID,
                League = l1,
                Manager = "Jurgen Klopp",
                Owner = "John William Henry II",
                Value = 1340000000,
                Players = new List<Player>()
            };

            Player p1 = new Player()
            {
                Player_ID = 1,
                Player_Name = "Mohamed Salah",
                Position = "Striker",
                Nationality = "Egyipt",
                Wage = 200000,
                Club = c1,
                Club_ID = c1.Club_ID
            };

            l1.Clubs.Add(c1);

            c1.Players.Add(p1);

            List<League> leagues = new List<League>();

            leagues.Add(l1);

            return leagues.AsQueryable();
        }

        private IQueryable<Club> FakeClubObjects()
        {
            League l1 = new League()
            {
                League_ID = 1,
                League_Name = "Premier League",
                CL_Places = 3,
                Nation = "England",
                Clubs = new List<Club>()
            };

            League l2 = new League()
            {
                League_ID = 3,
                League_Name = "LaLiga",
                CL_Places = 4,
                Nation = "Spain",
                Clubs = new List<Club>()
            };

            Club c1 = new Club()
            {
                Club_ID = 1,
                Club_Name = "Liverpool",
                League_ID = l1.League_ID,
                League = l1,
                Manager = "Jurgen Klopp",
                Owner = "John William Henry II",
                Value = 1340000000,
                Players = new List<Player>()
            };

            Club c2 = new Club()
            {
                Club_ID = 12,
                Club_Name = "Sevilla",
                League_ID = l2.League_ID,
                League = l2,
                Manager = "Julen Lopetegui",
                Owner = "José Castro Carmona",
                Value = 316000000,
                Players = new List<Player>()
            };

            Player p1 = new Player()
            {
                Player_ID = 1,
                Player_Name = "Mohamed Salah",
                Position = "Striker",
                Nationality = "Egyipt",
                Wage = 200000,
                Club = c1,
                Club_ID = c1.Club_ID
            };

            Player p2 = new Player()
            {
                Player_ID = 2,
                Player_Name = "Trent-Alexander Arnold",
                Position = "Left-back",
                Nationality = "England",
                Wage = 100000,
                Club = c1,
                Club_ID = c1.Club_ID
            };

            Player p3 = new Player()
            {
                Player_ID = 2,
                Player_Name = "Pau López",
                Position = "Goalkeeper",
                Nationality = "Spain",
                Wage = 79000,
                Club = c2,
                Club_ID = c2.Club_ID
            };

            l1.Clubs.Add(c1);
            l2.Clubs.Add(c2);

            c1.Players.Add(p1);
            c1.Players.Add(p2);
            c2.Players.Add(p3);

            List<Club> clubs = new List<Club>();

            clubs.Add(c1);
            clubs.Add(c2);

            return clubs.AsQueryable();
        }

        private IQueryable<Player> FakePlayerObjects()
        {
            League l1 = new League()
            {
                League_ID = 1,
                League_Name = "Premier League",
                CL_Places = 3,
                Nation = "England",
                Clubs = new List<Club>()
            };

            League l2 = new League()
            {
                League_ID = 3,
                League_Name = "LaLiga",
                CL_Places = 4,
                Nation = "Spain",
                Clubs = new List<Club>()
            };

            Club c1 = new Club()
            {
                Club_ID = 1,
                Club_Name = "Liverpool",
                League_ID = l1.League_ID,
                League = l1,
                Manager = "Jurgen Klopp",
                Owner = "John William Henry II",
                Value = 1340000000,
                Players = new List<Player>()
            };

            Club c2 = new Club()
            {
                Club_ID = 12,
                Club_Name = "Sevilla",
                League_ID = l2.League_ID,
                League = l2,
                Manager = "Julen Lopetegui",
                Owner = "José Castro Carmona",
                Value = 316000000,
                Players = new List<Player>()
            };

            Player p1 = new Player()
            {
                Player_ID = 1,
                Player_Name = "Mohamed Salah",
                Position = "Striker",
                Nationality = "Egyipt",
                Wage = 200000,
                Club = c1,
                Club_ID = c1.Club_ID
            };

            Player p2 = new Player()
            {
                Player_ID = 2,
                Player_Name = "Trent-Alexander Arnold",
                Position = "Left-back",
                Nationality = "England",
                Wage = 100000,
                Club = c1,
                Club_ID = c1.Club_ID
            };

            Player p3 = new Player()
            {
                Player_ID = 2,
                Player_Name = "Pau López",
                Position = "Goalkeeper",
                Nationality = "Spain",
                Wage = 79000,
                Club = c2,
                Club_ID = c2.Club_ID
            };

            l1.Clubs.Add(c1);
            l2.Clubs.Add(c2);

            c1.Players.Add(p1);
            c1.Players.Add(p2);
            c2.Players.Add(p3);

            List<Player> players = new List<Player>();

            players.Add(p1);
            players.Add(p2);
            players.Add(p3);

            return players.AsQueryable();
        }
    }
}
