using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SVINspace
{
    public abstract class Pig : Animal
    {

        public statusPig StatusPig { get; set; }
        public enum statusPig
        {
            Создано,
            Загружено
        }

        public virtual string Nickname { get; set; }

        public virtual int Appetite { get; set; }

        private int level;
        public override int Level
        {
            get => level;
            set
            {
                if (StatusPig == statusPig.Загружено)
                {
                    level = value;
                }
                else
                {
                    level = value;
                    if (Level != 1)
                    {
                        Color.Red("***Внимание!***");
                        Color.Green($"Хрюшка {Name} по кличке {Nickname} поднял уровень! Уровень хряка - {Level}.");

                        Appetite *= 2;
                        Color.Cyan($"Хрюшка {Nickname} теперь больше кушает. Ежедневно - на {Appetite} монет.");
                        Console.WriteLine();
                    }
                }
            }
        }

        private int fat;
        public virtual int Fat
        {
            get => fat;
            set
            {
                if (StatusPig == statusPig.Загружено)
                {
                    fat = value;
                }

                else
                {
                    fat = value;

                    int level = Fat switch
                    {
                        < 300 => 1,
                        < 900 => 2,
                        < 3000 => 3,
                        < 9000 => 4,
                        < 30000 => 5,
                        < 90000 => 6,
                        < 300000 => 7,
                        < 900000 => 8,
                        < 3000000 => 9,
                        _ => 10
                    };

                    if (level > Level)
                    {
                        Level = level;
                    }
                }
            }
        }

        public virtual int PigUrgeToEscape { get; set; }

        public override string ToString()
        {
            return $"Свинья: {Name}; Уровень: {Level}; Количество жира: {Fat}; Аппетит на: {Appetite} монет в день; " +
                $"Риск побега: {PigUrgeToEscape}%.";
        }


        public virtual int RunFromHero()
        {
            Random random = new Random();
            return random.Next(1, 7);
            //return 1;
        }

        public virtual bool TryToEscape(bool IsFed, int PigstyPigEscape)
        {
            int chanceToEscape;
            if (IsFed)
            {
                chanceToEscape = PigstyPigEscape + PigUrgeToEscape;
            }

            else
            {
                chanceToEscape = PigstyPigEscape + PigUrgeToEscape + 30;
            }

            Random random = new Random();
            if (chanceToEscape > random.Next(1, 101)) return true;
            else return false;
        }



    }
}
