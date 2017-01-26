using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takwira.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int NbDeJoueur { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public Joueur Organisateur { get; set; }
        public string OrganisateurEmail { get; set; }
        public ICollection<MatchJoueur> MatchJoueur { get; set; }
    }
}
