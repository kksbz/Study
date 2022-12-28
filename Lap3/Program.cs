using System;
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
            TrumpCard trumpCard = new TrumpCard();
            trumpCard.SetupTrumpCards();

            int point = 10_000;
            int userInPut = 0;
            string computer1 = default;
            string computer2 = default;
            string player = default;
            bool gameWin = false;

            while (gameWin == false)
            {
                for (int index = 0; index < 1; index++)
                {
                    trumpCard.ShuffleCards();
                    computer1 = trumpCard.RollCard();

                    trumpCard.ShuffleCards();
                    computer2 = trumpCard.RollCard();

                    int com1 = TrumpCard.turn(computer1);
                    int com2 = TrumpCard.turn(computer2);
                    Console.WriteLine("컴퓨터가 뽑은 카드는 {0}, {1}입니다.", computer1, computer2);

                    Console.Write("베팅할 금액을 입력하세요. : ");
                    int.TryParse(Console.ReadLine(), out userInPut);
                    point -= userInPut;
                    Console.WriteLine("포인트{0}", point);

                    trumpCard.ShuffleCards();
                    player = trumpCard.RollCard();
                    int play1 = TrumpCard.turn(player);
                    Console.WriteLine("플레이어가 뽑은 카드는 {0} 입니다.", player);

                    if (com1 < com2)
                    {
                        if (play1 > com1 && play1 < com2)
                        {
                            point += (userInPut * 2);
                            Console.WriteLine("베팅성공 포인트 2배 겟 총포인트: {0}", point);
                            index--;
                        }
                        else
                        {
                            Console.WriteLine("베팅실패");
                            index--;
                        }
                    }
                    else
                    {
                        if (play1 > com2 && play1 < com1)
                        {
                            point += (userInPut * 2);
                            Console.WriteLine("베팅성공 포인트 2배 겟 총포인트: {0}", point);
                            index--;
                        }
                        else
                        {
                            Console.WriteLine("베팅실패");
                            index--;
                        }
                    }
                }//for문 종료

            }//while 종료

        }
    }
}