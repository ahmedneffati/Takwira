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
    class JoueurViewModel : INotifyPropertyChanged
    {
        JoueurServices u = new JoueurServices();
        private List<Joueur> _JoueursList;
        public List<Joueur> JoueursList
        {
            get
            {
                return _JoueursList;
            }
            set
            {
                _JoueursList = value;
                OnPropertyChanged();
            }
        }
        private Joueur _JoueursAdd = new Joueur();
        public Joueur JoueursAdd
        {
            get
            {
                return _JoueursAdd;
            }
            set
            {
                _JoueursAdd = value;
                OnPropertyChanged();
            }
        }
        public Command PostCommand
        {
            get
            {

                return new Command(async () =>
                {
                   // if(_JoueursAdd.Email.Equals(""))
                    await u.PostJoueursAsync(_JoueursAdd);
                    //NavigationPage _navPage = new NavigationPage(new InscriptionJoueur());
                    // await _navPage.PushAsync(new AjouterTerrain());
                });
            }
        }
        public JoueurViewModel()
        {
            InitializerDataASYNC();
        }

        private async Task InitializerDataASYNC()
        {

            JoueursList = await u.getJoueursAsync();

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

                    await u.PutJoueursAsync(_JoueursAdd.Email, _JoueursAdd);
                });
            }
        }
        public Command DeletetCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.DeleteJoueursAsync(_JoueursAdd.Email);
                });
            }
        }

    }
}
