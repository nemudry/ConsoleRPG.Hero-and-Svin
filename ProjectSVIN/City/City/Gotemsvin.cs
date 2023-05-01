using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class Gotemsvin : City
    {
        public Gotemsvin(List<Item> itemsInGame, List<Monster> monsters)
            :base()
        {
            Name = "Готэмсвин";
            Description = "Город основан вне времён первым героем, \nпоймавшим свинью, в честь данного события.\n" +
                "Долгое время был единственным населённым пунктом, \nпока однажды демографический бум не привёл к тому, \n" +
                "что появились и другие поселения. И всё же Готэмсвин \nтак до сих пор и остался основным центром экономики, \n" +
                "культуры и жизни, словом, столицей. Здесь есть всё, \nо чём можно мечтать и что необходимо для жизни героя:\n" +
                "таверны, магазины, публичные дома, свинарники. \nВы будете поражены величественными башнями, \n" +
                "видными ещё издалека, пышными садами и богатыми фасадами столицы. \nЭтот город — в одном лице сердце и мозг страны. \n" +
                "Особой похвалы заслуживает дружелюбие горожан, \nособенно торговцев и трактирщиков.";
            Magazin = new PigShineMagazin(itemsInGame);
            RefreshMagazin();

            Guildhall = new GotemsvinGuildhall(itemsInGame, monsters);
            RefreshGuildhall();

            Workshop = new GotemsvinWorkshop();

            PigstyInCity = new List<Pigsty>() 
            {
                new PublicPigsty(),
                new PrivateNoblePig(),
                new PalazzoSuino(),
            };
            
        }


    }
}
