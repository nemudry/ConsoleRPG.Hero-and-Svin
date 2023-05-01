using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    interface IAttackEnhancing : IMonsterEnhancing
    {

        void UseAttackEnhancing(Monster monster)
        {
            Random random = new Random();
            int ds = random.Next(0, 100);
            if (ds < 15)
            {
                monster.Attack += (int)(monster.MainFeatures.Attack * 0.20);
                Color.Red($"Монстр взбешен. Он использует древнюю силу предков - хлещет себя по заду, чтобы разъяриться!" +
                    $"\nАтака монстра увеличена на {(int)(monster.MainFeatures.Attack * 0.20)} пункта.");
                Console.WriteLine();
                monster.BuffsHandler += CanselAttackEnhancing;
            }
        }
        void CanselAttackEnhancing(Monster monster)
        {
            monster.Attack -= (int)(monster.MainFeatures.Attack * 0.20);
            Color.Green($"Атака монстра уменьшена на {(int)(monster.MainFeatures.Attack * 0.20)} пункта.");
            Console.WriteLine();
            monster.BuffsHandler -= CanselAttackEnhancing;
        }

    }
}
