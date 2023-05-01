using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Attack_poisonLarge : Poison
    {
        const int CountPoison = 3;
        public int AlreadyPoison { get; set; }
        public Attack_poisonLarge()
        {
            Name = "Большой яд слабости";
            Description = "Отравляет соперника, уменьшает атаку на 30 в течение 3 ходов";
            Price = 500;
            RareLevel = Rareness.Эпическая;
        }

        public override void UsePoison(Monster monster)
        {

            monster.Attack -= 30;
            Color.Green($"Атака монстра {monster.Name} уменьшена на 30 пунктов и составляет {monster.Attack} пункта. Действует в течение 3 ходов.");
            Console.WriteLine();

            monster.BuffsHandler += CanselPoison;

        }


        public override void CanselPoison(Monster monster)
        {
            AlreadyPoison++;
            if (monster.HP < 1 || AlreadyPoison == CountPoison)
            {
                monster.Attack += 30;
                monster.BuffsHandler -= CanselPoison;
                Color.Red($"Действие яда слабости прекращено.");
                Console.WriteLine();
                AlreadyPoison = 0;
            }
        }
           




    }
}
