using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takwira.Models
{
    public class MatchJoueur
    {
        public int Id { get; set; }
        public string JoueurEmail { get; set; }
        public int MatchId { get; set; }
        public string EtatDeConfirmation { get; set; }
        public Match Match { get; set; }
        public Joueur Joueur { get; set; }
    }
}
