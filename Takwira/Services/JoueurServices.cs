using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takwira.Models;
using Takwira.RestClient;

namespace Takwira.Services
{
    class JoueurServices
    {
        RestClientString<Joueur> restClient = new RestClientString<Joueur>("http://takwira.azurewebsites.net/api/Joueurs");
        public async Task<List<Joueur>> getJoueursAsync()
        {

            var Joueur = await restClient.GetAsync();
            return Joueur;

        }


        public async Task PostJoueursAsync(Joueur e)
        {

            var Joueur = await restClient.PostAsync(e);

        }
        public async Task PutJoueursAsync(string id, Joueur e)
        {

            var Joueur = await restClient.PutAsync(id, e);

        }
        public async Task DeleteJoueursAsync(string id)
        {

            var Joueur = await restClient.DeleteAsync(id);


        }

    }

}