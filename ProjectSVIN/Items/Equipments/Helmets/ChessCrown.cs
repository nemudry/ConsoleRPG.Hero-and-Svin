using SVINspace;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SVINspace
{
    public class ChessCrown : Helmet
    {
        public ChessCrown()
        {
            Name = "Шахматная корона";
            Description = "Шахматная корона — первоначально была обычной королевской короной, \nсамой непримечательной аккуратной и красивой, " +
                "\nодним словом — чудовищно скучным предметом. Но однажды один придворный шут \nрешил повеселиться и украл корону, искали её долго, " +
                "\nднями, ночами, но корона бесследно пропала. Нашлась она спустя годы, \nкогда в королевстве решили затеять ремонт. " +
                "\nТогда-то и стало ясно, что она изрядно пострадала: \nнекогда одинаковые и ровные зубья с красивыми бубенчиками стали отчего-то " +
                "\nразного размера, длины и даже формы, один зубец был вообще отгрызан \n(не иначе как дворцовыми крысами, а может и самим шутом, как знать), ," +
                "\nпосему корону решено было отправить на помойку, где она провела \nни один десяток лет, приобретая всё более знакомый нам вид. ";
            Price = 700;
            Bonus = 5;
            RareLevel = Rareness.Редкая;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
