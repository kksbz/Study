using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap2
{
    public class TextRpgBattle
    {
    } //TextRpgBattle
    
    //Creature 클래스에서는 몬스터와 플레이어의 스텟을 입력할 변수를 선언
    public class Creature
    {
        protected string name;
        protected double hp;
        public double damage;
        public double defence;
        public int speed;

        //Property 적용함
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public double Hp
        {
            get { return this.hp; }
            set { this.hp = value; }
        }
        //Property 적용함
    } //Creature
    
    //Battles 클래스에서는 게임의 전투방식을 정함
    class Battles
    {
        //Battle함수
        public void Battle(Creature temp, Creature temp2)
        {
            //랜덤으로 선택된 몬스터의 정보출력
            Console.WriteLine("{0} 가 나타났다!", temp2.Name);
            Console.WriteLine("{0}의 정보 HP: {1}, 공격력: {2}, 방어력: {3} 스피드: {4}", temp2.Name, temp2.Hp,
                temp2.damage, temp2.defence, temp2.speed);
            Console.WriteLine();
            //while문 진입 조건 선언 조건: game이 temp.hp > 0이면 True
            bool game = temp.Hp > 0;
            while (game)
            {
                int userInPut = 0;
                //선턴을 누가 가져갈지 정하는 for문 시작 loop: 1번 루프
                for (int index = 0; index < 1; index++)
                {
                    //if문 시작 조건: 플레이어의 스피드가 몬스터의 스피드보다 같거나 빠를때
                    if(temp.speed >= temp2.speed)
                    {
                        //플레이어 턴
                        Console.WriteLine("===========================================");
                        Console.WriteLine();
                        Console.WriteLine("{0}의 턴 입니다.", temp.Name);
                        Console.WriteLine();
                    }
                    else
                    {
                        //몬스터 턴
                        Console.WriteLine("*******************************************");
                        Console.WriteLine();
                        Console.WriteLine("{0}의 턴!", temp2.Name);
                        Console.WriteLine();
                        //몬스터 턴에선 몬스터가 플레이어를 공격 defence수치에따른 데미지감소는 Main()메서드에 주석으로 설명해둠
                        Console.WriteLine("{0}가 {1}에게 {2} 데미지를 줌 \n{3}의 남은체력 {4}", temp2.Name, temp.Name,
                                temp2.damage, temp.Name, Math.Round(temp.Hp - (temp2.damage - (temp.defence * 0.3))));
                        Math.Round(temp.Hp -= (temp2.damage - (temp.defence * 0.3)));
                        //Math.Round함수를 통해 반올림처리하여 소수점이 안나오게함
                        Console.WriteLine();
                        Console.WriteLine("*******************************************");
                        //몬스터가 공격했으므로 플레이어의 스피드를 += 3시킴 (몬스터의 스피드는 변동이안되서 무한공격을 막음)
                        temp.speed += 3;
                        //몬스터가 턴이 종료됨 -> for문을 다시 돌려 누가 턴을 가져갈지 정함
                        index--;
                        //만약 몬스터의 공격으로 플레이어의 체력이 0보다 작아지면 사망판정
                        if(temp.Hp < 0)
                        {
                            //몬스터 턴때 index--했으므로 플레이어의 체력과 상관없이 for문이 반복되서
                            //플레이어의 체력이 0아래로 떨어지면 반복문을 즉시종료하기위해 index++함
                            index++;
                        }
                    } //if문 종료
                } //for문 종료
                
                //if문 시작 조건: 플레이어의 체력이 0보다 작거나 같을때
                if (temp.Hp <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("{0} 에게 죽었습니다. 게임종료", temp2.Name);
                    //플레이어가 죽었으므로 게임종료
                    game = false;
                    break;
                } //if문 종료
                
                //플레이어 턴 선택시작을 위한 for문 시작 loop: 1번 루프
                for(int index = 0; index < 1; index++)
                {
                    Console.Write("수행할 행동을 선택하세요.\n1번: 공격, 2번: 방어, 3번: 도망 ");
                    //string형식으로 받은 값을 int형식으로 변환
                    int.TryParse(Console.ReadLine(), out userInPut);
                    Console.WriteLine();
                    //입력예외처리 if문 시작 조건: 입력값이 0~4사이일 때
                    if (0 < userInPut && userInPut < 4) { }
                    else
                    {
                        //입력값이 0~4사이가 아니므로 index--시켜 for문 다시 반복
                        Console.WriteLine("잘못 입력했습니다. 다시 입력하세요.");
                        Console.WriteLine();
                        index--;
                    } //if문 종료
                } //for문 종료

                //입력값 선택이 수행할 일을 정하기 위한 switch문 시작 조건: userInPut
                switch (userInPut)
                {
                    //1번 입력시 실행(공격)
                    case 1:
                        //플레이어의 공격
                        Console.WriteLine("{0}가 {1}에게 {2} 데미지를 줌 \n{3}의 남은체력 {4}", temp.Name, temp2.Name,
                            temp.damage, temp2.Name, Math.Round((temp2.Hp - (temp.damage - (temp2.defence * 0.3)))));
                        Math.Round(temp2.Hp -= (temp.damage - (temp2.defence * 0.3)));
                        //플레이어가 공격했으므로 플레이어의 스피드를 낮춤
                        temp.speed -= 2;
                        //if문 시작 조건: 몬스터의 체력이 0보다 작거나 같을 때
                        if (temp2.Hp <= 0)
                        {
                            Console.WriteLine("{0} 을(를) 잡았다! 전투종료", temp2.Name);
                            //몬스터를 잡았으므로 게임종료
                            game = false;
                            break;
                        } //if문 종료
                        break;
                    //2번 입력시 실행(방어)
                    case 2:
                        //코드를 짧게 처리하기위해 방어데미지변수를 선언함
                        double blockDamage = 0;
                        //방어데미지공식 Math.Round로 반올림하여 소수점이 출력안되게 함
                        blockDamage = Math.Round(temp2.damage - ((temp2.damage - (temp.defence * 0.3)) * 0.4));

                        Console.WriteLine("{0} 공격을 방어했습니다 받은피해: {1},방어한 피해: {2} \n남은체력: {3}", temp2.Name, temp2.damage,
                            blockDamage, Math.Round(temp.Hp - (temp2.damage - blockDamage)));
                        Math.Round(temp.Hp -= (temp2.damage - blockDamage));
                        //공격을 하지않고 방어했으므로 플레이어의 스피드 수치 증가
                        temp.speed += 2;
                        break;
                    //3번 입력시 실행(도망)
                    case 3:
                        //도망확률을 정하기 위한 Random문 선언 주사위0~10까지
                        int runNum = 0;
                        Random run = new Random();
                        runNum = run.Next(0, 10 + 1);
                        //if문 시작 조건: 랜덤하게 정해진 수가 5보다 클 때
                        if (runNum > 5)
                        {
                            Console.WriteLine();
                            Console.WriteLine("도망에 성공했습니다.");
                            //도망성공 게임종료
                            game = false;
                            break;
                        }
                        else
                        {
                            //랜덤하게 정해진 수가 5이하 일 때 도망실패
                            //몬스터의 공격력이 1.5배가되어 공격받음 (defence수치로 인한 데미지감소 적용됨)
                            double UpDamage = 0;
                            UpDamage = temp2.damage * 1.5;
                            Console.WriteLine("도망 실패!\n{0} 의 데미지보너스 1.5배! 받은피해: {1} \n남은체력: {2}",
                                temp2.Name, UpDamage, temp.Hp - (UpDamage - (temp.defence * 0.3)));
                            Math.Round(temp.Hp -= (UpDamage - (temp.defence * 0.3)));
                            //도망실패시 플레이어의 스피드를 증가
                            temp.speed += 2;
                            //if문 시작 조건: 플레이어의 체력이 0보다 작거나 같을 때
                            if (temp.Hp <= 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("{0} 에게 죽었습니다. 게임종료", temp2.Name);
                                //플레이어가 죽었으므로 게임종료
                                game = false;
                                break;
                            } //if문 종료
                        } //if문 종료
                        break;
                } //switch문 종료
                Console.WriteLine();
                Console.WriteLine("===========================================");
            } //while문 종료
        } //Battle함수 종료
    } //Battles

    //플레이어가 선택할 캐릭터와 관련된 자식클래스 선언 (부모는 Creature)
    class Players : Creature
    {
        //플레이어가 선택할 캐릭터 함수
        public void Select()
        {
            //입력 예외처리를 위한 for문 시작 loop: 1번 돔
            for (int index = 0; index < 1; index++)
            {
                int userInPut = 0;
                Console.Write("캐릭터를 선택하세요.\n 1번: 김씨, 2번: 이씨, 3번: 박씨 : ");
                //string형식으로 입력받은 값을 int형식으로 변환
                int.TryParse(Console.ReadLine(), out userInPut);
                Console.WriteLine();
                //입력값에 따른 선택을 위한 switch문 시작 조건: userInPut
                switch (userInPut)
                {
                    //1번 선택시 실행
                    case 1:
                        //첫번째 캐릭터 고름
                        Player1();
                        break;
                    case 2:
                        Player2();
                        break;
                    case 3:
                        Player3();
                        break;
                    //입력 예외처리
                    default:
                        Console.WriteLine("잘못 입력했습니다. 다시 입력하세요.");
                        //for문을 다시 돌리기 위한 index--
                        index--;
                        break;
                } //switch문 종료
            } //for문 종료
        } //Select
        
        //첫번째 캐릭터 함수
        
        
        public void Player1()
        {
            this.name = "김씨";
            this.hp = 300;
            this.damage = 25;
            this.defence = 40;
            this.speed = 20;
            Console.WriteLine("1번 김씨를 선택했습니다.");
            Console.WriteLine("플레이어 {0} 의 정보: HP = {1}, 공격력 = {2}, 방어력 = {3}, 스피드 = {4}",
                name, hp, damage, defence, speed);
        } //Player1
        
        //두번째 캐릭터 함수
        public void Player2()
        {
            this.name = "이씨";
            this.hp = 200;
            this.damage = 40;
            this.defence = 10;
            this.speed = 26;
            Console.WriteLine("2번 이씨를 선택했습니다.");
            Console.WriteLine("플레이어 {0} 의 정보: HP = {1}, 공격력 = {2}, 방어력 = {3}, 스피드 = {4}",
                name, hp, damage, defence, speed);
        } //Player2

        //3번째 캐릭터 함수
        public void Player3()
        {
            this.name = "박씨";
            this.hp = 250;
            this.damage = 30;
            this.defence = 20;
            this.speed = 23;
            Console.WriteLine("3번 박씨를 선택했습니다.");
            Console.WriteLine("플레이어 {0} 의 정보: HP = {1}, 공격력 = {2}, 방어력 = {3}, 스피드 = {4}",
                name, hp, damage, defence, speed);
        } //Player3
    } //Player

    //몬스터의 정보를 총관리하는 Enemy클래스 (부모클래스 -> Creature)
    class Enemy : Creature
    {
        //몬스터의 타입별 자식함수들 중에서 랜덤하게 1개의 몬스터 정보를 가져오기 위한 함수
        public Enemy SetRandomEnemyType()
        {
            //자식클래스인 몬스터들을 선언
            Orcs orcs = new Orcs();
            Wolfs wolfs = new Wolfs();
            Random rd = new Random();
            int rdNum = rd.Next(1, 10 + 1);
            //랜덤한 몬스터 1개를 뽑기 위한 if문 시작 조건: 5이상
            if (rdNum <= 5)
            {
                //5이상의 수가 나오면 오크들중 한종류의 오크를 뽑음
                orcs.Setorc();
                //orcs에 값저장
                return orcs;
            }
            else
            {
                //5미만의 수가 나오면 늑대들중 한종류의 늑대를 뽑음
                wolfs.SteWolf();
                //wolfs에 값저장
                return wolfs;
            }
        } //SetRandomEnemyType
    }
    //오크종류의 몬스터를 모아둔 함수 (부모클래스 -> Enemy)
    class Orcs : Enemy
    {
        //오크중에서 랜덤하게 한마리를 뽑기위한 함수
        public void Setorc()
        {
            Random rd = new Random();
            int rdNum = rd.Next(1, 10 + 1);
            if (rdNum <= 5)
            {
                Orc();
            }
            else
            {
                RedOrk();
            }
        } //Setorc

        //기본오크 정보 함수
        public void Orc()
        {
            this.name = "오크";
            this.hp = 200;
            this.damage = 25;
            this.defence = 5;
            this.speed = 22;
        } //Orc
        //붉은오크 정보 함수
        public void RedOrk()
        {
            this.name = "붉은 오크";
            this.hp = 230;
            this.damage = 35;
            this.defence = 1;
            this.speed = 20;
        } //RedOrk
    } //Orcs

    //늑대종류의 몬스터를 모아둔 함수 (부모클래스 -> Enemy)
    class Wolfs : Enemy
    {
        //오크에서 단 주석과 동일함
        public void SteWolf()
        {
            Random rd = new Random();
            int rdNum = rd.Next(1, 10 + 1);
            if (rdNum <= 5)
            {
                Wolf();
            }
            else
            {
                BuleWolf();
            }
        } //SteWolf

        public void Wolf()
        {
            this.name = "늑대";
            this.hp = 100;
            this.damage = 50;
            this.defence = 10;
            this.speed = 24;
        } //Wolf
        public void BuleWolf()
        {
            this.name = "푸른 늑대";
            this.hp = 150;
            this.damage = 30;
            this.defence = 15;
            this.speed = 25;
        } //BuleWolf
    } //Wolfs

} //namespace
