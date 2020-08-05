using System;
using System.Collections.Generic;
using System.Text;

namespace Animalerie
{
    class Chat : Animal
    {
        public Chat()
        {
            Price = 110;
            type_ = Type.Chat;
        }

        public override void Parle()
        {
            Console.WriteLine("Miaou");
        }
    }
}
