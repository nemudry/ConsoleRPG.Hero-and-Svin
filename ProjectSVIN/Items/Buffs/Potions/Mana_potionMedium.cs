using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Mana_potionMedium : Potion
    {
        public Mana_potionMedium()
        {
            Name = "Среднее зелье маны";
            Description = "Восстанавливает 50 маны";
            Price = 200;
            RareLevel = Rareness.Редкая;
        }

        public override void UsePotion (Hero hero)
        {
            hero.Mana += 50;
            Color.Green($"Мана героя увеличена на 50 пунктов и составляет {hero.Mana} пункта.");
            Console.WriteLine();
        }

    }
}
