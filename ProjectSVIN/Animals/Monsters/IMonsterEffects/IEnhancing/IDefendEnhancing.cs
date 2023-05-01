using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    interface IDefendEnhancing : IMonsterEnhancing
    {
        const int CountDefence = 3;
        int AlreadyTimeDefencedIEnhancing { get; set; }
        bool IsDefencedIEnhancing { get; set; }


        void UseDefendEnhancing(Monster monster)
        {
            if (AlreadyTimeDefencedIEnhancing == 0)
            {
                Random random = new Random();
                int ds = random.Next(0, 100);
                if (ds < 15)
                {
                    monster.Defence += (int)(monster.MainFeatures.Defence * 0.20);
                    Color.Red($"Монстр взбешен. Он использует древнюю силу предков - поднимает волосы торчком." +
                        $"\nЗащита монстра увеличена на {(int)(monster.MainFeatures.Defence * 0.20)} пункта в течение 3 ходов.");
                    Console.WriteLine();
                    monster.BuffsHandler += CanselDefendEnhancing;
                    IsDefencedIEnhancing = true;
                }
            }
            


        }
        void CanselDefendEnhancing(Monster monster)
        {
            if (IsDefencedIEnhancing)
            {
                AlreadyTimeDefencedIEnhancing++;

                if (monster.HP < 1 || AlreadyTimeDefencedIEnhancing == CountDefence)
                {
                    monster.Defence -= (int)(monster.MainFeatures.Defence * 0.20);
                    Color.Green($"Защита монстра уменьшена на {(int)(monster.MainFeatures.Defence * 0.20)} пункта.");
                    Console.WriteLine();
                    monster.BuffsHandler -= CanselDefendEnhancing;
                    AlreadyTimeDefencedIEnhancing = 0;
                    IsDefencedIEnhancing = false;
                }
            }

        }

    }
}
