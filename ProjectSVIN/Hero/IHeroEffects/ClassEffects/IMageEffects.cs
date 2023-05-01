using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    interface IMageEffects : IClassEffects
    {

        const int CountMageEnhancing = 3;
        int AlreadyTimeMageEnhancing { get; set; }

        public const int ManaMageHit = 30;
        public const int ManaMageEnhancing = 90;
        public const int ManaSuperMageHit = 150;



        void UseMageHit(Hero hero, Monster monster)
        {
            if (hero.ClassEffect == Hero.heroEffect.МожноЮзать)
            {
                int damage = monster.Attack / 3;
                Color.Green($"Герой использует заклинание и заставляет монстра {monster.Name} нанести атаку самому себе на {damage} урона.");
                Console.WriteLine();

                hero.ClassEffect = Hero.heroEffect.НавыкУжеИспользуется;
                monster.HP -= damage;
                hero.ClassEffect = Hero.heroEffect.МожноЮзать;
            }
            else
            {
                Color.Red($"Нельзя использовать несколько навыков одновременно!");
                Console.WriteLine();
            }
        }


        void UseMageEnhancing(Hero hero)
        {
            if (hero.ClassEffect == Hero.heroEffect.МожноЮзать)
            {
                Color.Green($"Герой использует навык мага - кастует себе грозный облик. Монстр испуган. " +
                $"\nАтака героя {hero.Name} будет увеличена на {(int)(hero.MainFeatures.Attack * 0.20)} пункта. Действует в течение 3 ходов.");
                Console.WriteLine();

                hero.ClassEffect = Hero.heroEffect.НавыкУжеИспользуется;
                if (AlreadyTimeMageEnhancing == 0)
                {
                    hero.Attack += (int)(hero.MainFeatures.Attack * 0.20);
                    hero.BuffsHandler += CanselMageEnhancing;
                }
            }

            else
            {
                Color.Red($"Нельзя использовать несколько навыков одновременно!");
                Console.WriteLine();
            }
        }
        void CanselMageEnhancing(Hero hero)
        {

            AlreadyTimeMageEnhancing++;
            if (hero.StatusHero != Hero.statusHero.Битва || hero.HP < 1 || AlreadyTimeMageEnhancing == CountMageEnhancing)
            {
                hero.Defence -= (int)(hero.MainFeatures.Defence * 0.20);
                hero.BuffsHandler -= CanselMageEnhancing;
                Color.Red($"Действие навыка прекращено.");
                Console.WriteLine();

                AlreadyTimeMageEnhancing = 0;
                hero.ClassEffect = Hero.heroEffect.МожноЮзать;

            }
        }


        void UseSuperMageHit(Hero hero, Monster monster)
        {
            if (hero.ClassEffect == Hero.heroEffect.МожноЮзать)
            {
                int damage = monster.Attack * 2;
                Color.Green($"Герой использует навык мага - кастует огненное торнадо вокруг монстра. Монстр ошарашен. " +
                    $"\nГерой наносит монстру {damage} урона.");
                Console.WriteLine();

                hero.ClassEffect = Hero.heroEffect.НавыкУжеИспользуется;
                monster.HP -= damage;
                hero.ClassEffect = Hero.heroEffect.МожноЮзать;
            }

            else
            {
                Color.Red($"Нельзя использовать несколько навыков одновременно!");
                Console.WriteLine();
            }
        }

    }
}
