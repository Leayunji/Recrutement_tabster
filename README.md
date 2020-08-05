# Recrutement_tabster

Lea Tristan

------

Contenu : 
* Une classe abstraite Animal : 
	- 2 attributs : type et price
	- Type ne possède pas de setter pour une question de logique (on peut modifier le prix d'un animal mais pas son type)
	- Une fonction abstraite Parle()
* Une classe Chien et une classe Chat, elles héritent d'Animal et implémente Parle() (Ouaf/Miaou)
* Une classe Magasin :
	- 2 attributs : Liste d'animaux et trésorerie (trésorerie ne possède pas de setter public)
	- Ajouter(Animal) : ajoute un animal
	- Supprimer(Animal) : Supprime un animal
	- Afficher_animaux() : Affiche tous les animaux du magasin
	- Afficher_tresorerie() : Affiche le montant de la trésorerie
	- Acheter(Animal) : Achète un animal, l'ajoute à la liste et soustrait son prix à la trésorerie.
	- Acheter(List<Animal>) : Achète les animaux de la liste si la trésorerie est suffisante.
	- Vendre(Animal) : Vend un animal, le supprime de la liste et ajoute son prix à la trésorerie.
	- Vendre(List<Animal>) : Vend les animaux de la liste si le magasin les possède tous.
	- AvoirUnAnimalDeTypeX(Type) : Return un animal du magasin du type donné en argument.
