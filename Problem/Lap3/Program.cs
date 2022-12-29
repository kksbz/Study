using System;
using System.Linq;

namespace Lap3
{
    public class Program
    {
        static void Main(string[] args)
        {
            /**카드 뽑기 게임
             *카드 뽑기 게임을 작성해서 제출
             *- 컴퓨터가 2장을 뽑아서 보여줌.
             *- 플레이어가 베팅을 함. (패스하려면 0포인트 베팅)
             *-플레이어가 뽑은 카드가 컴퓨터가 뽑은 2장의 카드 사이에 있는 카드라면 플레이어가 2배 벌어감
             *-플레이어가 뽑은 카드가 컴퓨터가 뽑은 2장의 카드 사이에 없다면 플레이어는 베팅금액을 잃음
             *- 플레이어는 10,000 포인트 들고 게임을 시작함.
             *-카드의 대,소 비교는 오직 숫자로만. (컴퓨터가 중복숫자를 뽑으면 0포인트 베팅하고 패스하자)
             *-게임 종료는 100,000 포인트를 벌거나, 모두 잃을 때
             *-썻던 카드는 버리지말고 걍 52개카드 모두에서 다시 뽑음
             */
            //TrumpCard 인스턴스화 시켜서 사용
            TrumpCard trumpCard = new TrumpCard();
            trumpCard.SetupTrumpCards();

            //변수선언 
            int point = 10_000;
            int userInPut = -1;
            string computer1 = default;
            string computer2 = default;
            string player = default;
            int comPick1 = 0;
            int comPick2 = 0;
            bool gameWin = false;
            
            //while문 시작 조건: gameWin = Ture 일때 종료
            while (gameWin == false)
            {
                //입력예외처리 for문 시작 loop: 1번돔
                for (int index = 0; index <1; index++)
                {
                    //컴퓨터1이 카드 섞고 11, 12, 13자리는 J Q K로 변환
                    trumpCard.ShuffleCards();
                    //선택된 string형식의 카드 1장을 저장
                    computer1 = trumpCard.RollCard();
                    //컴퓨터2가 카드 섞고 11, 12 ,13자리는 J Q K로 변환
                    trumpCard.ShuffleCards();
                    //선택된 string형식의 카드 1장을 저장
                    computer2 = trumpCard.RollCard();
                    //선택된 카드숫자(string형식)를 turn을 통해 int형변환(J=11, Q=12, K=13) 후com1과 com2에 저장
                    int com1 = TrumpCard.turn(computer1);
                    int com2 = TrumpCard.turn(computer2);
                    Console.WriteLine("컴퓨터가 뽑은 카드는 {0}, {1}입니다.", computer1, computer2);
                    //억까패턴 예외처리 조건: 컴퓨터1 과 컴퓨터2 가 같은 숫자를 뽑았을 때
                    if(com1 == com2)
                    {
                        Console.WriteLine("컴퓨터가 뽑은 두카드가 {0},{1} 같습니다 억까당했습니다 패배!", com1, com2);
                        Console.WriteLine();
                        //gameWin값을 true로 바꾸고 while문 탈출 프로그램종료
                        gameWin = true;
                        break;
                    } //if문 종료

                    Console.Write("베팅할 금액을 입력하세요. : ");
                    string str = Console.ReadLine();
                    Console.WriteLine();
                    //입력예외처리를 위한 입력받은 string형식의 str값을 char형식으로 쪼개 하나하나 숫자가맞는지
                    //숫자가 아닌지 비교함 숫자면 true 그외는 false값이 나옴
                    bool isNum = str.All(char.IsDigit);
                    //숫자가 아닌 문자열,특수문자 예외처리 if문시작 조건: 위에서비교한 isNum이 true일때
                    if(isNum == true)
                    {
                        //isNum이 ture면 str문자열은 모두 숫자로 구성되어있으므로 int형식으로 변환하여 userInPut에 저장
                        int.TryParse(str, out userInPut);
                    }
                    else
                    {
                        //false면 숫자가 아니므로 예외처리
                        Console.WriteLine("정수를 입력하세요.");
                        Console.WriteLine();
                        //for문 다시 반복해야되므로 index--
                        index--;
                    } //if문 종료

                    //예외처리 for문 시작 조건:userInPut값이 0보다 크고 가지고있는 point보다 작거나 같을때
                    if (0 < userInPut  && userInPut <= point)
                    {
                        //포인트를 사용했으므로 point에서 userInPut값만큼 뺌
                        point -= userInPut;
                        Console.WriteLine("{0} 포인트 사용, 남은 포인트{1}",userInPut, point);
                        Console.WriteLine();
                    }
                    //0을입력하면 패스해야되므로 조건: userInPut이 0일 때
                    else if(userInPut == 0)
                    {
                        Console.WriteLine("패스했습니다.");
                        Console.WriteLine();
                        //userInPut값 초기화 ->이거안하면 0입력으로 패스후 다음 반복시 문자열or특수문자입력시
                        //정수가아닙니다 출력되고 userInPut값이 0이므로 패스했습니다가 또 출력됨 
                        userInPut -= 1;
                        //for문 다시 반복해야되므로 index--
                        index--;
                    } //if문 종료
                    //com1, com2는 for문안에서 선언된 변수라 for문을 벗어나지못함 각값을 comPick1,2에 저장
                    comPick1 = com1;
                    comPick2 = com2;
                } //for문 종료
                //플레이어 턴차례 (컴퓨터가 뽑는방식이랑 같음)
                trumpCard.ShuffleCards();
                player = trumpCard.RollCard();
                int playerPick = TrumpCard.turn(player);
                Console.WriteLine("플레이어가 뽑은 카드는 {0} 입니다.", player);
                //게임 승패 조건 if문 시작 조건: 컴퓨터가 뽑은 첫번째수가 두번째수보다 작을 때 
                if (comPick1 < comPick2)
                {
                    //if문 시작 조건: 첫번째수 ~ 두번째수 사이에 플레이어가 뽑은 카드값이 있으면 승리
                    if (playerPick > comPick1 && playerPick < comPick2)
                    {
                        //베팅성공으로 지출한포인트2배를 가져옴
                        point += (userInPut * 2);
                        Console.WriteLine("베팅성공 포인트 2배 겟 총포인트: {0}", point);
                    }
                    else
                    {
                        //베팅실패 베팅포인트 사라짐
                        Console.WriteLine("베팅실패");
                    } //if문 종료
                }
                else //컴퓨터가 뽑은 첫번째수가 두번째보다 클 때
                {
                    //if문 시작 조건: 두번째수 ~ 첫번째수 사이에 플레이어가 뽑은 카드값이 있으면 승리
                    if (playerPick > comPick2 && playerPick < comPick1)
                    {
                        point += (userInPut * 2);
                        Console.WriteLine("베팅성공 포인트 2배 겟 총포인트: {0}", point);
                    }
                    else
                    {
                        //베팅실패 베팅포인트 사라짐 
                        Console.WriteLine("베팅실패");
                    } //if문 종료
                } //if문 종료
                Console.WriteLine();
                //게임패배 조건확인 if문시작 조건: point가 0보다 작거나 같을때
                if (point <= 0)
                {
                    Console.WriteLine("남은 포인트가 없습니다 패배!");
                    Console.WriteLine();
                    //point가 0보다 작거나 같으므로 패배 while문 빠져나가기위한 gameWin값을 true
                    gameWin = true;
                }
                //게임승리 조건확인 조건: point가 15_000 이상일 때 (10만포인트모으기힘들어서 임시로 15_000으로함)
                else if (point >= 15_000)
                {
                    Console.WriteLine("{0} 를 모았습니다 승리!", point);
                    Console.WriteLine();
                    //while문 빠져나가기위한 gameWin값을 true로
                    gameWin = true;
                } //if문 종료
            }//while 종료
        }
    }
}