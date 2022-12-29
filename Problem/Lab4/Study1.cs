using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Lab
{
    internal class Study1
    {
        static void Main(string[] args)
        {
            ////1. 보유한 금액에서 최대한도로 커피를 사고 남은 금액 출력
            ////보유한 금액 입력, 커피가격 = 2000원
            //int money = 0;
            ////커피값은 변하지않으므로 상수로 선언
            //const int COFFEE = 2000;
            ////예외처리를 위한 for문 시작
            //for(int index = 0; index < 1; index++)
            //{
            //    Console.Write("보유한 금액을 입력하시오. ");
            //    //string형식으로 입력받은 money값을 int형식으로 변환함
            //    int.TryParse(Console.ReadLine(), out money);
            //    Console.WriteLine();
            //    //if문 시작 조건: money값이 0보다 클때 실행
            //    if(money > 0)
            //    {
            //        //money값이 0보다 큰 정수이므로 출력
            //        Console.WriteLine("보유한 금액은 {0} 원 입니다.", money);
            //    }
            //    else
            //    {
            //        //money값이 정수가 아닐때 출력
            //        Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요. ");
            //        Console.WriteLine();
            //        //money값을 다시 입력받기위한 반복을 해야하므로 index--로 증감식적용
            //        index--;
            //    } //if문 종료
            //} //for문 종료
            //// '/'로 커피를 산 갯수를 구하고 '%'로 나머지 금액을 구함
            //Console.WriteLine("보유금액으로 {0} 개의 커피를 사고 남은 금액은 {1} 원 입니다.", money / COFFEE, money % COFFEE);

            /*
             * 비밀코드 맞추기
             * 컴퓨터가 숨기고 있는 비밀 코드를 추측하는 게임을 작성
             * 비밀 코드는 a~z 사이의 문자
             *컴퓨터는 사용자의 추측을 읽고서 앞에 있는지, 뒤에 있는지를 알려준다.(즉, 사용자에게 힌트를 준다.)
             * ex)컴퓨터의 비밀코드: h(미리 초기화해서 변수에 가지고 있음.)
             * 비밀코드를 맞춰보세요: c(->User input)
             * c 뒤에 있음.
             *---프로그램이 종료됨.-- -
             *비밀코드를 맞춰보세요: c(->User input)
             * 정답입니다.
             */

            //Random randomChar = new Random();
            ////비밀코드는 알파벳중 하나이므로 char형식으로 선언
            //char secretCode = default;
            ////비밀코드를 알파벳 소문자,대문자 중 하나로 뽑기위한 알파벳 선언
            //string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            ////string형식으로 입력받은 alphabet을 char형식으로 쪼개서 atoz배열안에 저장
            //char[] atoz = alphabet.ToCharArray();
            ////secretCode안에 atoz배열 값중 하나를 랜덤하게 저장
            //secretCode = atoz[randomChar.Next(0, atoz.Length)];
            ////힌트를 주기 위한 if문 시작 조건: secretCode가 'a'와 같거나 크고 'z'와 같거나 작음을 만족
            //if (secretCode <= 'z' && secretCode >= 'a')
            //{
            //    Console.WriteLine("힌트: 비밀코드는 소문자 입니다.");
            //}
            //else
            //{
            //    Console.WriteLine("힌트: 비밀코드는 대문자 입니다.");
            //}

            //char userInPut = default;
            //bool smallAlphabet = false;
            //bool bigAlphabet = false;
            //bool isAlphabet = false;
            ////첫번째 for문 시작 loop: 1번도는 루프
            //for (int index = 0; index < 1; index++)
            //{
            //    //입력 예외처리 두번째 for문 시작 loop: 1번도는 루프
            //    for (int index2 = 0; index2 < 1; index2++)
            //    {
            //        Console.WriteLine("a~z(대문자 또는 소문자) 중 한가지를 입력해주세요.");
            //        //string형식으로 입력받은 값을 char형식으로 변환
            //        char.TryParse(Console.ReadLine(), out userInPut);
            //        //userInPut값이 대소문자인지 구분하기위한 변수선언
            //        smallAlphabet = ('a' <= userInPut && userInPut <= 'z');
            //        bigAlphabet = ('A' <= userInPut && userInPut <= 'Z');
            //        isAlphabet = smallAlphabet || bigAlphabet;
            //        //if문 시작 조건: userInPut값이 소문자 또는 대문자일때
            //        if (isAlphabet)
            //        {
            //            //소문자 또는 대문자이므로 그대로 실행
            //        }
            //        else
            //        {
            //            //소문자 또는 대문자가 아니므로 오류출력
            //            Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요. ");
            //            //새로운 값을 입력받기위해 for문을 다시 돌려야하므로 index2--증감식 사용
            //            index2--;
            //        } //if문 종료
            //    } //두번째 for문 종료

            //    //위에 두번째 for문이 끝나고 시작되는 첫번째 if문 시작 조건: userInPut값이 secretCode와 다를때
            //    if (userInPut != secretCode)
            //    {
            //        //두번째 if문 시작 조건: userInPut값이 sceretCode값보다 클때
            //        if (userInPut > secretCode)
            //        {
            //            //userInPut값이 sceretCode값보다 크므로 힌트 출력
            //            Console.WriteLine("입력한 {0} 은(는) 비밀코드보다 뒤에 있습니다. ", userInPut);
            //            //첫번째 for문을 다시 돌리기위해 index-- 증감식 사용
            //            index--;
            //        }
            //        //조건: userInPut값이 sceretCode값보다 작을 때
            //        else if (userInPut < secretCode)
            //        {
            //            //힌트 출력
            //            Console.WriteLine("입력한 {0} 은(는) 비밀코드보다 앞에 있습니다. ", userInPut);
            //            //첫번째 for문을 다시 돌리기위해 index-- 증감식 사용
            //            index--;
            //        } //두번째 if문 종료
            //    }
            //    else
            //    {
            //        //userInPut값과 secretCode값이 같으므로 정답출력
            //        Console.WriteLine("정답입니다.");
            //    } //첫번째 if문 종료
            //} //첫번째 for문 종료

            //숫자야구
            //비밀코드를 담을 secretNumber int형 List 선언
            List<int> secretNumber = new List<int>();
            //랜덤선언
            Random computer = new Random();
            //secretNumber 안에 저장될 code 선언
            int code = 0;
            //비밀코드는 3개이므로 for문 시작 loop: 3번루프
            for (int index = 0; index < 3; index++)
            {
                //비밀코드를 중복없는 랜덤난수로 넣기위한 do while문 시작
                do
                {
                    //code 안에 1부터 9+1 범위중 랜덤정수 1개 저장
                    code = computer.Next(1, 9 + 1);
                }
                //secretNumber 안에 code값과 같은 값이 존재하면 do로 올라가 반복
                while (secretNumber.Contains(code));
                //secretNumber 안에 code값 저장
                secretNumber.Add(code);
                Console.Write("{0}, ", secretNumber[index]); // do while문 종료
            } //for문 종료
            //공백처리
            Console.WriteLine();
            
            int[] userNumber = new int[3];
            int userInPut = 0;
            for (int index = 0; index < 3; index++)
            {
                Console.Write("1~9 사이의 {0}번째 숫자를 입력하세요. : ", index+1);
                int.TryParse(Console.ReadLine(), out userInPut);
                userNumber[index] = userInPut;
                Console.WriteLine();
                if (userNumber[index] > 0 && userNumber[index] < 10)
                {
                }
                else if (userNumber[0].Equals(userNumber[1]) || userNumber[0].Equals(userNumber[2]) || userNumber[1].Equals(userNumber[2]))
                {
                    Console.WriteLine("중복된 숫자를 입력하셨습니다. 다시 입력하세요.");
                    Console.WriteLine();
                    index--;
                }
                else
                {
                    Console.WriteLine("잘못된 숫자를 입력하셨습니다. 다시 입력하세요.");
                    Console.WriteLine();
                    index--;
                }
            }
            Console.WriteLine("{0}, {1}, {2}", userNumber[0], userNumber[1], userNumber[2]);


        }
    }
}
