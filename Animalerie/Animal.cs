using System;
using System.Collections.Generic;
using System.Text;

namespace Animalerie
{
    enum Type
    {
        Chien,
        Chat
    }
    abstract class Animal
    {
        private int price_;
        protected Type type_;

        public int Price {
            get { return price_; }
            set { 
                if (value >= 0) // Un prix est toujours positif
                {
                    price_ = value;
                }
            }
        }
        public Type Type
        {
            get { return type_; }
            // Pas de set pour le type d'un animal
        }

        public abstract void Parle(); // Aboie ou miaule
        public override bool Equals(object obj)
        {
            Animal tmp = (Animal)obj;
            return price_ == tmp.price_ && type_ == tmp.type_;
        }
    }
}
