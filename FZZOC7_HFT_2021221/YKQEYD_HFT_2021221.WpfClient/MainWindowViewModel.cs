using FZZOC7_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace YKQEYD_HFT_2021221.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Player> Players { get; set; }
        public RestCollection<League> Leagues { get; set; }
        public RestCollection<Club> Clubs { get; set; }

        public ICommand CreatePlayerCommand { get; set; }
        public ICommand DeletePlayerCommand { get; set; }
        public ICommand UpdatePlayerCommand { get; set; }

        private Player selectedPlayer;

        public Player SelectedPlayer
        {
            get { return selectedPlayer; }
            set
            {
                if(value!=null)
                {
                    selectedPlayer = new Player()
                    {
                        Player_ID=value.Player_ID,
                        Player_Name = value.Player_Name,
                        Nationality = value.Nationality,
                        Club_ID = value.Club_ID,
                        Wage = value.Wage,
                        Position = value.Position,
                    };
                    OnPropertyChanged();
                    (DeletePlayerCommand as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }

        public ICommand CreateLeagueCommand { get; set; }
        public ICommand DeleteLeagueCommand { get; set; }
        public ICommand UpdateLeagueCommand { get; set; }


        private League selectedLeague;

        public League SelectedLeague
        {
            get { return selectedLeague; }
            set
            {
                if (value != null)
                {
                    selectedLeague = new League()
                    {
                       League_ID =value.League_ID,
                       League_Name=value.League_Name,
                       Nation = value.Nation,
                       CL_Places =value.CL_Places                   
                    };
                    OnPropertyChanged();
                    (DeleteLeagueCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateLeagueCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateClubCommand { get; set; }
        public ICommand DeleteClubCommand { get; set; }
        public ICommand UpdateClubCommand { get; set; }
    
        private Club selectedClub;

        public Club SelectedClub
        {
            get { return selectedClub; }
            set
            {
                if (value != null)
                {
                    selectedClub = new Club()
                    {
                        Club_ID = value.Club_ID,
                        Club_Name = value.Club_Name,
                        League_ID = value.League_ID,
                        Value = value.Value,
                        Owner = value.Owner,
                        Manager = value.Manager,
                        Players = value.Players
                    };
                    OnPropertyChanged();
                    (DeleteClubCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateClubCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public static bool IsDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {

            if (!IsDesignMode)
            {
                Players = new RestCollection<Player>("http://localhost:4894/", "player");

                CreatePlayerCommand = new RelayCommand(() =>
                {
                    Players.Add(new Player()
                    {
                        Club_ID = SelectedPlayer.Club_ID,
                        Nationality = SelectedPlayer.Nationality,
                        Player_Name = SelectedPlayer.Player_Name,
                        Position = SelectedPlayer.Position,
                        Wage = SelectedPlayer.Wage
                    });
                });

                UpdatePlayerCommand = new RelayCommand(() =>
                {
                    Players.Update(SelectedPlayer);
                },
                 () =>
                 {
                     return SelectedPlayer != null;
                 });

                DeletePlayerCommand = new RelayCommand(() =>
                {
                    Players.Delete(SelectedPlayer.Player_ID);
                },
                () =>
                {
                    return SelectedPlayer != null;
                });

                SelectedPlayer = new Player();
            }

            Leagues = new RestCollection<League>("http://localhost:4894/", "league");

            CreateLeagueCommand = new RelayCommand(() =>
            {
                Leagues.Add(new League()
                {
                    League_Name = SelectedLeague.League_Name,
                    Nation = SelectedLeague.Nation,
                    CL_Places = SelectedLeague.CL_Places
                });
            });

            UpdateLeagueCommand = new RelayCommand(() =>
            {
                Leagues.Update(SelectedLeague);
            },
            () =>
            {
                return SelectedLeague != null;
            });

            DeleteLeagueCommand = new RelayCommand(() =>
            {
                Leagues.Delete(SelectedLeague.League_ID);
            },
            () =>
            {
                return SelectedLeague != null;
            });

            SelectedLeague = new League();


            Clubs = new RestCollection<Club>("http://localhost:4894/", "club");

            CreateLeagueCommand = new RelayCommand(() =>
            {
                Clubs.Add(new Club()
                {
                    Club_Name = SelectedClub.Club_Name,
                    Value = SelectedClub.Value,
                    League_ID = SelectedClub.League_ID,
                    Owner = SelectedClub.Owner,
                    Manager = SelectedClub.Manager,
                    Players = SelectedClub.Players
                });
            });

            UpdateClubCommand = new RelayCommand(() =>
            {
                Clubs.Update(SelectedClub);
            },
            () =>
            {
                return SelectedClub != null;
            });

            DeleteClubCommand = new RelayCommand(() =>
            {
                Clubs.Delete(SelectedClub.Club_ID);
            },
            () =>
            {
                return SelectedClub != null;
            });

            SelectedClub = new Club();
        }
    }
}
