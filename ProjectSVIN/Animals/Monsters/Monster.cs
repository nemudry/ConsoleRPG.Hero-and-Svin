using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SVINspace
{
    public abstract class Monster : Animal, IMonsterEffect
    {

        private int hp;
        public int HP
        {
            get => hp;
            set
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

        private int defence;
        public int Defence
        {
            get => defence;
            set
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

        private int attack;
        public int Attack
        {
            get => attack;
            set
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

        public int Crit { get; set; }

        public (int HP, int Attack, int Defence) MainFeatures { get; set; }

        public string NameMonsterEffects { get; set; }

        public event Action<Monster> BuffsHandler;
        public override string ToString()
        {
            return $"Монстр: {Name}; Уровень: {Level}; HP: {HP}; Атака: {Attack}; Защита: {Defence}; Шанс критического удара: {Crit}%.";
        }

        
        public virtual void UseOrCancelAllBuffs()
        {
            BuffsHandler?.Invoke(this);
        }


        public virtual void AttackHero(out int attack, out int defence)
        {
            Random random = new Random();
            attack = random.Next(1, 4);
            defence = random.Next(1, 4);
        }


        public void MonsterInfo ()
        {
            Color.Green($"{Name}.");
            Color.CyanShort($"{this} ");
            if (NameMonsterEffects != null) Color.Red(NameMonsterEffects);
            Console.WriteLine(Description);
            Console.WriteLine();
        }

    }
}
