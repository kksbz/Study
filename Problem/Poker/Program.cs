using Lap3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Poker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //트럼프 카드 게임(포커 게임)
            //컴퓨터가 5장의 카드를 뽑는다. (플레이어가 볼 수 있음)
            //플레이어도 5장의 카드를 뽑는다.
            //플레이어는 베팅을 한다(0~알아서)
            //컴퓨터는 2장의 카드를 추가로 받는다. -> 총 7장의 카드 보유
            //플레이어는 2장의 카드를 교체할 수 있다. (카드 1장 교체가능 횟수-> 0~2회)
            //모든 액션이 끝난 후에는 결과를 체크한다.
            //플레이어가 이기면 2배로 받고
            //플레이어가 지면 베팅금액을 잃는다.
            //-100,000 포인트 이상을 얻거나, 0포인트 이하가 되면 게임 종료
            //- 시작 포인트 10,000 포인트
            //- 노페어, 원페어, 투페어, 트리플, 포카드, 플러쉬, 스트레이트(기본형)
            //- 마운틴, 백스트레이트, 스티플, 로티플은(어려움)
            
            TrumpCard trumpCard = new TrumpCard();
            PlayGame playGame = new PlayGame();
            trumpCard.SetupTrumpCards();
            List<string> playerCard = new List<string>();
            List<string> computerCard = new List<string>();
            
            

            int point = 10_000;
            int userInPut = -1;
            bool gameOver = false;

            while (gameOver == false)
            {
                playerCard = trumpCard.PickCards();
                computerCard = trumpCard.PickCards();
                Console.Write("컴퓨터   픽: ");
                playGame.ShowCardSet(computerCard);

                Console.Write("플레이어 픽: ");
                playGame.ShowCardSet(playerCard);

                for (int i = 0; i < 2; i++)
                {
                    int playerInPut = 0;
                    Console.Write("교체할 카드(1~5번, 6번->패스) 선택: ");
                    int.TryParse(Console.ReadLine(), out playerInPut);

                    //switch (playerInPut)
                    //{
                    //    case 1:
                    //        playerCard[0] = trumpCard.ReRollCard();
                    //        break;
                    //    case 2:
                    //        playerCard[1] = trumpCard.ReRollCard();
                    //        break;
                    //    case 3:
                    //        playerCard[2] = trumpCard.ReRollCard();
                    //        break;
                    //    case 4:
                    //        playerCard[3] = trumpCard.ReRollCard();
                    //        break;
                    //    case 5:
                    //        playerCard[4] = trumpCard.ReRollCard();
                    //        break;
                    //    case 6:
                    //        //pass
                    //        break;
                    //    default:
                    //        Console.WriteLine("잘못 입력했습니다. 다시 선택하세요.");
                    //        i--;
                    //        break;
                    //} //switch문 종료
                } //for문 종료
                Console.WriteLine();
                Console.WriteLine("플레이어 카드");
                for (int i = 0; i < playerCard.Count; i++)
                {
                    Console.Write("{0} ", playerCard[i]);
                }
                Console.WriteLine();
                Console.WriteLine();

                for (int i = 0; i < 1; i++)
                {
                    Console.Write("베팅할 금액을 입력: ");
                    string str = Console.ReadLine();
                    Console.WriteLine();
                    bool isNum = str.All(char.IsDigit);

                    if (isNum == true)
                    {
                        int.TryParse(str, out userInPut);
                    }
                    else
                    {
                        Console.WriteLine("잘못 입력했습니다. 다시 입력하세요.");
                        Console.WriteLine();
                        i--;
                        continue;
                    }

                    if (0 < userInPut && userInPut <= point)
                    {
                        //포인트를 사용했으므로 point에서 userInPut값만큼 뺌
                        point -= userInPut;
                        Console.WriteLine("{0} 포인트 사용, 남은 포인트{1}", userInPut, point);
                        Console.WriteLine();
                    }
                    //0을입력하면 패스해야되므로 조건: userInPut이 0일 때
                    else if (userInPut == 0)
                    {
                        Console.WriteLine("패스했습니다.");
                        Console.WriteLine();
                        //userInPut값 초기화 ->이거안하면 0입력으로 패스후 다음 반복시 문자열or특수문자입력시
                        //정수가아닙니다 출력되고 userInPut값이 0이므로 패스했습니다가 또 출력됨 
                        userInPut -= 1;
                        //for문 다시 반복해야되므로 index--
                        i--;
                    } //if문 종료
                } //for문 종료
                string cardA = string.Empty;
                string cardB = string.Empty;
                cardA = trumpCard.ReRollCard();
                cardB = trumpCard.ReRollCard();
                computerCard.Add(cardA);
                computerCard.Add(cardB);
                Console.WriteLine("컴퓨터 카드");
                for (int i = 0; i < computerCard.Count; i++)
                {
                    Console.Write("{0} ", computerCard[i]);
                }
                Console.WriteLine();
                Console.WriteLine();
            } //while 종료
        } //main
    }
}