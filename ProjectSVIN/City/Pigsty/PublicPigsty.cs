using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SVINspace
{
    public class PublicPigsty : Pigsty
    {
        public PublicPigsty()
        {
            Name = "Общественный свинарник «Дружный хрюк»";
            Description = "Общественный свинарник «Дружный хрюк» — подходящее место для того чтобы помыться, \nотдохнуть и оздоровиться вашей хрюшке. " +
                "\nЗдесь свиньи расслабляются, кушают и на время забывают о заботах. \nСюда может прийти любой человек, у которого " +
                "\nесть свинья и хватает денег на входной билет. Благодаря демократичным ценам, \nэто удовольствие могут позволить себе даже " +
                "\nлюди ниже среднего достатка. При посещении нужно готовиться к тому, \nчто свиней тут будет много. К сожалению, высока вероятность," +
                "\nчто, воспользовавшись невнимательностью охраны, \nваша хрюшка сбежит из свинарника обратно на волю.";
            Payment = 100;
            PigstyPigEscape = 20;
            PigsInPigsty = new List<Pig>();
        }




    }
}
