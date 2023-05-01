using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVINspace
{
    interface IHealthRecoveryEnhancing : IMonsterEnhancing
    {

        void UseHealthRecoveryEnhancing(Monster monster)
        {
            monster.HP += (int)(monster.MainFeatures.HP * 0.03);

            Color.Red($"Монстр регенирирует. Жизнь монстра увеличена на 3 процента - {(int)(monster.MainFeatures.HP * 0.03)}.");
            Console.WriteLine();
            
        }

    }
}
