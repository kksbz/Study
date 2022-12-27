using System;
using System.Collections.Generic;

namespace Lap2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /**
             * 슬라이딩 퍼즐 프로그램 작성하기 
             * 3x3 보드크기에 1~9숫자 부여 9=X로 표현
             * ex)
             * 4 1 3
             * X 5 2
             * 7 6 8
             * w, a, s, d입력으로 X를 움직임 X가 움직인 방향의 숫자와 X의 위치가 바뀜
             * 1 2 3
             * 4 5 6
             * 7 8 X
             * 식으로 숫자를 정렬하면 승리. 몇번 움직였는지 출력
             */

            char[,] chars = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', 'X' } };


            for (int index = 0; index < 3; index++)
            {
                Console.WriteLine("=========");
                for (int index2 = 0; index2 < 3; index2++)
                {

                    Console.Write(" {0} ", chars[index, index2]);

                }
                Console.WriteLine();
            }
            Console.WriteLine("=========");


            //int rN = 0;
            //for (int index = 0; index < 3; index++)
            //{
            //    Console.WriteLine("=========");
            //    for (int index2 = 0; index2 < 3; index2++)
            //    {
            //        board[index, index2] = rN + 1;
            //        rN++;
            //        Console.Write(" {0} ", board[index, index2]);
            //    }
            //    Console.WriteLine();
            //}
            //board[2, 2] = "X";
            //Console.Write("=========");

            //Console.WriteLine();
            //for (int index = 0; index < 3; index++)
            //{
            //    Console.WriteLine("=========");
            //    for (int index2 = 0; index2 < 3; index2++)
            //    {
            //        int y = randomNum.Next(0, 3);
            //        int x = randomNum.Next(0, 3);
            //        if (board[index,index2] != board[y, x])
            //        {
            //            int temp = board[index, index2];
            //            board[index, index2] = board[y, x];
            //            board[y, x] = temp;
            //        }
            //        else
            //        {
            //            break;
            //        }
            //        Console.Write(" {0} ", board[index, index2]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.Write("=========");

        }
    }
}