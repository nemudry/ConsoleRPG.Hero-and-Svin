using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class DiagonalMonitor : Trophy
    {
        public DiagonalMonitor()
        {
            Name = "Диагональ от монитора";
            Description = "С наступлением тёплых дней, по окончании первых \nчетверговых дождиков, деревни пустеют — все жители, от мала до велика, " +
                "\nвзяв корзинки и вооружившись острыми ножиками, идут в лес по мониторы. \nРазновидностей их в лесах произрастает множество — " +
                "\nогромных плоских и доисторических круглых, чёрных и зеленоватых, \nтреснутых и в полиэтилене, пластиковых и стеклянных. " +
                "\nСобирают их на серверной стороне старых деревьев \nили на 486 пнях, срезая держащие мониторы пучки проводов. ";
            Price = 50;
            RareLevel = Rareness.Обычная;

        }
    }
}
