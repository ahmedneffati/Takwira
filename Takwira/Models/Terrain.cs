using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takwira.Models
{
   public class Terrain
    {
        public int Id { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string PathImage { get; set; }
        public Proprietaire Proprietaire { get; set; }
        public string EmailProp { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
