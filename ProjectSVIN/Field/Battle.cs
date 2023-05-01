using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Battle : OutdoorActivity
    {

        public virtual Hero Hero { get; set; }
        public virtual Monster Monster { get; set; }

        public Battle (Hero hero, Monster monster, List<Item> gameItems)
        {
            Hero = hero;
            Monster = monster;
            GameItems = gameItems;
        }



        public virtual void StartBattle()
        {
            Hero.StatusHero = Hero.statusHero.Битва;
            do
            {
                BattleInfo();

                Hero.AttackMonster(out int attackHero, out int defenceHero);

                Monster.AttackHero(out int attackMonster, out int defenceMonster);



                if (Hero.HeroInventory.Buffs.Any()) Hero.GetHeroBuff(Monster);

                if (Hero.RaceEffect == Hero.heroEffect.МожноЮзать) Hero.GetHeroRaceEnhancing();

                if (Hero.Mana >= IWarriorEffects.ManaWarriorHit) Hero.GetHeroClassEffects(Monster);



                if (Hero.StatusHero == Hero.statusHero.БежитИзБитвы) break;



                if (attackHero == defenceMonster)
                {
                    Color.Red($"Атака героя {Hero.Name} заблокирована.");
                    Console.WriteLine();
                }
                else
                {

                    int damage = (int)(Hero.Attack * FactorOfDamage(Hero.Crit) - Monster.Defence);
                    if (damage < 0)
                    {
                        Color.Red($"Герой {Hero.Name} наносит монстру {Monster.Name} [0] урона. Шкура монстра слишком крепкая.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Color.Green($"Герой {Hero.Name} наносит монстру {Monster.Name} {damage} урона.");
                        Monster.HP -= damage;
                        Console.WriteLine();

                    }

                }


                if (attackMonster == defenceHero)
                {
                    Color.Green($"Атака монстра {Monster.Name} заблокирована.");
                    Console.WriteLine();
                }

                else
                {
                    int damage = (int)(Monster.Attack * FactorOfDamage(Monster.Crit)) - Hero.Defence;
                    if (damage < 0)
                    {
                        Color.Green($"Монстр {Monster.Name} наносит герою {Hero.Name} [0] урона. Броня героя слишком крепкая.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Color.Red($"Монстр {Monster.Name} наносит герою {Hero.Name} {damage} урона.");
                        Hero.HP -= damage;
                        Console.WriteLine();
                    }

                }


                Hero.UseOrCancelAllBuffs();
                Monster.UseOrCancelAllBuffs();

                if (Monster is IMonsterEnhancing monster) monster.UseEnhancing(Monster);
                if (Monster is IMonsterСursing monster2) monster2.UseСursing(Hero);

                BattleInfo();
                Color.Green("Нажмите любую клавишу для продолжения.");
                Console.ReadKey();
                Console.Clear();

            } while (Hero.HP > 0 && Monster.HP > 0);

            Hero.UseOrCancelAllBuffs();

            if (Hero.StatusHero == Hero.statusHero.БежитИзБитвы) ResultOfBattle(false);

            else ResultOfBattle(true);





            double FactorOfDamage(int crit)
            {

                double factor;
                Random random = new Random();
                int chanceOfCrit = random.Next(0, 101);

                if (crit >= chanceOfCrit)
                {
                    Color.Red("Критический удар!");
                    factor = random.Next(180, 210);
                }
                else
                {
                    factor = random.Next(70, 131);
                }

                return factor / 100.0;
            }


            void ResultOfBattle(bool BattleIsOver)
            {
                if (BattleIsOver)
                {
                    Color.Cyan($"Герой {Hero.Name} подрался с монстром {Monster.Name}.");

                    if (Hero.HP < 1)
                    {
                        Color.Red($"Победил монстр {Monster.Name}. Герой {Hero.Name} погиб. Он теряет все свои деньги - {Hero.Money} монет.");
                        Console.WriteLine();

                        Hero.Money = 0;
                        Hero.StatusHero = Hero.statusHero.Мертв;
                    }

                    else
                    {

                        Color.Green($"Победил герой {Hero.Name}. Он забирает сокровища монстра:");
                        (Hero.HP, Hero.Mana, Hero.Attack, Hero.Defence, Hero.Crit) = Hero.MainFeatures;

                        foreach (Item treasure in PrizeTreasure(Monster, GameItems))
                        {
                            Color.GreenShort($"{treasure.Name}.");
                            if (treasure is Equipment || treasure is Inventory || treasure is Buff)
                            {
                                Color.CyanShort($" {treasure}");
                            }
                            if (treasure is Trophy item3) Color.CyanShort($" Трофей!");
                            Console.WriteLine();

                            Hero.AddItemToInventory(treasure);
                        }

                        int money = PrizeMoney(Monster);
                        int exp = PrizeExp(Hero, Monster);
                        Color.Cyan($"И получает {exp} опыта и {money} монет.");
                        Hero.Exp += exp;
                        Hero.Money += money;
                        Hero.StatusHero = Hero.statusHero.Жив;
                        Hero.RaceEffect = Hero.heroEffect.МожноЮзать;
                        Hero.ClassEffect = Hero.heroEffect.МожноЮзать;

                        if (Hero.ActualHeroQuest?.Target.Name == Monster.Name && Hero.ActualHeroQuest?.StatusQuest == Quest.statusQuest.ВпроцессеВыполнения)
                        {
                            Hero.ActualHeroQuest.KilledMonstersQuest++;
                            if (Hero.ActualHeroQuest.KilledMonstersQuest == Hero.ActualHeroQuest.AmountMonster)
                                Hero.ActualHeroQuest.StatusQuest = Quest.statusQuest.Выполнено;
                        }

                    }
                    Console.WriteLine($"Для продолжения нажмите на клавишу.");
                    Console.ReadKey();
                    Console.Clear();
                }

                else
                {
                    Color.Red($"Герой {Hero.Name} постыдно сбежал с поля боя от монстра {Monster.Name}.");
                    Color.Red($"Позор!");
                    Console.WriteLine();

                    Hero.UseOrCancelAllBuffs();
                    (Hero.HP, Hero.Mana, Hero.Attack, Hero.Defence, Hero.Crit) = Hero.MainFeatures;
                    Hero.RaceEffect = Hero.heroEffect.МожноЮзать;
                    Hero.ClassEffect = Hero.heroEffect.МожноЮзать;


                    Console.WriteLine($"Для продолжения нажмите на клавишу.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }


            void BattleInfo()
            {
                Color.Green("Информация боя:");
                Console.WriteLine(Hero);
                Console.Write($"{Monster} ");
                if (Monster.NameMonsterEffects != null) Color.Red(Monster.NameMonsterEffects);
                Console.WriteLine();
            }

        }
    }
}
