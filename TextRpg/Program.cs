using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace TextRpg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //타이틀 씬
            Console.WriteLine("=============================");
            Console.WriteLine("===== 타     이      틀 =====");
            Console.WriteLine("=============================");
            Console.WriteLine();
            Console.WriteLine("계속 하려면 아무거나 입력하세요.");
            Console.ReadLine();

            //선택지를 포함한 이벤트->유저가 선택 가능한 형태
            string[] item = { "장검", "지팡이", "활", "창", "머신건" };
            int[] itemInfo = {10, 11,15,3,200 };
            Random startItem = new Random();
            int a = startItem.Next(0, 5);
            Console.WriteLine("items: {0}를 (데미지{1}) 얻었습니다", item[a], itemInfo[a]);

            Console.WriteLine("=====================================================");
            Console.WriteLine("당신은 동굴을 탐험하다 돌이 쌓인 돌탑을 발견했습니다." +
                "\n돌탑을 살펴보자 틈사이로 빛나는 무언가를 발견했습니다.");
            Console.WriteLine("=====================================================");

            Console.WriteLine();
            Console.WriteLine("선택1: 돌을 치워 무언가를 얻는다");
            Console.WriteLine("선택2: 무시하고 갈 길 간다.");
            Console.WriteLine("선택1 -> 1 입력 , 선택2 -> 2 입력");
            int userInPut = 0;
            for (int index = 0; index < 1; index++)
            {
                int.TryParse(Console.ReadLine(), out userInPut);
                if (userInPut == 1)
                {
                    Console.WriteLine("1 번 선택");
                }
                else if (userInPut == 2)
                {
                    Console.WriteLine("2 번 선택");
                }
                else
                {
                    Console.WriteLine("잘못 입력 하셨습니다. 다시 선택하세요.");
                    index--;
                }
            }
            Console.WriteLine();
            switch (userInPut)
            {
                case 1:
                    Console.WriteLine("낡은 보물상자를 얻었다!");
                    break;
                case 2:
                    Console.WriteLine("무시하고 탐험시작.");
                    break;
            }
            Console.WriteLine();

            //전투
            int playerHp = 100;
            int playerAttack = 17;
            Random number = new Random();

            string[] monsters = new string[] { "늑대", "오크", "슬라임", "닭" };
            int[] monAttack = new int[4];
            int[] monHp = new int[4];
            for(int index = 0; index <5; index++)
            {
                if(index == 0)
                {
                    monAttack[index] = number.Next(7, 15 + 1);
                    monHp[index] = number.Next(40, 60 + 1);
                }
                else if(index == 1)
                {
                    monAttack[index] = number.Next(10, 20 + 1);
                    monHp[index] = number.Next(80, 110 + 1);
                }
                else if(index == 2)
                {
                    monAttack[index] = number.Next(5, 10 + 1);
                    monHp[index] = number.Next(70, 90 + 1);
                }
                else if(index == 3)
                {
                    monAttack[index] = number.Next(15, 30 + 1);
                    monHp[index] = number.Next(20, 30 + 1);
                }
            }
            int monsterNumber = number.Next(0, 4 - 1);
            int monsterAttack = monAttack[monsterNumber];
            int monsterHp = monHp[monsterNumber]; 

            Console.WriteLine("{0} 이(가) 나타났다! 전투준비\n체력: {1}, 공격력: {2}", monsters[monsterNumber],monsterHp ,monsterAttack);
            Console.WriteLine();
            
            while (playerHp > 0)
            {
                monsterHp -= playerAttack;
                Console.WriteLine("플레이어가 {0} 에게 {1} 데미지 만큰 공격!\n남은 플레이어 HP = {2}, {3} 의 HP = {4}",
                    monsters[monsterNumber], playerAttack, playerHp, monsters[monsterNumber], monsterHp);
                if (monsterHp <= 0)
                {
                    Console.WriteLine("승리! {0} 을(를) 잡았습니다.", monsters[monsterNumber]);
                    break;
                }
                else
                {
                    Console.WriteLine();
                    playerHp -= monsterAttack;
                    Console.WriteLine("{0} 이(가) 플레이어에게 {1} 데미지 만큰 공격!\n남은 플레이어 HP = {2}, {3} 의 HP = {4}",
                    monsters[monsterNumber], monsterAttack, playerHp, monsters[monsterNumber], monsterHp);
                    if (playerHp <= 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("{0} 에게 죽었습니다", monsters[monsterNumber]);
                        break;
                    }
                }
                Console.WriteLine();
            }
            /*
             * 1. 사용자로부터 2개의 문자열을 읽어서 같은지 다른지 화면에 출력하는 프로그램 작성
             * ex) 첫번째 문자열: Hello
             *     두번째 문자열: World
             *     2개의 문자열은 다릅니다.
             *-Equals 메서드를 사용하지 않을 것.
             *hint - Lenth 를 비교 ?
             */
            //Console.Write("문자를 입력하시오: ");
            //string messageA = Console.ReadLine();
            //Console.Write("문자를 입력하시오: ");
            //string messageB = Console.ReadLine();
            //if(messageA == messageB)
            //{
            //    Console.WriteLine("2개의 문자열 {0} 와 {1} 은(는) 같습니다.", messageA, messageB);
            //}
            //else
            //{
            //    Console.WriteLine("2개의 문자열 {0} 와 {1} 은(는) 다릅니다.", messageA, messageB);
            //}

            ///*
            // * 2. 5개의 음료(콜라, 물, 스프라이트, 주스, 커피)를 판매하는 자판기 머신을 구현해보기
            // * 사용자가 1부터 5사이의 숫자를 입력함.
            // * 선택한 음료를 출력함.
            // * 1~5 이외의 숫자를 선택하면 오류 메시지 출력함.
            // * hint - switch 문이나, if/else 문을 사용한다.
            // */
            //int[] drink = { 1, 2, 3, 4, 5 };
            //int userInPut = 0;
            //for(int index = 0; index <1; index++)
            //{
            //    Console.Write("콜라(1), 물(2), 스프라이트(3), 주스(4), 커피(5) 중 선택하시오.");
            //    int.TryParse(Console.ReadLine(), out userInPut);
            //    Console.WriteLine();
            //    switch (userInPut)
            //    {
            //        case 1 :
            //        Console.WriteLine("콜라 를 뽑았습니다.");
            //            break;
            //        case 2 :
            //        Console.WriteLine("물 을 뽑았습니다.");
            //            break;
            //        case 3 :
            //            Console.WriteLine("스프라이트 를 뽑았습니다.");
            //            break;
            //        case 4 :
            //            Console.WriteLine("주스 를 뽑았습니다.");
            //            break;
            //        case 5 :
            //            Console.WriteLine("커피 를 뽑았습니다.");
            //            break;
            //        default :
            //            Console.WriteLine("잘못 입력하셨습니다.");
            //            Console.WriteLine();
            //            index -= 1;
            //            break;
            //    }
            //}
            //Console.WriteLine();
            ///*
            // * 3. 배열 days[]를 아래와 같이 초기화하고 배열 요소의 값을 다음과 같이 출력하는 프로그램 작성
            // * 배열 days[]는 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
            // * ex) 1월은 31일까지 입니다..
            // *     2월은 29일까지 입니다..
            // * hint - 배열의 초기화는 중괄호를 사용한다.
            // */
            //int[] days = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            //for(int index = 0; index <12;index++)
            //{
            //    Console.WriteLine("{0} 월은 {1} 일까지 입니다.", index + 1, days[index]);
            //}

        }
    }
}
