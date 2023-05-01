using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class MastersYodaQuotesCollection : Trophy
    {
        public MastersYodaQuotesCollection()
        {
            Name = "Мастера Йоды цитат сборник";
            Description = "Трофеем книга эта является. Йоды мастера, что Ордена Джедаев магистром прославился, изречения " +
                "\nмудрые записаны в ней. Опасность великую представляет для тебя это сборник, юный ситх. Ибо прилежность " +
                "\nк чтению повлечь на светлую сторону может тебя, и слова будешь в порядке необычном произносить ты. " +
                "\n«Развращение джедая» книга противоположностью сборнику этому является. ";
            Price = 50;
            RareLevel = Rareness.Обычная;

        }
    }
}
