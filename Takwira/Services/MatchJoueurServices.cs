using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takwira.Models;
using Takwira.RestClient;

namespace Takwira.Services
{
    class MatchJoueurServices

    {

        RestClient<MatchJoueur> restClient = new RestClient<MatchJoueur>("http://takwira.azurewebsites.net/api/MatchJoueurs/");

        public async Task<List<MatchJoueur>> getMatchJoueursAsync()

        {





            var MatchJoueurs = await restClient.GetAsync();

            return MatchJoueurs;



        }





        public async Task PostMatchJoueursAsync(MatchJoueur e)

        {



            var MatchJoueurs = await restClient.PostAsync(e);







        }

        public async Task PutMatchJoueursAsync(int id, MatchJoueur e)

        {



            var MatchJoueurs = await restClient.PutAsync(id, e);





        }

        public async Task DeleteMatchJoueursAsync(int id)

        {



            var MatchJoueurs = await restClient.DeleteAsync(id);





        }



    }



}