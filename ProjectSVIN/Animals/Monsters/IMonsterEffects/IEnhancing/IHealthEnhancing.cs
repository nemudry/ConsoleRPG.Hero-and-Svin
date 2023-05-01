using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    interface IHealthEnhancing : IMonsterEnhancing
    {
        void UseHealthEnhancing(Monster monster)
        {
            Random random = new Random();
            int ds = random.Next(0, 100);
            if (ds < 15)
            {
                if (monster.HP > 0)
                {
                    monster.HP += (int)(monster.MainFeatures.HP * 0.30);
                    Color.Red($"Монстр взбешен. Он использует древнюю силу предков - мажет лицо лечебной грязью." +
                        $"\nЗдоровье монстра увеличено на {(int)(monster.MainFeatures.HP * 0.30)} пункта.");
                    Console.WriteLine();
                }
            }            
        }

    }
}
