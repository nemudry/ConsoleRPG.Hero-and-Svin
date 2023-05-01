using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class InflatableDrinkingCompanion : Trophy
    {
        public InflatableDrinkingCompanion()
        {
            Name = "Надувной собутыльник";
            Description = "«Пф‐ф‐ф»! Стремительно сдувающийся «труп» наполнил помещение ароматом сивухи. Шериф и трактирщик, не отрывая глаз, " +
                "\nсмотрели на небольшую бирку с надписью, выскользнувшую из под рубашки несостоявшегося пострадавшего. Выполненная изящными рунами, " +
                "\nнадпись на бирке гласила: «надувной собутыльник».  ";
            Price = 50;
            RareLevel = Rareness.Обычная;

        }
    }
}
