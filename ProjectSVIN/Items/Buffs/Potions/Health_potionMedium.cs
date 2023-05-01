using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Health_potionMedium : Potion
    {
        public Health_potionMedium()
        {
            Name = "Среднее зелье здоровья";
            Description = "Восстанавливает 50 HP";
            Price = 200;
            RareLevel = Rareness.Редкая;
        }

        public override void UsePotion (Hero hero)
        {
            hero.HP += 50;
            Color.Green($"Здоровье героя увеличено на 50 пунктов и составляет {hero.HP} пункта.");
            Console.WriteLine();
        }

    }
}
