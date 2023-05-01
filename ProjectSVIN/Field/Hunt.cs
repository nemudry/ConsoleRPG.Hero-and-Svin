using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Hunt : OutdoorActivity
    {

        public virtual Hero Hero { get; set; }
        public virtual Pig HuntedPig { get; set; }

        public Hunt(Hero hero, Pig huntedPig, List<Item> gameItems)
        {
            Hero = hero;
            HuntedPig = huntedPig;
            GameItems = gameItems;  
        }


        public virtual void StartHunt()
        {

            if (Hero.ActualHeroPig == null)
            {
                int catchDirection = Hero.CatchPig();
                int runDirection = HuntedPig.RunFromHero();
                Console.Clear();


                if (catchDirection == runDirection)
                {
                    Color.Green($"Вы поймали хрюшку!");
                    Hero.ActualHeroPig = HuntedPig;
                    Hero.HeroPigs.Add(HuntedPig);
                    Hero.NickNamePig();

                    int exp = PrizeExp(Hero, HuntedPig);
                    int money = PrizeMoney(HuntedPig);
                    Color.Cyan($"За поимку свиньи герой {Hero.Name} получает {exp} опыта и {money} монет.");
                    Console.WriteLine();
                    Hero.Exp += exp;
                    Hero.Money += money;


                    Color.Red("Хрюшка на привязи! Необходимо поместить ее в свинарник.");
                    Console.WriteLine();
                }

                else
                {
                    Color.Red("К несчастью, свинья убежала.");
                    Console.WriteLine();
                }
            }

            else
            {
                Color.Red("У вас уже есть одна хрюшка на привязи! Необходимо поместить ее в свинарник.");
                Color.Red("К несчастью, свинья убежала.");
                Console.WriteLine();
            }
        }


    }
}
