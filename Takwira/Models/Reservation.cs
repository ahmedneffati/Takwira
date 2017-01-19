using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takwira.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Joueur Joueur { get; set; }
        public string EmailJoueur { get; set; }
        public Terrain Terrain { get; set; }
        public int IdTerrain { get; set; }
        public Horaire Horaire { get; set; }
        public int HoraireId { get; set; }
        public string EtatDeConfirmation { get; set; }
    }
}
