using System;
using System.Globalization;
using System.Xml;

namespace WhatIsFunction
{
    internal class Program2
    {
        //1번 함수
        static void SayHello(int loopNumber)
        {
            for (int i = 0; i < loopNumber; i++)
            {
                Console.WriteLine("Hello");
            }
        }
        //2번 함수
        static void Maximum(int x, int y, int z)
        {
            int max = Math.Max(x, Math.Max(y, z));
            Console.WriteLine("{0}, {1}, {2} 중 가장 큰값은: {3} 입니다.", x, y, z, max);
        }

        //3번 함수
        static void Hypot(double side1, double side2)
        {
            double hypotenuse = Math.Sqrt((side1 * side1) + (side2 * side2));
            Console.WriteLine("빗변의 길이는: {0:F4} 입니다", hypotenuse); //F4 끝자리 몇글자까지 출력할것인지 표현 F2는 2자리
        }

        //4번 함수
        static void Prime(int numbers)
        {
            for (int i = 2; i <= numbers; i++)
            {
                int j = 2;
                while (i > j)
                {
                    if (i % j == 0)
                    {
                        break;
                    }
                    else
                    {
                        j++;
                    }
                }
                if (i == j)
                {
                    Console.Write("{0}, ", i);
                }
            }
        }
        //소수뽑기 다른풀이
        static void Prime2(int numbers)
        {
            Console.WriteLine("2~100사이의 값 중에서 소수 출력하는 프로그램");
            for (int index = 2; index <= numbers; index++)
            {
                if (FindPrime2(index))
                {
                    Console.Write("{0} ", index);
                }
            }
        }
        static bool FindPrime2(int numbers)
        {
            bool isPrime = true;
            for (int index = numbers - 1; 2 <= index; index--)
            {
                if (numbers % index == 0)
                {
                    isPrime = false;
                    break;
                }
                else
                {
                    continue;
                }
            }//loop: 소수를 찾을 숫자 -1~2까지 나눠보는 루프
            return isPrime;
        }
        //소수뽑기 다른풀이 종료 함수 2개씀

        //5번 함수
        static void PhonNumber(string phoneNum)
        {
            bool Pn = false;
            while (Pn == false)
            {

                Console.Write("전화번호를 입력하세요. [ex) (010)1234-5678] : ");
                phoneNum = Console.ReadLine();
                if (phoneNum == "quit")
                {
                    Console.WriteLine("프로그램을 종료합니다.");
                    Pn = true;
                }
                string a = phoneNum.Replace("(", "");
                string b = a.Replace(")", "");
                string changePhoneNum = b;
                Console.WriteLine("입력한 전화번호는 : {0} 입니다.", changePhoneNum);
            }
        }

        //6번 함수
        static void Reverse(string inPut)
        {
            Console.Write("입력하시오. : ");
            inPut = Console.ReadLine();
            char[] h = inPut.ToCharArray();
            Array.Reverse(h);
            Console.WriteLine(h);
        }
        static void Main(string[] args)
        {
            //1. 화면에 "Hello"를 출력하는 SayHello()함수를 작성.
            //-int 타입 매개변수 받아서 그 횟수만큼 "Hello"를 반복해서 출력.
            int loopNumber = 4;
            SayHello(loopNumber);

            //2. 3개의 정수 중에서 최대값을 찾는 함수 Maximum(x,y,z)를 정의할 것.
            int x = 50;
            int y = 70;
            int z = 40;
            Maximum(x, y, z);

            /**
             * 3. 다른 두 변이 주어 졌을 때 직각 삼각형의 빗변을 계산하는 함수 Hypot()를 정의할 것.
             * 매개변수는 2개 타입은 double 형
             * 리턴 타입도 double 형
             */
            double side1 = 3;
            double side2 = 4;
            Hypot(side1, side2);

            //4. 주어진 숫자가 소수인지 여부를 찾는 함수 Prime()을 작성.
            //-판별할 값의 범위는 2~100 사이의 값 중에서 소수는 모두 출력
            int numbers = 100;
            Prime(numbers);
            Console.WriteLine();
            Prime2(numbers);
            Console.WriteLine();

            //5. 사용자가 입력하는 전화번호에서 소괄호를 삭제한 형태로 출력하는 프로그램 작성(함수사용)
            //-전화번호를 입력 받는다. -> 소괄호를 삭제한 형태로 출력한다
            //-quit 입력하면 프로그램을 종료한다.
            //-프로그램 종료 전까지 전화번호를 입력 받는다.
            string phoneNum = default;
            PhonNumber(phoneNum);

            //6. 입력받은 문자열은 뒤집어서 출력하기
            string inPut = default;
            Reverse(inPut);
        }
    }
}
