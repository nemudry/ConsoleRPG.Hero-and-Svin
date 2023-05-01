﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class PieceGraniteScience : Trophy
    {
        public PieceGraniteScience()
        {
            Name = "Огрызок гранита науки";
            Description = "Достаточно распространённый трофей. Распространённость \nобъясняется наличием двух факторов: падающими с неба " +
                "\nкаменными скрижалями (в том числе и гранитными), и мабританскими учёными. \nПоследние сугубо научными методами преобразуют " +
                "\nобычный гранит в гранит науки, и тщательно изгрызают его, \nне жалея собственных зубов. Для чего это им нужно — непонятно, " +
                "\nно есть мнение, что таким образом поднимается личный статус учёного. \nВпрочем, некоторые герои также приложили свои зубы " +
                "\nк созданию этого трофея. Иногда в качестве очередного квеста \nим приходит в голову идея выгрызть статуэтку любимого бога " +
                "\nиз гранита науки. Увы, не всегда это выходит с первой попытки, \nи огрызок безжалостно выбрасывается. ";
            Price = 300;
            RareLevel = Rareness.Редкая;

        }
    }
}
