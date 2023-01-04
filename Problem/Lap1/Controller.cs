using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Lap1.Map;

namespace Lap1
{
    public class Controller
    {
        public ConsoleKeyInfo userInPut;

        public void Moving()
        {
            //if문 시작 조건: 키입력이 있을 때
            if (Console.KeyAvailable)
            {
                //키입력이있으면 키값을 가져와 userInPut에 저장
                userInPut = Console.ReadKey();
            } //if문 종료
        } //Moving

        public bool isRightInput()
        {
            //ConsoleKey. 사용으로 엔터를 치지않고 입력받을 때 예외처리를위한 bool 선언
            bool bIsRightInput = false;
            switch (userInPut.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.A:
                case ConsoleKey.S:
                case ConsoleKey.D:
                case ConsoleKey.X:
                    //위의 입력값만 true로 변환
                    bIsRightInput = true;
                    break;
                default:
                    break;
            }

            return bIsRightInput;
        } //isRightInput
        public void Init()
        {
            //ConsoleKeyInfo 클래스 인스턴스화
            ConsoleKeyInfo newCki = new ConsoleKeyInfo();
            userInPut = newCki;
        } //Init
    }


    public class MoveKey
    {
        public void PlayGame()
        {
            Map map = new Map();
            BoardSet board = new BoardSet();
            BoardSet board2 = new BoardSet();
            BoardSet board3 = new BoardSet();

            BoardSet temp = new BoardSet();
            Random randomNum = new Random();
            bool IsThereCoin = false;
            board = map.Map1();
            board.mapName = 1;
            board2 = map.Map2();
            board2.mapName = 2;
            board3 = map.Map3();

            
            while (board.loop == false)
            {
                //0.5초 멈춤
                Thread.Sleep(50);
                //콘솔창 커서위치 초기화
                Console.SetCursorPosition(0, 0);

                if(board.mapName == 2)
                {
                    board = map.CoinMap(board);
                }
                Console.WriteLine("플레이방법: w-위, s-아래, a-왼, d-오른, x-게임종료");
                Console.WriteLine("보유코인: {0} 현재 위치한 맵: {1}번방", board.cntCoin, board.mapName);

                //board의 상황을 출력하기 위한 첫번째 for문 시작 조건: y는 0 부터 boardSizeY -1 까지
                for (int y = 0; y < board.boardSizeY; y++)
                {
                    //두번째 for문 시작 조건 : X는 0 부터 boardSizeX -1 까지
                    for (int x = 0; x < board.boardSizeX; x++)
                    {
                        //board값 출력
                        Console.Write("{0}", board.board[y, x]);
                    }
                    //공백출력
                    Console.WriteLine();
                } //첫번째 for문 종료


                Console.WriteLine();

                //Controller controller = new Controller();
                MoveKey moveKey = new MoveKey();
                board = moveKey.MoveInfo(board);
                if (board.mapCount > 0)
                {
                    for(int i=0; i < 1; i++)
                    {
                        Console.Write("다음맵으로 이동하시겠습니까? (y/n): ");
                        string userInPut = string.Empty;
                        userInPut = Console.ReadLine();
                        switch (userInPut)
                        {
                            case "y":
                                if (board.mapName == 1)
                                {
                                    if (board.board[board.peopleY, board.peopleX] == board.board[(board.boardSizeY / 2) - 1, board.boardSizeX - 2])
                                    {
                                        temp = board;
                                        board = board2;
                                        board.cntCoin += temp.cntCoin;
                                    }
                                    else if (board.board[board.peopleY, board.peopleX] == board.board[1, (board.boardSizeX / 2) - 1])
                                    {
                                        temp = board;
                                        board = board3;
                                        board.cntCoin += temp.cntCoin;
                                    }
                                    break;
                                }
                                else if (board.mapName == 2)
                                {
                                    board = temp;
                                    temp = board;
                                }
                                break;
                            case "n":
                                break;
                            default:
                                Console.WriteLine("잘못 입력했습니다.");
                                i--;
                                break;
                        }
                        board.mapCount = 0;
                    }
                    Console.Clear();
                }

            } //while문 종료

        }

        public BoardSet MoveInfo(BoardSet board)
        {
            //Controller 클래스 인스턴스화
            Controller controller = new Controller();
            //Map map= new Map();
            //Moving함수 호출
            controller.Moving();
            //공백출력
            Console.WriteLine();

            //Moving함수에서 처리한 결과값 예외처리 함수 호출
            if (controller.isRightInput())


                //w, a, s, d 입력을 받았을때 people의 위치변경을 위한 switch문 시작 조건: userInPut값이 들어왔을때
                switch (controller.userInPut.Key)
                {
                    //"w"를 입력받을 때 시작
                    case ConsoleKey.W:
                        if (board.board[board.peopleY - 1, board.peopleX] == board.coin)
                        {
                            board.cntCoin++;
                        }
                        //Console.WriteLine("w입력 위로 이동합니다. ");
                        //사람의 기존위치값에 ". "을 입력하여 빈칸임을 표시하기함
                        board.board[board.peopleY, board.peopleX] = ". ";
                        //board의 Y축 위로 이동하므로 peopleY - 1 시킴 이동한칸에 people값 저장
                        board.board[board.peopleY - 1, board.peopleX] = board.people;
                        //Y축으로 - 1만큼 이동했으므로 --증감식을 사용해 people의 이동위치 저장
                        board.peopleY--;
                        //공백출력
                        Console.WriteLine();
                        
                        //맨위쪽 테두리에 막히면 이동불가하다를 구현하기위한 if문 시작 조건: peopleY값이 0일때 peopleX값이 0~boardSizeX - 1까지
                        if (board.peopleY == 0 && 0 <= board.peopleX && board.peopleX < board.boardSizeX)
                        {
                            if (board.board[board.peopleY, board.peopleX] == board.board[0 , (board.boardSizeX / 2) - 1])
                            {
                                if (board.mapName == 1)
                                {
                                    board.board[board.peopleY, board.peopleX] = "↑";
                                    board.board[board.peopleY + 1, board.peopleX] = board.people;
                                    board.peopleY++;
                                    board.mapCount++;
                                    break;
                                }
                            }
                            //맨위쪽 테두리에 막혔으므로 벽쪽으로 이동한 people의 위치에 "■" 값을 저장하여 테두리를 다시채움
                            board.board[board.peopleY, board.peopleX] = "■";
                            //테두리에 막혀 이동불가능하므로 전에 있던 위치에 다시 people값 저장
                            board.board[board.peopleY + 1, board.peopleX] = board.people;
                            //위쪽에서 --증감식으로 - 1 된값을 ++증감식으로 다시 복구시킴
                            board.peopleY++;
                            //Console.WriteLine("위쪽벽에 막혔습니다. 다시 입력하세요.");
                        }
                        break; //case 종료
                               //"a"를 입력받을 때 시작
                    case ConsoleKey.A:
                        //Console.WriteLine("a입력 왼쪽으로 이동합니다. ");
                        if (board.board[board.peopleY, board.peopleX - 1] == board.coin)
                        {
                            board.cntCoin++;
                        }
                        //사람의 기존위치값에 ". "을 입력하여 빈칸임을 표시하기함
                        board.board[board.peopleY, board.peopleX] = ". ";
                        //board의 X축 왼쪽으로 이동하므로 peopleX - 1 시킴 이동한칸에 people값 저장
                        board.board[board.peopleY, board.peopleX - 1] = board.people;
                        //X축으로 - 1만큼 이동했으므로 --증감식을 사용해 people의 이동위치 저장
                        board.peopleX--;

                        // 코인 습득 처리

                        //공백처리
                        Console.WriteLine();
                        //맨왼쪽 테두리에 막히면 이동불가하다를 구현하기위한 if문 시작 조건: peopleX값이 0일때 peopleY값이 0~boardSizeY - 1까지
                        if (board.peopleX == 0 && 0 <= board.peopleY && board.peopleY < board.boardSizeY)
                        {
                            if (board.board[board.peopleY, board.peopleX] == board.board[(board.boardSizeY / 2) - 1, 0])
                            {
                                if (board.mapName == 2)
                                {
                                    board.board[board.peopleY, board.peopleX] = "←";
                                    board.board[board.peopleY, board.peopleX + 1] = board.people;
                                    board.peopleX++;
                                    board.mapCount++;
                                    break;
                                }
                            }
                            //맨왼쪽 테두리에 막혔으므로 벽쪽으로 이동한 people의 위치에 "■" 값을 저장하여 테두리를 다시채움
                            board.board[board.peopleY, board.peopleX] = "■";
                            //테두리에 막혀 이동불가능하므로 전에 있던 위치에 다시 people값 저장
                            board.board[board.peopleY, board.peopleX + 1] = board.people;
                            //위쪽에서 --증감식으로 - 1 된값을 ++증감식으로 다시 복구시킴
                            board.peopleX++;
                            //Console.WriteLine("왼쪽벽에 막혔습니다. 다시 입력하세요.");

                        } //if문 종료
                        break; //case 종료
                               //"s"를 입력받을 때 시작           
                    case ConsoleKey.S:
                        if (board.board[board.peopleY + 1, board.peopleX] == board.coin)
                        {
                            board.cntCoin++;
                        }
                        //Console.WriteLine("s입력 밑으로 이동합니다. ");
                        //사람의 기존위치값에 ". "을 입력하여 빈칸임을 표시하기함
                        board.board[board.peopleY, board.peopleX] = ". ";
                        //board의 Y축 밑쪽으로 이동하므로 peopleY + 1 시킴 이동한칸에 people값 저장
                        board.board[board.peopleY + 1, board.peopleX] = board.people;
                        //Y축으로 + 1만큼 이동했으므로 ++증감식을 사용해 people의 이동위치 저장
                        board.peopleY++;
                        //공백출력
                        Console.WriteLine();
                        //맨밑쪽 테두리에 막히면 이동불가하다를 구현하기위한 if문 시작 조건: peopleY값이 boardSizeY - 1 일때 peopleX값이 0~boardSizeX - 1까지
                        if (board.peopleY == board.boardSizeY - 1 && 0 <= board.peopleX && board.peopleX < board.boardSizeX)
                        {
                            //맨밑쪽 테두리에 막혔으므로 벽쪽으로 이동한 people의 위치에 "■" 값을 저장하여 테두리를 다시채움
                            board.board[board.peopleY, board.peopleX] = "■";
                            //테두리에 막혀 이동불가능하므로 전에 있던 위치에 다시 people값 저장
                            board.board[board.peopleY - 1, board.peopleX] = board.people;
                            //위쪽에서 ++증감식으로 + 1 된값을 --증감식으로 다시 복구시킴
                            board.peopleY--;
                            //Console.WriteLine("밑쪽벽에 막혔습니다. 다시 입력하세요.");
                        } //if문 종료
                        break; //case 종료
                               //"d"를 입력받을 때 시작
                    case ConsoleKey.D:
                        if (board.board[board.peopleY, board.peopleX + 1] == board.coin)
                        {
                            board.cntCoin++;
                        }
                        //Console.WriteLine("d입력 오른쪽으로 이동합니다. ");
                        //사람의 기존위치값에 ". "을 입력하여 빈칸임을 표시하기함
                        board.board[board.peopleY, board.peopleX] = ". ";
                        //board의 X축 오른쪽으로 이동하므로 peopleX + 1 시킴 이동한칸에 people값 저장
                        board.board[board.peopleY, board.peopleX + 1] = board.people;
                        //X축으로 + 1만큼 이동했으므로 ++증감식을 사용해 people의 이동위치 저장
                        board.peopleX++;
                        //공백출력
                        Console.WriteLine();
                        //맨오른쪽 테두리에 막히면 이동불가하다를 구현하기위한 if문 시작 조건: peopleX값이 boardSizeX - 1 일때 peopleY값이 0~boardSizeY - 1까지
                        if (board.peopleX == board.boardSizeX - 1 && 0 <= board.peopleY && board.peopleY < board.boardSizeY)
                        {
                            if (board.board[board.peopleY, board.peopleX] == board.board[(board.boardSizeY / 2) - 1, board.boardSizeX - 1])
                            {
                                if (board.mapName == 1)
                                {
                                    board.board[board.peopleY, board.peopleX] = "→";
                                    board.board[board.peopleY, board.peopleX - 1] = board.people;
                                    board.peopleX--;
                                    board.mapCount++;
                                    break;
                                }
                            }
                            //맨오른쪽 테두리에 막혔으므로 벽쪽으로 이동한 people의 위치에 "■" 값을 저장하여 테두리를 다시채움
                            board.board[board.peopleY, board.peopleX] = "■";
                            //테두리에 막혀 이동불가능하므로 전에 있던 위치에 다시 people값 저장
                            board.board[board.peopleY, board.peopleX - 1] = board.people;
                            //위쪽에서 ++증감식으로 + 1 된값을 --증감식으로 다시 복구시킴
                            board.peopleX--;
                            //Console.WriteLine("오른쪽벽에 막혔습니다. 다시 입력하세요.");

                        } //if문 종료
                        break; //case 종료
                               //"X"를 입력받을 때 시작
                    case ConsoleKey.X:
                        Console.WriteLine("2초 뒤 게임을 종료합니다.");
                        Thread.Sleep(2000);
                        //게임종료를 입력했으므로 while문을 빠져나가기위한 조건인 loop값을 true로 저장
                        board.loop = true;
                        break; //case 종료
                               //w, a, s, d, X를 제외한 입력들을 예외처리하기위한 default 시작
                } //switch문 종료
            //ConsoleKeyInfo 값 초기화 함수 호출
            controller.Init();
            Console.WriteLine();
            return board;
        } //MoveInfo

    } //MoveKey
}
