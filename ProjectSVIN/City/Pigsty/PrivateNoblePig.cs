using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SVINspace
{
    public class PrivateNoblePig : Pigsty
    {
        public PrivateNoblePig()
        {
            Name = "Частный дом «Благородная свинья»";
            Description = "Частный дом «Благородная свинья» — частный свинарник \nподойдет для тех хрюшек, кто любит уединение. " +
                "\nХряк получает доступ в помещение на оплаченный период времени. \nПосторонним вход воспрещен, и свинку никто " +
                "\nне потревожит. Между посещениями в частной свинарне происходит \nтщательная уборка. По согласованию с хозяевами " +
                "\nсвин может пригласить друзей-хрюшек, их жен и детей. \nПоскольку посторонние отсутствуют, правила поведения " +
                "\nв свинарнике компания свиней определяет самостоятельно. \nХрюшкам тут хорошо, и сбежать они пытаются только если" +
                "\nпредставится хорошая возможность.";
            Payment = 300;
            PigstyPigEscape = 0;
            PigsInPigsty = new List<Pig>();
        }




    }
}
