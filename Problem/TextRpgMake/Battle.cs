using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpgMake
{
    public class Battle
    {
        public Battle(Player player, Monster monster)
        {
            Console.WriteLine("{0} vs {1}",player.Name, monster.Name);
            Console.WriteLine("{0}가 {1}에게 {2}데미지 공격", player.Name, monster.Name, player.Damage);
            Console.WriteLine("남은체력 {0}", monster.Hp = monster.Hp - player.Damage);
            player.Exp += monster.Exp;
            Console.WriteLine("경험치: {0}", player.Exp);
        }
    }
}
