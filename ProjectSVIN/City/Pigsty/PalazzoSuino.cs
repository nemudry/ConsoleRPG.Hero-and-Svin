using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SVINspace
{
    public class PalazzoSuino : Pigsty
    {
        public PalazzoSuino()
        {
            Name = "Дворец «Суино-Палаццо»";
            Description = "Дворец «Суино-Палаццо» – дворец в центре города, \nрассчитанный на проживание VIP-свиней. Вашу хрюшку " +
                "\nожидают тут: джакузи, аквапарк, личный повар, массажист \nи великолепный вид из окна на снующих внизу жалких людей. " +
                "\nДворец «Суино-Палаццо» - рай для свиней. Тут настолько хорошо, \nчто попавший сюда хрюк не думает более о побеге. " +
                "\nПравда стоит такое проживание не дешего.";
            Payment = 500;
            PigstyPigEscape = -20;
            PigsInPigsty = new List<Pig>();
        }




    }
}
