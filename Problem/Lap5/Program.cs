using System;
namespace Lap2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //각 클래스들을 인스턴스화 시킴
            Players player = new Players();
            Battles battles = new Battles();
            Enemy enemy = new Enemy();

            //player클래스의 Select함수 호출 -> 여기서 선택할 케릭터 정함
            player.Select();
            Console.WriteLine();
            
            //Enemy클래스의 SetRandomEnemyType 호출 -> 여기서 몬스터 랜덤으로 1개 정함
            //몬스터들의 종류(늑대,오크) 클래스는 Enemy클래스를 부모클래스로 두고있음
            //늑대2종류, 오크2종류 총 4마리의 몬스터중 랜덤으로 1마리 뽑아서 enemy에 저장
            enemy = enemy.SetRandomEnemyType();
            
            //Battles클래스의 Battle함수 호출 (전투관련)
            //턴제로 진행되고 플레이어와 몬스터마다 speed 수치를 비교하여
            //누가 먼저 시작할지 정하고 전투시작됨
            //플레이어 턴에서는 총 3가지 선택을할 수 있음 (1번-공격,2번-방어,3번-도망)
            //플레이어와 몬스터의 defence수치로 인해 각 공격력에서 일정부분 감소해서 데미지를 받음
            //->여기선 defence수치에 0.3을 곱한 수치를 적공격력에서 마이너스시킴
            //3번 도망을 선택하면 주사위(1~10)를굴려 6이상이나오면 도망성공->전투종료
            //5이하가 나오면 도망실패 -> 몬스터의 공격력을 1.5배시켜 데미지를 받음
            //플레이어가 턴을 사용하면 각턴마다 speed수치가 변동되어 잘계산하면 턴을 2번이상 가져올 수 있음
            //몬스터가 공격시에도 speed수치가 변동됨
            //speed수치로 유리하게 턴을 가져올 수 있게만들어봄
            battles.Battle(player, enemy);

            //enemy = enemy.SetRandomEnemyType();
            //battles.Battle(player, enemy);
        }
    }
}