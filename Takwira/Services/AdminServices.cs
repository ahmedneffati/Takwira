using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takwira.Models;
using Takwira.RestClient;

namespace Takwira.Services
{
    class AdminServices
    {

        RestClientString<Admin> restClient = new RestClientString<Admin>("http://takwira.azurewebsites.net/api/Admins");

        public async Task<List<Admin>> getAdminsAsync()

        {



            var Admin = await restClient.GetAsync();

            return Admin;



        }





        public async Task PostAdminsAsync(Admin e)

        {



            var Admin = await restClient.PostAsync(e);



        }

        public async Task PutAdminsAsync(string id, Admin e)

        {



            var Admin = await restClient.PutAsync(id, e);



        }

        public async Task DeleteAdminsAsync(string id)

        {



            var Admin = await restClient.DeleteAsync(id);





        }



    }



}