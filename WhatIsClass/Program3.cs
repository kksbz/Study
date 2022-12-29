using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatIsClass2;

namespace WhatIsClass
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            //Description description = new Description();
            //description.ValueTypeAndRefferencoType();
            //TrumpCard trumpCard = new TrumpCard(); //생성자를 불러올때 카드셋업을 하고 옴
            //trumpCard.ReRollCard(); //카드셋팅은 생성자를 불러올때 처리했으므로 정상출력됨

            ////{부모클래스와 자식클래스
            //Child child = new Child();
            //child.PrintChild();
            //child.Print(); //부모클래스 멤버를 호출함
            ////}부모클래스와 자식클래스
            
            Players player = new Players();
            Battles battles = new Battles();
            Enemy enemy = new Enemy();
            
            player.Select();
            Console.WriteLine();
            enemy = enemy.SetRandomEnemyType();
            
            battles.Battle(player, enemy);

            enemy = enemy.SetRandomEnemyType();
            battles.Battle(player,enemy);
        }
    }
}
