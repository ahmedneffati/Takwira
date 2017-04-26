using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Takwira.Models;
using Takwira.Services;
using Xamarin.Forms;

namespace Takwira.ViewModels
{
  public  class MatchViewModel : INotifyPropertyChanged
    {
        MatchServices u = new MatchServices();
        private List<Match> _MatchsList;
        public List<Match> MatchsList
        {
            get
            {
                return _MatchsList;
            }
            set
            {
                _MatchsList = value;
                OnPropertyChanged();
            }
        }
        private Match _MatchsAdd = new Match();
        public Match MatchsAdd
        {
            get
            {
                return _MatchsAdd;
            }
            set
            {
                _MatchsAdd = value;
                OnPropertyChanged();
            }
        }
        public Command PostCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.PostMatchsAsync(_MatchsAdd);
                    //NavigationPage _navPage = new NavigationPage(new InscriptionJoueur());
                    // await _navPage.PushAsync(new AjouterTerrain());
                });
            }
        }
        public MatchViewModel()
        {
            InitializerDataASYNC();
        }

        public async Task InitializerDataASYNC()
        {

            MatchsList = await u.getMatchsAsync();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public Command PutCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.PutMatchsAsync(_MatchsAdd.Id, _MatchsAdd);
                });
            }
        }
        public Command DeletetCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.DeleteMatchsAsync(_MatchsAdd.Id);
                });
            }
        }

    }
}