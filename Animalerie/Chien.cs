using System;
using System.Collections.Generic;
using System.Text;

namespace Animalerie
{
    class Chien : Animal
    {
        public Chien()
        {
            Price = 100;
            type_ = Type.Chien;
        }

        public override void Parle()
        {
            Console.WriteLine("Ouaf");
        }
    }
}
