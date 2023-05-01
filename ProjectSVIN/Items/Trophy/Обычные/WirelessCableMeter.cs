using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class WirelessCableMeter : Trophy
    {
        public WirelessCableMeter()
        {
            Name = "Метр беспроводного кабеля";
            Description = "Весьма странный трофей, представляющий из себя… собственно, \nотрез беспроводного кабеля длинной один метр. Трудно объяснить, " +
                "\nчем он отличается от обычного шланга, тем не менее, \nразличие довольно существенное. Никто не может с уверенностью сказать, " +
                "\nпроводит ли беспроводной кабель электрический ток: \nникто не пробовал. Если вдруг кому-то нужен проводник, " +
                "\nиспользуют обычный проводной кабель.  ";
            Price = 50;
            RareLevel = Rareness.Обычная;

        }
    }
}
