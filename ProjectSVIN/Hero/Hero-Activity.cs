using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    public abstract partial class Hero
    {
        public event Action<Hero> BuffsHandler;
        public Pig ActualHeroPig { get; set; }
        public List<Pig> HeroPigs { get; set; }
        public Quest ActualHeroQuest { get; set; }
        public heroEffect RaceEffect { get; set; }

        public heroEffect ClassEffect { get; set; }
        public enum heroEffect
        {
            НавыкУжеИспользуется,
            МожноЮзать
        }


        public virtual void UseOrCancelAllBuffs()
        {
            BuffsHandler?.Invoke(this);
        }
        public virtual void GetHeroRaceEnhancing()
        {
            int answerRaceEnhancing;
            do
            {
                Color.Cyan("Использовать силу предков? \n[1] Да. \n[2] Нет.");
                int.TryParse(Console.ReadLine(), out answerRaceEnhancing);

                if (answerRaceEnhancing < 1 || answerRaceEnhancing > 2)
                {
                    Color.Red("Введенное значение неверно.");
                    Console.WriteLine();
                }

            } while (answerRaceEnhancing < 1 || answerRaceEnhancing > 2);
            Console.WriteLine();

            if (answerRaceEnhancing == 2) return;

            else 
            if (this is IRaceEffects hero) hero.UseRaceEffect(this);
        }
        public virtual void GetHeroClassEffects(Monster monster)
        {
            int answerClassEffects;
            do
            {
                Color.Cyan("Использовать навыки класса? \n[1] Да. \n[2] Нет.");
                int.TryParse(Console.ReadLine(), out answerClassEffects);

                if (answerClassEffects < 1 || answerClassEffects > 2)
                {
                    Color.Red("Введенное значение неверно.");
                    Console.WriteLine();
                }

            } while (answerClassEffects < 1 || answerClassEffects > 2);
            Console.WriteLine();

            if (answerClassEffects == 2) return;

            else
            {
                int answerEffect;
                int classLimit = 0;
                do
                {
                    Color.Cyan("Выберите навык класса:");

                    if (ClassHero == classHero.Воин)
                    {
                        if (Level < 4)
                        { 
                            Console.WriteLine($"[1] Техника полного копирования. Стоимость - {IWarriorEffects.ManaWarriorHit} маны.");
                            classLimit = 1;
                        }

                        else if (Level < 7)
                        {
                            Console.WriteLine($"[1] Техника полного копирования. Стоимость - {IWarriorEffects.ManaWarriorHit} маны.");
                            Console.WriteLine($"[2] Блестящая броня. Стоимость - {IWarriorEffects.ManaWarriorEnhancing} маны.");
                            classLimit = 2;
                        }

                        else
                        {
                            Console.WriteLine($"[1] Техника полного копирования. Стоимость -  {IWarriorEffects.ManaWarriorHit}  маны.");
                            Console.WriteLine($"[2] Блестящая броня. Стоимость - {IWarriorEffects.ManaWarriorEnhancing} маны.");
                            Console.WriteLine($"[3] Приемы Джеки Чана. Стоимость - {IWarriorEffects.ManaSuperWarriorEnhancing} маны.");
                            classLimit = 3;
                        }
                    }

                    if (ClassHero == classHero.Маг)
                    {

                        if (Level < 4)
                        {
                            Console.WriteLine($"[1] Магический абьюз. Стоимость - {IMageEffects.ManaMageHit} маны.");
                            classLimit = 1;
                        }

                        else if(Level < 7)
                        {
                            Console.WriteLine($"[1] Магический абьюз. Стоимость - {IMageEffects.ManaMageHit} маны.");
                            Console.WriteLine($"[2] Грозная иллюзия. Стоимость - {IMageEffects.ManaMageEnhancing} маны.");
                            classLimit = 2;
                        }

                        else
                        {
                            Console.WriteLine($"[1] Магический абьюз. Стоимость - {IMageEffects.ManaMageHit} маны.");
                            Console.WriteLine($"[2] Грозная иллюзия. Стоимость - {IMageEffects.ManaMageEnhancing} маны.");
                            Console.WriteLine($"[3] Огненное торнадо. Стоимость - {IMageEffects.ManaSuperMageHit} маны.");
                            classLimit = 3;
                        }
                    }

                    if (ClassHero == classHero.Вор)
                    {

                        if (Level < 4)
                        {
                            Console.WriteLine($"[1] Капкан на дурака. Стоимость - {IThiefEffects.ManaThiefHit} маны.");
                            classLimit = 1;
                        }

                        else if(Level < 7)
                        {
                            Console.WriteLine($"[1] Капкан на дурака. Стоимость - {IThiefEffects.ManaThiefHit} маны.");
                            Console.WriteLine($"[2] Ночное зрение. Стоимость - {IThiefEffects.ManaThiefEnhancing} маны.");
                            classLimit = 2;
                        }

                        else
                        {
                            Console.WriteLine($"[1] Капкан на дурака. Стоимость - {IThiefEffects.ManaThiefHit} маны.");
                            Console.WriteLine($"[2] Ночное зрение. Стоимость - {IThiefEffects.ManaThiefEnhancing} маны.");
                            Console.WriteLine($"[3] Дымовая шашка. Стоимость - {IThiefEffects.ManaSuperThiefRun} маны.");
                            classLimit = 3;
                        }
                    }

                    Console.WriteLine("[-1] Не использовать навык класса.");
                    

                    int.TryParse(Console.ReadLine(), out answerEffect);

                    if (answerEffect == -1)
                    {
                        Console.Clear();
                        return;
                    }


                    if (answerEffect < 1 || answerEffect > classLimit)
                    {
                        Color.Red("Введенное значение неверно.");
                        Console.WriteLine();
                    }

                } while (answerEffect < 1 || answerEffect > classLimit);
                Console.WriteLine();


                if (answerEffect == 1)
                {
                    if (ClassHero == classHero.Воин)
                    {
                        if (SpendMana(IWarriorEffects.ManaWarriorHit))
                        {                          
                            if (this is IWarriorEffects warrior) warrior.UseWarriorHit(this, monster);          
                        }
                        else
                        {
                            Color.Red("Недостаточно маны.");
                            Console.WriteLine();
                        }
                    }

                    if (ClassHero == classHero.Маг)
                    {
                        if (SpendMana(IMageEffects.ManaMageHit))
                        {
                            if (this is IMageEffects mage) mage.UseMageHit(this, monster);
                        }
                        else
                        {
                            Color.Red("Недостаточно маны.");
                            Console.WriteLine();
                        }                        
                    }

                    if (ClassHero == classHero.Вор)
                    {
                        if (SpendMana(IThiefEffects.ManaThiefHit))
                        {
                            if (this is IThiefEffects thief) thief.UseThiefHit(this, monster);
                        }
                        else
                        {
                            Color.Red("Недостаточно маны.");
                            Console.WriteLine();
                        }                        
                    }
                }

                if (answerEffect == 2)
                {
                    if (ClassHero == classHero.Воин)
                    {
                        if (SpendMana(IWarriorEffects.ManaWarriorEnhancing))
                        {
                            if (this is IWarriorEffects warrior) warrior.UseWarriorEnhancing(this);
                        }
                        else
                        {
                            Color.Red("Недостаточно маны.");
                            Console.WriteLine();
                        }
                    }

                    if (ClassHero == classHero.Маг)
                    {
                        if (SpendMana(IMageEffects.ManaMageEnhancing))
                        {
                            if (this is IMageEffects mage) mage.UseMageEnhancing(this);
                        }
                        else
                        {
                            Color.Red("Недостаточно маны.");
                            Console.WriteLine();
                        }

                    }
                    if (ClassHero == classHero.Вор)
                    {

                        if (SpendMana(IThiefEffects.ManaThiefEnhancing))
                        {
                            if (this is IThiefEffects thief) thief.UseThiefEnhancing(this);
                        }
                        else
                        {
                            Color.Red("Недостаточно маны.");
                            Console.WriteLine();
                        }
                    }
                }

                if (answerEffect == 3)
                {
                    if (ClassHero == classHero.Воин)
                    {
                        if (SpendMana(IWarriorEffects.ManaSuperWarriorEnhancing))
                        {
                            if (this is IWarriorEffects warrior) warrior.UseSuperWarriorEnhancing(this, monster);
                        }
                        else
                        {
                            Color.Red("Недостаточно маны.");
                            Console.WriteLine();
                        }
                    }

                    if (ClassHero == classHero.Маг)
                    {
                        if (SpendMana(IMageEffects.ManaSuperMageHit))
                        {
                            if (this is IMageEffects mage) mage.UseSuperMageHit(this, monster);
                        }
                        else
                        {
                            Color.Red("Недостаточно маны.");
                            Console.WriteLine();
                        }
                    }
                    if (ClassHero == classHero.Вор)
                    {

                        if (SpendMana(IThiefEffects.ManaSuperThiefRun))
                        {
                            if (this is IThiefEffects thief) thief.UseSuperThiefRun(this);
                        }
                        else
                        {
                            Color.Red("Недостаточно маны.");
                            Console.WriteLine();
                        }
                    }
                }

            }
        }
        public virtual void GetHeroBuff(Monster monster)
        {
            int answerYNPotion;
            do
            {
                Color.Cyan("Использовать зелье/яд? \n[1] Да. \n[2] Нет.");
                int.TryParse(Console.ReadLine(), out answerYNPotion);

                if (answerYNPotion < 1 || answerYNPotion > 2)
                {
                    Color.Red("Введенное значение неверно.");
                    Console.WriteLine();
                }

            } while (answerYNPotion < 1 || answerYNPotion > 2);
            Console.WriteLine();

            if (answerYNPotion == 2) return;


            int answerKindBuff;
            do
            {
                Color.Cyan("Выберите зелье: ");

                foreach (Buff buff in HeroInventory.Buffs)
                {
                    Console.WriteLine($"[{HeroInventory.Buffs.IndexOf(buff) + 1}] {buff.Name}. Описание: {buff.Description}.");
                }
                Console.WriteLine("[-1] Не пить зелье.");

                int.TryParse(Console.ReadLine(), out answerKindBuff);

                if (answerKindBuff == -1)
                {
                    Console.WriteLine();
                    return;
                }

                if (answerKindBuff < 1 || answerKindBuff > HeroInventory.Buffs.Count())
                {
                    Color.Red("Введенное значение неверно.");
                    Console.WriteLine();
                }

            } while (answerKindBuff < 1 || answerKindBuff > HeroInventory.Buffs.Count());
            Console.WriteLine();


            if (HeroInventory.Buffs[answerKindBuff - 1] is Potion potion)
            {
                potion.UsePotion(this);
                DeleteItemFromInventory(HeroInventory.Buffs[answerKindBuff - 1]);
            }

            else
            {
                if (HeroInventory.Buffs[answerKindBuff - 1] is Poison poison)
                {
                    poison.UsePoison(monster);
                    DeleteItemFromInventory(HeroInventory.Buffs[answerKindBuff - 1]);
                }
            }
        }



        public virtual void AttackMonster(out int attack, out int defence)
        {

            Color.Cyan("Выберите направление для атаки.");
            attack = ChooseDirection();
            Color.Cyan("Выберите направление для защиты.");
            defence = ChooseDirection();

            int ChooseDirection()
            {
                int answerDirection;
                do
                {
                    Console.WriteLine("Выберите направление: \n[1] Голова. \n[2] Живот. \n[3] Ноги.");
                    int.TryParse(Console.ReadLine(), out answerDirection);

                    if (answerDirection < 1 || answerDirection > 3)
                    {
                        Color.Red("Введенное значение неверно.");
                        Console.WriteLine();
                    }

                } while (answerDirection < 1 || answerDirection > 3);
                Console.WriteLine();
                return answerDirection;
            }
        }



        public virtual void NickNamePig()
        {
            string answerName;
            do
            {
                Color.Cyan("Придумайте кличку для хрюшки:");
                answerName = Console.ReadLine();

                if (answerName!.Length < 3 || answerName == null)
                {
                    Color.Red("Введенное значение не подходит - слишком короткое. Попробуйте иное имя.");
                    Console.WriteLine();
                }

            } while (answerName!.Length < 3 || answerName == null);
            Console.WriteLine();

            ActualHeroPig.Nickname = answerName;
        }
        public virtual int CatchPig()
        {

            Color.Cyan("Вы скрытно приближаетесь. В самый последний миг хрюшка вас заметила - она собирается бежать!");

            int answerDirection;
            do
            {
                Console.WriteLine("Выберите направление для ловли хрушки: \n[1] Север. \n[2] Запад. \n[3] Восток." +
                    "\n[4] Юг. \n[5] Зарылась в землю. \n[6] Воспарила в небеса.");
                int.TryParse(Console.ReadLine(), out answerDirection);

                if (answerDirection < 1 || answerDirection > 6)
                {
                    Color.Red("Введенное значение неверно.");
                    Console.WriteLine();
                }

            } while (answerDirection < 1 || answerDirection > 6);
            Console.WriteLine();
            return answerDirection;
        }



        public virtual void EatAndDrinkHeroInDay(Hero hero)
        {
            int dayPay = hero.Level switch
            {
                < 2 => 50,
                < 3 => 100,
                < 4 => 150,
                < 5 => 200,
                < 6 => 250,
                < 7 => 300,
                < 8 => 350,
                < 9 => 400,
                _ => 500
            };

            if (hero.StatusHero != Hero.statusHero.Мертв)
            {
                if (hero.SpendMoney(dayPay))
                {
                    Color.Cyan($"Герой {hero.Name} закупает еду и питье на следующий день на сумму {dayPay} монет.");
                    Color.Cyan($"У героя {hero.Name} в кошельке звенит {hero.Money} монет.");
                    Console.WriteLine();
                }


                else
                {
                    Console.Clear();
                    Color.Red($"У героя {hero.Name} недостаточно денег для оплаты еды и питья на следующий день.");
                    Color.Cyan($"У героя {hero.Name} в кошельке звенит {hero.Money} монет.");
                    Console.WriteLine();

                    int answerWhatToDoToPayDebt;
                    do
                    {
                        Color.Cyan("Выберите действие?");
                        Console.WriteLine("[1] Оплатить долг вещами из рюкзака \n[2] Откупиться обещанием откопать клад");

                        int.TryParse(Console.ReadLine(), out answerWhatToDoToPayDebt);

                        if (answerWhatToDoToPayDebt < 1 || answerWhatToDoToPayDebt > 2)
                        {
                            Color.Red("Введенное значение неверно.");
                            Console.WriteLine();
                        }

                    } while (answerWhatToDoToPayDebt < 1 || answerWhatToDoToPayDebt > 2);


                    if (answerWhatToDoToPayDebt == 1)
                    {
                        Console.Clear();
                        Color.Cyan($"Дабы расплатиться за еду и питье на следующий день, герой {hero.Name} согласился отдать тавернщику вещи из рюкзака.");

                        var heroInventoryAllItems = new List<Item>();
                        heroInventoryAllItems.AddRange(hero.HeroInventory.AllItems);
                        var payItems = (from item in heroInventoryAllItems
                                        where item.Price != 0
                                        select item).ToList();

                        foreach (Item item in payItems)
                        {
                            if (dayPay > 0)
                            {
                                Color.Red($"В оплату долга герой {hero.Name} отдает предмет {item}");
                                hero.DeleteItemFromInventory(item);
                                dayPay -= item.Price;
                            }
                        }
                        Console.WriteLine();

                        if (dayPay > 0)
                        {
                            Color.Red($"Отданных товаров оказалось недостаточно.");
                            Console.WriteLine();
                            answerWhatToDoToPayDebt = 2;
                        }

                        else
                        {
                            Color.Green($"Долг героя {hero.Name} оплачен.");
                            Console.WriteLine();
                        }
                    }

                    if (answerWhatToDoToPayDebt == 2)
                    {
                        Color.Red($"Дабы расплатиться за еду и питье на следующий день, герой {hero.Name} согласился поискать клад, и все найденное - отдать тавернщику.");
                        Console.WriteLine("Нажмите клавишу для продолжения.");
                        Console.ReadKey();
                        Console.WriteLine();
                        Console.WriteLine();
                        hero.StatusHero = Hero.statusHero.Вдолгах;
                    }

                }



            }
        }

        public virtual void PayDebts (List<Pig> pigs, List<Monster> monsters, List<Item> gameItems)
        {

            Color.Red($"Дабы расплатиться за еду и питье, герой {Name} согласился поискать клад, и все найденное - отдать тавернщику.");
            Console.WriteLine("Нажмите клавишу для продолжения.");
            Console.ReadKey();
            Console.WriteLine();

            int BeforeHeroMoney = Money;
            List<Item> BeforeHeroAllItems = new List<Item>();
            BeforeHeroAllItems.AddRange(HeroInventory.AllItems);

            TreasureHunting treasureHunting = new TreasureHunting(this, pigs, monsters, gameItems);
            treasureHunting.StartTreasureHunting();

            if (StatusHero == Hero.statusHero.Вдолгах)
            {
                StatusHero = Hero.statusHero.Жив;
            }

            if (StatusHero == Hero.statusHero.Жив)
            {
                if (ActualHeroPig != null)
                {
                    Color.Red($"В оплату долга герой {Name} отдает хрюшку {ActualHeroPig.Name} по прозвищу {ActualHeroPig.Nickname}.");
                    Pig payPig = ActualHeroPig;
                    HeroPigs.Remove(payPig);
                    ActualHeroPig = null;

                    int payMoney = Money - BeforeHeroMoney;
                    if (payMoney != 0)
                    {
                        SpendMoney(payMoney);
                        Color.Red($"В оплату долга герой {Name} отдает {payMoney} монет.");
                    }
                    Console.WriteLine();
                }
                else
                {
                    var payItem = HeroInventory.AllItems.Except(BeforeHeroAllItems).ToList();
                    foreach (Item item in payItem)
                    {
                        Color.Red($"В оплату долга герой {Name} отдает предмет {item}");
                        DeleteItemFromInventory(item);
                    }

                    int payMoney = Money - BeforeHeroMoney;
                    if (payMoney != 0)
                    {
                        SpendMoney(payMoney);
                        Color.Red($"В оплату долга герой {Name} отдает {payMoney} монет.");
                    }
                    Console.WriteLine();
                }
            }


            if (StatusHero == Hero.statusHero.Мертв)
            {
                Color.Red($"Герой {Name} мертв.");
                Console.WriteLine();
            }

            Color.Green($"Долг героя {Name} оплачен.");
            Console.WriteLine();
        }

        public virtual void WaitOneDay(DayInGame dayInGame, City city)
        {
            do
            {
                dayInGame = dayInGame.TikTak(this, city);
            } while (DayInGame.countActivities != 0);
        }

        public virtual void WaitRebornHero(DayInGame dayInGame, City city)
        {
            dayInGame.DayHeroEventHandler += dayInGame.RebornHero;
            do
            {
                Console.Clear();
                dayInGame.DayInfo();
                Color.Green("Время идет...");

                Color.Red($"Труп героя {Name} лежит в некрасивой позе. Прохожие брезгливо отворачиваются." +
                    $"\nНеужели это конец?");
                Console.WriteLine();

                Console.WriteLine("Нажмите клавишу, чтобы подождать спасения.");
                Console.WriteLine();
                Console.ReadKey();

                dayInGame = dayInGame.TikTak(this, city);

            } while (StatusHero == Hero.statusHero.Мертв);
        }

    }
}

