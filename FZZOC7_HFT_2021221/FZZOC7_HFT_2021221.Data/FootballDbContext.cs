using FZZOC7_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FZZOC7_HFT_2021221.Data
{
    public class FootballDbContext : DbContext
    {
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Player> Players { get; set; }

        public FootballDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Leagues

            League l1 = new() {League_ID = 1, League_Name = "Premier League", Nation = "England", CL_Places = 4};
            League l2 = new() {League_ID = 2, League_Name = "Bundesliga", Nation = "Germany", CL_Places = 4};
            League l3 = new() {League_ID = 3, League_Name = "LaLiga", Nation = "Spain", CL_Places = 4};
            League l4 = new() {League_ID = 4, League_Name = "Serie A", Nation = "Italy", CL_Places = 4};
            League l5 = new() {League_ID = 5, League_Name = "Ligue 1", Nation = "France", CL_Places = 3};

            #endregion

            #region Clubs

            Club c1 = new() { Club_ID = 1, Club_Name = "Liverpool", Value = 1340000000, Owner = "John William Henry II", Manager = "Jürgen Klopp" };
            Club c2 = new() { Club_ID = 2, Club_Name = "Chelsea", Value = 2130000000, Owner = "Roman Abramovich", Manager = "Thomas Tuchel" };
            Club c3 = new() { Club_ID = 3, Club_Name = "Manchester City", Value = 1410000000, Owner = "Sheikh Mansour", Manager = "Pep Guardiola" };
            Club c4 = new() { Club_ID = 4, Club_Name = "Manchester United", Value = 4120000000, Owner = "Joel Glazer", Manager = "Ole Gunnar Solskjaer" };
            Club c5 = new() { Club_ID = 5, Club_Name = "Arsenal", Value = 1450000000, Owner = "Stan Kroenke", Manager = "Mikel Arteta" };
            Club c6 = new() { Club_ID = 6, Club_Name = "Bayern München", Value = 1470000000, Owner = "Herbert Hainer", Manager = "Julian Nagelsmann" };
            Club c7 = new() { Club_ID = 7, Club_Name = "Borussia Dortmund", Value = 896000000, Owner = "Reinhard Rauball", Manager = "Marco Rose" };
            Club c8 = new() { Club_ID = 8, Club_Name = "RB Leipzig", Value = 561000000, Owner = "Oliver Mintzlaff", Manager = "Jesse Marsch" };
            Club c9 = new() { Club_ID = 9, Club_Name = "Barcelona", Value = 4060000000, Owner = "Josep Maria Bartomeu Floreta", Manager = "Ronald Koeman" };
            Club c10 = new() { Club_ID = 10, Club_Name = "Real Madrid", Value = 1270000000, Owner = "Florentino Perez", Manager = "Carlo Ancelotti" };
            Club c11 = new() { Club_ID = 11, Club_Name = "Atletico Madrid", Value = 732000000, Owner = "Enrique Cerezo", Manager = "Diego Simeone" };
            Club c12 = new() { Club_ID = 12, Club_Name = "Sevilla", Value = 316000000, Owner = "José Castro Carmona", Manager = "Julen Lopetegui" };
            Club c13 = new() { Club_ID = 13, Club_Name = "AS Roma", Value = 405000000, Owner = "Dan Friedkin", Manager = "José Mourinho" };
            Club c14 = new() { Club_ID = 14, Club_Name = "Juventus", Value = 1510000000, Owner = "Andrea Agnelli", Manager = "Massimiliano Allegri" };
            Club c15 = new() { Club_ID = 15, Club_Name = "Inter", Value = 685000000, Owner = "Steven Zhang", Manager = "Simone Inzaghi" };
            Club c16 = new() { Club_ID = 16, Club_Name = "Napoli", Value = 379000000, Owner = "Aurelio De Laurentiis", Manager = "Luciano Spalletti" };
            Club c17 = new() { Club_ID = 17, Club_Name = "AC Milan", Value = 583000000, Owner = "Paolo Scaroni", Manager = "Stefano Pioli" };
            Club c18 = new() { Club_ID = 18, Club_Name = "Paris Saint-Germain", Value = 998000000, Owner = "Tamim bin Hamad Al Thani", Manager = "Mauricio Pochettino" };
            Club c19 = new() { Club_ID = 19, Club_Name = "Olympique Marseille", Value = 277000000, Owner = "Pablo Longoria", Manager = "Jorge Sampaoli" };
            Club c20 = new() { Club_ID = 20, Club_Name = "Olympique Lyon", Value = 489000000, Owner = "Jean-Michel Aulas", Manager = "Peter Bosz" };

            c1.League_ID = l1.League_ID;
            c2.League_ID = l1.League_ID;
            c3.League_ID = l1.League_ID;
            c4.League_ID = l1.League_ID;
            c5.League_ID = l1.League_ID;
            c6.League_ID = l2.League_ID;
            c7.League_ID = l2.League_ID;
            c8.League_ID = l2.League_ID;
            c9.League_ID = l3.League_ID;
            c10.League_ID = l3.League_ID;
            c11.League_ID = l3.League_ID;
            c12.League_ID = l3.League_ID;
            c13.League_ID = l4.League_ID;
            c14.League_ID = l4.League_ID;
            c15.League_ID = l4.League_ID;
            c16.League_ID = l4.League_ID;
            c17.League_ID = l4.League_ID;
            c18.League_ID = l5.League_ID;
            c19.League_ID = l5.League_ID;
            c20.League_ID = l5.League_ID;

            #endregion

            #region Players

            Player p1 = new() { Player_ID = 1, Player_Name = "Alisson Becker", Wage = 150000, Nationality = "Brazil", Position = "Goalkeeper" };
            Player p2 = new() { Player_ID = 2, Player_Name = "Trent Alexander-Arnold", Wage = 180000, Nationality = "England", Position = "Right back" };
            Player p3 = new() { Player_ID = 3, Player_Name = "Jordan Henderson", Wage = 140000, Nationality = "England", Position = "Central midfielder" };
            Player p4 = new() { Player_ID = 4, Player_Name = "Mohamed Salah", Wage = 200000, Nationality = "Egypt", Position = "Right winger" };
            Player p5 = new() { Player_ID = 5, Player_Name = "Edouard Mendy", Wage = 52000, Nationality = "France", Position = "Goalkeeper" };
            Player p6 = new() { Player_ID = 6, Player_Name = "César Azpilicueta", Wage = 150000, Nationality = "Spain", Position = "Center back" };
            Player p7 = new() { Player_ID = 7, Player_Name = "N'Golo Kante", Wage = 290000, Nationality = "France", Position = "Central defensive midfielder" };
            Player p8 = new() { Player_ID = 8, Player_Name = "Romelu Lukaku", Wage = 325000, Nationality = "Belgium", Position = "Striker" };
            Player p9 = new() { Player_ID = 9, Player_Name = "Ederson Moraes", Wage = 100000, Nationality = "Brazil", Position = "Goalkeeper" };
            Player p10 = new() { Player_ID = 10, Player_Name = "Ruben Dias", Wage = 115385, Nationality = "Portugal", Position = "Center back" };
            Player p11 = new() { Player_ID = 11, Player_Name = "Kevin De Bruyne", Wage = 400000, Nationality = "Belgium", Position = "Central attacking midfielder" };
            Player p12 = new() { Player_ID = 12, Player_Name = "Jack Grealish", Wage = 300000, Nationality = "England", Position = "Left winger" };
            Player p13 = new() { Player_ID = 13, Player_Name = "David De Gea", Wage = 375000, Nationality = "Spain", Position = "Goalkeeper" };
            Player p14 = new() { Player_ID = 14, Player_Name = "Luke Shaw", Wage = 150000, Nationality = "England", Position = "Left back" };
            Player p15 = new() { Player_ID = 15, Player_Name = "Bruno Fernandes", Wage = 180000, Nationality = "Portugal", Position = "Central attacking midfielder" };
            Player p16 = new() { Player_ID = 16, Player_Name = "Cristiano Ronaldo", Wage = 510000, Nationality = "Portugal", Position = "Striker" };
            Player p17 = new() { Player_ID = 17, Player_Name = "Aaron Ramsdale", Wage = 50000, Nationality = "England", Position = "Goalkeeper" };
            Player p18 = new() { Player_ID = 18, Player_Name = "Ben White", Wage = 120000, Nationality = "England", Position = "Center back" };
            Player p19 = new() { Player_ID = 19, Player_Name = "Emile Smith Rowe", Wage = 20000, Nationality = "England", Position = "Central attacking midfielder" };
            Player p20 = new() { Player_ID = 20, Player_Name = "Bukayo Saka", Wage = 30000, Nationality = "England", Position = "Left winger", };
            Player p21 = new() { Player_ID = 21, Player_Name = "Manuel Neuer", Wage = 316000, Nationality = "Germany", Position = "Goalkeeper" };
            Player p22 = new() { Player_ID = 22, Player_Name = "Lucas Hernández", Wage = 237000, Nationality = "France", Position = "Left back" };
            Player p23 = new() { Player_ID = 23, Player_Name = "Joshua Kimmich", Wage = 175000, Nationality = "Germany", Position = "Central midfielder" };
            Player p24 = new() { Player_ID = 24, Player_Name = "Robert Lewandowski", Wage = 352000, Nationality = "Poland", Position = "Striker" };
            Player p25 = new() { Player_ID = 25, Player_Name = "Roman Bürki", Wage = 59000, Nationality = "Switzerland", Position = "Goalkeeper" };
            Player p26 = new() { Player_ID = 26, Player_Name = "Mats Hummels", Wage = 175000, Nationality = "Germany", Position = "Center back" };
            Player p27 = new() { Player_ID = 27, Player_Name = "Emre Can", Wage = 163000, Nationality = "Germany", Position = "Central defensive midfielder" };
            Player p28 = new() { Player_ID = 28, Player_Name = "Erling Haaland", Wage = 141000, Nationality = "Norway", Position = "Striker" };
            Player p29 = new() { Player_ID = 29, Player_Name = "Péter Gulácsi", Wage = 60000, Nationality = "Hungary", Position = "Goalkeeper" };
            Player p30 = new() { Player_ID = 30, Player_Name = "Willi Orban", Wage = 40000, Nationality = "Hungary", Position = "Center back" };
            Player p31 = new() { Player_ID = 31, Player_Name = "Dominik Szoboszlai", Wage = 43000, Nationality = "Hungary", Position = "Central attacking midfielder" };
            Player p32 = new() { Player_ID = 32, Player_Name = "André Silva", Wage = 282000, Nationality = "Portugal", Position = "Striker" };
            Player p33 = new() { Player_ID = 33, Player_Name = "Marc-André ter Stegen", Wage = 151000, Nationality = "Germany", Position = "Goalkeeper" };
            Player p34 = new() { Player_ID = 34, Player_Name = "Jordi Alba", Wage = 212000, Nationality = "Spain", Position = "Right back" };
            Player p35 = new() { Player_ID = 35, Player_Name = "Sergio Busquets", Wage = 271000, Nationality = "Spain", Position = "Central defensive midfielder" };
            Player p36 = new() { Player_ID = 36, Player_Name = "Memphis Depay", Wage = 350000, Nationality = "Netherlands", Position = "Striker" };
            Player p37 = new() { Player_ID = 37, Player_Name = "Thibaut Courtois", Wage = 271000, Nationality = "Belgium", Position = "Goalkeeper" };
            Player p38 = new() { Player_ID = 38, Player_Name = "Dani Carvajal", Wage = 163000, Nationality = "Spain", Position = "Right back" };
            Player p39 = new() { Player_ID = 39, Player_Name = "Luka Modric", Wage = 294000, Nationality = "Croatia", Position = "Central midfielder" };
            Player p40 = new() { Player_ID = 40, Player_Name = "Karim Benzema", Wage = 294000, Nationality = "France", Position = "Striker" };
            Player p41 = new() { Player_ID = 41, Player_Name = "Jan Oblak", Wage = 271000, Nationality = "Slovenia", Position = "Goalkeeper" };
            Player p42 = new() { Player_ID = 42, Player_Name = "José Giménez", Wage = 88000, Nationality = "Uruguay", Position = "Center back" };
            Player p43 = new() { Player_ID = 43, Player_Name = "Joao Félix", Wage = 165000, Nationality = "Portugal", Position = "Central attacking midfielder" };
            Player p44 = new() { Player_ID = 44, Player_Name = "Luis Suárez", Wage = 281000, Nationality = "Uruguay", Position = "Striker" };
            Player p45 = new() { Player_ID = 45, Player_Name = "Yassine Bounou", Wage = 44000, Nationality = "Morocco", Position = "Goalkeeper" };
            Player p46 = new() { Player_ID = 46, Player_Name = "Jules Koundé", Wage = 73000, Nationality = "France", Position = "Center back" };
            Player p47 = new() { Player_ID = 47, Player_Name = "Ivan Rakitic", Wage = 114000, Nationality = "Croatia", Position = "Central midfielder" };
            Player p48 = new() { Player_ID = 48, Player_Name = "Alejandro Gómez", Wage = 71000, Nationality = "Argentina", Position = "Striker" };
            Player p49 = new() { Player_ID = 49, Player_Name = "Pau López", Wage = 79000, Nationality = "Spain", Position = "Goalkeeper" };
            Player p50 = new() { Player_ID = 50, Player_Name = "Leonardo Spinazzola", Wage = 98000, Nationality = "Italy", Position = "Right back" };
            Player p51 = new() { Player_ID = 51, Player_Name = "Lorenzo Pellegrini", Wage = 116000, Nationality = "Italy", Position = "Central midfielder" };
            Player p52 = new() { Player_ID = 52, Player_Name = "Tammy Abraham", Wage = 130000, Nationality = "England", Position = "Striker" };
            Player p53 = new() { Player_ID = 53, Player_Name = "Wojciech Szczesny", Wage = 211000, Nationality = "Poland", Position = "Goalkeeper" };
            Player p54 = new() { Player_ID = 54, Player_Name = "Leonardo Bonucci", Wage = 211000, Nationality = "Italy", Position = "Center back" };
            Player p55 = new() { Player_ID = 55, Player_Name = "Paulo Dybala", Wage = 237000, Nationality = "Argentina", Position = "Central attacking midfielder" };
            Player p56 = new() { Player_ID = 56, Player_Name = "Federico Chiesa", Wage = 57000, Nationality = "Italy", Position = "Right winger" };
            Player p57 = new() { Player_ID = 57, Player_Name = "Samir Handanovic", Wage = 104000, Nationality = "Slovenia", Position = "Goalkeeper" };
            Player p58 = new() { Player_ID = 58, Player_Name = "Stefan de Vrij", Wage = 124000, Nationality = "Netherlands", Position = "Center back" };
            Player p59 = new() { Player_ID = 59, Player_Name = "Arturo Vidal", Wage = 174000, Nationality = "Chile", Position = "Central defensive midfielder" };
            Player p60 = new() { Player_ID = 60, Player_Name = "Edin Dzeko", Wage = 244000, Nationality = "Bosnia & Herzegovina", Position = "Striker" };
            Player p61 = new() { Player_ID = 61, Player_Name = "Alex Meret", Wage = 36000, Nationality = "Italy", Position = "Goalkeeper" };
            Player p62 = new() { Player_ID = 62, Player_Name = "Kalidou Koulibaly", Wage = 195000, Nationality = "Senegal", Position = "Center back" };
            Player p63 = new() { Player_ID = 63, Player_Name = "Dries Mertens", Wage = 146000, Nationality = "Belgium", Position = "Central attacking midfielder" };
            Player p64 = new() { Player_ID = 64, Player_Name = "Lorenzo Insigne", Wage = 150000, Nationality = "Italy", Position = "Right winger" };
            Player p65 = new() { Player_ID = 65, Player_Name = "Mike Maignan", Wage = 50000, Nationality = "France", Position = "Goalkeeper" };
            Player p66 = new() { Player_ID = 66, Player_Name = "Alessio Romagnoli", Wage = 114000, Nationality = "Italy", Position = "Center back" };
            Player p67 = new() { Player_ID = 67, Player_Name = "Franck Kessié", Wage = 74000, Nationality = "Ivory Coast", Position = "Central defensive midfielder" };
            Player p68 = new() { Player_ID = 68, Player_Name = "Ante Rebic", Wage = 96000, Nationality = "Croatia", Position = "Striker" };
            Player p69 = new() { Player_ID = 69, Player_Name = "Gianluigi Donnarumma", Wage = 208000, Nationality = "Italy", Position = "Goalkeeper" };
            Player p70 = new() { Player_ID = 70, Player_Name = "Achraf Hakimi", Wage = 86000, Nationality = "Morocco", Position = "Right back" };
            Player p71 = new() { Player_ID = 71, Player_Name = "Lionel Messi", Wage = 730000, Nationality = "Argentina", Position = "Central attacking midfielder" };
            Player p72 = new() { Player_ID = 72, Player_Name = "Kylian Mbappé", Wage = 458000, Nationality = "France", Position = "Striker" };
            Player p73 = new() { Player_ID = 73, Player_Name = "Steve Mandanda", Wage = 36000, Nationality = "France", Position = "Goalkeeper" };
            Player p74 = new() { Player_ID = 74, Player_Name = "Duje Caleta-Car", Wage = 44000, Nationality = "Croatia", Position = "Center back" };
            Player p75 = new() { Player_ID = 75, Player_Name = "Dimitri Payet", Wage = 55000, Nationality = "France", Position = "Central attacking midfielder" };
            Player p76 = new() { Player_ID = 76, Player_Name = "Arkadiusz Milik", Wage = 84000, Nationality = "Poland", Position = "Striker" };
            Player p77 = new() { Player_ID = 77, Player_Name = "Anthony Lopes", Wage = 87000, Nationality = "Portugal", Position = "Striker" };
            Player p78 = new() { Player_ID = 78, Player_Name = "Jason Denayer", Wage = 57000, Nationality = "Belgium", Position = "Center back" };
            Player p79 = new() { Player_ID = 79, Player_Name = "Houssem Aouar", Wage = 64000, Nationality = "France", Position = "Central attacking midfielder" };
            Player p80 = new() { Player_ID = 80, Player_Name = "Moussa Dembélé", Wage = 55000, Nationality = "France", Position = "Striker" };

            p1.Club_ID = c1.Club_ID;
            p2.Club_ID = c1.Club_ID;
            p3.Club_ID = c1.Club_ID;
            p4.Club_ID = c1.Club_ID;
            p5.Club_ID = c2.Club_ID;
            p6.Club_ID = c2.Club_ID;
            p7.Club_ID = c2.Club_ID;
            p8.Club_ID = c2.Club_ID;
            p9.Club_ID = c3.Club_ID;
            p10.Club_ID = c3.Club_ID;
            p11.Club_ID = c3.Club_ID;
            p12.Club_ID = c3.Club_ID;
            p13.Club_ID = c4.Club_ID;
            p14.Club_ID = c4.Club_ID;
            p15.Club_ID = c4.Club_ID;
            p16.Club_ID = c4.Club_ID;
            p17.Club_ID = c5.Club_ID;
            p18.Club_ID = c5.Club_ID;
            p19.Club_ID = c5.Club_ID;
            p20.Club_ID = c5.Club_ID;
            p21.Club_ID = c6.Club_ID;
            p22.Club_ID = c6.Club_ID;
            p23.Club_ID = c6.Club_ID;
            p24.Club_ID = c6.Club_ID;
            p25.Club_ID = c7.Club_ID;
            p26.Club_ID = c7.Club_ID;
            p27.Club_ID = c7.Club_ID;
            p28.Club_ID = c7.Club_ID;
            p29.Club_ID = c8.Club_ID;
            p30.Club_ID = c8.Club_ID;
            p31.Club_ID = c8.Club_ID;
            p32.Club_ID = c8.Club_ID;
            p33.Club_ID = c9.Club_ID;
            p34.Club_ID = c9.Club_ID;
            p35.Club_ID = c9.Club_ID;
            p36.Club_ID = c9.Club_ID;
            p37.Club_ID = c10.Club_ID;
            p38.Club_ID = c10.Club_ID;
            p39.Club_ID = c10.Club_ID;
            p40.Club_ID = c10.Club_ID;
            p41.Club_ID = c11.Club_ID;
            p42.Club_ID = c11.Club_ID;
            p43.Club_ID = c11.Club_ID;
            p44.Club_ID = c11.Club_ID;
            p45.Club_ID = c12.Club_ID;
            p46.Club_ID = c12.Club_ID;
            p47.Club_ID = c12.Club_ID;
            p48.Club_ID = c12.Club_ID;
            p49.Club_ID = c13.Club_ID;
            p50.Club_ID = c13.Club_ID;
            p51.Club_ID = c13.Club_ID;
            p52.Club_ID = c13.Club_ID;
            p53.Club_ID = c14.Club_ID;
            p54.Club_ID = c14.Club_ID;
            p55.Club_ID = c14.Club_ID;
            p56.Club_ID = c14.Club_ID;
            p57.Club_ID = c15.Club_ID;
            p58.Club_ID = c15.Club_ID;
            p59.Club_ID = c15.Club_ID;
            p60.Club_ID = c15.Club_ID;
            p61.Club_ID = c16.Club_ID;
            p62.Club_ID = c16.Club_ID;
            p63.Club_ID = c16.Club_ID;
            p64.Club_ID = c16.Club_ID;
            p65.Club_ID = c17.Club_ID;
            p66.Club_ID = c17.Club_ID;
            p67.Club_ID = c17.Club_ID;
            p68.Club_ID = c17.Club_ID;
            p69.Club_ID = c18.Club_ID;
            p70.Club_ID = c18.Club_ID;
            p71.Club_ID = c18.Club_ID;
            p72.Club_ID = c18.Club_ID;
            p73.Club_ID = c19.Club_ID;
            p74.Club_ID = c19.Club_ID;
            p75.Club_ID = c19.Club_ID;
            p76.Club_ID = c19.Club_ID;
            p77.Club_ID = c20.Club_ID;
            p78.Club_ID = c20.Club_ID;
            p79.Club_ID = c20.Club_ID;
            p80.Club_ID = c20.Club_ID;

            #endregion

            modelBuilder.Entity<Club>(entity =>
            {
                entity.HasOne(club => club.League)
                .WithMany(league => league.Clubs)
                .HasForeignKey(club => club.League_ID)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasOne(player => player.Club)
                .WithMany(club => club.Players)
                .HasForeignKey(player => player.Club_ID)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<League>().HasData(l1, l2, l3, l4, l5);
            modelBuilder.Entity<Club>().HasData(c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20);
            modelBuilder.Entity<Player>().HasData(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20,
                p21, p22, p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33, p34, p35, p36, p37, p38, p39, p40,
                p41, p42, p43, p44, p45, p46, p47, p48, p49, p50, p51, p52, p53, p54, p55, p56, p57, p58, p59, p60,
                p61, p62, p63, p64, p65, p66, p67, p68, p69, p70, p71, p72, p73, p74, p75, p76, p77, p78, p79, p80);
        }
    }
}
