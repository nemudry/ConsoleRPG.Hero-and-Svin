using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SVINspace
{
    public class DayInGame
    {
        
        public static int passedDaysInGame;
        public static int countActivities;
        const int maxCountActivitiesInDay = 16;

        public event Action<Hero> DayHeroEventHandler;

        public event Action<City> DayCityEventHandler;


        public DayInGame()  { }

        public DayInGame(Hero hero, City city)
        {
            countActivities = 0;
            passedDaysInGame++;

            DayCityEventHandler += city.NewDayInCity;

            if (hero.ActualHeroQuest != null) DayHeroEventHandler += hero.ActualHeroQuest.TickTackQuest;

            DayHeroEventHandler += hero.EatAndDrinkHeroInDay;
            DayHeroEventHandler += DoomsDayIsComing;

            foreach (Pigsty pigsty in city.PigstyInCity)
            {
                DayHeroEventHandler += pigsty.PayPaymentForPigs;
            }
        }

        public virtual DayInGame TikTak(Hero hero, City city)
        {
            countActivities++;
            if (IsEndOfDay())
            {
                EndDayEvent(hero, city);
                Console.WriteLine("Нажмите клавишу для продолжения игры.");
                Console.ReadKey();
                Console.Clear();

                Color.Green($"Доброе утро! Начался день №{passedDaysInGame + 1}.");
                Console.WriteLine();

                return new DayInGame(hero, city);

            }
            else return this;


            bool IsEndOfDay()
            {
                if (countActivities >= maxCountActivitiesInDay)
                {
                    Console.Clear();
                    Color.Red($"День №{passedDaysInGame} закончен.");
                    Console.WriteLine();


                    Console.WriteLine("Нажмите клавишу для продолжения игры.");
                    Console.ReadKey();
                    Console.Clear();


                    return true;
                }
                else return false;
            }
        }

        public virtual void DayInfo()
        {
            Color.Cyan($"День №{passedDaysInGame}. {TimeInfo(countActivities)}.");
            Console.WriteLine();
        }
        public string TimeInfo(int countActivities)
        {
            return (countActivities) switch
            {
                < 4 => "Утро",
                < 8 => "День",
                < 12 => "Вечер",
                < 16 => "Близится ночь",
                _ => "Полночь"
            };
        }



        public virtual void EndDayEvent(Hero hero, City city)
        {
            DayHeroEventHandler?.Invoke(hero);
            DayCityEventHandler?.Invoke(city);
        }

        public virtual void DoomsDayIsComing(Hero hero)
        {
            if (passedDaysInGame / 7 == 0)
            {
                if (passedDaysInGame % 7 > 4 && passedDaysInGame % 7 < 7)
                {
                    Color.Red($"Cудный день приближается.");
                    Console.WriteLine();

                }

                if (passedDaysInGame % 7 == 0)
                {
                    Color.Red($"Cудный день... наступил!");
                    Console.WriteLine();
                    hero.StatusHero = Hero.statusHero.СражениеСудногоДня;
                }
            }

            else
            {
                if (passedDaysInGame % 7 > 4 && passedDaysInGame % 7 < 7)
                {
                    Color.Red($"Cудный день приближается.");
                    Console.WriteLine();

                }

                if (passedDaysInGame % 7 == 0)
                {
                    Color.Red($"Cудный день... наступил!");
                    Console.WriteLine();
                    hero.StatusHero = Hero.statusHero.СражениеСудногоДня;
                }
            }


        }

        public virtual void RebornHero(Hero hero)
        {
            Color.Cyan($"Проходивший мимо Жрец сжалился над героем {hero.Name} и оживил его.");
            Random random = new Random();
            var stealItems = (from item in hero.HeroInventory.AllItems
                              where item.Price != 0
                              select item).ToList();

            if (stealItems.Any())
            {
                Item item = stealItems[random.Next(0, stealItems.Count())];
                Console.Write($"В награду Жрец покапался в инвентаре героя и забрал ");
                Color.Red($"{item.Name}.");
                hero.DeleteItemFromInventory(item);
            }
            Console.WriteLine();

            if (hero.StatusHero == Hero.statusHero.Мертв) hero.StatusHero = Hero.statusHero.Жив;            
            hero.RaceEffect = Hero.heroEffect.МожноЮзать;
            hero.ClassEffect = Hero.heroEffect.МожноЮзать;
            (hero.HP, hero.Mana, hero.Attack, hero.Defence, hero.Crit) = hero.MainFeatures;
            DayHeroEventHandler -= RebornHero;
        }


    }


}
