using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class LazyPig : Pig
    {
       public LazyPig()
        {
            StatusPig = Pig.statusPig.Загружено;
            Name = "Ленивый Мед";
            Nickname = "";
            Description = "Ленивый Мед - находка для разводчика. Слишком ленив, чтобы сбежать, \nвстать и даже посрать - поэтому срет там, где лежит. " +
                "\nЕму даже жрать лень, но так как миску суют прямо в рыло - ленивый Мед смиряется. ";
            Level = 1;
            Fat = 0;
            Appetite = 150;
            PigUrgeToEscape = 3;

        }

        public LazyPig(string name, string nickname, string description, int level, int fat, int appetite, int pigUrgeToEscape)
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
