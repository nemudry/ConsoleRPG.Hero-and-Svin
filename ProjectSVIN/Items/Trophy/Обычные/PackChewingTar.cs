using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class PackChewingTar : Trophy
    {
        public PackChewingTar()
        {
            Name = "Пачка жевательного гудрона";
            Description = "\nЖевательный гудрон стал популярен ещё в 80-x днях до г.э. \nКогда все жители окончательно зажрались и обнаглели, " +
                "\nпошла мода на бедных. На себя люди надевали всё, начиная от бочек с вином, \nзаканчивая своими домами. Среднестатистические герои " +
                "\nносили неубитых монстров. В конце концов слова «гигиена», «чистота» \nи фраза «Наплодилось донатов! Рандома на вас не хватает!» " +
                "\nбыли удалены из словаря. Гудрон использовали для «ЭВЗ» (эффекта выбитых зубов). \nИ им же дорисовывали синяки и пририсовывали брови. ";
            Price = 50;
            RareLevel = Rareness.Обычная;

        }
    }
}
