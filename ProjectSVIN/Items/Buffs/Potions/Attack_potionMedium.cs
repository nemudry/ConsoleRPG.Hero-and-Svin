using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Attack_potionMedium : Potion
    {
        public Attack_potionMedium()
        {
            Name = "Среднее зелье силы";
            Description = "Увеличивает силу следующего удара на 30 пунктов";
            Price = 200;
            RareLevel = Rareness.Редкая;
        }

        public override void UsePotion(Hero hero)
        {
            hero.Attack += 30;
            Color.Green($"Атака героя увеличена на 30 пунктов и составляет {hero.Attack} пункта.");
            Console.WriteLine();
            hero.BuffsHandler += CanselPotion;

        }

        public override void CanselPotion(Hero hero) 
        { 
            hero.Attack -= 30;
            Color.Red($"Атака героя уменьшена на 30 пунктов и составляет {hero.Attack} пункта.");
            Console.WriteLine();
            hero.BuffsHandler -= CanselPotion;
        }

    }
}
