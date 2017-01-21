using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Takwira.RestClient;

namespace Takwira.Services

{

    class MatchServices

    {

        RestClient<Match> restClient = new RestClient<Match>("http://takwira.azurewebsites.net/api/Matches/");

        public async Task<List<Match>> getMatchsAsync()

        {


            var Matchs = await restClient.GetAsync();

            return Matchs;



        }





        public async Task PostMatchsAsync(Match e)

        {



            var Matchs = await restClient.PostAsync(e);







        }

        public async Task PutMatchsAsync(int id, Match e)

        {



            var Matchs = await restClient.PutAsync(id, e);





        }

        public async Task DeleteMatchsAsync(int id)

        {



            var Matchs = await restClient.DeleteAsync(id);





        }



    }



}