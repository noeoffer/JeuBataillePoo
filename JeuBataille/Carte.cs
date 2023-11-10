using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JeuBataille
{
    public class Carte
    {
        public string Nom { get; set; }
        public int Valeur { get; set; }
        public string Couleur { get; set; }

        public Carte(string nom, int valeur, string couleur)
        {
            Nom = nom;
            Valeur = valeur;
            Couleur = couleur;
        }
    }
}
