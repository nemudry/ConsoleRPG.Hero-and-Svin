using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Crit_potionLarge : Potion
    {
        public Crit_potionLarge()
        {
            Name = "Большое зелье критического удара";
            Description = "Единоразово увеличивает шанс критического удара на 50 пунктов";
            Price = 500;
            RareLevel = Rareness.Эпическая;
        }

        public override void UsePotion(Hero hero)
        {
            hero.Crit += 50;
            Color.Green($"Шанс критического удара героя увеличен на 50 пунктов и составляет {hero.Crit}%.");
            Console.WriteLine();
            hero.BuffsHandler += CanselPotion;

        }

        public override void CanselPotion(Hero hero) 
        { 
            hero.Crit -= 50;
            Color.Red($"Шанс критического удара героя уменьшен на 50 пунктов и составляет {hero.Crit}%.");
            Console.WriteLine();
            hero.BuffsHandler -= CanselPotion;
        }

    }
}
