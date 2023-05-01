using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Mana_potionLarge : Potion
    {
        public Mana_potionLarge()
        {
            Name = "Большое зелье маны";
            Description = "Восстанавливает 100 маны";
            Price = 500;
            RareLevel = Rareness.Эпическая;
        }

        public override void UsePotion (Hero hero)
        {
            hero.Mana += 100;
            Color.Green($"Мана героя увеличена на 100 пунктов и составляет {hero.Mana} пункта.");
            Console.WriteLine();
        }

    }
}
