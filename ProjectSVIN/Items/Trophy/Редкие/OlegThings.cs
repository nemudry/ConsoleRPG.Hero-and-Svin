using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class OlegThings : Trophy
    {
        public OlegThings()
        {
            Name = "Вещи Олега";
            Description = "Набор необычных предметов, которые бы очень пригодились \nдревнекиевскому князю Олегу. Обычно хранятся вместе," +
                "\n собранные в мешочек или сундучок, так как по отдельности \nне представляют интерес для торговцев.Очевидно, Олег не даром " +
                "\nзвался вещим и обладал в свое время княжеским могуществом. \nСвоими силами, либо же прибегнув к помощи выдающихся провидцев," +
                "\n он понял, что встреча со змеем угрожает его жизни. \nИсходя из этих предсказаний он решил обезопасить себя, собрав все " +
                "\nнеобходимые вещи, чтобы коварная рептилия не смогла его одолеть.   ";
            Price = 300;
            RareLevel = Rareness.Редкая;

        }
    }
}
