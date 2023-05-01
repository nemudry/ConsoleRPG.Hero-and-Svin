using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class SizeFiveBunch : Trophy
    {
        public SizeFiveBunch()
        {
            Name = "Груздь пятого размера";
            Description = "Этот простой по сути трофей разделяет героическое сообщество \nна противоборствующие лагеря. Одни герои считают, " +
                "\nчто грибы должны быть только такими. И вообще: больше — лучше.\nИм в ответ раздаются презрительные замечания, что идеальный груздь " +
                "\nдолжен помещаться в ладошку. ";
            Price = 50;
            RareLevel = Rareness.Обычная;

        }
    }
}
