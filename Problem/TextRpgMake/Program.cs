using System;
using static TextRpgMake.Map;

namespace TextRpgMake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MoveKey moveKey= new MoveKey();
            moveKey.PlayGame();


            //monster = monster.SelectMonster();
            //Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", player.Name, player.Level, player.Exp, player.Hp, player.Mp, player.Damage, player.Defence);
            //Battle battle = new Battle(player, monster);

            Console.WriteLine();
        } //Main
    }
}