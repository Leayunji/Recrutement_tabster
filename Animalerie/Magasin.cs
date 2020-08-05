using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Animalerie
{
    class Magasin
    {
        // Liste des animaux du magasin
        private List<Animal> animaux_ = new List<Animal>();
        private int tresorerie_ = 0;

        public int Tresorerie
        {
            get { return tresorerie_; }
            // Pas de set, pour ne pas modifier la tresorerie en dehors des méthodes de ventes/achats
        }
        // -----------------

        // Ajoute un animal au magasin
        public void Ajouter(Animal animal)
        {
            if (animal != null)
                animaux_.Add(animal);
            else
                Console.Error.WriteLine("Ajouter : L'objet est null.");
        }

        public void Supprimer(Animal animal)
        {
            if (animaux_.Contains(animal))
                animaux_.Remove(animal);
            else
                Console.Error.WriteLine("Supprimer : Le magasin ne possède pas cet animal.");
        }
        // Affiche l'ensemble des animaux sous le format [ Type : x euro ]
        public void Afficher_animaux()
        {
            int i = 0;
            foreach (var animal in animaux_)
            {
                Console.WriteLine(i + ") " + animal.Type + " : " + animal.Price + "euros");
                i++;
            }
        }

        public void Afficher_tresorerie()
        {
            Console.WriteLine("La trésorerie du magasin est de " + tresorerie_ + "euros.");
        }

        // TRESORERIE -----

        /* Ajoute un animal à la liste du magasin et soustrait son prix à la trésorerie,
         * s'il n'y a pas assez d'argent la fonction return False, en cas de réussite elle return True.
        */
        public bool Acheter(Animal animal)
        {
            if (tresorerie_ - animal.Price >= 0)
            {
                // Soustrait le prix à la trésorerie et l'ajoute au magasin.
                tresorerie_ -= animal.Price;
                Ajouter(animal);
                return true;
            }
            else // Argent insuffisant 
            {
                int difference = animal.Price - tresorerie_;
                Console.WriteLine("Acheter : il manque " + difference + "euros.");
                return false;
            }
        }

        /* Vérifie que la trésorerie est suffisante pour acheter tous les animaux, et apelle Achete() sur chacun.
         * S'il n'y a pas assez d'argent la fonction return False, en cas de réussite elle return True.
         */
        public bool Acheter(List<Animal> list_animaux)
        {
            int total = 0;
            // Calcule le prix total de tout les animaux.
            list_animaux.ForEach(x => total += x.Price);

            if (total > tresorerie_)
            {
                int difference = total - tresorerie_;
                Console.WriteLine("Acheter : il manque " + difference + "euros.");
                return false;
            }
            else
            {
                // Achete chaque animal de la liste.
                list_animaux.ForEach(x => Acheter(x));
                return true;
            }
        }

        // Vendre un seul animal
        public bool Vendre(Animal animal)
        {
            if (animaux_.Contains(animal))
            {
                tresorerie_ += animal.Price;
                Supprimer(animal);
                return true;
            }
            else
            {
                Console.Error.WriteLine("Vendre : Le magasin ne possède pas de " + animal.Type + " à " + animal.Price + "euros.");
                return false;
            }
        }

        // Vendre plusieurs animaux
        public bool Vendre(List<Animal> list_animaux)
        {
            int total = 0;
            List<Animal> vendu = new List<Animal>();
            foreach (var animal in list_animaux)
            {
                if (!Vendre(animal)) // On ne possède pas l'animal
                {
                    // On annule la vente
                    tresorerie_ -= total;
                    vendu.ForEach(x => animaux_.Add(x));
                    return false;
                }
                total += animal.Price;
            }

            return true;
        }

        // Fonction qui permet de récupérer un chat ou un chien.
        public Animal AvoirUnAnimalDeTypeX(Type x)
        {
            foreach (var animal in animaux_)
            {
                if (animal.Type == x)
                    return animal;
            }
            return null;
        }

    }

}
