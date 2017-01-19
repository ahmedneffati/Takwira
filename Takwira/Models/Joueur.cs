using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takwira.Models
{
    public class Joueur
    {
        public string Email { get; set; }

        public string MotDePass { get; set; }
        public string NomEtPrenom { get; set; }
        public string NumTel { get; set; }
        public DateTime DateDeNaiss { get; set; }
        public ICollection<Match> MatchOrganiser { get; set; }
        public ICollection<MatchJoueur> MatchsParticiper { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
