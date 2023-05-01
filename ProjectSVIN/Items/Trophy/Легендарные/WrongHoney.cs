using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class WrongHoney : Trophy
    {
        public WrongHoney()
        {
            Name = "Неправильный мёд";
            Description = "Неправильный мёд делают неправильные пчёлы (не путать с правильными) \nв неправильных ульях из неправильного нектара, " +
                "\nсобранного на неправильных цветах. И цвет у него тоже неправильный. ";
            Price = 2000;
            RareLevel = Rareness.Легендарная;

        }
    }
}
