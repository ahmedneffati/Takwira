using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takwira.Models;
using Takwira.RestClient;

namespace Takwira.Services
{
    class TerrainServices
    {

        RestClient<Terrain> restClient = new RestClient<Terrain>("http://takwira.azurewebsites.net/api/Terrains/");
        public async Task<List<Terrain>> getTerrainsAsync()
        {


            var Terrains = await restClient.GetAsync();
            return Terrains;

        }


        public async Task PostTerrainsAsync(Terrain e)
        {

            var Terrains = await restClient.PostAsync(e);


        }
        public async Task PutTerrainsAsync(int id, Terrain e)
        {

            var Terrains = await restClient.PutAsync(id, e);


        }
        public async Task DeleteTerrainsAsync(int id)
        {

            var Terrains = await restClient.DeleteAsync(id);


        }

    }

}