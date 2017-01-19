using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takwira.Models;
using Takwira.RestClient;

namespace Takwira.Services
{
    class HoraireServices

    {

        RestClient<Horaire> restClient = new RestClient<Horaire>("http://takwira.azurewebsites.net/api/Horaires/");

        public async Task<List<Horaire>> getHorairesAsync()

        {





            var Horaires = await restClient.GetAsync();

            return Horaires;



        }





        public async Task PostHorairesAsync(Horaire e)

        {



            var Horaires = await restClient.PostAsync(e);







        }

        public async Task PutHorairesAsync(int id, Horaire e)

        {



            var Horaires = await restClient.PutAsync(id, e);





        }

        public async Task DeleteHorairesAsync(int id)

        {



            var Horaires = await restClient.DeleteAsync(id);





        }



    }



}