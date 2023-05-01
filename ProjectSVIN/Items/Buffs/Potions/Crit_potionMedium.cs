using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Crit_potionMedium : Potion
    {
        public Crit_potionMedium()
        {
            Name = "Среднее зелье критического удара";
            Description = "Единоразово увеличивает шанс критического удара на 30 пунктов";
            Price = 200;
            RareLevel = Rareness.Редкая;
        }

        public override void UsePotion(Hero hero)
        {
            hero.Crit += 30;
            Color.Green($"Шанс критического удара героя увеличен на 30 пунктов и составляет {hero.Crit}%.");
            Console.WriteLine();
            hero.BuffsHandler += CanselPotion;

        }

        public override void CanselPotion(Hero hero) 
        { 
            hero.Crit -= 30;
            Color.Red($"Шанс критического удара героя уменьшен на 30 пунктов и составляет {hero.Crit}%.");
            Console.WriteLine();
            hero.BuffsHandler -= CanselPotion;
        }

    }
}
