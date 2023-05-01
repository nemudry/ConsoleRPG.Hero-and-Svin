using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class ChillingDrink : Trophy
    {
        public ChillingDrink()
        {
            Name = "Леденящий душу напиток";
            Description = "Леденящий душу напиток — редкий трофей, особо ценимый алхимиками. \nПо легенде, именно этот ценный компонент входит в состав " +
                "\nфилософского камня. Его с удовольствием покупают торговцы, частенько \nзанижая цену, и наивный герой, не сознающий ценности трофея, " +
                "\nостается обманутым. Добыть этот трофей непросто, поэтому достается он \nтолько опытным и искушенным героям.Только самые отчаянные " +
                "\nсмельчаки отважились попробовать леденящий душу напиток на вкус. \nНо после этого никто их больше не видел, так что данных о вкусе " +
                "\nсего вещества до сих пор нет. ";
            Price = 300;
            RareLevel = Rareness.Редкая;

        }
    }
}
