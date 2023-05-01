using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SVINspace
{
    public class Quest
    {

        public Quest(Monster target, int amountMonster, int timeToComplite, int prizeMoney, int prizeExp, Item prizeItem)            
        {
            Target = target;
            AmountMonster = amountMonster;
            TimeToComplite = timeToComplite;
            PrizeMoney = prizeMoney;
            PrizeItem = prizeItem;
            PrizeExp = prizeExp;
            StatusQuest = statusQuest.НаДоске;
            KilledMonstersQuest = 0;
            DayOfDoingQuest = 0;

        }

        public statusQuest StatusQuest { get; set; }
        public enum statusQuest
        {
            НаДоске,
            ВпроцессеВыполнения,
            Выполнено,
            Провалено,
        }

        public Monster Target { get; set; }
        public int AmountMonster { get; set; }
        public int KilledMonstersQuest { get; set; }
        public int TimeToComplite { get; set; }
        public int DayOfDoingQuest { get; set; }


        public int PrizeMoney { get; set; }
        public int PrizeExp { get; set; }
        public Item PrizeItem { get; set; }

       
        public override string ToString()
        {
            return $"Квест на монстра: {Target.Name}; Уровень монстра: {Target.Level};" +
                $"\nКоличество: {AmountMonster}; Время: {TimeToComplite} дней; " +
                $"\nНаграда в деньгах: {PrizeMoney}; Награда в опыте: {PrizeExp}; " +
                $"\nНаграда в вещах: {PrizeItem}";
        }



        public virtual void TickTackQuest(Hero hero)
        {
            if (hero.ActualHeroQuest.StatusQuest == statusQuest.ВпроцессеВыполнения)
            {
                hero.ActualHeroQuest.DayOfDoingQuest++;
                if (hero.ActualHeroQuest.DayOfDoingQuest == hero.ActualHeroQuest.TimeToComplite)
                    hero.ActualHeroQuest.StatusQuest = statusQuest.Провалено;
            }

        }
    }
}
