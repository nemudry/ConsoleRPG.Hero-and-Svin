using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract class Pigsty
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Payment { get; set; }

        public int PigstyPigEscape { get; set; }

        public List<Pig> PigsInPigsty { get; set; }

        public override string ToString()
        {
            return $"Свинарник: {Name}; Ежедневная плата за одну свинью: {Payment} монет; Шанс побега свиньи: {PigstyPigEscape}%.";
        }

        public virtual void GoToPigsty(Hero hero)
        {
            do
            {
                PigstyInfo(hero);
                int answerWhatToDoInPigsty;
                do
                {
                    Color.Cyan("Выберите действие: ");
                    Console.WriteLine("[1] Поместить свинью в свинарник. \n[2] Забрать свинью из свинарника. \n[3] Забить свинью. \n[-1] Выйти в город.");

                    int.TryParse(Console.ReadLine(), out answerWhatToDoInPigsty);

                    if (answerWhatToDoInPigsty == -1)
                    {
                        Console.Clear();
                        return;
                    }

                    if (answerWhatToDoInPigsty < 1 || answerWhatToDoInPigsty > 3)
                    {
                        Color.Red("Введенное значение неверно.");
                        Console.WriteLine();
                    }


                } while (answerWhatToDoInPigsty < 1 || answerWhatToDoInPigsty > 3);                
                Console.Clear();

                switch (answerWhatToDoInPigsty)
                {
                    case 1: LeavePigInPigsty(hero); break;
                    case 2: TakePigFromPigsty(hero); break;
                    case 3: SlaughterPig(hero); break;
                    default: break;
                }
            } while (true);
        }

        public virtual void LeavePigInPigsty(Hero hero)
        {
            if (hero.ActualHeroPig == null)
            {
                Color.Red("У вас нет хрюшки на привязи!");
                Console.WriteLine();
            }

            else
            {
                Color.Green($"Хрюшка {hero.ActualHeroPig.Name} по кличке {hero.ActualHeroPig.Nickname} помещена в свинарник!");
                Console.WriteLine();
                Pig pig = hero.ActualHeroPig;
                hero.ActualHeroPig = null;
                PigsInPigsty.Add(pig);
            }
        
        }

        public virtual void TakePigFromPigsty(Hero hero)
        {
            if (hero.ActualHeroPig != null)
            {
                Color.Red("У вас уже есть хрюшка на привязи!");
                Console.WriteLine();
            }

            else
            {
                int answerPig;
                do
                {
                    Color.Cyan("Выберите хрюшку: ");

                    foreach (Pig pig in PigsInPigsty)
                    {
                        Console.WriteLine($"[{PigsInPigsty.IndexOf(pig) + 1}] {pig.Name} по кличке {pig.Nickname}.");
                    }
                    Console.WriteLine("[-1] Вернуться к выбору действия.");

                    int.TryParse(Console.ReadLine(), out answerPig);

                    if (answerPig == -1)
                    {
                        Console.Clear();
                        return;
                    }

                    if (answerPig < 1 || answerPig > PigsInPigsty.Count())
                    {
                        Color.Red("Введенное значение неверно.");
                        Console.WriteLine();
                    }

                } while (answerPig < 1 || answerPig > PigsInPigsty.Count());               
                Console.Clear();


                hero.ActualHeroPig = PigsInPigsty[answerPig - 1];
                PigsInPigsty.Remove(hero.ActualHeroPig);

                Color.Green($"Хрюшка {hero.ActualHeroPig.Name} по кличке {hero.ActualHeroPig.Nickname} на привязи!");
                Console.WriteLine();
            }
        }

        public virtual void SlaughterPig(Hero hero)
        {
            if (hero.ActualHeroPig == null)
            {
                Color.Red("У вас нет хрюшки на привязи! Принесите хрюшку.");
                Console.WriteLine();
            }

            else
            {
                int answerSlaughterPig;
                do
                {
                    Color.Cyan($"Хрюшка {hero.ActualHeroPig.Name} по кличке {hero.ActualHeroPig.Nickname}.");
                    Console.WriteLine($"Детали. {hero.ActualHeroPig}");
                    Console.WriteLine();
                    Color.Red("Забить хрюшку? \n[1] Да \n[2] Нет");

                    int.TryParse(Console.ReadLine(), out answerSlaughterPig);

                    if (answerSlaughterPig == 2)
                    {
                        Console.Clear();
                        return;
                    }

                    if (answerSlaughterPig < 1 || answerSlaughterPig > 2)
                    {
                        Color.Red("Введенное значение неверно.");
                        Console.WriteLine();
                    }

                } while (answerSlaughterPig < 1 || answerSlaughterPig > 2);                
                Console.Clear();

                Pig killedPig = hero.ActualHeroPig;
                hero.HeroPigs.Remove(killedPig);
                hero.ActualHeroPig = null;

                Color.Green($"Хрюшка {killedPig.Name} по кличке {killedPig.Nickname} забита.");
                Console.WriteLine();

                int money = MoneyForSlaughterPig(killedPig);
                Color.Cyan($"За забой свиньи данной жирности герой {hero.Name} получает {money} монет.");
                Console.WriteLine();
                hero.Money += money;


            }
        }

        public virtual int MoneyForSlaughterPig(Pig pig)
        {

            int amountOfMoney = pig.Level switch
            {
                < 2 => 1000,
                < 3 => 2000,
                < 4 => 4000,
                < 5 => 8000,
                < 6 => 16000,
                < 7 => 32000,
                < 8 => 64000,
                < 9 => 128000,
                _ => 256000
            };

            int money = (int)(amountOfMoney * (double)new Random().Next(40, 141) / 100);

            return money;
        }

        public virtual void PayPaymentForPigs(Hero hero)
        {
            if (PigsInPigsty.Count > 0)
            {                
                Color.CyanShort($"Администрация {Name} присылает счёт для оплаты содержания и корма хрюшек.");
                Console.WriteLine();
                Color.Cyan($"У героя {hero.Name} в кошельке звенит {hero.Money} монет.");
                Console.WriteLine();

                int moneyForPig;

                List<Pig> termPigsInPigsty = new List<Pig>();
                termPigsInPigsty.AddRange(PigsInPigsty);
                foreach (Pig pig in termPigsInPigsty)
                {
                    moneyForPig = pig.Appetite + Payment;
                    Console.WriteLine($"Для своей хрюшки {pig.Name} по кличке {pig.Nickname} необходимо корма " +
                            $"на {pig.Appetite} монет. Содержание хряка - {Payment} монет. \nИтого: {moneyForPig} монет.");

                    if (hero.SpendMoney(moneyForPig))
                    {
                        Color.Green($"Хрюшка {pig.Name} по кличке {pig.Nickname} накормлена!");
                        Console.WriteLine();
                        pig.Fat += pig.Appetite;


                        if (pig.TryToEscape(true, PigstyPigEscape))
                        {
                            Color.Red($"Хрюшка {pig.Name} по кличке {pig.Nickname} сбежала из свинарника!");
                            Color.Red($"Администрация {Name} приносит глубочайшие извинения.");
                            Console.WriteLine();

                            hero.HeroPigs.Remove(pig);
                            PigsInPigsty.Remove(pig);

                        }
                    }

                    else
                    {
                        Color.Red($"Хрюшка {pig.Name} по кличке {pig.Nickname} не накормлена! У вас недостаточно денег!");
                        Console.WriteLine();

                        if (pig.TryToEscape(false, PigstyPigEscape))
                        {
                            Color.Red($"Хрюшка {pig.Name} по кличке {pig.Nickname} сбежала из свинарника!");
                            Color.Red($"Администрация {Name} приносит глубочайшие извинения.");
                            Console.WriteLine();

                            hero.HeroPigs.Remove(pig);
                            PigsInPigsty.Remove(pig);
                        }
                    }


                }
            }

            else
            {
                Color.Green($"У вас нет хрюшек в {Name}. Платить за них не надо.");
                Console.WriteLine();
            }
        }

        public virtual void PigstyInfo(Hero hero)
        {
            Color.Green($"У героя {hero.Name} в кошельке звенит {hero.Money} монет.");
            Console.WriteLine();

            Color.Cyan("Вид cвинарника:");
            Color.Cyan(ToString());
            Console.WriteLine(Description);
            Console.WriteLine();

            Color.Cyan("Ваши свиньи в свинарнике:");
            foreach (Pig pig in PigsInPigsty)
            {
                Console.WriteLine($"[{PigsInPigsty.IndexOf(pig) + 1}] {pig.Name} по кличке {pig.Nickname}." +
                    $"\nДетали. {pig}");
            }
            Console.WriteLine();

        }



    }



}
