using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SVINspace
{
    public abstract partial class Hero : IHeroEffect
    {
        public string Name { get; set; }
        public classHero ClassHero { get; set; }
        public raceHero RaceHero { get; set; }
        public statusHero StatusHero { get; set; }
        public enum statusHero
        {
            Загружен,
            Жив,
            Мертв,
            Битва,
            БежитИзБитвы,
            Вдолгах,
            СражениеСудногоДня
        }
        public enum classHero
        {

            Воин = 1,
            Маг,
            Вор,
            Любая,
        }
        public enum raceHero
        {
            Эльф = 1,
            Гном,
            Человек,
            Любая,
        }



        private int hp;
        public int HP
        {
            get => hp;
            set
            {
                if (StatusHero == statusHero.Загружен)
                {
                    hp = value;
                }
                else
                {
                    if (hp == 0) hp = value;
                    else
                    {
                        if (value > MainFeatures.HP)
                        {
                            hp = MainFeatures.HP;
                        }
                        else
                        {
                            if (value < 0)
                            {
                                hp = 0;
                            }
                            else hp = value;
                        }

                    }
                }
            }

        }

        private int mana;
        public int Mana
        {
            get => mana;
            set
            {
                if (StatusHero == statusHero.Загружен)
                {
                    mana = value;
                }
                else
                {
                    if (mana == 0) mana = value;
                    else
                    {
                        if (value > MainFeatures.Mana)
                        {
                            mana = MainFeatures.Mana;
                        }
                        else
                        {
                            if (value < 0)
                            {
                                mana = 0;
                            }
                            else mana = value;
                        }

                    }
                }
            }

        }
        public virtual bool SpendMana(int mana)
        {
            if (Mana >= mana)
            {
                Mana -= mana;
                return true;
            }
            else
            {
                return false;
            }
        }

        private int defence;
        public int Defence
        {
            get => defence;
            set
            {
                if (StatusHero == statusHero.Загружен)
                {
                    defence = value;
                }
                else
                {
                    if (defence == 0)
                    {
                        if (MainFeatures.Defence != 0 && value > MainFeatures.Defence) defence = MainFeatures.Defence;
                        else defence = value;
                    }

                    else
                    {
                        if (value < 0)
                        {
                            defence = 0;
                        }
                        else defence = value;
                    }
                }
            }

        }

        private int attack;
        public int Attack
        {
            get => attack;
            set
            {
                if (StatusHero == statusHero.Загружен)
                {
                    attack = value;
                }
                else
                {
                    if (attack == 0)
                    {
                        if (MainFeatures.Attack != 0 && value > MainFeatures.Attack) attack = MainFeatures.Attack;
                        else attack = value;
                    }

                    else
                    {
                        if (value < 0)
                        {
                            attack = 0;
                        }
                        else attack = value;
                    }
                }
            }

        }

        public int Crit { get; set; }

        public (int HP, int Mana, int Attack, int Defence, int Crit) MainFeatures { get; set; }



        public int Rank { get; set; }

        private int exp;
        public int Exp
        {
            get => exp;
            set
            {
                if (StatusHero == statusHero.Загружен)
                {
                    exp = value;
                }
                else
                {
                    exp = value;

                    int level = Exp switch
                    {
                        < 50 => 1,
                        < 140 => 2,
                        < 350 => 3,
                        < 700 => 4,
                        < 1200 => 5,
                        < 2000 => 6,
                        < 3000 => 7,
                        < 5000 => 8,
                        < 8000 => 9,
                        _ => 10
                    };

                    if (level > Level)
                    {
                        for (int lev = Level; level > Level;)
                        {
                            lev++;
                            Level = lev;
                        }
                    }
                }
            }
        }

        private int level;
        public virtual int Level
        {
            get => level;
            set
            {
                if (StatusHero == statusHero.Загружен)
                {
                    level = value;
                }
                else
                {
                    level = value;
                    if (Level != 1)
                    {
                        Color.Red("***Внимание!***");
                        Color.Green($"Герой {Name} поднял уровень! Уровень героя - {Level}.");
                        Console.WriteLine();

                        MainFeatures = (HP + 30, HP + 15, Attack + 5, Defence + 5, Crit + 0);
                        (HP, Mana, Attack, Defence, Crit) = MainFeatures;
                    }
                }
            }
        }




        public int Money { get; set; }

        public virtual bool SpendMoney(int money)
        {
            if (Money >= money)
            {
                Money -= money;
                return true;
            }
            else
            {
                return false;
            }
        }


        public override string ToString()
        {
            return $"Герой: {Name}; Класс: {RaceHero}; Раса: {ClassHero}; " +
                $"\nУровень: {Level}; HP: {HP}; Мана: {Mana}; " +
                $"Атака: {Attack}; Защита: {Defence}; Шанс критического удара: {Crit}%.";
        }



    }

}
