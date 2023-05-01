using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class DeckVideoCards : Trophy
    {
        public DeckVideoCards()
        {
            Name = "Колода видеокарт";
            Description = "Видеокарты водятся в других вселенных, откуда добываются \nособенно пронырливыми монстрами. Монстры добывают их не по одной, " +
                "\nа по нескольку десятков и сразу складывают в колоды. В дальнейшем \nколоды видеокарт переходят от одних монстров к другим, " +
                "\nпоэтому определить, какие именно монстры на столько пронырливы, невозможно. \nПотом колоды видеокарт отбираются у монстров героями. ";
            Price = 50;
            RareLevel = Rareness.Обычная;

        }
    }
}
