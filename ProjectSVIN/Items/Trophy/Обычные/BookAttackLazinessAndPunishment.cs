using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class BookAttackLazinessAndPunishment : Trophy
    {
        public BookAttackLazinessAndPunishment()
        {
            Name = "Книга «Приступ лени и наказание»";
            Description = "Художественный роман, повествующий о душевных мучениях, терзаниях, \nкусаниях, кромсаниях, обливаниях едкой щёлочью и прочих " +
                "\nкошмарах, творимых совестью с главным героем. Фёдор Михайлович Достоевский \nкатегорически отрицает свою причастность к созданию " +
                "\nэтого произведения, обвиняя в его написании исключительно Фому Фомича Опискина. \nПоследний же отказался давать любые комментарии " +
                "\nпо поводу сего романа, пока его титанический талант и ранимое \nчувство творца не будет оценено хотя бы нобелевской премией " +
                "\nпо литературе. На меньшее мэтр из села Степачиково не согласен.";
            Price = 50;
            RareLevel = Rareness.Обычная;

        }
    }
}
