using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Study
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
             * 1.자음과 모음 개수 세기
             * 사용자로부터 영문자를 받아서 자음과 모음의 개수를 세는 프로그램을 작성
             *-대, 소문자 모두 카운트 -
             *ex) a
             * b
             *c
             * d
             * e
             * 모음:2
             * 자음:3
             */
            
            //','로 구분되는 문자열들을 한글자씩 char형식으로 변환해서 모음,자음을 구분하고싶어서 혼자 머리짜봄
            string[] inPutStr = Console.ReadLine().Split(','); //inPutStr이라는 string배열안에 ','로 구분한 문자열들을 넣음
            List<char[]> cList = new List<char[]>(); //cList라는 char배열을 초기화함
            int vowels = 0; //모음값인 vowels
            int consonant = 0; //자음값인 consonant
            for (int i = 0; i < inPutStr.Length; i++) //i가 inPutStr의길이보다 작을 때 0부터 ++증감시킴
            {
                cList.Add(inPutStr[i].ToCharArray()); //string[]로 받은 문자열들을 char[]로 바꿔서 cList에 넣음
            }                                         //cList[]안에 char[]인 inPutStr가 들어가있음 배열안에 배열구조 (즉 cList[첫번째배열]안에[inPutStr배열] 이런식)
            for (int i = 0; i < cList.Count; i++) //배열안에 배열부터 계산해야되므로 2중 for문사용 i가 첫번째배열인 cList의 길이보다 작으면 0부터 ++증감됨
            {
                for (int j = 0; j < cList[i].Length; j++) //위for문에서 첫번째배열을 처리하므로 안에 있는 첫번째배열을 처리하기위해 cList[i]안의 길이를 조건으로 줌
                {                                         //cList[i].Length는 cList i번째 배열에 있는 배열의 길이임
                    switch (cList[i][j]) //switch문을 사용하여 cList[i]번째배열 [j]번째배열의 길이부터 쭉돔 (입력을 abab, abcd 이렇게 넣어도 a, b, a, b, a, b, c, d 이렇게 따로 구분하고싶어서 이렇게함
                    {
                        case 'a': //cList[i][j]의 값이 'a'이면 vowels값을 ++증감시킴
                        case 'e': //  동일
                        case 'i':
                        case 'o':
                        case 'u':
                        case 'A':
                        case 'E':
                        case 'I':
                        case 'O':
                        case 'U'://  동일
                            vowels++;
                            break; //여기서 끝냄
                        default : consonant++; //위에case로 구분한 모음값을 제외한 값들을 자음값인 consonant에 ++증감시킴
                            break; //여기서 끝냄
                    } //switch문의 끝
                }//for문의 끝
            }//for문의끝
            Console.WriteLine($"모음: {vowels}, 자음: {consonant}"); //모음과 자음값 출력
            //Console.WriteLine("모음{0}, 자음{1}", vowels, consonant);//다른방식의 출력


            //한 문자열을 입력받았을때 자음 모음 나누는 풀이
            string str = Console.ReadLine(); //문자열을 입력함
            int vowels2 = 0, cocsonants2 = 0; //모음값을 담을 vowels2, 자음값을 담을 cocsonants2
            for (int i = 0; i < str.Length; i++) //i가 문자열길이보다 낮을때 0부터 시작해서 ++증감해서 반복함
            {
                switch (str[i]) //str[i]<<입력한 문자열의 i번째 값 i는 0부터 시작하니 첫값부터 마지막값까지 돔
                {
                    case 'a': //str[i]값이 'a'일때 vowels2값을 ++증감시킴
                    case 'e': // 동일
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'A': //str[i]값이 'A'일떄 vowels2값을 ++증감시킴 (모음의 대소문자 구분위해 case여러개씀)
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U': //동일
                        vowels2++;
                        break; //여기서 끝낸다
                    default: //vowels의 속하지않은 것들은 자음인 cocsonants2값을 ++증감시킴
                        cocsonants2++;
                        break; //여기서 끝낸다
                } //swith문의 끝
            }//for문의 끝
            Console.WriteLine("모음{0}, 자음{1}", vowels2, cocsonants2); //모음과 자음값 출력


            /*
             * 2. 숫자 맞추기 게임
             * 숫자 알아맞히기 게임이다. 프로그램은 1~100 사이의 정수를 저장하고 있음.
             * 사용자는 질문을 통해서 숫자를 알아 맞힌다. 답을 제시하면 프로그램은 제시된 정수가
             * 더 낮은 값인지, 높은 값인지 알려준다. 사용자가 알아맞힐 때까지 루프한다.(기본형)
             * -프로그램을 수정하여 컴퓨터가 생성한 숫자를 사용자가 추측하는 대신에, 사용자가 결정한 번호를
             * 컴퓨터가 추측하도록 작성. 사용자는 컴퓨터가 추측한 숫자가 높거나 낮은지를 컴퓨터에 알려야 한다.
             * 컴퓨터가 맞힐 때까지 반복.-(어려움1)
             * -사용자가 결정한 값의 범위는 (1~100) 어떤 숫자를 생각하던 간에 7번 이하의 추측으로 컴퓨터가
             * 맞출 수 있도록 프로그램 (어려움1)을 수정하시오. (어려움2)
             */
            Random land = new Random(); //land라는 랜덤 변수를 주고 초기화
            int program = land.Next(1, 100 + 1); //컴퓨터가 정할 정수를 program 안에 land.Next를 이용하여 1~100+1값중 랜덤 1개를 넣음 (100+1인이유는 최상위값은 포함이안되서그럼)
            int answer = program; //program에 랜덤하게 정해진 정수가 정답
            int userInPut = 0; //유저가 입력할 값을 userInPut에 넣음
            while (userInPut != answer) //유저 입력 값이 정답이 아닐때 반복함
            {
                Console.Write("정수를 입력하시오. ");
                int.TryParse(Console.ReadLine(), out userInPut); //여기서 유저 입력 값을 넣음
                if (userInPut < answer) //만약 유저 입력 값이 정답보다 작다면 실행
                {
                    Console.WriteLine("{0}은 answer보다 작습니다.", userInPut);
                }
                else if (userInPut > answer) //위 if조건에 만족하지 않았을때 유저 입력 값이 정답보다 크다면 실행
                {
                    Console.WriteLine("{0}은 answer보다 큽니다.", userInPut);
                }
                else // 위 2개의 if문을 만족하지않았을때 즉 유저 입력 값이 정답과 동일할 때 실행
                {
                    Console.WriteLine("정답입니다.");
                }
            }
            //Random land = new Random(); //어려움2 시도해보다 시간부족으로 못품 1번문제에서 시간 다씀
            //int program = land.Next(1, 100 + 1);
            //int answer = 0;
            //int userInPut = 0;
            //Console.WriteLine("정답인 정수를 입력하시오. ");
            //int.TryParse(Console.ReadLine(), out answer);
            //while(program != answer)
            //{
            //    if(program < answer)
            //    {
            //        Console.WriteLine("정답은 {0}보다 큽니다.", program);
            //        //Console.WriteLine("힌트를 입력하시오: ");
            //        //int.TryParse(Console.ReadLine(), out userInPut);
            //        //Console.WriteLine("정답은 {0}보다 큽니다. ",userInPut);
            //    }
            //    else if(program > answer)
            //    {
            //        Console.WriteLine("정답은 {0}보다 작습니다.", program);
            //        //Console.WriteLine("힌트를 입력하시오.");
            //        //int.TryParse(Console.ReadLine(), out userInPut);
            //        //Console.WriteLine("정답은 {0}보다 작습니다. ", userInPut);
            //    }
            //    program = land.Next(1, 100 + 1); 
            //}
            //Console.WriteLine("{0}정답 입니다.", program);

            /*
             * 3. 산수 문제 자동 출제
             * 산수 문제를 자동으로 출제하는 프로그램을 작성해보자. 덧셈 문제들을 자동으로 생성하여야 한다.
             * 피연산자는 0~99사이의 숫자(난수) 한 번이라도 맞으면 종료. 틀리면 리트라이 (기본형)
             * -뺄셈, 곱셈, 나눗셈 문제도 출제(추가문제) -> 나눗셈 예외처리(무한대 값 주의)
             */
            Random land1 = new Random(); //land1라는 Random변수 선언
            Random land2 = new Random(); //land2라는 Random변수 선언
            int a = land1.Next(0, 99 + 1); //컴퓨터가 정할 랜덤변수를 a라는 변수에 land1.Next를사용하여 0부터 99+1까지 정수중 랜덤한 한개값을 저장 (99+1인 이유는 최대값은 제외되서 그럼)
            int b = land2.Next(0, 99 + 1); // 동일
            int answer2 = a + b; //a라는 랜덤변수와 b라는 랜덤변수의 합을 정답으로 정함
            int userInPut2 = 0; //유저가 입력할 값 변수
            while (userInPut2 != answer2) //userInPut2가 answer2와 같지 않을 때 반복 위에 미리 a,b값을 정해둔건 while문들어오는 조건을 만족하기위해서임
            {                             //a,b 둘다 0이나 default 초기화하면 answer2값은 userInPut2 값과 동일하기 때문에 while문실행안됨
                                          
                a = land1.Next(0, 99 + 1); //새롭게 a에 랜덤값 부여
                b = land2.Next(0, 99 + 1); // 동일
                answer2 = a + b; //새로부여된 a, b의 합
                Console.Write("{0} + {1} = ", a, b); //문제를 눈으로 확인할 수 있게 출력
                int.TryParse(Console.ReadLine(), out userInPut2); //ReadLine으로 받는 입력값은 string형식이라 int형식으로 변환함
                if (userInPut2 == answer2) //userInPu2값이 answer2값과 동일하면 if문실행
                {
                    Console.WriteLine("정답 입니다. 프로그램을 종료합니다. "); //userInPut2값과 answer2값이 같으므로 정답출력
                } //if문 끝
            } //while문 끝 (userInPut2값이 answer2값과 != 즉 같지않을 때 반복하고 == 같게되면 끝

            //while (userInPut2 != answer2) //위와 동일한 코드인데 연산자만 - 임(뺄셈문제)
            //{
            //    a = land1.Next(0, 99 + 1);
            //    b = land2.Next(0, 99 + 1);
            //    answer2 = a - b;
            //    Console.Write("{0} - {1} = ", a, b);
            //    int.TryParse(Console.ReadLine(), out userInPut);
            //    if (userInPut2 == answer2)
            //    {
            //        Console.WriteLine("정답 입니다. 프로그램을 종료합니다. ");
            //    }
            //}

            //while (userInPut2 != answer2) //위와 동일한 코드인데 연산자만 * 임(곱셈문제)
            //{
            //    a = land1.Next(0, 99 + 1);
            //    b = land2.Next(0, 99 + 1);
            //    answer2 = a * b;
            //    Console.Write("{0} * {1} = ", a, b);
            //    int.TryParse(Console.ReadLine(), out userInPut);
            //    if (userInPut2 == answer2)
            //    {
            //        Console.WriteLine("정답 입니다. 프로그램을 종료합니다. ");
            //    }
            //}

        }
    }
}