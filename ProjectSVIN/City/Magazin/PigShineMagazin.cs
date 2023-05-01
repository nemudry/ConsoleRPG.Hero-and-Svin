using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SVINspace
{
    public class PigShineMagazin : Magazin
    {
        public PigShineMagazin(List<Item> itemsInGame)
        {
            Name = "Магазин «Свиной блеск»";
            Description = "Магазин «Свиной блеск» — сеть небольших торгово-диверсионных \nпунктов, охватывающая весь Готэмсвин. \n" +
                "Эти маленькие, но гордые магазинчики раскиданы повсюду. \nКаждый такой домик служит для отдельно взятого торговца \n" +
                "одновременно кровом, ночлегом, гостевой комнатой, \nкамуфляжем и источником наживы. \n" +
                "Облокотившись на прилавок, хозяин терпеливо выжидает, \nпока в его лавку не забредёт очередная жертва - незадачливый герой. \n" +
                "И как только оный натыкается на магазинчик, \nторгаш гипнотизирует его взглядом, \n" +
                "тем самым заставляя совершить внеплановый \nакт купли-продажи. Говорят, что некоторые торговцы \n" +
                "заводят себе для таких целей специально обученого гипноманула. ";
            AllProductsInMagazin = (from item in itemsInGame
                                    where item.Price != 0
                                    where item.Category != "Трофей"
                                    where item.RareLevel == Item.Rareness.Обычная || item.RareLevel == Item.Rareness.Редкая || item.RareLevel == Item.Rareness.Эпическая
                                    select item).ToList();

            AvailableProductsInMagazin = new Dictionary<Item, int>();

        }




    }
}
