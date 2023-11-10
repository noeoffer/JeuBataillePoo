using JeuBataille;
using System.ComponentModel;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Carte> paquet = CreerPaquetDeCartes();
        MelangerCartes(paquet);

        Joueur joueur1 = new Joueur("Joueur 1");
        Joueur joueur2 = new Joueur("Joueur 2");

        DistribuerCartes(paquet, joueur1, joueur2);

        while (joueur1.Main.Count > 0 || joueur2.Main.Count > 0)
        {
            Carte carteJoueur1 = joueur1.Main[0];
            Carte carteJoueur2 = joueur2.Main[0];

            Console.WriteLine($"{joueur1.Nom} joue {carteJoueur1.Nom} de {carteJoueur1.Couleur}");
            Console.WriteLine($"{joueur2.Nom} joue {carteJoueur2.Nom} de {carteJoueur2.Couleur}");

            if (carteJoueur1.Valeur > carteJoueur2.Valeur || (carteJoueur1.Valeur == carteJoueur2.Valeur && carteJoueur1.Couleur == "Coeur"))
            {
                Console.WriteLine($"{joueur1.Nom} remporte la manche !");
                joueur1.Main.RemoveAt(0);
                joueur2.Main.RemoveAt(0);
                joueur1.Main.Add(carteJoueur1);
                joueur1.Main.Add(carteJoueur2);
            }

            else if (carteJoueur1.Valeur < carteJoueur2.Valeur || (carteJoueur1.Valeur == carteJoueur2.Valeur && carteJoueur2.Couleur == "Coeur"))
            {
                Console.WriteLine($"{joueur2.Nom} remporte la manche !");
                joueur1.Main.RemoveAt(0);
                joueur2.Main.RemoveAt(0);
                joueur2.Main.Add(carteJoueur1);
                joueur2.Main.Add(carteJoueur2);
            }
            else
            {
                Console.WriteLine("Égalité ! Les cartes retournées sont placées au fond du paquet.");
                joueur1.Main.RemoveAt(0);
                joueur2.Main.RemoveAt(0);
            }

            Console.WriteLine($"Cartes restantes : {joueur1.Nom} = {joueur1.Main.Count}, {joueur2.Nom} = {joueur2.Main.Count}");
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();

            if (joueur1.Main.Count == 0)
            {
                Console.WriteLine($"{joueur2.Nom} remporte la partie !");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else if (joueur2.Main.Count == 0)
            {
                Console.WriteLine($"{joueur1.Nom} remporte la partie !");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }

    static List<Carte> CreerPaquetDeCartes()
    {
        List<Carte> paquet = new List<Carte>();
        string[] noms = { "As", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Valet", "Dame", "Roi" };
        string[] couleurs = { "Coeur", "Trèfle", "Pique", "Carreau" };

        foreach (string nom in noms)
        {
            int valeur;
            if (nom == "Valet")
            {
                valeur = 11;
            }
            else if (nom == "Dame")
            {
                valeur = 12;
            }
            else if (nom == "Roi")
            {
                valeur = 13;
            }
            else if (nom == "As")
            {
                valeur = 14;
            }
            else
            {
                valeur = int.Parse(nom);
            }

            foreach (string couleur in couleurs)
            {
                paquet.Add(new Carte($"{nom}", valeur, couleur));
            }
        }

        return paquet;
    }



    static void MelangerCartes(List<Carte> paquet)
    {
        Random random = new Random();
        int n = paquet.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Carte carte = paquet[k];
            paquet[k] = paquet[n];
            paquet[n] = carte;
        }
    }

    static void DistribuerCartes(List<Carte> paquet, Joueur joueur1, Joueur joueur2)
    {
        for (int i = 0; i < paquet.Count; i++)
        {
            if (i % 2 == 0)
            {
                joueur1.Main.Add(paquet[i]);
            }
            else
            {
                joueur2.Main.Add(paquet[i]);
            }
        }
    }
}



