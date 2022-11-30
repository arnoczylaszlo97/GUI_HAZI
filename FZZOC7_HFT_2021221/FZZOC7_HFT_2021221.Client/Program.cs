using ConsoleTools;
using FZZOC7_HFT_2021221.Data;
using FZZOC7_HFT_2021221.Logic;
using FZZOC7_HFT_2021221.Models;
using FZZOC7_HFT_2021221.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;

namespace FZZOC7_HFT_2021221.Client
{
    static class Extension
    {
        public static void ToProcess<T>(this IEnumerable<T> query, string headline)
        {
            Console.WriteLine($"\n:: {headline} ::\n");

            foreach (var item in query)
                Console.WriteLine("\t" + item);

            Console.WriteLine("\n\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(8000);

            RestService rserv = new RestService("http://localhost:4894");

            var menu = new ConsoleMenu().
                 Add("Player CRUD", () => PlayerSubMenu(rserv)).
                 Add("Club CRUD", () => ClubSubMenu(rserv)).
                 Add("League CRUD", () => LeagueSubMenu(rserv)).
                 Add("non-CRUD", () => NonCrudSubMenu(rserv)).
                 Add("Exit", ConsoleMenu.Close);
            menu.Show();

        }

        private static void PlayerSubMenu(RestService rserv)
        {
            var subMenu = new ConsoleMenu().
                Add("Create new Player", () => CreatePlayer(rserv)).
                Add("Update Player", () => UpdatePlayer(rserv)).
                Add("Delete Player", () => DeletePlayer(rserv)).
                Add("ReadAll Player", () => ReadAllPlayer(rserv)).
                Add("Read Player", () => ReadPlayer(rserv)).
                Add("Back", ConsoleMenu.Close).
                Configure(config =>
                {
                    config.Selector = "--> ";
                });
            subMenu.Show();
        }

        #region Player CRUD
        private static void CreatePlayer(RestService rserv)
        {
            rserv.Post<Player>(new Player()
            {
                Player_Name = "Dibusz Dénes",
                Nationality = "Hungary",
                Club_ID = 1,
                Position = "Goalkeeper",
                Wage = 5000,
            }, "player");
            Console.WriteLine("Dibusz Dénes created!");
            Console.ReadLine();
        }

        private static void UpdatePlayer(RestService rserv)
        {
            Player testPlayer = new Player()
            {
                Player_ID = 10,
                Player_Name = "Dibusz Dénes",
                Nationality = "Hungary",
                Club_ID = 2,
                Position = "Goalkeeper",
                Wage = 10000
            };

            rserv.Put(testPlayer, "player");

            Console.WriteLine("Dibusz Dénes updated");

            Console.ReadLine();
        }

        private static void DeletePlayer(RestService rserv)
        {
            rserv.Delete(rserv.Get<Player>("player").Count, "player");

            Console.WriteLine("Player deleted");
            Console.ReadLine();
        }

        private static void ReadAllPlayer(RestService rserv)
        {
            var players = rserv.Get<Player>("player");
            Console.WriteLine("Players:\n");
            foreach (var item in players)
            {
                Console.WriteLine($"{item.Player_Name}");
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void ReadPlayer(RestService rserv)
        {
            Console.WriteLine("GET SINGLE PLAYER");
            Console.WriteLine(rserv.GetSingle<Player>(1, "player").Player_Name.ToString());
            Console.WriteLine();
            Console.ReadLine();
        }
        #endregion

        private static void ClubSubMenu(RestService rserv)
        {
            var subMenu = new ConsoleMenu().
                Add("Create new Club", () => CreateClub(rserv)).
                Add("Update Club", () => UpdateClub(rserv)).
                Add("Delete Club", () => DeleteClub(rserv)).
                Add("ReadAll Club", () => ReadAllClub(rserv)).
                Add("Read Club", () => ReadClub(rserv)).
                Add("Back", ConsoleMenu.Close).
                Configure(config =>
                {
                    config.Selector = "--> ";
                });
            subMenu.Show();
        }

        #region Club CRUD
        private static void CreateClub(RestService rserv)
        {
            rserv.Post<Club>(new Club()
            {
                //Club_ID = 1000,
                Club_Name = "Ferencváros",
                League_ID = 1,
                Manager = "Peter Ströger",
                Owner = "Kubatov Gábor",
                Players = null,
                Value = 1000000
            }, "club");

            Console.WriteLine("Club created");
            Console.ReadLine();
        }

        private static void UpdateClub(RestService rserv)
        {
            Club testClub = new Club()
            {
                Club_ID = 1,
                Club_Name = "Ferencvárosi Torna Klub",
                League_ID = 1,
                Manager = "Gera Zoltán",
                Owner = "Kubatov Gábor",
                Players = null,
                Value = 10000
            };

            rserv.Put(testClub, "club");

            Console.WriteLine("Club updated");
            Console.ReadLine();
        }

        //HIBA
        private static void DeleteClub(RestService rserv)
        {
            rserv.Delete(rserv.Get<Club>("club").Count, "club");
            Console.WriteLine("Club deleted");
            Console.ReadLine();
        }

        private static void ReadAllClub(RestService rserv)
        {
            var clubs = rserv.Get<Club>("club");
            Console.WriteLine("Clubs:\n");
            foreach (var item in clubs)
            {
                Console.WriteLine($"{item.Club_Name}");
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void ReadClub(RestService rserv)
        {
            Console.WriteLine("GET SINGLE CLUB");
            Console.WriteLine(rserv.GetSingle<Club>(1, "club").Club_Name.ToString());
            Console.WriteLine();
            Console.ReadLine();
        }
        #endregion

        private static void LeagueSubMenu(RestService rserv)
        {
            var subMenu = new ConsoleMenu().
                Add("Create new League", () => CreateLeague(rserv)).
                Add("Update League", () => UpdateLeague(rserv)).
                Add("Delete League", () => DeleteLeague(rserv)).
                Add("ReadAll League", () => ReadAllLeague(rserv)).
                Add("Read League", () => ReadLeague(rserv)).
                Add("Back", ConsoleMenu.Close).
                Configure(config =>
                {
                    config.Selector = "--> ";
                });
            subMenu.Show();
        }

        #region League CRUD
        private static void CreateLeague(RestService rserv)
        {
            rserv.Post<League>(new League()
            {
                //League_ID = "ASD",
                League_Name = "ASDASD",
                Nation = "Hungary",
                CL_Places = 1,
                Clubs = null
            }, "league");
            Console.WriteLine("League created");
            Console.ReadLine();
        }

        private static void UpdateLeague(RestService rserv)
        {
            League testLeague = new League()
            {
                //League_ID = "LL",
                CL_Places = 0,
                Nation = "Russia",
                Clubs = null
            };

            rserv.Put(testLeague, "league");
            Console.WriteLine("League updated");
            Console.ReadLine();
        }

        private static void DeleteLeague(RestService rserv)
        {
            rserv.Delete(rserv.Get<League>("league").Count, "league");
            Console.WriteLine("League deleted");
            Console.ReadLine();
        }

        private static void ReadAllLeague(RestService rserv)
        {
            var leagues = rserv.Get<League>("league");
            Console.WriteLine("Leagues:\n");
            foreach (var item in leagues)
            {
                Console.WriteLine($"{item.League_Name}");
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void ReadLeague(RestService rserv)
        {
            Console.WriteLine("GET SINGLE LEAGUE:");
            Console.WriteLine(rserv.GetSingle<League>(1, "league").League_Name.ToString(), "league/pl");
            Console.WriteLine();
            Console.ReadLine();
        }
        #endregion

        private static void NonCrudSubMenu(RestService rserv)
        {
            var subMenu = new ConsoleMenu().
                Add("List PL players", () => PLPlayers(rserv)).
                Add("League players that are loyal to their country", () => NationLoyalPlayers(rserv)).
                Add("List league values", () => LeagueValues(rserv)).
                Add("List the best paid player by clubs", () => BestPaidPlayersByClubs(rserv)).
                Add("List strikers by clubs", () => StrikersByClubs(rserv)).
                Add("Back", ConsoleMenu.Close).
                Configure(config =>
                {
                    config.Selector = "--> ";
                });
            subMenu.Show();
        }

        #region Non-CRUD
        private static void PLPlayers(RestService rserv)
        {
            var plPlayers = rserv.Get<Player>("stat/plplayers");
            Console.WriteLine("List of Premier League players:\n");
            foreach (var item in plPlayers)
            {
                Console.WriteLine($"{item.Player_Name}");
            }
            Console.ReadLine();
        }

        private static void NationLoyalPlayers(RestService rserv)
        {
            var nationLoyalPlayers = rserv.Get<Player>("stat/nationloyalplayers");
            Console.WriteLine("\nList of players, that play in their home country:\n");

            foreach (var item in nationLoyalPlayers)
            {
                Console.WriteLine($"{item.Player_Name}");
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void LeagueValues(RestService rserv)
        {
            var leagueValues = rserv.Get<KeyValuePair<string, long>>("stat/leaguevalues");
            Console.WriteLine("Value of leagues:\n");
            foreach (var item in leagueValues)
            {
                Console.WriteLine($"{item.Key} value: {item.Value}");
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void BestPaidPlayersByClubs(RestService rserv)
        {
            var bestPaidPlayersByClubs = rserv.Get<KeyValuePair<string, Player>>("stat/bestpaidplayersbyclubs");
            Console.WriteLine("List of the best paid players by clubs:\n");
            foreach (var item in bestPaidPlayersByClubs)
            {
                if (item.Value != null)
                {
                    Console.WriteLine($"The most paid {item.Key} player is {item.Value.Player_Name}, he earns {item.Value.Wage}EUR/month");
                }
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void StrikersByClubs(RestService rserv)
        {
            var strikersByClubs = rserv.Get<KeyValuePair<string, IEnumerable<Player>>>("stat/strikersbyclubs");
            Console.WriteLine("Strikers list by clubs:\n");
            foreach (var item in strikersByClubs)
            {
                Console.Write($"{item.Key}: ");
                foreach (var items in item.Value)
                {
                    Console.Write($"{items.Player_Name}     ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        #endregion
    }

}
