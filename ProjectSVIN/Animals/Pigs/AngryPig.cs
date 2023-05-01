using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class AngryPig : Pig
    {
       public AngryPig()
        {
            StatusPig = Pig.statusPig.Создано;
            Name = "Злой Мед";
            Nickname = "";
            Description = "Не сказать, что вам повезло. Злого Меда поймать так же сложно, \nкак и Ленивого, но при этом данный свин постоянно злится - " +
                "nи по этой причине мало ест. Так и норовит сбежать. ";
            Level = 1;
            Fat = 0;
            Appetite = 50;
            PigUrgeToEscape = 10;            

        }

        public AngryPig(string name, string nickname, string description, int level, int fat, int appetite, int pigUrgeToEscape)
        {
            StatusPig = Pig.statusPig.Загружено;
            Name = name;
            Nickname = nickname;
            Description = description;
            Level = level;
            Fat = fat;
            Appetite = appetite;
            PigUrgeToEscape = pigUrgeToEscape;
            StatusPig = Pig.statusPig.Создано;

        }


    }
}
