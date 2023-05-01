using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Defence_poisonLarge : Poison
    {
        const int CountPoison = 3;
        public int AlreadyPoison { get; set; }
        public Defence_poisonLarge()
        {
            Name = "Большой яд уязвимости";
            Description = "Отравляет соперника, уменьшает защиту на 30 в течение 3 ходов";
            Price = 500;
            RareLevel = Rareness.Эпическая;
        }

        public override void UsePoison(Monster monster)
        {

            monster.Defence -= 30;
            Color.Green($"Защита монстра {monster.Name} уменьшена на 30 пунктов и составляет {monster.Defence} пункта. Действует в течение 3 ходов.");
            Console.WriteLine();

            monster.BuffsHandler += CanselPoison;

        }


        public override void CanselPoison(Monster monster)
        {
            AlreadyPoison++;
            if (monster.HP < 1 || AlreadyPoison == CountPoison)
            {
                monster.Defence += 30;
                monster.BuffsHandler -= CanselPoison;
                Color.Red($"Действие яда уязвимости прекращено.");
                Console.WriteLine();
                AlreadyPoison = 0;
            }
        }

    }
}
