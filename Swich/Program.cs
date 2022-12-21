using System;
namespace Swich
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
             * 선택문인 switch 문은 값에 따라 다양한 제어를 처리할 수 있다. 조건을 처리할 내용이 많은 경우 유용하다.
             * switch, case, default 키워드를 사용하여 조건을 처리한다. 
             */
            //Console.WriteLine("정수 1, 2, 3 중에 하나를 입력하시오: ");
            //int switchNumber = 0;
            //int.TryParse(Console.ReadLine(), out switchNumber);

            //switch (switchNumber)
            //{
            //    case 1:
            //        Console.WriteLine("1을(를) 입력했습니다. ");
            //        break;
            //    case 2:
            //        Console.WriteLine("2을(를) 입력했습니다. ");
            //        break;
            //    case 3:
            //        Console.WriteLine("3을(를) 입력했습니다. ");
            //        break;
            //    default:
            //        Console.WriteLine("처리하지 않은 예외 입력입니다. ");
            //        break;
            //}
            //switch
            /*
             * 중간점검
             * 1. case 절에서 break 문을 생략하면 어떻게 되는가?
             */
            //switch (switchNumber)
            //{
            //    case 1:
            //        Console.WriteLine("1을(를) 입력했습니다. ");
            //        goto case 3;
            //    case 2:
            //    case 3:
            //        Console.WriteLine("3을(를) 입력했습니다. ");
            //        break;
            //    default:
            //        Console.WriteLine("처리하지 않은 예외 입력입니다. ");
            //        break;
            //}       //goto case? ->?로 바로 넘어감 (추천되지않는 방식)

            //Console.WriteLine("가장 좋아하는 프로그래밍 언어는? ");
            //Console.Write("1. c\t");
            //Console.Write("1. c++\t");
            //Console.Write("1. c#\t");
            //Console.Write("1. Java\t");
            //int choice = Convert.ToInt32(Console.ReadLine());
            //switch (choice)
            //{
            //    case 1:
            //        Console.WriteLine("c 선택");
            //        break;
            //    case 2:
            //        Console.WriteLine("c++ 선택");
            //        break;
            //    case 3:
            //        Console.WriteLine("c# 선택");
            //        break;
            //    case 4:
            //        Console.WriteLine("Java 선택");
            //        break;
            //    default:
            //        Console.WriteLine("예외 입력입니다. ");
            //        break;
            //}     //switch

            //Console.WriteLine("오늘의 날씨는 어떤가요? (맑음, 흐림, 비, 눈, ...)");
            //string weather = Console.ReadLine(); //날씨 입력
            //switch (weather) //swich문에 weather값을 입력받아 아래 실행
            //{
            //    case "맑음": //weather값이 맑음 일 때 실행
            //        Console.WriteLine("오늘 날씨는 맑군요.");
            //        break; //맑은 조건 실행 후 종료
            //    case "흐림": //weather값이 흐림 일 때 실행
            //        Console.WriteLine("오늘 날씨는 흐리군요.");
            //        break; //흐림 조건 실행 후 종료
            //    case "비": //weather값이 비 일 때 실행
            //        Console.WriteLine("오늘 날씨는 비가 오는군요.");
            //        break; //비 조건 실행 후 종료
            //    default: //weather값이 case조건과 모두 일치하지 않을 때 실행(예외처리)
            //        Console.WriteLine("혹시 오늘 눈이 오나요?");
            //        break; //종료
            //}       //switch 종료

            /*
             * while 문은 조건식이 참일 동안 문장을 반복 실행한다.
             */
            //while 문은 반복문인데 5번 실행할 예정

            //int loopCounter = 0;
            //while (loopCounter < 5)
            //{
            //    Console.WriteLine("{0}반복문이 정말로 5번만 실행되나?", loopCounter + 1);
            //    loopCounter++;
            //}       //loop : 5번만 도는 루프

            ////10~1카운트 후 발사 출력하는 프로그램 작성
            //int loopCounter2 = 10;
            //while (loopCounter2 > 0)
            //{
            //    Console.WriteLine("{0}초 후에 발사!", loopCounter2);
            //    loopCounter2 -= 1;
            //}

            //구구단 출력하는 프로그램 작성. user input 받아서 해당 단을 출력
            //구구단 출력 프로그램 작성
            //int userInPut = 0;
            //Console.Write("구구단 중에서 출력하고 싶은 단 입력: ");
            //int.TryParse(Console.ReadLine(), out userInPut); //string형식으로 입력받은걸 int형식으로 변환함.
            //const int timeTableLoopCount = 9; //1단~9단까지 구하기위해 loopCount를 9로 설정.
            //int timeTableLoopStart = 1; //1단부터 구하기위해 설정
            //while (timeTableLoopStart <= timeTableLoopCount) //while문 시작 
            //{                                                   //timeTableLoopStart 값이 timeTableLoopCount과 작거나 같을때까지 반복함.
            //    Console.WriteLine("{0}*{1}={2}", userInPut, timeTableLoopStart, userInPut * timeTableLoopStart);
            //    timeTableLoopStart++; //while문이 반복할때마다 timeTableLoopStart를 1씩 더해서 userInPut * 1, userInPut * 2...출력하기위해 설정
            //} //while 종료

            /*
             * 1.프로그램 사용자로부터 양의 정수를 하나 입력 받아서, 그 수만큼 "Hello World!"를 출력하는 프로그램 작성
             * //양의 정수를 입력 받음 ->예외처리하라는 것.
             */
            //int number = default;
            //Console.Write("양의 정수를 입력하시오: ");
            //int.TryParse(Console.ReadLine(), out number);
            //while (number > 0)
            //{
            //    Console.WriteLine("Hello World!");
            //    number--;
            //}
            //if (number <= 0)
            //{
            //    Console.WriteLine("잘못 입력");
            //}

            /* 2.프로그램 사용자로부터 양의 정수를 하나 입력 받은 다음, 그 수만큼 3의 배수를 출력하는 프로그램 작성
             * ex) User input -> 5 //양의 정수를 입력 받음 ->예외처리하라는 것.
             * "3, 6, 9, 12, 15"
             */
            //int number2 = default;
            //int loopN = 1;
            //Console.Write("양의 정수를 입력하시오: ");
            //int.TryParse(Console.ReadLine(), out number2);
            //while (number2 > 0)
            //{
            //    Console.Write("{0},", 3 * loopN);
            //    loopN++;
            //    number2--;
            //}
            //if (number2 <= 0)
            //{
            //    Console.WriteLine("잘못 입력");
            //}
            //Console.WriteLine();

            /*
             * 3.프로그램 사용자로부터 계속해서 정수를 입력 받는다. 그리고 그 값을 계속해서 더해 나간다. 이러한 작업은
             * 프로그램 사용자가 0을 입력할 때까지 계속되어야 하며, 0이 입력되면 입력된 모든 정수의 합을 출력하고 프로그램 종료
             * ex) User input -> 1
             * ex) User input -> 10
             * ex) User input -> 0
             * "모든 정수의 합: 11"
             */
            //int userInPut = 1;
            //int sum = default;
            //while(userInPut != 0)
            //{
            //    Console.Write("정수를 입력하시오: ");
            //    int.TryParse(Console.ReadLine(), out userInPut);
            //    sum += userInPut;
            //}
            //Console.WriteLine("입력한 정수의 총합은 {0} 입니다.", sum);


            /*
             * 4.프로그램 사용자로부터 입력 받은 숫자에 해당하는 구구단을 출력하되, 역순으로 출력하는 프로그램을 작성
             */
            //int guguDan = default;
            //int loopGu = 9;
            //Console.Write("원하는 구구단을 입력하시오: ");
            //int.TryParse(Console.ReadLine(), out guguDan);
            //while (loopGu > 0)
            //{
            //    Console.WriteLine("{0}*{1}={2}", guguDan, loopGu, guguDan * loopGu);
            //    loopGu--;
            //}

            /*
             * 5.프로그램 사용자로부터 입력 받은 정수의 평균을 출력하는 프로그램을 작성하되, 다음 두 가지의 조건을 만족할 것.
             * -1.먼저 몇 개의 정수를 입력할 것인지 프로그램 사용자에게 묻는다. 그리고 그 수만큼 정수를 입력 받는다.
             * -2.평균 값은 소수점 이하까지 계산해서 출력한다.
             * ex)User input(Loop count) -> 3
             *    User input -> 10
             *    User input -> 10
             *    User input -> 10
             *    "평균 값: 10.0"
             */
            //int userNum = 1; //1번째 방법 userNum을 while문 조건식에 씀
            //int userInPutN = default;
            //int SUM = default;
            //double MEDIUM = default;
            //Console.Write("몇개의 정수를 입력할 것입니까? ");
            //int.TryParse(Console.ReadLine(), out userNum);
            //int ctNum = userNum;
            //while (userNum != 0)
            //{
            //    Console.Write("정수를 입력하시오: ");
            //    int.TryParse(Console.ReadLine(), out userInPutN);
            //    SUM += userInPutN;
            //    userNum--;
            //}
            //MEDIUM = Convert.ToDouble(SUM) / Convert.ToDouble(ctNum);
            //Console.Write("평균 값: {0}", MEDIUM);

            //int userNum = 1; //2번째 방법 userNum을 while문 조건식에 쓰지않고 처리함
            //int userInPutN = default;
            //int SUM = default;
            //double MEDIUM = default;
            //Console.Write("몇개의 정수를 입력할 것입니까? ");
            //int.TryParse(Console.ReadLine(), out userNum);
            //int loopNum = 1;
            //while (loopNum <= userNum)
            //{
            //    Console.Write("정수를 입력하시오: ");
            //    int.TryParse(Console.ReadLine(), out userInPutN);
            //    SUM += userInPutN;
            //    loopNum++;
            //}
            //MEDIUM = Convert.ToDouble(SUM) / Convert.ToDouble(userNum);
            //Console.Write("평균 값: {0}", MEDIUM);

            //const float FLOAT_VALUE = 0.1f;
            //float sumOfFloatVaule = 0.0f;
            //int loopCount = 10;
            //while(0 < loopCount)
            //{
            //    sumOfFloatVaule += FLOAT_VALUE;
            //    loopCount--;
            //}       //loopL 10번 돈다
            //Console.WriteLine("무슨 값이 나오나? {0}", sumOfFloatVaule);

            //두 실수를 입력받아서 값이 같은지 다른지 출력하는 프로그램 작성. (Equals등 메서드 사용 X)
            //float Num1 = 1;
            //float Num2 = 2;
            //Console.Write("a를 입력하시오: ");
            //float.TryParse(Console.ReadLine(), out Num1);
            //Console.Write("b를 입력하시오: ");
            //float.TryParse(Console.ReadLine(), out Num2);
            //if (Num1 < Num2)
            //{
            //    Console.WriteLine("{0} < {1}", Num1, Num2);
            //}
            //else if (Num1 > Num2)
            //{
            //    Console.WriteLine("{0} > {1}", Num1, Num2);
            //}
            //else
            //{
            //    Console.WriteLine("{0} = {1}", Num1, Num2);
            //}

            /*
             * for 문은 일정한 횟수만큼 반복할 때 유용하다.
             * 초기식을 실행한 후에 조건식이 참인 동안, 문장을 반복한다. 한번 반복이 끝날 때마다
             * 증감식이 실행된다.
             */

            ////1~10까지 정수의 합
            //int sumNumber = 0;
            ////                       5번         7번
            ////       1번             2번         4번
            ////for(int index = 1; index <= 10; index++)
            //for(int index = 1; index <= 10; index++)
            //{
            //    //       3번, 6번
            //    sumNumber += index;
            //}
            //Console.WriteLine($"1부터 10까지의 정수의 합 = {sumNumber}");
            //Console.WriteLine("1부터 10까지의 정수의 합 = {0}",sumNumber);

            //1~100 숫자 중에서 5의 배수를 제외한 수의 합 구하기
            //int sum = 0; //5의 배수를 제외한 수의 합을 입력할 변수
            //for (int index = 1; index <= 100; index++) //for문 시작 index가 1일때 index가 100보다 작거나 같으면
            //{                                          //index에 1씩 증감해서 반복함.
            //    if (index % 5 == 0) //if문 조건식 시작 index를 5로 나눈 나머지가 0과 같을때 실행.
            //    {
            //        /* 의도적으로 아무것도 안씀 */
            //    }
            //    else //if문의 조건식에 해당되지 않을 때 실행.
            //    {    //index%5 != 0 이 아닌 값들일 때 실행.
            //        sum += index; //sum변수에 index값을 더함.
            //        Console.WriteLine("5의 배수가 아닌 수: {0}, 합: {1}", index, sum);
            //        Console.WriteLine(); //보기 편하게 줄바꿈
            //    } //if문 종료 후 for문의 반복실행
            //} //for문 종료
            //Console.WriteLine("5의 배수가 아닌 수의 총합: {0}", sum); //출력

            /*
             * break 문
             * break 문은 반복 루프를 벗어나기 위해서 사용한다. break 문이 실행되면 반복 루프는 즉시 중단되고
             * 반복 루프 다음에 있는 문장이 실행된다.
             */
            //for(int index = 1; index <=10; index++)
            //{
            //    if(index == 4)
            //    {
            //        break;
            //    }
            //    Console.WriteLine("현재 인덱스: {0}", index);
            //}

            /*
             * continue 문
             * continue 문은 현재 수행하고 있는 반복 과정의 나머지를 건너뛰고 다음 반복 과정을 강제적으로
             * 시작하게 만든다. 반복 루프에서 continue 문은 만나게 되면 continue 문 다음에 있는 후속 코드들은
             * 실행되지 않고 건너뛰게 된다.
             */

            //1~100 숫자 중에서 3의 배수를 제외한 수의 합 구하기
            //int sum = 0;
            //for (int index = 1; index <= 100; index++)
            //{
            //    if (index % 3 == 0)
            //    {                  
            //        Console.WriteLine("{0}은(는) 3의 배수 입니다", index);
            //        continue; //continue를 쓸때 index % 3 == 0이 되면 밑에 식을 무시하고 증감식시작
            //        Console.WriteLine("실행되나요?");//continue문 밑에있는 식이므로 무시됨.
            //    }
            //    else
            //    {
            //        sum += index;
            //    }
            //}
            //Console.WriteLine("3의 배수를 제외한 수의 총합은: {0} 입니다", sum);

            /*
             * 1. 자음과 모음 개수 세기
             * 사용자로부터 영문자를 받아서 자음과 모음의 개수를 세는 프로그램을 작성
             * -대, 소문자 모두 카운트-
             * ex) a
             *     b
             *     c
             *     d
             *     e
             *     모음:2
             *     자음:3
             */
            //string[] str = Console.ReadLine().Split(',');
            //int vowels = 0;
            //for (int i= 0; i < str.Length; i++)
            //{
            //    switch (str[i])
            //    {
            //        case "a":
            //        case "e":
            //        case "i":
            //        case "o":
            //        case "u":
            //        case "A":
            //        case "E":
            //        case "I":
            //        case "O":
            //        case "U":
            //            vowels++;
            //            break;
            //    }
            //}
            //    Console.WriteLine("모음{0}, 자음{1}", vowels, str.Length - vowels);

            //string str = Console.ReadLine();
            //int vowels = 0, cocsonants = 0;
            //for (int i = 0; i < str.Length;  i++)
            //{
            //    switch (str[i])
            //    {
            //        case 'a':
            //        case 'e':
            //        case 'i':
            //        case 'o':
            //        case 'u':
            //        case 'A':
            //        case 'E':
            //        case 'I':
            //        case 'O':
            //        case 'U':
            //            vowels++;
            //            break;
            //        default: cocsonants++;
            //            break;
            //    }
            //}
            //Console.WriteLine("모음{0}, 자음{1}", vowels, cocsonants);
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

            //몇번할지 정확히 알때는 for문이 편하고 몇번반복할지 모를때는while이 좋음
            //Random land = new Random();
            //int program = land.Next(1, 100 + 1);
            //int answer = program;
            //int userInPut = 0;
            //while (userInPut != answer)
            //{
            //    Console.Write("정수를 입력하시오. ");
            //    int.TryParse(Console.ReadLine(), out userInPut);
            //    if (userInPut < answer)
            //    {
            //        Console.WriteLine("{0}은 answer보다 작습니다.", userInPut);
            //    }
            //    else if (userInPut > answer)
            //    {
            //        Console.WriteLine("{0}은 answer보다 큽니다.", userInPut);
            //    }
            //    else
            //    {
            //        Console.WriteLine("정답입니다.");
            //    }
            //}
            //Random land = new Random();
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
            //Random land1 = new Random();
            //Random land2 = new Random();
            //int a = land1.Next(0, 99 + 1);
            //int b = land2.Next(0, 99 + 1);
            //int answer = a + b;
            //int userInPut = 0;
            //while(userInPut != answer)
            //{
            //    a = land1.Next(0, 99 + 1);
            //    a = land1.Next(0, 99 + 1);
            //    answer = a + b;
            //    Console.Write("{0} + {1} = ", a, b);
            //    int.TryParse(Console.ReadLine(), out userInPut);
            //    if (userInPut == answer)
            //    {
            //        Console.WriteLine("정답 입니다. 프로그램을 종료합니다. ");
            //    }
            //}

            //while (userInPut != answer)
            //{
            //    a = land1.Next(0, 99 + 1);
            //    b = land1.Next(0, 99 + 1);
            //    answer = a - b;
            //    Console.Write("{0} - {1} = ", a, b);
            //    int.TryParse(Console.ReadLine(), out userInPut);
            //    if (userInPut == answer)
            //    {
            //        Console.WriteLine("정답 입니다. 프로그램을 종료합니다. ");
            //    }
            //}

            //while (userInPut != answer)
            //{
            //    a = land1.Next(0, 99 + 1);
            //    b = land1.Next(0, 99 + 1);
            //    answer = a * b;
            //    Console.Write("{0} * {1} = ", a, b);
            //    int.TryParse(Console.ReadLine(), out userInPut);
            //    if (userInPut == answer)
            //    {
            //        Console.WriteLine("정답 입니다. 프로그램을 종료합니다. ");
            //    }
            //}

            /*
             * foreach 문은 배열(Array)이나 컬렉션(Collection) 같은 값을 여러 개 담고 있는 데이터 구조에서
             * 각각의 데이터가 들어 있는 만큼 반복하는 반복문이다. 데이터 개수나 반복 조건을 처리할 필요가 없다.
             */
            //string 에서 글자를 하나씩 출력
            //string stringText = "Hello World!";
            //int loopCount = 0;
            //foreach (char oneCharactor in stringText) //stringText안에있는 값을 char로 변환하여 oneCharactor에 넣음.
            //{
            //    Console.Write("{0},", oneCharactor); //oneCharactor에 담긴 값을 확인.
            //    //loop : stringText의 길이만큼 도는 루프
            //    loopCount++; //몇번 loop했는지 알아보기위한 변수 돌때마자 1씩 증감.
            //} //foreach문 종료
            //Console.WriteLine();
            //Console.WriteLine("Loop count: {0}, stringText.Length: {1}", loopCount, stringText.Length);
            
            //1. 1~100숫자 중에서 3의 배수이면서 4의 배수인 정수 합 구하기
            //int sum = 0;
            //for (int i = 0; i <100; i++)
            //{
            //    if(i % 3 == 0 && i % 4 == 0)
            //    {
            //        sum += i;
            //    }
            //}

            //Console.WriteLine(sum);

            //2. 두 개의 정수를 입력 받아서 두 수의 차를 출력하는 프로그램 작성.
            //-항상 큰 수에서 작은 수를 뺀 결과는 언제나 0 이상이어야 함.

            //3. 구구단을 출력하되 짝수(2, 4, 6, 8단)만 출력되도록 하는 프로그램을 작성.
            //2단은 2x2까지만, 4단은 4x4까지만,...8단은 8x8까지만 출력한다.
            //break와 continue를 사용할 것.

            //4. 다음 식을 만족하는 모든 A와 Z를 구하는 프로그램을 작성.
            /*
             *     A Z
             *   + Z A
             *   ======
             *     9 9
             */

        }
    }
}