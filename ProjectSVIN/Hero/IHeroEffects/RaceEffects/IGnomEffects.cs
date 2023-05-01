using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    interface IGnomEffects : IRaceEffects
    {

        const int CountDefencedIEnhancing = 3;
        int AlreadyTimeDefencedIEnhancing { get; set; }



        void UseDefendEnhancing(Hero hero)
        {
            if (hero.RaceEffect == Hero.heroEffect.МожноЮзать)
            {
                if (AlreadyTimeDefencedIEnhancing == 0)
                {
                    hero.Defence += (int)(hero.MainFeatures.Defence * 0.20);

                    Color.Green($"Герой использует древнюю силу бородатых предков - поднимает волосы торчком. " +
                       $"\nЗащита героя {hero.Name} увеличена на {(int)(hero.MainFeatures.Defence * 0.20)} пункта. Действует в течение 3 ходов.");
                    Console.WriteLine();
                    hero.RaceEffect = Hero.heroEffect.НавыкУжеИспользуется;
                    hero.BuffsHandler += CanselDefendEnhancing;
                }
            }
            else
            {
                Color.Red($"Нельзя использовать древнюю силу бородатых предков больше одного раза за битву.");
                Console.WriteLine();
            }

        }
        void CanselDefendEnhancing(Hero hero)
        {
            AlreadyTimeDefencedIEnhancing++;
            if (hero.StatusHero != Hero.statusHero.Битва || hero.HP < 1 || AlreadyTimeDefencedIEnhancing == CountDefencedIEnhancing)
            {
                hero.Defence -= (int)(hero.MainFeatures.Defence * 0.20);
                hero.BuffsHandler -= CanselDefendEnhancing;
                Color.Red($"Действие силы бородатых предков прекращено.");
                Console.WriteLine();
                AlreadyTimeDefencedIEnhancing = 0;
            }

        }



    }
}
