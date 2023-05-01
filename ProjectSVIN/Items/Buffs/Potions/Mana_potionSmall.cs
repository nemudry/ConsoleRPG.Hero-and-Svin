using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Mana_potionSmall : Potion
    {
        public Mana_potionSmall()
        {
            Name = "Маленькое зелье маны";
            Description = "Восстанавливает 20 маны";
            Price = 50;
            RareLevel = Rareness.Обычная;
        }

        public override void UsePotion (Hero hero)
        {
            hero.Mana += 20;
            Color.Green($"Мана героя увеличена на 20 пунктов и составляет {hero.Mana} пункта.");
            Console.WriteLine();
        }

    }
}
