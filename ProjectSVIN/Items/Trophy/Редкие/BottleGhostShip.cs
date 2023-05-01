using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class BottleGhostShip : Trophy
    {
        public BottleGhostShip()
        {
            Name = "Бутылка с кораблём-призраком";
            Description = "Бутылка с кораблём-призраком — не очень ценимый торговцами трофей \nиз-за его коварного характера. В лучшие дни " +
                "\nза него можно получить сотню монет, это если призрак не успеет улизнуть \nв другую бутылку, дабы позлить незадачливого героя. ";
            Price = 300;
            RareLevel = Rareness.Редкая;

        }
    }
}
