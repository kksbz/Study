using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsClass
{
    internal class Program2 //internal 대신 public도 사용가능함
    {
        public static void Main()
        {
            /**
             * c#의 모든 코드에 반드시 들어가는 클래스(Class) 알아보자.
             * 
             * 클래스 소개하기
             * 클래스는 지금까지 작성한 모든 예제에서 기본이 되는 c#의 핵심 코드이다.
             * public class [클래스 이름] 
             * {
             *      -내용
             * }
             * 같은 코드 블록을 사용하여 정의할 수 있다. 클래스를 정의하는 전반적인 내용과 클래스 내부 또는 외부에
             * 올 수 있는 구성 요소는 다음 장에서 살펴볼 것.
             * 
             * 클래스의 구성 요소는 많지만, 그중 속성과 메서드를 가장 많이 사용한다. 속성은 데이터를 다루고,
             * 메서드는 로직을 다룬다.
             * - 클래스
             * - 속성: 데이터
             * - 메서드: 로직 (클래스의 멤버함수 -> 클래스안에 속해있음)
             * 
             * 클래스는 그 의미에 따라, 이미 닷넷 프레임워크에서 만들어 놓은 내장 형식(Built-in type)과 사용자가
             * 직접 클래스 구조를 만드는 사용자 정의 형식(User defined type)으로 구분할 수 있다. 예를 들어
             * Console, string, Math 등 클래스는 내장 형식이다. 그리고 class 키워드로 Product, Note, User, Group
             * 처럼 새로운 형식(기존에 제공되지 않는)을 정의할 수 있는데, 이를 사용자 데이터 형식 이라고 한다.
             * 
             * 클래스 만들기
             * 클래스를 정의하면 다음과 같다.
             * - 클래스는 개체(인스턴스)를 생성하는 틀(템플릿)이다.
             * - 클래스는 무엇인가를 만들어 내는 설계도이다.
             * 
             * 클래스는 c#프로그래밍의 기본 단위로 새로운 개체(실체-인스턴스)를 생성하는 설계도(청사진) 역할을 한다.
             * 예를 들어 자동차라는 개체(Object)를 만들려면 자동차 설계도가 필요하다. 이와 마찬가지로
             * 프로그래밍에서도 설계도가 필요한데, 이 역할을 하는 것이 클래스(Class)이다. 즉 클래스는
             * 개체를 생성하는 틀(템플릿)이며, 더 간단히 말하자면 "무엇인가를 만들어 내는 설계도"이다.
             * 
             * 클래스 선언하기
             * - 클래스 이름은 반드시 대문자로 시작한다.
             * public class [클래스 이름]
             * {
             *      //클래스 내용을 구현
             *      - 속성 -> 변수
             *      - 메서드 -> 함수
             * }
             */

            /**
             * 클래스를 여러 개 사용할 때는 public 키워드를 써야 한다. public 키워드가 붙은 클래스는
             * 클래스 외부에서 해당 클래스를 바로 호출해서 사용할 수 있도록 공개되었다는 의미이다.
             * 반대 의미는 private 키워드를 사용한다.
             * 
             * static과 정적 메서드
             * c#에서는 static을 정적으로 표현한다. 의미가 같은 다른 말로 표현하면 공유(Shared)이다.
             * static이 붙는 클래스의 모든 멤버는 해당 클래스 내에서 누구나 공유해서 접근할 수 있다.
             * 메서드에 static이 붙는 메서드를 정적 메서드라고 하는데, 이를 공유 메서드(Shared method)라고도 한다.
             * 
             * 정적 메서드와 인스턴스 메서드
             * 닷넷의 많은 API처럼 우리가 새롭게 만드는 클래스는 메서드를 포함한 각 멤버에 static키워드
             * 유무에 따라 정적 또는 인스턴스 멤버가 될 수 있다.
             * - static이 붙으면 정적 메서드, 안붙으면 인스턴스 메서드
             */

            //ClassNote.StaticMethod(); //ClassNote의 StaticMethod메서드에 접근하는 방법
            ////ClassNote.InstanceMethod(); //static이 없어 인스턴스 이므로 공유X 접근불가임
            //ClassNote classNote = new ClassNote(); //인스턴스 화 한 것이다.
            //classNote.InstanceMethod(); //하지만 인스턴스화 하면 접근가능함

            /**
             * 클래스 시그니처
             * 클래스는 다음 시그니처를 가진다.
             * 
             * public class Car{}
             * 
             * public 액세스 한정자(piblic과 private)를 사용하면 기본값인 internal을 갖는데 internal은
             * 해당 프로그램 내에서 언제든지 접근 가능하다. 하지만 학습 단계에서는 클래스에 public만 사용해도 괜찮다.
             * 그리고 class 키워드 다음에 클래스 이름이 오는데, 클래스 이름은 대문자로 시작하는 명사를 사용한다.
             * 클래스 본문 또는 몸통(Class Body)을 표현하는 중괄호 안에는 지금까지 배운 메서드와 앞으로 다룰
             * 필드, 속성, 생성자, 소멸자 등이 올 수 있는데, 이 모두를 가리켜 클래스 멤버라고 한다.
             * 
             * 클래스 이름 짓기
             * 클래스 이름은 의미 있는 이름을 사용하면 좋다. 이름은 명사를 사용하며, 첫 글자는 꼭 대문자여야 한다.
             * 또 클래스 이름을 지을 때는 축약형이나 특정 접두사, 언더스코어(_) 같은 특수문자는 쓰지 않는다.
             * - 클래스 이름은 누구나 알기 쉽게
             * - 간단하고 명확하게 한다
             * 
             * 클래스의 주요 구성 요소
             * 클래스의 시작과 끝, 즉 클래스 블록 내에는 다음 용어(개념)들이 포함될 수 있다.
             * 클래스 구성 요소를 가리킬 때 클래스 멤버라는 용어와 혼용해서 사용한다.
             * 
             * - 필드(Field): 클래스의 부품 역할을 한다. 클래스 내에 선언된 변수나 데이터를 담는 그릇으로
             *                개체 상태를 저장한다.
             * - 메서드(Method): 개체 동작이나 기능을 정의한다.
             * - 생성자(Constructor): 개체 필드를 초기화한다. 즉, 개체를 생성할 때 미리 수행해야 할 기능을
             *                        정의한다.
             * - 소멸자(Destructor): 개체를 모두 사용한 후 메모리에서 소멸될 때 실행한다.
             * - 속성(Property): 개체의 색상, 크기, 형태 등을 정의한다.
             * 
             * 엑세스 한정자
             * 클래스를 생성할 때 public, private, internal, abstract, sealed 같은 키워드를 붙일 수 있다.
             * 이를 엑세스 한정자라고 한다. 엑세스 한정자는 클래스에 접근할 수 있는 범위를 결정하는 데 도움이 된다.
             * 특별히 지정하지 않는 한 기본적으로 public 액세스 한정자를 사용하면 된다.
             */

            //Random random = new Random(); //Random클래스를 쓰려고 인스턴스화 함
            //int randomNumber = random.Next(1, 100 + 1);

            //1. class를 사용하며 로또번호 생성기 만드는 프로그램 작성
            //- 1~45사이의 랜덤한 숫자(중복X)
            //- 6개의 랜덤한 숫자를 뽑아서 출력할 것

            //Lotto.LottoNumber(); //static 줘서 공개상태임
            //LottoCreator lotto = new LottoCreator(); //인스턴스화시킴
            //lotto.PrintLottoNumber();

            //2. 가위바위보 만들기

            //RockPaperScissors rps = new RockPaperScissors();
            //rps.RockPaperScissorsGame();

            //다른파일에있는 class 불러오기
            //TrumpCard trumpCard = new TrumpCard();
            //trumpCard.SetupTrumpCards();
            //trumpCard.ReRollCard();

            /**카드 뽑기 게임
             *카드 뽑기 게임을 작성해서 제출
             *- 컴퓨터가 2장을 뽑아서 보여줌.
             *- 플레이어가 베팅을 함. (패스하려면 0포인트 베팅)
             *-플레이어가 뽑은 카드가 컴퓨터가 뽑은 2장의 카드 사이에 있는 카드라면 플레이어가 2배 벌어감
             *-플레이어가 뽑은 카드가 컴퓨터가 뽑은 2장의 카드 사이에 없다면 플레이어는 베팅금액을 잃음
             *- 플레이어는 10,000 포인트 들고 게임을 시작함.
             *-카드의 대,소 비교는 오직 숫자로만. (컴퓨터가 중복숫자를 뽑으면 0포인트 베팅하고 패스하자)
             *-게임 종료는 100,.000 포인트를 벌거나, 모두 잃을 때
             *-썻던 카드는 버리지말고 걍 52개카드 모두에서 다시 뽑음
             */
            TrumpCard trumpCard = new TrumpCard();
            trumpCard.SetupTrumpCards();
            trumpCard.ReRollCard();        


        } //Main
    } //class Program2

    //1번 문제
    //public class Lotto
    //{
    //    public static void LottoNumber()
    //    {
    //        List<int> lottoPick = new List<int>();
    //        int pickNumber = 0;
    //        Random randomNumber = new Random();
    //        for (int index = 0; index < 6; index++)
    //        {
    //            do
    //            {
    //                pickNumber = randomNumber.Next(1, 45 + 1);
    //            }
    //            while (lottoPick.Contains(pickNumber));
    //            lottoPick.Add(pickNumber);
    //            Console.WriteLine("선택한 {0}번째 로또번호: {1} ", index + 1, lottoPick[index]);
    //        }
    //    }
    //}

    //////1번 문제 교수님풀이
    //public class LottoCreator
    //{
    //    int[] lottoNumbers;
    //    public void PrintLottoNumber()
    //    {
    //        //여기서 로또 번호 출력할 것임
    //        lottoNumbers = new int[45];
    //        for (int index = 0; index < 45; index++)
    //        {
    //            lottoNumbers[index] = index + 1;
    //        } //loop: 로또 번호를 순서대로 초기화 하는 루프

    //        for (int index = 0; index < 100; index++)
    //        {
    //            lottoNumbers = shuffleOnce(lottoNumbers);
    //        }

    //        for (int index = 0; index < 6; index++)
    //        {
    //            Console.Write("{0} ", lottoNumbers[index]);
    //        }
    //    }
    //    //! 내부에서 사용하는 배열을 1번 섞는 함수
    //    private int[] shuffleOnce(int[] lottoNumbers_)
    //    {
    //        Random random = new Random();
    //        int sourIndex = random.Next(0, lottoNumbers_.Length);
    //        int destIndex = random.Next(0, lottoNumbers_.Length);

    //        int temp = lottoNumbers_[sourIndex];
    //        lottoNumbers_[sourIndex] = lottoNumbers_[destIndex];
    //        lottoNumbers_[destIndex] = temp;
    //        return lottoNumbers_;
    //    }
    //}

    //2번 문제
    public class RockPaperScissors
    {
        private bool IsPlayerTurn { get; set; }
        public void RockPaperScissorsGame()
        {
            int playerPick = 0;
            int computerPick = 0;
            int[] pick = {0, 1, 2};
            Random random= new Random();
            for (int index = 0; index < 10; index++)
            {
                pick = shuffles(pick);
            }
            playerPick = pick[random.Next(0,3)]; // 1
            computerPick = pick[random.Next(0,3)]; // 1

            IsPlayerTurn= true;
            PrintGame(playerPick);
            IsPlayerTurn = false;
            PrintGame(computerPick);
        }
        public static int[] shuffles(int[] pick_)
        {
            Random random= new Random();
            int pick1 = random.Next(0, 3);
            int pick2 = random.Next(0, 3);
            int temp = pick_[pick1];
            pick_[pick1] = pick_[pick2];
            pick_[pick2] = temp;
            return pick_;
        }
        public void PrintGame(int a)
        {
            string strWho = string.Empty;
            if(IsPlayerTurn)
            {
                strWho = "플레이어";
            }
            else
            {
                strWho = "컴퓨터";
            }
            switch (a)
            {
                case 0:
                    Console.WriteLine("{0}는 바위를 냈다", strWho);
                    break;
                case 1:
                    Console.WriteLine("{0}는 가위를 냈다", strWho);
                    break;
                case 2:
                    Console.WriteLine("{0}는 보를 냈다",strWho);
                    break;
            }
        }
    }
    public class ClassNote
    {
        public static void StaticMethod()
        {
            Console.WriteLine("ClassNote 클래스의 StaticMethod");
        }

        public void InstanceMethod()
        {
            Console.WriteLine("ClassNote 클래스의 InstanceMethod");
        }
    }
}//namespace
