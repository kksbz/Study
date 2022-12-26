﻿using System;
using System.Security.Cryptography.X509Certificates;

namespace WhatIsFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////별찍기 직각 삼각형 했었던거
            ////별을 초기화 하는 코드
            //string[,] starArray = new string[5, 5];
            //for(int y = 0; y <5; y++)
            //{
            //    for(int x = 0; x <5; x++)
            //    {
            //        starArray[y, x] = "*";
            //    }
            //} //loop : 별을 배열에 초기화 하는 루프

            ////별을 출력하는 코드
            //for(int y = 0; y < 5; y++)
            //{
            //    for(int x = 0; x < 5; x++)
            //    {
            //        if (starArray[y, x].Equals("*"))
            //        {
            //            Console.Write("{0} ", starArray[y, x]);
            //        }
            //    }
            //    Console.WriteLine();
            //} //배열의 담긴 별을 출력하는 루프

            /**
             * 함수(Function) 또는 메서드(Method)는 재사용을 목적으로 만든 특정 작업을 수행하는 코드 블록이다.
             * 함수를 부르는 다양한 명칭
             * 함수(Function)
             * 메서드(Method) -> class 맴버(속에있다)함수를 특히 메서드라 함 (즉 class 안에있으면 메서드라함)
             * 프로시저(Procedure)
             * 서브루틴(Subroutine)
             * 서브모듈(Submodule)
             * 
             * 프로그래밍을 하다 보면 같은 유형의 코드를 반복할 때가 많다. 이 코드들을 매번 입력하면 불편하고
             * 입력하다 실수도 할 수 있다. 이때 '함수'를 사용한다.
             * 
             * 프로그래밍 언어에서 함수는 어떤 동작 및 행위를 표현한다. 함수의 사용 목적은 코드 재사용에 있다.
             * 한 번 만들어 놓은 함수는 프로그램에서 한 번 이상 사용할 수 있다.
             * 지금까지 사용한 main() 메서드는 c#의 시작 지점을 나타내는 특수한 목적의 함수로 볼 수 있다.
             * 또, Console 클래스의 WriteLine() 메서드도 함수로 볼 수 있다.
             * 
             * - 함수란 어떤 값을 받아서 그 값을 가지고 가공을 거쳐 어떤 결과값을 반환시켜 주는 코드
             * - 함수는 프로그램 코드 내에서 특정한 기능을 처리하는 독립적인 하나의 단위 또는 모듈을 가리킨다.
             * 
             * 입력 -> 처리 -> 출력
             * 
             * 함수의 종류(내장 함수와 사용자 정의 함수)
             * 함수에는 내장 함수와 사용자 정의 함수가 있다. 내장 함수는 c#이 자주 사용하는 기능을 미리 만들어서
             * 제공하는 함수로, 특정 클래스의 함수로 표현된다.
             * 내장 함수도 그 용도에 따라 문자열 관련 함수, 날짜 및 시간 관련 함수, 수학 관련 함수, 형식 변환 관련 함수
             * 등으로 나눌 수 있다. 이러한 내장 함수를 API(Application programming Interface)로 표현한다.
             * 사용자 정의 함수는 내장 함수와 달리 프로그래머가 필요할 때마다 새롭게 기능을 추가하여 사용하는 함수이다.
             * 
             * 함수 정의하고 사용하기
             * 함수 정의(Define)는 함수를 만드는 작업이다. 함수 호출(Call)은 함수를 사용하는 작업이다. 함수 생성 및
             * 호출은 반드시 소괄호가 들어간다. 함수를 정의하는 형태는 지금까지 사용한 main() 메서드와 유사하다.
             * 다음 코드는 함수를 만드는 가장 기본적인 형태를 보여준다.
             * static void 함수이름()
             * {
             *     함수내용
             * }
             * 
             * 만든 함수를 호출하는 형태는 다음 세 가지가 있다.
             * 함수이름();
             * 함수이름(매개변수);
             * 변수(결과값) = 함수이름(매개변수);
             */

            show();

        } //main종료

        // Hello World! 출력하는 사용자 정의 함수
        // static인 이유는 메인메서드가 static으로 시작해서 지우면 함수사용안됨
        static void show()
        {
            Console.WriteLine("Hello World!");
            /**
             * 이 함수는 가장 간단한 형태의 함수로, 매개변수(Parameter)도 없고 반환값(Return Value)도 없는 형태이다.
             */
        }
    } //class
}