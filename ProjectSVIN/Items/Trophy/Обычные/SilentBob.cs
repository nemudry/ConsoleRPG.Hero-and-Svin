using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class SilentBob : Trophy
    {
        public SilentBob()
        {
            Name = "Молчаливый боб";
            Description = "Молчаливый боб — один из немногих трофеев, имеющий, \nсогласно заверениям мабританских учёных, самосознание. Участь любого " +
                "\nмолчаливого боба незавидна и печальна — ведь раньше каждый из этих \nбезобидных предметов, которые занимают так немного места " +
                "\nи так мало весят, был грозным монстром, вселяющим ужас \nв сердца героев одним своим видом. Или не настолько грозным — сами они, " +
                "\nк сожалению, ничего не рассказывают.  ";
            Price = 50;
            RareLevel = Rareness.Обычная;

        }
    }
}
