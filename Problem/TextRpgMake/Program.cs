using System;
namespace TextRpgMake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Monster monster = new Monster();
            monster = monster.SelectMonster();
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6} ",player.Name,player.Level,player.Exp, player.Hp,player.Mp,player.Damage,player.Defence);
            Battle battle = new Battle(player, monster);
            Console.WriteLine("몬스터의 남은체력: {0}",monster.Hp);
        }
    }
}