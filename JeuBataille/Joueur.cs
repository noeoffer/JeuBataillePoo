using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuBataille
{
    using System.Collections.Generic;

    using System.Collections.Generic;

    public class Joueur
    {
        public string Nom { get; set; }
        public List<Carte> Main { get; set; }

        public Joueur(string nom)
        {
            Nom = nom;
            Main = new List<Carte>();
        }
    }

}

