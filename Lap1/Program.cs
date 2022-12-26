using System;
using System.ComponentModel;

namespace Lap1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /**
             * 5x5보드(사이즈 줘도 ok)
             * □<ㅁ한자, '.(닷)'은 빈칸, □는 벽 을 의미
             * □ □ □ □ □
             * □. . .  □
             * □. . .  □
             * □. . .  □
             * □ □ □ □ □
             * 빈 곳중에 아무곳(ex-정중앙)이나 사람(이모티콘 또는 옷)을 초기화해서
             * w, a, s, d 입력 받아서 빈 곳을 자유롭게 이동하는 프로그램 작성. (유저입력받아서 이동)
             * - 사람은 빈 곳을 다닐 수 있음.
             * -사람은 벽을 넘어다닐 수 없음.
             */
            const int BOARD_SIZE_Y = 5;
            const int BOARD_SIZE_X = 5;
            string[,] board = new string[BOARD_SIZE_Y, BOARD_SIZE_X];
            string people = "옷";
            string userInPut = default;

            for (int y = 0; y < BOARD_SIZE_Y; y++)
            {
                for (int x = 0; x < BOARD_SIZE_X; x++)
                {
                    board[y, x] = "■";
                    Console.Write("{0}", board[y, x]);
                    if (0 < x && x < 4)
                    {
                        board[y, x] = ". ";
                    }
                    if (y == 0)
                    {
                        board[y, x] = "■";
                    }
                    if (y == 4)
                    {
                        board[y, x] = "■";
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            board[2, 2] = people;
            //잘입력됐나 출력하기
            for (int y = 0; y < BOARD_SIZE_Y; y++)
            {
                for (int x = 0; x < BOARD_SIZE_X; x++)
                {
                    Console.Write("{0}", board[y, x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            
            for (int y = 0; y < BOARD_SIZE_Y; y++)
            {
                for (int x = 0; x < BOARD_SIZE_X; x++)
                {
                    for (int index = 0; index < 1; index++)
                    {
                        Console.WriteLine("w, a, s, d 중 하나를 입력하세요.");
                        userInPut = Console.ReadLine();
                        switch (userInPut)
                        {
                            case "w":
                                Console.Write("w입력 위로 이동합니다. ");
                                board[2 - 1, 2] = people;
                                break;
                            case "a":
                                Console.Write("a입력 왼쪽으로 이동합니다. ");
                                board[2, 2 - 1] = people;
                                break;
                            case "s":
                                Console.Write("s입력 밑으로 이동합니다. ");
                                board[2 + 1, 2] = people;
                                break;
                            case "d":
                                Console.Write("d입력 오른쪽으로 이동합니다. ");
                                board[2, 2 + 1] = people;
                                break;
                            default:
                                Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요.");
                                y--;
                                break;
                        }
                        Console.WriteLine();
                    }
                }
            }


            for (int y = 0; y < BOARD_SIZE_Y; y++)
            {
                for (int x = 0; x < BOARD_SIZE_X; x++)
                {
                    Console.Write("{0}", board[y, x]);
                }
                Console.WriteLine();
            }


        } // main
    } // class
}
