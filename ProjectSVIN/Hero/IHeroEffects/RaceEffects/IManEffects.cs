using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    interface IManEffects : IRaceEffects
    {

        const int CountHealthEnhancing = 3;
        int AlreadyTimeHealthEnhancing { get; set; }


        void UseHealthEnhancing(Hero hero)
        {
            if (hero.RaceEffect == Hero.heroEffect.МожноЮзать)
            {
                if (AlreadyTimeHealthEnhancing == 0)
                {
                    Color.Green($"Герой использует древнюю силу людских предков - мажет лицо лечебной грязью. " +
                       $"\nЗдоровье героя {hero.Name} будет восстанавливаться на {(int)(hero.MainFeatures.HP * 0.10)} пункта. Действует в течение 3 ходов.");
                    Console.WriteLine();
                    hero.RaceEffect = Hero.heroEffect.НавыкУжеИспользуется;
                    hero.BuffsHandler += CanselHealthEnhancing;
                    
                }
            }
            else
            {
                Color.Red($"Нельзя использовать древнюю силу людских предков больше одного раза за битву.");
                Console.WriteLine();
            }


            void CanselHealthEnhancing(Hero hero)
            {
                Color.Green($"Здоровье героя {hero.Name} увеличено на {(int)(hero.MainFeatures.HP * 0.10)} пункта.");
                Console.WriteLine();
                hero.HP += (int)(hero.MainFeatures.HP * 0.10);
                AlreadyTimeHealthEnhancing++;
                if (hero.StatusHero != Hero.statusHero.Битва || hero.HP < 1 || AlreadyTimeHealthEnhancing == CountHealthEnhancing)
                {
                    hero.Defence -= (int)(hero.MainFeatures.Defence * 0.20);
                    hero.BuffsHandler -= CanselHealthEnhancing;
                    Color.Red($"Действие силы людских предков прекращено.");
                    Console.WriteLine();
                    AlreadyTimeHealthEnhancing = 0;
                }

            }

        }
    }
}
