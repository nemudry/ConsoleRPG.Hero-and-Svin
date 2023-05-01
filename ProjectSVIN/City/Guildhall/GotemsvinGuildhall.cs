using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SVINspace
{
    public class GotemsvinGuildhall : Guildhall
    {

        public GotemsvinGuildhall(List<Item> itemsInGame, List<Monster> monsters)
        {
            Name = "Ратуша города Готэмсвин";
            Description = "Местный орган государственной власти на территории города. \nДля героя примечателен тем, что здесь можно получить " +
                "\nгеройскую работу на убийство монстров. ";
            QuestBoard = new List<Quest>(7);
            QuestPrizeItems = (from item in itemsInGame
                               where item.Price != 0
                               where item.Category != "Трофей"
                               where item.RareLevel == Item.Rareness.Эпическая || item.RareLevel == Item.Rareness.Легендарная
                               select item).ToList();
            QuestTargetMonsters = monsters;
        }


    }



}
