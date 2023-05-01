using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class СunningPig : Pig
    {
       public СunningPig()
        {
            StatusPig = Pig.statusPig.Создано;
            Name = "Коварный Мед";
            Nickname = "";
            Description = "Коварный Мед - не свинья, а исчадие ада, настолько он хитер и прожорлив. \nНе думайте, что являетесь хозяином коварного Меда. " +
                "\nКак только свин нажрет брюшко - сбежать из свинарника для него не проблема.";
            Level = 1;
            Fat = 0;
            Appetite = 100;
            PigUrgeToEscape = 20;

        }

        public СunningPig(string name, string nickname, string description, int level, int fat, int appetite, int pigUrgeToEscape)
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
