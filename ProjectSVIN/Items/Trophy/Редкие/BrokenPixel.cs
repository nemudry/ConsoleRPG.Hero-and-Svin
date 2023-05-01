using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class BrokenPixel : Trophy
    {
        public BrokenPixel()
        {
            Name = "Битый пиксель";
            Description = "Битый пиксель — трофей героев, за который можно выручить у барыг \nжалкие гроши. Но в то же время несколько золотых в кошельке " +
                "\nещё не помешали ни одному приключенцу, потому нет причин \nоставлять эту никчёмную вещицу на теле убитого монстра. ";
            Price = 300;
            RareLevel = Rareness.Редкая;

        }
    }
}
