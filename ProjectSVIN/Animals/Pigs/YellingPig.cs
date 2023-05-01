using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class YellingPig : Pig
    {
       public YellingPig()
        {
            StatusPig = Pig.statusPig.Загружено;
            Name = "Орущий Мед";
            Nickname = "";
            Description = "Орущий Мед - настоящая головная боль. Полчаса вблизи выдержит \nтолько тру-герой. Единственный плюс: так как орет и ругается " +
                "\nпостоянно - шансы на побег низкие.";
            Level = 1;
            Fat = 0;
            Appetite = 80;
            PigUrgeToEscape = 3;

        }

        public YellingPig(string name, string nickname, string description, int level, int fat, int appetite, int pigUrgeToEscape)
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
