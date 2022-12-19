using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsOperator
{
    internal class Progam2
    {
        static void Main(string[] args)
        {
            /*
             * 1.최대한도의 사탕사기
             * 현재 1000원이 있고 사탕의 가격이 300원 일 때, 최대 살 수 있는 사탕의 개수와 나머지 돈은 얼마인지 출력하는 프로그램.
             * ex)현재 가지고 있는 돈: 1000 (유저 입력하라)
             *    사탕의 가격: 300 (사탕의 가격은 상수)
             *    최대로 살 수 있는 캔디의 개수: 3
             *    사탕 구입 후 남은 돈: 100
            */
            //const int CANDY = 300; //1번 풀이
            //int money = default;
            //Console.Write("현재 가지고 있는 돈: ");
            //int.TryParse(Console.ReadLine(), out money);
            //Console.WriteLine("최대로 살 수 있는 캔디의 개수: {0}", money / CANDY);
            //Console.WriteLine("사탕 구입 후 남은 돈: {0}", money % CANDY);
            /* 
            * 2.화씨온도를 섭씨온도로 바꾸기
            * 우리나라는 섭씨 온도를 사용하지만, 미국에서는 화씨 온도를 사용한다.
            * 화씨 온도를 섭씨 온도로 바꾸는 프로그램을 작성.
            * ex) 화씨온도 60도는 섭씨온도 ??? 입니다.
           */
            //double f = default;
            //Console.Write("화씨온도를 입력하시오.: ");
            //double.TryParse(Console.ReadLine(), out f);
            //double c = (f - 32) / 1.8;
            //Console.WriteLine("화씨온도 {0}도는 섭씨온도 {1}도 입니다.", f, c);
            /* 
            * 3.주사위 게임
            * 2개의 주사위를 던져서 주사위의 합을 표시하는 프로그램을 작성. 주사위를 던지면 랜덤한 수가 나와야한다.
            * ex)첫번째 주사위:{0}
            *    두번째 주사위:{0}
            *    두 주사위 합:{0}
            */
            //var dice = new Random(); //Random(seed값) seed값을 안넣은것이 기본형태
            //int dice1 = dice.Next(1, 7), dice2 = dice.Next(1, 7); // Next(a,b)<< a이상 b미만 dice.Next(1, 6+1) 가독성업!
            //Console.WriteLine("첫번째 주사위:{0}, 두번째 주사위:{1}, 두 주사위 합:{2}", dice1, dice2, dice1 + dice2);

            /*
             * 제어문 소개
             * 프로그램을 이루는 3가지의 중요한 제어 구조에는 순차 구조(순차문), 선택 구조(조건문),반복 구조(반복문)가 있다.
             * 
             * 순차문
             * 프로그램은 기본적으로 Main() 메서드 시작 지점부터 끝 지점까지 코드가 나열되면 순서대로 실행 후 종료한다.
             * 
             * 제어문 (조건문과 반복문)
             * 프로그램 실행 순서를 제어하거나 프로그램 내용을 반복하는 작업 등을 처리할 때 사용하는 구문으로
             * 조건문과 반복문으로 구분한다.
             * 
             * 조건문(선택문)
             * 조건의 참 또는 거짓에 따라 서로 다른 명령문을 실행할 수 있는 구조이다.
             * 분기문 또는 비교 판단문이라고 하기도 한다.
             * 
             * 반복문
             * 특정 명령문을 지정된 수만큼 반복해서 실행할 때나 조건식이 참일 동안 반복시킬 때 사용한다.
             * 
             * if / else 문
             * 프로그램 흐름을 여러 가지 갈래로 가지치기(Branching)할 수 있는데, 이때 if 문을 사용한다.
             * if 문은 조건을 비교해서 판단하는 구문으로 if, else if, else 세가지 키워드가 있다.
             */
            //두개의 정수 중에서 더 큰 수를 찾는 프로그램
            //int numberX, numberY;
            //Console.Write("X 값을 입력하시오: ");
            //int.TryParse(Console.ReadLine(), out numberX);
            //Console.Write("Y 값을 입력하시오: ");
            //int.TryParse(Console.ReadLine(), out numberY);

            //if(numberY < numberX)
            //{
            //    Console.WriteLine("X가 Y보다 큽니다.");
            //}
            //else
            //{
            //    Console.WriteLine("Y가 X보다 큽니다.");
            //}
            /*
             * 컵의 사이즈를 받아서 100ml 미만은 small, 100ml 이상 200ml 미만은 medium, 200ml 이상은 large라고
             * 출력하는 if else 문을 작성
             */
            //int size;
            //Console.Write("컵의 사이즈를 입력하시오: ");
            //int.TryParse(Console.ReadLine(), out size);
            //if ( 0 < size && size < 100)
            //{
            //    console.writeline("컵의 사이즈는 small 입니다.");
            //}
            //else if (100 <= size && size < 200)
            //{
            //    Console.WriteLine("컵의 사이즈는 medium 입니다.");
            //}
            //else if (size >= 200)
            //{
            //    Console.WriteLine("컵의 사이즈는 large 입니다.");
            //}
            //else
            //{
            //    Console.WriteLine("사이즈를 잘못 입력하였습니다..");//예외처리
            //}
            /*
             * 비밀 코드 맞추기
             * 컴퓨터가 숨기고 있는 비밀 코드를 추측하는 게임을 작성
             * 비밀 코드는 a~z 사이의 문자
             * 컴퓨터는 사용자의 추측을 읽고서 앞에 있는지, 뒤에 있는지를 알려준다.(즉,사용자에게 힌트를 준다.)
             * ex)컴퓨터의 비밀코드: h (미리 초기화해서 변수에 가지고 있음.)
             * 비밀코드를 맞춰보세요:c (->User input)
             * c 뒤에 있음.
             * ---프로그램이 종료됨.---
             * 비밀코드를 맞춰보세요:c (->User input)
             * 정답입니다.
             */

            const char SECRET_CODE = 'h';
            char code = default;
            Console.Write("코드를 입력하세요: ");
            char.TryParse(Console.ReadLine(), out code);
            if (code < SECRET_CODE)
            {
                Console.WriteLine("비밀코드는 {0}보다 뒤입니다.", code);
            }
            else if (code > SECRET_CODE)
            {
                Console.WriteLine("비밀코드는 {0}보다 앞입니다.", code);
            }
            else
            {
                Console.WriteLine("정답입니다.");
            }

            const char SECRET_CODE2 = default;
            Console.Write("입력하세요: ");
           // char.TryParse(Console.ReadLine(), out SECRET_CODE2);
            bool isSmallAlphbet = false;
            bool isBigAlphbet = false;
            bool isAlphbet = false;
            isSmallAlphbet = ('a' <= SECRET_CODE2 && SECRET_CODE2 <= 'z');
            isBigAlphbet = ('A' <= SECRET_CODE2 && SECRET_CODE2 <= 'Z');

            isAlphbet = isSmallAlphbet || isBigAlphbet;
            if (isAlphbet)
            {
                Console.WriteLine("{0}은 알파벳이 맞습니다.", SECRET_CODE2);
            }
            else
            {
                Console.WriteLine("{0}은 알파벳이 아닙니다.", SECRET_CODE2);
            }

            /*
             * 세 개의 정수 중에서 큰 수 찾기
             * 사용자로부터 받은 3개의 정수 중에서 가장 큰 수를 찾는 프로그램 작성.
             * ex)3개의 정수를 입력하시오: 20 10 30 (어려운 버전)
             *    1번 정수를 입력하시오: 10 (같은방법으로 2번 3번 쉬운 버전)
             *    ===============================================
             *    가장 큰 정수는: ???
             */
            string[] numbers = new string[] { };
            Console.Write("3개의 정수를 입력하시오: ");
            numbers = Console.ReadLine().Split(',', 3);
            int num1, num2, num3 = default;
            int.TryParse(numbers[0], out num1);
            int.TryParse(numbers[1], out num2);
            int.TryParse(numbers[2], out num3);
            Console.WriteLine("{0},{1},{2}", num1, num2, num3);
            if (num1 < num2 || num1 < num3)
            {
                if (num2 < num3)
                {
                    Console.Write("{0} 가 가장 큼", num3);
                }
                else
                {
                    Console.Write("{0} 가 가장 큼", num2);
                }
            }
            else
            {
                Console.Write("{0} 가 가장 큼", num1);
            }


        }
    }
}
