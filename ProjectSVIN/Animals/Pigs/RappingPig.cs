using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class RappingPig : Pig
    {
       public RappingPig()
        {
            StatusPig = Pig.statusPig.Загружено;
            Name = "Читающий рэп Мед";
            Nickname = "";
            Description = "Читающий рэп Мед - нарцистичен и самолюбив. \nА так как свинья, читающая реп, как ни странно, не будет пользоваться " +
                "\nвсеобщей любовью и популярностью, то данная разновидность свина \nденно и нощно заедает свой стресс и разочарование.";
            Level = 1;
            Fat = 0;
            Appetite = 200;
            PigUrgeToEscape = 5;

        }

        public RappingPig(string name, string nickname, string description, int level, int fat, int appetite, int pigUrgeToEscape)
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
