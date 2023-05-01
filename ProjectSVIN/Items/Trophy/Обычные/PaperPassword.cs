using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class PaperPassword : Trophy
    {
        public PaperPassword()
        {
            Name = "Бумажка с паролем";
            Description = "«Да ну и ладно, пойду искать другого». Герой нахмурился и вышел вон. \nБумажка с паролем, которую он мял в кармане, " +
                "\nдосталась ему совершенно случайно, и он прекрасно это помнил, — \nкто-то забыл её на остановке вместе с недельным запасом пропитания. " +
                "\nПродукты оказались безнадёжно испорченными, а вот бумажка, \nприлипнувшая к раздувшейся банке тушёнки, сулила герою " +
                "\nнесколько десятков золотых. Занятый своими мыслями, герой не заметил, \nкак перед ним, словно из-под земли, выросла группа " +
                "\nстранных личностей. Внешне они походили на босяков, \nно было в них что-то зловещее... ";
            Price = 50;
            RareLevel = Rareness.Обычная;

        }
    }
}
