using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    interface IWarriorEffects : IClassEffects
    {

        const int CountSuperWarriorEnhancing = 3;
        int AlreadyTimeSuperWarriorEnhancing { get; set; }

        const int CountWarriorEnhancing = 3;
        int AlreadyTimeWarriorEnhancing { get; set; }

        public const int ManaWarriorHit = 30;
        public const int ManaWarriorEnhancing = 90;
        public const int ManaSuperWarriorEnhancing = 150;



        void UseWarriorHit(Hero hero, Monster monster)
        {
            if (hero.ClassEffect == Hero.heroEffect.МожноЮзать)
            {
                int damage = monster.Attack / 3;
                Color.Green($"Герой копирует атаку монстра {monster.Name} и наносит ему {damage} урона.");                
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



        void UseWarriorEnhancing(Hero hero)
        {
            if (hero.ClassEffect == Hero.heroEffect.МожноЮзать)
            {
                Color.Green($"Герой использует навык воина - намазывает броню маслицем. Монстр ослеплен. " +
                $"\nЗащита героя {hero.Name} будет увеличена на {(int)(hero.MainFeatures.Defence * 0.20)} пункта. Действует в течение 3 ходов.");
                Console.WriteLine();

                hero.ClassEffect = Hero.heroEffect.НавыкУжеИспользуется;
                if (AlreadyTimeWarriorEnhancing == 0)
                {
                    hero.Defence += (int)(hero.MainFeatures.Defence * 0.20);
                    hero.BuffsHandler += CanselWarriorEnhancing;
                }
            }

            else
            {
                Color.Red($"Нельзя использовать несколько навыков одновременно!");
                Console.WriteLine();
            }
        }
        void CanselWarriorEnhancing(Hero hero)
        {

            AlreadyTimeWarriorEnhancing++;
            if (hero.StatusHero != Hero.statusHero.Битва || hero.HP < 1 || AlreadyTimeWarriorEnhancing == CountWarriorEnhancing)
            {
                hero.Defence -= (int)(hero.MainFeatures.Defence * 0.20);
                hero.BuffsHandler -= CanselWarriorEnhancing;
                Color.Red($"Действие навыка прекращено.");
                Console.WriteLine();

                AlreadyTimeWarriorEnhancing = 0;
                hero.ClassEffect = Hero.heroEffect.МожноЮзать;
            }
        }



        void UseSuperWarriorEnhancing(Hero hero, Monster monster)
        {
            if (hero.ClassEffect == Hero.heroEffect.МожноЮзать)
            {
                Color.Green($"Герой использует навык воина - повторяет приемы Джеки Чана. Монстр ошарашен. " +
                $"\nЗащита героя {hero.Name} будет увеличена на {(int)(hero.MainFeatures.Defence * 0.20)} пункта. Действует в течение 3 ходов." +
                $"\nАтака героя {hero.Name} будет увеличена на {(int)(hero.MainFeatures.Attack * 0.20)} пункта. Действует в течение 3 ходов." +
                $"\nЗащита монстра {monster.Name} будет уменьшена на {(int)(monster.MainFeatures.Defence * 0.20)} пункта. Действует в течение 3 ходов.");//
                Console.WriteLine();

                hero.ClassEffect = Hero.heroEffect.НавыкУжеИспользуется;
                if (AlreadyTimeSuperWarriorEnhancing == 0)
                {
                    hero.Defence += (int)(hero.MainFeatures.Defence * 0.20);
                    hero.Attack += (int)(hero.MainFeatures.Attack * 0.20);
                    monster.Defence -= (int)(monster.MainFeatures.Defence * 0.20);                    
                    monster.BuffsHandler += CanselSuperWarriorEnhancingMonster;
                    hero.BuffsHandler += CanselSuperWarriorEnhancingHero;
                }
            }

            else
            {
                Color.Red($"Нельзя использовать несколько навыков одновременно!");
                Console.WriteLine();
            }
        }
        void CanselSuperWarriorEnhancingHero(Hero hero)
        {

            if (hero.StatusHero != Hero.statusHero.Битва || hero.HP < 1 || AlreadyTimeSuperWarriorEnhancing == CountSuperWarriorEnhancing)
            {
                hero.Defence -= (int)(hero.MainFeatures.Defence * 0.20);
                hero.Attack -= (int)(hero.MainFeatures.Attack * 0.20);
                hero.BuffsHandler -= CanselSuperWarriorEnhancingHero;
                hero.ClassEffect = Hero.heroEffect.МожноЮзать;
            }           

        }
        void CanselSuperWarriorEnhancingMonster(Monster monster)
        {
            AlreadyTimeSuperWarriorEnhancing++;
            if (monster.HP < 1 || AlreadyTimeSuperWarriorEnhancing == CountSuperWarriorEnhancing)
            {
                monster.Defence += (int)(monster.MainFeatures.Defence * 0.20);
                monster.BuffsHandler -= CanselSuperWarriorEnhancingMonster;
                Color.Red($"Действие супернавыка прекращено.");
                Console.WriteLine();

                AlreadyTimeSuperWarriorEnhancing = 0;
                
            }
        }
    }
}
