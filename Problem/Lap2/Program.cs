using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lap2
{
    internal class Program
    {
        //게임 Map 출력을 위한 함수선언
        static void Map(char[,] board)
        {
            //3X3배열 2중 for문시작 loop: 3번루프
            for (int index = 0; index < 3; index++)
            {
                Console.WriteLine("=========");
                //두번째 for문 시작
                for (int index2 = 0; index2 < 3; index2++)
                {
                    Console.Write(" {0} ", board[index, index2]);
                } //두번째 for문 종료
                Console.WriteLine();
            } //첫번째for문 종료
            Console.WriteLine("=========");
        } //함수 끝
        
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

            //board 에 초기값 저장
            char[,] board = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', 'X' } };
            //게임승리조건이 초기값과 같아야하므로 초기값을 gameWinBoard에 저장
            char[,] gameWinBoard = (char[,])board.Clone();
            //'X'를 이동시키기위한 입력변수선언
            char userInPut = default;
            //'X'값은 board[2,2]위치에 있으므로 좌표값을 얻기위해 y축 X축 따로 선언함
            int boardY = 2;
            int boardX = 2;
            //게임시작전 맵을 랜덤하게 섞어주기위한 컴퓨터가 명령할 단어를 선언
            char[] computer = { 'w', 'a', 's', 'd'};
            //w, a, s, d중 랜덤으로 뽑기위한 랜덤선언
            Random randomChar = new Random();
            //while문을 들어가기위한 조건 선언
            bool boardSetting = false;
            //while문 시작 조건: boardSetting이 false일때
            while (boardSetting == false)
            {
                //for문시작 loop: 5번 루프(컴퓨터가 5번이동시킬거임)
                for (int index = 0; index < 5; index++)
                {
                    //i변수에 0 ~ computer.Length(4) 중 랜덤하게 한개 저장
                    int i = randomChar.Next(0, computer.Length);
                    //컴퓨터가 랜덤하게 선택한 w,a,s,d값중 하나의 값 저장
                    char computerPick = computer[i];
                    //컴퓨터가 입력한 방향 역방향 입력이 정답임
                    Console.Write("{0} ", computerPick);
                    //컴퓨터가 입력한 이동을 실행하기위한 switch문 시작 조건: computerPick
                    switch (computerPick)
                    {
                        //컴퓨터가 'w'입력시 실행
                        case 'w':
                            //조건: 3x3배열 밖으로 나가지 않게 설정
                            if (boardY > 0)
                            {
                                //버블정렬사용
                                //temp값에 이동할 방향의 값을 저장함
                                char temp = board[boardY - 1, boardX];
                                //이동할 방향의 값을 현재위치의 값으로 저장
                                board[boardY - 1, boardX] = board[boardY, boardX];
                                //원래있던 위치의 값을 이동한 방향의 초기값으로 저장
                                board[boardY, boardX] = temp;
                                //y축으로 -1 이동했으므로 --증감식사용
                                boardY--;
                            }
                            //boardY값이 0보다 작아지면 즉시종료
                            break;
                        //아래 case문들은 위의 식과 구조가 동일해서 주석생략
                        case 's':
                            if (boardY < 2)
                            {
                                char temp2 = board[boardY + 1, boardX];
                                board[boardY + 1, boardX] = board[boardY, boardX];
                                board[boardY, boardX] = temp2;
                                boardY++;
                            }
                            break;
                        case 'a':
                            if (boardX > 0)
                            {
                                char temp3 = board[boardY, boardX - 1];
                                board[boardY, boardX - 1] = board[boardY, boardX];
                                board[boardY, boardX] = temp3;
                                boardX--;
                            }
                            break;
                        case 'd':
                            if (boardX < 2)
                            {
                                char temp4 = board[boardY, boardX + 1];
                                board[boardY, boardX + 1] = board[boardY, boardX];
                                board[boardY, boardX] = temp4;
                                boardX++;
                            }
                            break;
                    } //switch문 종료
                } //for문 종료
                Console.WriteLine();
                //'X'의 위치가 초기값과 동일하면 board값이 승리조건과 같아지므로 예외처리하기 위한 변수 x선언
                char X = 'X';
                //예외처리 위한 if문 시작 조건:X의시작값이 board[2,2]의 값이 'X'가 아닐때
                if (board[2,2] != X)
                {
                    //while문을 빠져나가기위한 true선언
                    boardSetting = true;
                } //if문종료
            } //while문 종료
            Console.WriteLine();
            //함수Map 실행 컴퓨터가 실행한 보드세팅이 게임시작 보드임
            Map(board);

            //while문을 들어가기위한 조건 gameWin을 false로 선언
            bool gameWin = false;
            //몇번 실행했는지 확인하기위한 loop 선언
            int loop = 0;
            //while문 시작 조건: gameWin이 false일 때
            while (gameWin == false)
            {
                //유저입력을 받아 'X'를 이동시키기위한 for문 시작 loop: 1번돔
                for (int index = 0; index < 1; index++)
                {
                    Console.Write("w, a, s, d 중 이동할 방향을 입력하세요. ");
                    //string형식으로 입력받은 값을 char형식으로 변환
                    char.TryParse(Console.ReadLine(), out userInPut);
                    Console.WriteLine();
                    //'X'값 이동을 위한 switch문 시작 조건: userInPut
                    switch (userInPut)
                    {
                        //컴퓨터가 'X'값을 이동시킨거와 같은 구조
                        case 'w':
                            if (boardY > 0)
                            {
                                //버블정렬사용 컴퓨터이동구조와 같음
                                char temp = board[boardY - 1, boardX];
                                board[boardY - 1, boardX] = board[boardY, boardX];
                                board[boardY, boardX] = temp;
                                boardY--;
                            }
                            //3X3배열의 위치 이외의 위치는 갈수없으므로 예외처리
                            else
                            {
                                Console.WriteLine("위쪽 막혔음");
                                Console.WriteLine();
                            }
                            break;
                        //나머지 case 위와 구조 동일
                        case 's':
                            if (boardY < 2)
                            {
                                char temp2 = board[boardY + 1, boardX];
                                board[boardY + 1, boardX] = board[boardY, boardX];
                                board[boardY, boardX] = temp2;
                                boardY++;
                            }
                            else
                            {
                                Console.WriteLine("아래쪽 막혔음");
                                Console.WriteLine();
                            }
                            break;
                        case 'a':
                            if (boardX > 0)
                            {
                                char temp3 = board[boardY, boardX - 1];
                                board[boardY, boardX - 1] = board[boardY, boardX];
                                board[boardY, boardX] = temp3;
                                boardX--;
                            }
                            else
                            {
                                Console.WriteLine("왼쪽 막혔음");
                                Console.WriteLine();
                            }
                            break;
                        case 'd':
                            if (boardX < 2)
                            {
                                char temp4 = board[boardY, boardX + 1];
                                board[boardY, boardX + 1] = board[boardY, boardX];
                                board[boardY, boardX] = temp4;
                                boardX++;
                            }
                            else
                            {
                                Console.WriteLine("오른쪽 막혔음");
                                Console.WriteLine();
                            }
                            break;
                        //입력 예외처리를 위한 default
                        default:
                            Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요.");
                            Console.WriteLine();
                            //잘못 입력했으므로 loop를 다시 돌기위한 index --증감식사용
                            index--;
                            break;
                    } //switch문 종료
                    //board배열과 gameWinBoard배열의 모든 값과 값의 위치가 같은지 확인하기 위한 변수 t선언
                    int t = 0;
                    //board와 gameWinBoard 비교 첫번째for문 시작 loop: 3번 루프
                    for(int y = 0; y < 3; y++)
                    {
                        //두번째 for문시작
                        for(int x = 0; x < 3; x++)
                        {
                            //if문 시작 조건: board[y,x]값이 gameWinBoard[y,x]값과 동일할 때
                            if (board[y,x] == gameWinBoard[y, x])
                            {
                                //동일하면 t에 +1씩함
                                t += 1;
                                //두배열의 같은위치의 값이 동일하므로 컨티뉴를 사용하여 다음값을 비교
                                continue;
                            }
                            else
                            {
                                //두배열의 같은위치의 값이 동일하지 않으므로 즉시종료
                                break;
                            } //if문 종료
                        } //두번째 for문 종료
                    } //첫번째 for문 종료
                    //if문 시작 조건: t값이 9일때
                    if(t == 9)
                    {
                        //t값이 9라는건 board와 gameWinBoard의 값의 위치와 값이 모두 동일한 것이기 때문에
                        //while문을 빠져나가기 위해 true값 저장
                        gameWin = true;
                    } //if문 종료
                } //for문 종료
                //몇번 이동시켰는지 확인하기위해 1번루프마다 loop값을 +1시킴
                loop++;
                //유저입력후 맵상태 출력
                Map(board);
            } //while문 종료
            Console.WriteLine("승리 {0} 번 이동했습니다.", loop);
        } //main
    }
}
