using System;
using System.Collections.Generic;

namespace Animalerie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("On crée un nouveau magasin qui possède 3 chats et 3 chiens.");
            Magasin magasin1 = new Magasin();
            magasin1.Afficher_tresorerie();

            for (int i = 0; i < 3; i++)
            {
                Chien chien = new Chien();
                Chat chat = new Chat();
                magasin1.Ajouter(chat);
                magasin1.Ajouter(chien);
            }

            // On affiche les animaux du magasin
            magasin1.Afficher_animaux();


            Console.WriteLine("\nOn récupère un chat.");
            Animal kitty = magasin1.AvoirUnAnimalDeTypeX(Type.Chat);
            // On test que c'est un chat, output attendu : "Miaou"
            kitty.Parle();

            Console.WriteLine("On le vend.");
            // On le vend
            magasin1.Vendre(kitty);

            // On affiche les animaux du magasin après avoir vendu un chat.
            magasin1.Afficher_tresorerie();
            magasin1.Afficher_animaux();

            Console.WriteLine("\nOn veut vendre 3 chiens et acheter 1 chat.");
            // On veut vendre plusieurs chiens en même temps et acheter un chat.
            List<Animal> a_vendre = new List<Animal>();
            for (int i = 0; i < 3; i++)
            {
                // On récupère un chien
                Animal chien = magasin1.AvoirUnAnimalDeTypeX(Type.Chien);
                // Il aboie
                chien.Parle();
                if (chien != null)
                    a_vendre.Add(chien);
            }
            Console.WriteLine("On vend les 3 chiens.");
            // On vend les 3 chiens de la liste.
            magasin1.Vendre(a_vendre);

            Console.WriteLine("On achète un nouveau chat à 50euros.");
            // On Achète un nouveau chat
            Chat minou = new Chat();
            minou.Price = 50;
            magasin1.Acheter(minou);

            magasin1.Afficher_tresorerie();
            magasin1.Afficher_animaux();
        }
    }
}
