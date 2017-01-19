using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takwira.Models;
using Takwira.RestClient;

namespace Takwira.Services
{
    class ReservationServices

    {

        RestClient<Reservation> restClient = new RestClient<Reservation>("http://takwira.azurewebsites.net/api/Reservations/");

        public async Task<List<Reservation>> getReservationsAsync()

        {





            var Reservations = await restClient.GetAsync();

            return Reservations;



        }





        public async Task PostReservationsAsync(Reservation e)

        {



            var Reservations = await restClient.PostAsync(e);







        }

        public async Task PutReservationsAsync(int id, Reservation e)

        {



            var Reservations = await restClient.PutAsync(id, e);





        }

        public async Task DeleteReservationsAsync(int id)

        {



            var Reservations = await restClient.DeleteAsync(id);





        }



    }



}