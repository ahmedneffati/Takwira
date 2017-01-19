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
    public class TerrainViewModel : INotifyPropertyChanged
    {
        TerrainServices u = new TerrainServices();
        private List<Terrain> _TerrainsList;
        public List<Terrain> TerrainsList
        {
            get
            {
                return _TerrainsList;
            }
            set
            {
                _TerrainsList = value;
                OnPropertyChanged();
            }
        }
        private Terrain _TerrainsAdd = new Terrain();
        public Terrain TerrainsAdd
        {
            get
            {
                return _TerrainsAdd;
            }
            set
            {
                _TerrainsAdd = value;
                OnPropertyChanged();
            }
        }
        public Command PostCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.PostTerrainsAsync(_TerrainsAdd);
                    //NavigationPage _navPage = new NavigationPage(new InscriptionJoueur());
                    // await _navPage.PushAsync(new AjouterTerrain());
                });
            }
        }
        public TerrainViewModel()
        {
            InitializerDataASYNC();
        }

        public async Task InitializerDataASYNC()
        {

            TerrainsList = await u.getTerrainsAsync();

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

                    await u.PutTerrainsAsync(_TerrainsAdd.Id, _TerrainsAdd);
                });
            }
        }
        public Command DeletetCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.DeleteTerrainsAsync(_TerrainsAdd.Id);
                });
            }
        }

    }
}
