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
            //int형 배열 sizeH의 길이를 100으로 선언
            int[] sizeH = new int[100];
            //sizeH 안에 0~100사이의 숫자를 랜덤하게 넣기위해 Random문 선언
            Random randomNumber = new Random();
            //for문 시작 loop: 100번 도는 루프
            for (int index = 0; index < 100; index++)
            {
                //index = 0 일때 시작해서 99까지돔
                //sizeH[0]번 부터 1~100까지의 랜덤한 수 하나를 뽑아 저장함
                //100+1인 이유 (최대값은 포함X기 때문)
                sizeH[index] = randomNumber.Next(1, 100 + 1);
                //sizeH에 값이 제대로 들어갔는지 출력
                Console.WriteLine("sizeH{0}의 값은 {1}입니다", index, sizeH[index]);
            } //for문 종료
            Console.WriteLine("sizeH배열의 최대값은 {0} 입니다.", sizeH.Max());

            //LAB 2.사과를 제일 좋아하는 사람찾기
            //사람들 5명 (사람1,사람2,...)에게 아침에 먹는 사과 개수를 입력하도록 요청하는 프로그램 작성
            //데이터 입력이 마무리 되면 누가 가장 많은 사과를 아침으로 먹었는지 출력한다. (기본형)
            //-이상한 입력 예외처리
            //-제일 적게 먹은 사람도 찾도록 수정해보기 (변형1)
            //-먹은 사과의 개수 순으로 정렬 ->알고리즘을 잘 모르겠다면 버블 정렬을 도전 해볼 것. (변형2)
            //                            ->알고리즘을 잘 알겠다면 Merge sort 도전 해볼 것. (어려운거)
            //                              정렬 도전시 유저 입력X, 데이터는 난수로 100~1000개 정도의 값
            //                              중복 제거, 시간초는 전혀 상관 없음.

            //기본 + 변형1
            //5명의 사람이 먹은 사과의 갯수를 입력하기 위해  int형 배열 appleCount 의 크기를 5로 선언
            int[] appleCount = new int[5];
            //입력값 예외처리 for문 시작 배열은 0부터 시작하므로 index < 5 로 정함 loop: 5번 도는 루프
            for (int index = 0; index < 5; index++)
            {
                Console.Write("아침에 먹은 사과 개수를 입력하시오.: ");
                //string형식으로 입력받은 것을 int형식으로 변환하여 appleCount[index]안에 저장함
                int.TryParse(Console.ReadLine(), out appleCount[index]);
                //if문 시작 조건: 입력받은 appleCount[index]의 값이 0 보다 큰 정수일 때
                if (appleCount[index] > 0)
                {
                }
                //입력받은 appleCount의 값이 정수가 아니면 실행
                else
                {
                    //정수가 아니므로 오류메시지 출력
                    Console.WriteLine("잘못 입력하였습니다.");
                    //appleCount[index] 안에 다시 값을 입력받아 저장해야하기 때문에 index-- 증감식으로 재실행하기위해 선언
                    index--;
                } //if문 종료
            } //for문 종료

            //appleCount배열안에 제대로 값이 들어갔는지 확인하기 위한 for문 시작
            for (int index = 0; index < 5; index++)
            {
                //출력 index가 0부터 시작하므로 사람1부터 표시하기위해 index + 1 시킴
                Console.WriteLine("사람{0} 이 먹은 사과 개수는?: {1}", index + 1, appleCount[index]);
            } //for문 종료

            //appleCOunt배열안에 최대값과 최소값을 찾기위해 Array.IndexOf문과 .Max, .Min 문을 사용함
            //Array.IndexOf(주소값을 찾고자하는 배열이름 , (찾고자하는 주소값의 들어있는 값)) 배열은 0번부터시작이라 사람1...5까지 출력하기위해 +1시킴
            Console.WriteLine("사람{0}가 가장 많은 {1} 개수의 사과를 먹었습니다.", Array.IndexOf(appleCount, appleCount.Max()) + 1,
                appleCount.Max()); //가장 많이 먹은 사람과 개수 구하기
            Console.WriteLine("사람{0}가 가장 적은 {1} 개수의 사과를 먹었습니다.", Array.IndexOf(appleCount, appleCount.Min()) + 1,
                appleCount.Min()); //(변형1) 가장 적개 먹은 사람과 개수 구하기

            //아래문제랑 공백 구분
            Console.WriteLine();

            //변형2 -먹은 사과의 개수 순으로 정렬 ->알고리즘을 잘 모르겠다면 버블 정렬을 도전 해볼 것.
            int userInPut = 0;
            //입력값 예외처리하기 위한 for문 시작 사람 수만 입력하면되므로 loop: 2번돔
            for (int index = 0; index <= 1; index++)
            {
                Console.Write("사람 수를 입력하시오: ");
                //string형식으로 입력받은 값을 int형식으로 변환해서 저장
                int.TryParse(Console.ReadLine(), out userInPut);
                //입력값 예외처리를 위한 if 문 실행 조건: userInPut이 0보다 큰 정수일 때
                if (userInPut > 0)
                {
                    //0보다 큰 정수를 입력받았으므로 break로 즉시 종료
                    break;
                }
                //위에 조건이 만족하지않을때 실행
                else
                {
                    //입력된 값이 0보다큰 정수가 아니므로 오류메시지 출력
                    Console.WriteLine("XX다시 입력하시오.XX ");
                    //for문을 다시 돌리기위해 index값을 --로 감소시킴
                    index--;
                } //if문 종료
            } //for문 종료

            //입력받은 userInPut의 값이 사람이 먹은 사과의 갯수가 되기 때문에 appleCount2 (위에 문제에 쓴 변수명이라 2를 붙임)
            //라는 int형 배열을 만들어 그안에 int로 변형된 입력값을 저장
            int[] appleCount2 = new int[userInPut];
            //appleCount2 배열안에 입력값이 잘 들어갔는지 확인용 출력문
            Console.WriteLine("appleCount2의 길이는{0}", appleCount.Length);
            //가장 적게 먹은 사과갯수를 뒤에 버블정렬로 배열의 Index주소마다 값이 바뀔거기때문에
            //마지막출력문에 사람순서를 가장적게먹은 사람순서로 출력하기위한 appleEat (int형 배열 선언) 안에 userInPut 초기값을 저장함
            int[] appleEat = new int[userInPut];
            //사과 먹은 갯수를 0~100사이의 난수로 저장하기위한 Random 변수 선언
            Random randomCount = new Random();
            //사과 먹은 갯수를 appleCount2 안에 저장하기 위한 for문 시작
            for (int index = 0; index < userInPut; index++)
            {
                //appleCount2[0]번부터 userInPut (userInPut크기가 곧 배열의 길이임) 안에
                //.Next 함수를 이용하여 0~100+1 (최대값은 포함X라 0~99까지 넣기위해 +1)의 범위안에 랜덤숫자 1개를 저장
                appleCount2[index] = randomCount.Next(0, 100 + 1);
                //appleCount2안에 값이 잘 저장되었는지 확인용 출력문
                Console.WriteLine("사람{0}\t이 먹은 사과 개수는 {1}\t개 입니다", index + 1, appleCount2[index]);
                //먹은 사람 1번부터 userInPut까지 구하기 위해 appleEat에 index + 1(index가 0부터 시작이므로 +1)
                //값 저장 (appleEat배열안에 1,2,...userInPut+1의 정수가 저장됨)
                appleEat[index] = index + 1;
            } //for문 끝
            //공백처리
            Console.WriteLine();
            //가장 적게 먹은 사과갯수 부터 가장 많은 갯수 순서로 구하기 위한 for문 시작 loop: userInPut - 1 만큼 루프(배열은0부터시작)
            for (int index = 0; index < userInPut; index++)
            {
                //2번째 for문 시작 userInPu - 1번까지 반복 (배열은 0부터 시작하기 때문)
                for (int index2 = 0; index2 < userInPut - 1; index2++)
                {
                    //appleCount2 앞에 주소값과 뒤에 주사값을 비교하기 위한 if문 시작. (조건: 앞의 주소값 > 뒤의 주소값)
                    if (appleCount2[index2] > appleCount2[index2 + 1])
                    {
                        //버블정렬사용
                        //appleCount[0] > appleCount[1]보다 클때 실행됨
                        //temp라는 새로운 변수를 선언하고 그안에 크기가 작은 뒤에값을 저장
                        int temp = appleCount2[index2 + 1];
                        //앞의값과 뒤의값을 바꾸기위해 뒤에값에 앞의값을 저장
                        appleCount2[index2 + 1] = appleCount2[index2]; //apppleCount[1]값이 더큰 값인 appleCount[0]의 값을 저장
                        //temp안에 저장된 뒤에값을 앞에값에 저장
                        appleCount2[index2] = temp;

                        //위식과 동일 먹은 사람의 순번도 구하기위해 작성함
                        temp = appleEat[index2 + 1];
                        appleEat[index2 + 1] = appleEat[index2];
                        appleEat[index2] = temp;
                    } //if문 끝
                } //두번째 for문 끝
            } //첫번째 for문 끝
            //버블정렬이 잘 작동했는지 확인하기 위한 foreach문 시작
            //appleCount2안에있는 첫번째 요소(Element)부터 시작해서 끝까지 반복
            foreach (int element in appleCount2)
            {
                //눈으로 보기 위한 출력문
                Console.WriteLine("appleCount2 안에 {0} 값이 들어있음", element);
            } //foreach문 종료
            //공백구분
            Console.WriteLine();
            //몇번째 사람이 가장 적게 먹었는지 최소값부터 보여주는 출력문을 위한 for문 시작 loop: userInPut - 1만큼 루프(배열은0부터시작) 
            for (int index = 0; index < userInPut; index++)
            {
                //appleEat[] = 몇번째 사람, appleCount2[] = 먹은 사과 갯수
                Console.WriteLine("사람{0}\t이 먹은 사과 개수는 {1}\t개 입니다", appleEat[index], appleCount2[index]);
            } //for문 끝

            /*
             * 레퍼런스 게임 직접 해보면서 내가 지금까지 배운 것들로 무엇을 어디까지 구현할 수 있을지 마인드맵 그려보기.
             * -타이틀 씬
             * -선택지를 포함한 이벤트
             * -얻을 수 있는 보상 or 패널티를 보여주는 이벤트 ex)골드,아이템획득 or 스탯감소 등..
             * -전투 씬 ex)몬스터 등장 전투
             */

            // 프로그램은 여기서 끝난다.
        }
    }
}