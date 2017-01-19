using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takwira.Models
{
    public class Proprietaire
    {
        public string Email { get; set; }
        public string MotDePass { get; set; }
        public string NomEtPrenom { get; set; }
        public string NumTel { get; set; }
        public ICollection<Terrain> TerrainS { get; set; }
    }
}
