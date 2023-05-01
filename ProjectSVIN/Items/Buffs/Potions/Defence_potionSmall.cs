using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Defence_potionSmall : Potion
    {
        const int CountDefence = 3;
        public int AlreadyDefenced { get; set; }
        public Defence_potionSmall()
        {
            Name = "Маленькое зелье защиты";
            Description = "Увеличивает защиту героя на 15 пунктов в течение 3 ходов";
            Price = 50;
            RareLevel = Rareness.Обычная;
        }

        public override void UsePotion (Hero hero)
        {
            if (AlreadyDefenced == 0)
            {
                hero.Defence += 15;
                Color.Green($"Защита героя увеличена на 15 пунктов и составляет {hero.Defence} пункта.");
                Console.WriteLine();
            }

            hero.BuffsHandler += CanselPotion;         

        }

        public override void CanselPotion(Hero hero)
        {
            AlreadyDefenced++;

            if (hero.HP < 1 || AlreadyDefenced == CountDefence)
            {
                hero.BuffsHandler -= CanselPotion;
                hero.Defence -= 15;
                Color.Red($"Действие зелья защиты прекращено.");
                Console.WriteLine();
                AlreadyDefenced = 0;
            }
        }
    }
}
