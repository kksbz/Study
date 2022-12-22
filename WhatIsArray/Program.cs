using System; //System 이라는 어셈블리에서 이것 저것 여러 기능을 가져와서 사용합니다.
using System.Linq;
using System.Runtime.InteropServices;

namespace WhatIsArray //내가 정한 프로그램 이름이다.
{
    internal class Program // 클래스 라는 것인데, C#에서는 모든 요소들이 클래스 안에 있어야 함.
    {
        static void Main(string[] args) //무조건 1개는 있어야 함 -> C# 콘솔(검은 창,터미널,커멘드, 쉘 등등 OS 마다 다르다)을 사용할 때 (유니티에선 없다)
        {
            ////사용자가 입력한 수 만큼 *로 마름모 출력하기
            //int userInPut = 0;
            //int loop = 0;
            //for (int index = 0; index <= loop; index++)
            //{
            //    Console.Write("홀수를 입력하시오. ");
            //    int.TryParse(Console.ReadLine(), out userInPut);
            //    if (userInPut % 2 != 0)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("짝수 입니다.");
            //        loop++;
            //    }
            //}
            //int star = 1;
            //int blank = userInPut / 2;
            //for (int index = 1; index <= userInPut / 2 + 1; index++)
            //{
            //    for (int index2 = 1; index2 <= blank; index2++)
            //    {
            //        Console.Write(" ");
            //    }
            //    blank--;
            //    for (int index3 = 1; index3 <= star; index3++)
            //    {
            //        Console.Write("*");
            //    }
            //    star += 2;
            //    Console.WriteLine();
            //}
            //int star2 = userInPut - 2; //역피라미드 실행시 별갯수는 입력값-2개 시작이므로 정함
            //int blank2 = 1; //역피라미드 실행시 공백은 무조건 1개 부터 시작이므로 정함
            //for (int index = 0; index < userInPut / 2 + 1; index++)
            //{
            //    for (int index2 = 1; index2 <= blank2; index2++)
            //    {
            //        Console.Write(" ");
            //    }
            //    blank2++;
            //    for (int index3 = 1; index3 <= star2; index3++)
            //    {
            //        Console.Write("*");
            //    }
            //    star2 -= 2;
            //    Console.WriteLine();
            //}
            //프로그램은 여기서부터 읽기 시작한다.
            /*
             * 컬렉션
             * 이름 하나로 데이터 여러 개를 담을 수 있는 자료 구조를 컬렉션(Collection) 또는
             * 컨테이너(Container) 라고 한다. C# 에서 다루는 컬랙션은 배열 (Array), 리스트(List),
             * 사전(Dictinary) 등이 있다.
             * 
             * 배열
             * 배열(Array)은 같은 종류의 데이터를 순차적으로 메모리에 저장되는 자료 구조이다. 각각의 데이터들은
             * 인덱스(번호)를 사용하여 독립적으로 접근된다. 배열을 사용하면 편리하게 데이터를 모아서 관리할 수있다.
             * 
             * 배열의 특징들
             * 1. 배열 하나에는 데이터 형식 한 종류만 보관할 수 있다.
             * 2. 배열은 메모리의 연속된 공간을 미리 할당하고, 이를 대괄호 ([])와 0부터 시작하는 정수형 인덱스를
             *    사용하여 접근할 수 있다.
             * 3. 배열을 선언할 때는 new 키워드로 배열을 생성한 후 사용할 수 있다.
             * 4. 배열에서 값 하나는 요소(Element) 또는 항목(Item)으로 표현한다.
             * 5. 필요한 데이터 개수를 정확히 정한다면 메모리를 적게 사용하여 프로그램 크기가 작아지고 성능이 향상된다.
             * 
             * 배열에는 세가지 종류가 있다.
             * 1차원 배열 : 배열의 첨자를 하나만 사용하는 배열
             * 다차원 배열 : 첨자 2개이상을 사용하는 배열 (2차원,3차원, ..., n차원 배열)
             * 가변(Jagged) 배열 : '배열의 배열'이라고 하며, 이름 하나로 다양한 차원의 배열을 표현할때 사용한다.
             */


            //배열의 선언과 초기화
            //int[] numbers = new int[5] { 1, 2, 3, 4, 5 };

            ////numbers.Length
            //Console.WriteLine(numbers[numbers.Length - 1]);

            //for(int index = 0; index < numbers.Length; index++)
            //{
            //    Console.WriteLine("{0} ",numbers[index]);
            //}

            //foreach(int element in numbers)
            //{
            //    Console.WriteLine("{0} ", element);
            //}

            //int number1 = 1;
            //int number2 = 2;
            //int number3 = 3;
            //int number4 = 4;
            //int number5 = 5;

            ////Console.WriteLine(numbers);
            //int number = 1_0822;
            //Console.WriteLine("64로 모드 연산: {0}", number % 64); //Random함수랑 같은 원리 랜덤마지막범위는 -1
            //                                                      //64로 나눈 나머지의 몫을 1~63까지 나타냄

            /*
             * 다차원 배열
             * 2차원 배열, 3차원 배열처럼 차원이 2개 이상인 배열을 다차원 배열이라고 한다.
             * c#에서 배열을 선언할 때는 콤마를 기준으로 차원을 구분한다.
             */
            //int[] oneArray = new int[2] { 1, 2 };
            //int[,] twoArray = new int[2, 2] { { 1, 2 }, { 3, 4 } };
            //int[,] twoArray2 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            //int[,] twoArray3 = new int[3, 2] { { 1, 2 }, { 3, 4 },{ 5, 6 } };
            //int[,,] threeArray = new int[2, 2, 2]
            //{
            //    { { 1, 2 }, { 3, 4 } },
            //    { { 1, 2 }, { 3, 4 } }
            //};
            ////3행 3열짜리 배열에서 행과 열이 같으면 1, 다르면 0을 출력 행- 열ㅣ
            //twoArray = new int[3, 3];

            //for(int y = 0; y <3; y++)
            //{
            //    for(int x=0; x < 3; x++)
            //    {
            //        if(x == y)
            //        {
            //            twoArray[y, x] = 1;
            //        }
            //        else
            //        {
            //            twoArray[y, x] = 0;
            //        }
            //    }
            //}//loop: 값을 대입하는 루프

            //for (int y = 0; y <= twoArray.GetUpperBound(0); y++) //GetUpperBound를 쓰는 방법
            //{
            //    for (int x = 0; x <= twoArray.GetUpperBound(1); x++)
            //    {
            //        Console.Write("{0} ", twoArray[y, x]);
            //    }
            //    Console.WriteLine();
            //}//loop: 값을 대입하는 루프

            //int[] integers = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
            //// Get the upper and lower bound of the array.
            //int upper = integers.GetUpperBound(0);
            //int lower = integers.GetLowerBound(0);
            //Console.WriteLine($"Elements from index {lower} to {upper}:");

            ///*
            // * 가변 배열
            // * 차원이 2개 이상인 배열은 다차원 배열이고, 배열 길이가 가변 길이인 배열은 가변 배열이라고 한다.
            // */
            //int[][] zagArray = new int[2][]; //뒤에 배열의 길이를 가변적으로 넣겠다는 의미
            //zagArray[0] = new int[] { 1, 2 };
            //zagArray[1] = new int[3] { 3, 4, 5 };
            //for(int y = 0; y <= 2; y++)
            //{
            //    for(int x = 0; x < zagArray[y].Length; x++)
            //    {
            //        Console.Write("{0}", zagArray[y][x]);
            //    }
            //    Console.WriteLine();
            //}
            //int[] intArray; //int형 데이터 타입의 intArray 라는 배열을 선언
            //intArray = new int[3]; //int형 데이터 타입의 변수를 3개 메모리에 할당(실질적인 메모리할당)
            //intArray[0] = 1; //intArray 0번째 인덱스에 1이라는 정수값을 대입
            //intArray[1] = 2; //intArray 1번째 인덱스에 2이라는 정수값을 대입
            //intArray[2] = 3; //intArray 2번째 인덱스에 3이라는 정수값을 대입
            ////배열 직접 출력해보자.
            //for (int index = 0; index < 3; index++)
            //{
            //    Console.WriteLine("{0} 번째 인덱스의 값 : {1}", index, intArray[index]);
            //} //loop: 3번 도는 루프
            //Console.WriteLine();
            //Console.WriteLine();

            ////intArray 배열에서 int 형 데이터 타입의 값을 하나씩 뽑아서 index에 저장 할거임.
            //foreach(int index in intArray) //intArray배열의 값을 index에 저장
            //{
            //    Console.WriteLine("intArray배열에서 뽑아온 값 : {0}", index);
            //} //loop: inArray 배열의 길이만큼 도는 루프

            //1.배열을 사용하여 국어 점수의 총점과 평균 구하기
            //학생 3명의 점수를 저장하는 배열 선언해서, 각 학생별로 점수를 할당하고(범위는 1~100)
            //모든 점수의 총점과 평균을 구해서 출력하는 프로그램
            //user input받아서 프로그램 작성
            //user input은 3회 (3명의 학생이니까)
            //점수 범위 (범위는 1~100점)
            //이상한 입력 예외처리
            //int userInPut = 0;
            //int[] score = new int[3];
            //for (int index=0; index < 3; index++)
            //{
            //    Console.Write("점수를 입력하시오: ");
            //    int.TryParse(Console.ReadLine(), out userInPut);
            //    if (userInPut > 0 && userInPut <= 100)
            //    {
            //        score[index] = userInPut;
            //    }
            //    else
            //    {
            //        Console.WriteLine("잘못된 입력입니다.");
            //        index--;
            //    }
            //}
            //Console.WriteLine("김씨의 점수:{0},이씨의 점수: {1},박씨의 점수: {2}", score[0], score[1], score[2]);
            //Console.WriteLine("3명의 총점은: {0}, 3명의 평균은: {1}", score.Sum(), score.Average());

            //LAB 1.크기가 100인 배열을 1부터 100 사이의 난수로 채우고 배열 요소 중에서 최대값을 찾는 프로그램 작성.
            //가독성 좋게 출력
            //int[] sizeH = new int[100];
            //Random randomNumber = new Random();
            //for(int index = 0; index < 100; index++)
            //{
            //    sizeH[index] = randomNumber.Next(1, 100 + 1);
            //    //Console.WriteLine("sizeH{0}의 값은 {1}입니다", index, sizeH[index]);
            //}
            //Console.WriteLine("sizeH배열의 최대값은 {0} 입니다.", sizeH.Max());

            //LAN 2.사과를 제일 좋아하는 사람찾기
            //사람들 5명 (사람1,사람2,...)에게 아침에 먹는 사과 개수를 입력하도록 요청하는 프로그램 작성
            //데이터 입력이 마무리 되면 누가 가장 많은 사과를 아침으로 먹었는지 출력한다. (기본형)
            //-이상한 입력 예외처리
            //-제일 적게 먹은 사람도 찾도록 수정해보기 (변형1)
            //-먹은 사과의 개수 순으로 정렬 ->알고리즘을 잘 모르겠다면 버블 정렬을 도전 해볼 것. (변형2)
            //                            ->알고리즘을 잘 알겠다면 Merge sort 도전 해볼 것. (어려운거)
            //                              정렬 도전시 유저 입력X, 데이터는 난수로 100~1000개 정도의 값
            //                              중복 제거, 시간초는 전혀 상관 없음.

            //기본+변형1
            //int[] appleCount = new int[5];
            //for(int index = 0; index < 5; index++)
            //{
            //    Console.Write("아침에 먹은 사과 개수를 입력하시오.: ");
            //    int.TryParse(Console.ReadLine(), out appleCount[index]);
            //    if (appleCount[index] > 0)
            //    {
            //    }
            //    else
            //    {
            //        Console.WriteLine("잘못 입력하였습니다.");
            //        index--;
            //    }
            //}
            ////Console.WriteLine("{0},{1},{2},{3},{4}", appleCount[0], appleCount[1], appleCount[2], appleCount[3], appleCount[4]);
            //Console.WriteLine("사람{0}가 가장 많은 {1} 개수의 사과를 먹었습니다.", Array.IndexOf(appleCount, appleCount.Max()) + 1,
            //    appleCount.Max()); //가장 많이 먹은 사람과 개수 구하기
            //Console.WriteLine("사람{0}가 가장 적은 {1} 개수의 사과를 먹었습니다.", Array.IndexOf(appleCount, appleCount.Min()) + 1,
            //    appleCount.Min()); //(변형1) 가장 적개 먹은 사람과 개수 구하기

            //변형2
            Random randomCount = new Random();
            int userInPut = 0;
            for (int index = 0; index <= 1; index++) //입력 예외 처리for문
            {
                Console.Write("입력하시오: ");
                int.TryParse(Console.ReadLine(), out userInPut); //string형식으로 입력받은걸 int형식으로 변환해서 담음
                if (userInPut > 0) //userInPut이 정수일때 실행
                {
                    break; //즉시 종료
                }
                else //userInPut이 정수가 아닐때 실행
                {
                    Console.WriteLine("XX다시 입력하시오.XX ");
                    index--; //for문을 다시 돌리기위해 index-1을함
                } //if문 종료
            } //for문 종료
            int[] appleCount = new int[userInPut]; //userInPut만큼 appleCount[]에 저장
            Console.WriteLine("appleCount의 길이는{0}", appleCount.Length); //appleCount안에 잘들어갔나 확인용
            int[] appleEat = new int[userInPut]; //나중에 사람번호째로 정렬하기위해 appleEat에 초기값저장함

            for (int index = 0; index < userInPut; index++) //for문 시작
            {
                appleCount[index] = randomCount.Next(0, 100 + 1);
                //appleCount[0]번부터 userInPut-1수까지 랜덤(0~99)값을 저장
                Console.WriteLine("사람{0}이 먹은 사과 개수는 {1} 입니다", index + 1, appleCount[index]);
                appleEat[index] = index + 1; //먹은사람 1번부터~userInPut까지 구하기위해 appleEat에 저장
            } //for문 끝
            Console.WriteLine();//공백

            for (int index = 0; index < userInPut; index++) //첫번째 for문 시작 
            {
                for (int index2 = 0; index2 < userInPut - 1; index2++) //두번째 for문 시작 userInPut-1번(포함X)까지 반복
                {
                    if (appleCount[index2] > appleCount[index2 + 1]) //if문시작 ex) appleCount[0] > appleCount[1] 일때 시작
                    {
                        //appleCount[0] > appleCount[1]보다 클때 실행됨
                        int temp = appleCount[index2 + 1]; //새로 정한 temp변수에 appleCount[1]값을 저장
                        appleCount[index2 + 1] = appleCount[index2]; //apppleCount[1]값이 더큰 값인 appleCount[0]의 값을 저장
                        appleCount[index2] = temp; //appCount[0]값에 temp값을 저장 (temp값에는 더 작은 appleCount[1]의 값이 있음)

                        temp = appleEat[index2 + 1]; //사람구하기 위식과 동일
                        appleEat[index2 + 1] = appleEat[index2];
                        appleEat[index2] = temp;
                    } //if문 끝
                } //두번째 for문 끝
            } //첫번째 for문 끝

            for (int index = 0; index < userInPut; index++) //for문 시작 userInPut만큼 반복
            {
                Console.WriteLine("{0}번째\t사람이 먹은 사과 개수는 {1} 입니다", appleEat[index], appleCount[index]);
                //appleEat[index]값은 사람을 표시, appleCount[index]값은 먹은 사과 개수 표시
            } //for문 끝

            foreach (int index in appleCount) //버블정렬이 잘 실행됐는지 확인함.
            {
                Console.WriteLine("{0}", index);
            }

            // 프로그램은 여기서 끝난다.
        }
    }
}