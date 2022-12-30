using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
namespace Lap1
{
    public class Controller
    {
        //변수 선언
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
            switch(userInPut.Key)
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
    } //Controller

    internal class Program
    {
        public static void SwapCoin(string[,] Input)
        {
            //입력받은 배열[,]에 코인위치 출력
            string coin = "$";
            for (int y = 0; y < Input.GetUpperBound(0); y++)
            {
                for (int x = 0; x < Input.GetUpperBound(1); x++)
                {
                    if (Input[y, x] == coin)
                    {
                        Console.Write("{0}", Input[y, x]);
                        Task.Delay(100).Wait();
                    }
                }
            }
        } //SwapCoin
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

            //board의 사이즈를 입력받고 사람이 중앙에서 시작하는 프로그램으로 작성해봄
            //w, a, s, d 입력은 이동하고 X 입력은 게임종료

            int boardSizeY = 0;
            int boardSizeX = 0;
            Console.Write("보드의 Y축 길이를 입력하세요.: ");
            //보드의 크기를 정하기위한 Y축 string형식으로 입력받은걸 int형식으로 변환해서 저장
            int.TryParse(Console.ReadLine(), out boardSizeY);
            Console.Write("보드의 X축 길이를 입력하세요.: ");
            //보드의 크기를 정하기위한 X축 string형식으로 입력받은걸 int형식으로 변환해서 저장
            int.TryParse(Console.ReadLine(), out boardSizeX);



            //보드 ?X?배열 선언 (Y축,X축은 유저입력으로 받음)
            string[,] board = new string[boardSizeY, boardSizeX];
            //사람을 "옷"으로 표시하기위해 선언
            string people = "옷";
            //w, a, s, d 입력받기위한 userInPut 선언
            string userInPut = default;



            //보드에 테두리는 "■"로 채우고 나머지 빈칸은 ". "로 채우기위한 첫번째 for문 loop: boardSizeY - 1 까지 루프
            for (int y = 0; y < boardSizeY; y++)
            {
                //보드의 X축에 값을 입력하기위한 두번째 for문 loop: boardSizeX - 1 까지 루프
                for (int x = 0; x < boardSizeX; x++)
                {
                    //board의 모든주소에 "■"를 채움
                    board[y, x] = "■";
                    //눈으로 보기 위한 출력
                    //Console.Write("{0}", board[y, x]);
                    //테두리만 "■"로 채우고 안쪽으노 ". "로 채우기위한 첫번째 if문 조건: x값이 0보다 크고 boardSizeX - 1 보다 작음
                    if (0 < x && x < boardSizeX - 1)
                    {
                        //양옆 테두리를 제외한 나머지칸에 ". " 저장
                        board[y, x] = ". ";
                    } //첫번째 if문 종료
                    //맨위쪽은 테두리이므로 "■" 저장하기 위한 두번째 if문 조건: y값이 0 일때
                    if (y == 0)
                    {
                        //맨위쪽 테두리이므로 "■" 저장
                        board[y, x] = "■";
                    } //두번째 if문 종료
                    //맨아래쪽 테두리이므로 "■" 저장하기 위한 세번째 if문 조건: y값이 boardSizeY - 1 일때
                    if (y == boardSizeY - 1)
                    {
                        //맨아래쪽 테두리이므로 "■" 저장
                        board[y, x] = "■";
                    } //세번째 if문 종료
                } //두번째 for문 종료
                //공백출력
                Console.WriteLine();
            } //첫번째 for문 종료
            //공백출력
            Console.WriteLine();
            //사람의 위치가 정중앙에서 시작하기위한 변수선언
            int peopleY = boardSizeY / 2;
            int peopleX = boardSizeX / 2;
            //board의 중앙위치에 people값("옷") 저장
            board[peopleY, peopleX] = people;

            // 코인
            string coin = "$ ";
            Random randomNum = new Random();
            int coinY = 0;
            int coinX = 0;
            int cntCoin = 0;
            //코인별 위치 예외처리를 위한 bool값 선언
            bool IsThereCoin = false;
            //while문을 들어가기 위한 bool값 선언
            bool loop = false;
            //while문 시작
            while (loop == false)
            {
                //0.5초 멈춤
                Thread.Sleep(50);
                //콘솔창 커서위치 초기화
                Console.SetCursorPosition(0, 3);

                //코인이 보드안에 있으면 true 없으면 false
                IsThereCoin = false;
                for (int i = 0; i <= board.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= board.GetUpperBound(1); j++)
                    {
                        if (board[i, j] == coin)
                        {
                            //코인이 보드안에 존재하므로 true로 값변경 진행
                            IsThereCoin = true;
                        }
                    }
                }

                Console.WriteLine("보유코인: {0}", cntCoin);

                //if문 시작 조건: IsThereCoin의 값이 반대일때
                //IsthereCoin은 필드에 코인이있으면 true, 없으면 false
                if (!IsThereCoin)
                {
                    //보드안에 코인위치 선택을 위한 for문 시작 조건: 코인을 5개 둘거임
                    for (int index = 0; index < 5; index++)
                    {
                        //코인의 좌표값 랜덤설정
                        coinY = randomNum.Next(1, boardSizeY - 1);
                        coinX = randomNum.Next(1, boardSizeX - 1);
                        //코인위치 예외처리 if문 시작 조건: 보드위치에 코인값이 없을때
                        if (board[coinY, coinX] != coin)
                        {
                            //보드위치에 코인값이 없으므로 코인값저장
                            board[coinY, coinX] = coin;
                        }
                        else
                        {
                            //보드위치에 코인값이 이미 있으므로 for문 한번 더돌림
                            index--;
                        }
                        //if문 시작 조건: 배치된 코인위치 중 사람의 위치와 겹칠 때
                        if (coinY == peopleY && coinX == peopleX)
                        {
                            //사람의 위치가 코인과 겹치므로 사람으로 저장 for문 한번 더돌림
                            board[coinY, coinX] = people;
                            index--;
                        } //if문 종료
                    } //for문 종료
                    //모든 예외처리가 완료되면 true로
                    IsThereCoin = true;
                } //if문 종료

                //board의 상황을 출력하기 위한 첫번째 for문 시작 조건: y는 0 부터 boardSizeY -1 까지
                for (int y = 0; y < boardSizeY; y++)
                {
                    //두번째 for문 시작 조건 : X는 0 부터 boardSizeX -1 까지
                    for (int x = 0; x < boardSizeX; x++)
                    {
                        //board값 출력
                        Console.Write("{0}", board[y, x]);
                    }
                    //공백출력
                    Console.WriteLine();
                } //첫번째 for문 종료

                //보드위에 코인위치가 있는곳에 코인 배치 함수 호출
                SwapCoin(board);

                //for (int y = 0; y < boardSizeY; y++)
                //{
                //    for (int x = 0; x < boardSizeX; x++)
                //    {
                //        if (board[y, x] == coin)
                //        {
                //            Console.Write("{0}", board[y, x]);
                //            Task.Delay(300).Wait();
                //        }
                //    }
                //}
                Console.WriteLine();

                //예외처리를 위한 for문 시작 조건: index값이 1 보다 작을 때
                for (int index = 0; index < 1; index++)
                {
                    //Console.Write("w, a, s, d 중 하나를 입력하세요. 게임종료는 X를 입력하세요. : ");
                    //userInPut 안에 입력값을 저장함
                    //userInPut = Console.ReadLine();
                    
                    //Controller 클래스 인스턴스화
                    Controller controller = new Controller();
                    //Moving함수 호출
                    controller.Moving();
                    //공백출력
                    Console.WriteLine();

                    //Moving함수에서 처리한 결과값 예외처리 함수 호출
                    if(controller.isRightInput())

                    //w, a, s, d 입력을 받았을때 people의 위치변경을 위한 switch문 시작 조건: userInPut값이 들어왔을때
                    switch (controller.userInPut.Key)
                    {
                        //"w"를 입력받을 때 시작
                        case ConsoleKey.W :
                            if (board[peopleY - 1, peopleX] == coin)
                            {
                                cntCoin++;
                            }
                            Console.WriteLine("w입력 위로 이동합니다. ");
                            //사람의 기존위치값에 ". "을 입력하여 빈칸임을 표시하기함
                            board[peopleY, peopleX] = ". ";
                            //board의 Y축 위로 이동하므로 peopleY - 1 시킴 이동한칸에 people값 저장
                            board[peopleY - 1, peopleX] = people;
                            //Y축으로 - 1만큼 이동했으므로 --증감식을 사용해 people의 이동위치 저장
                            peopleY--;
                            //공백출력
                            Console.WriteLine();
                            //맨위쪽 테두리에 막히면 이동불가하다를 구현하기위한 if문 시작 조건: peopleY값이 0일때 peopleX값이 0~boardSizeX - 1까지
                            if (peopleY == 0 && 0 <= peopleX && peopleX < boardSizeX)
                            {
                                //맨위쪽 테두리에 막혔으므로 벽쪽으로 이동한 people의 위치에 "■" 값을 저장하여 테두리를 다시채움
                                board[peopleY, peopleX] = "■";
                                //테두리에 막혀 이동불가능하므로 전에 있던 위치에 다시 people값 저장
                                board[peopleY + 1, peopleX] = people;
                                //위쪽에서 --증감식으로 - 1 된값을 ++증감식으로 다시 복구시킴
                                peopleY++;
                                Console.WriteLine("위쪽벽에 막혔습니다. 다시 입력하세요.");
                            }
                            break; //case 종료
                        //"a"를 입력받을 때 시작
                        case ConsoleKey.A:
                            Console.WriteLine("a입력 왼쪽으로 이동합니다. ");
                            if (board[peopleY, peopleX - 1] == coin)
                            {
                                cntCoin++;
                            }
                            //사람의 기존위치값에 ". "을 입력하여 빈칸임을 표시하기함
                            board[peopleY, peopleX] = ". ";
                            //board의 X축 왼쪽으로 이동하므로 peopleX - 1 시킴 이동한칸에 people값 저장
                            board[peopleY, peopleX - 1] = people;
                            //X축으로 - 1만큼 이동했으므로 --증감식을 사용해 people의 이동위치 저장
                            peopleX--;

                            // 코인 습득 처리

                            //공백처리
                            Console.WriteLine();
                            //맨왼쪽 테두리에 막히면 이동불가하다를 구현하기위한 if문 시작 조건: peopleX값이 0일때 peopleY값이 0~boardSizeY - 1까지
                            if (peopleX == 0 && 0 <= peopleY && peopleY < boardSizeY)
                            {
                                //맨왼쪽 테두리에 막혔으므로 벽쪽으로 이동한 people의 위치에 "■" 값을 저장하여 테두리를 다시채움
                                board[peopleY, peopleX] = "■";
                                //테두리에 막혀 이동불가능하므로 전에 있던 위치에 다시 people값 저장
                                board[peopleY, peopleX + 1] = people;
                                //위쪽에서 --증감식으로 - 1 된값을 ++증감식으로 다시 복구시킴
                                peopleX++;
                                Console.WriteLine("왼쪽벽에 막혔습니다. 다시 입력하세요.");
                            } //if문 종료
                            break; //case 종료
                        //"s"를 입력받을 때 시작           
                        case ConsoleKey.S:
                            if (board[peopleY + 1, peopleX] == coin)
                            {
                                cntCoin++;
                            }
                            Console.WriteLine("s입력 밑으로 이동합니다. ");
                            //사람의 기존위치값에 ". "을 입력하여 빈칸임을 표시하기함
                            board[peopleY, peopleX] = ". ";
                            //board의 Y축 밑쪽으로 이동하므로 peopleY + 1 시킴 이동한칸에 people값 저장
                            board[peopleY + 1, peopleX] = people;
                            //Y축으로 + 1만큼 이동했으므로 ++증감식을 사용해 people의 이동위치 저장
                            peopleY++;
                            //공백출력
                            Console.WriteLine();
                            //맨밑쪽 테두리에 막히면 이동불가하다를 구현하기위한 if문 시작 조건: peopleY값이 boardSizeY - 1 일때 peopleX값이 0~boardSizeX - 1까지
                            if (peopleY == boardSizeY - 1 && 0 <= peopleX && peopleX < boardSizeX)
                            {
                                //맨밑쪽 테두리에 막혔으므로 벽쪽으로 이동한 people의 위치에 "■" 값을 저장하여 테두리를 다시채움
                                board[peopleY, peopleX] = "■";
                                //테두리에 막혀 이동불가능하므로 전에 있던 위치에 다시 people값 저장
                                board[peopleY - 1, peopleX] = people;
                                //위쪽에서 ++증감식으로 + 1 된값을 --증감식으로 다시 복구시킴
                                peopleY--;
                                Console.WriteLine("밑쪽벽에 막혔습니다. 다시 입력하세요.");
                            } //if문 종료
                            break; //case 종료
                        //"d"를 입력받을 때 시작
                        case ConsoleKey.D:
                            if (board[peopleY, peopleX + 1] == coin)
                            {
                                cntCoin++;
                            }
                            Console.WriteLine("d입력 오른쪽으로 이동합니다. ");
                            //사람의 기존위치값에 ". "을 입력하여 빈칸임을 표시하기함
                            board[peopleY, peopleX] = ". ";
                            //board의 X축 오른쪽으로 이동하므로 peopleX + 1 시킴 이동한칸에 people값 저장
                            board[peopleY, peopleX + 1] = people;
                            //X축으로 + 1만큼 이동했으므로 ++증감식을 사용해 people의 이동위치 저장
                            peopleX++;
                            //공백출력
                            Console.WriteLine();
                            //맨오른쪽 테두리에 막히면 이동불가하다를 구현하기위한 if문 시작 조건: peopleX값이 boardSizeX - 1 일때 peopleY값이 0~boardSizeY - 1까지
                            if (peopleX == boardSizeX - 1 && 0 <= peopleY && peopleY < boardSizeY)
                            {
                                //맨오른쪽 테두리에 막혔으므로 벽쪽으로 이동한 people의 위치에 "■" 값을 저장하여 테두리를 다시채움
                                board[peopleY, peopleX] = "■";
                                //테두리에 막혀 이동불가능하므로 전에 있던 위치에 다시 people값 저장
                                board[peopleY, peopleX - 1] = people;
                                //위쪽에서 ++증감식으로 + 1 된값을 --증감식으로 다시 복구시킴
                                peopleX--;
                                Console.WriteLine("오른쪽벽에 막혔습니다. 다시 입력하세요.");
                            } //if문 종료
                            break; //case 종료
                        //"X"를 입력받을 때 시작
                        case ConsoleKey.X:
                            Console.WriteLine("게임을 종료합니다.");
                            //게임종료를 입력했으므로 while문을 빠져나가기위한 조건인 loop값을 true로 저장
                            loop = true;
                            break; //case 종료
                        //w, a, s, d, X를 제외한 입력들을 예외처리하기위한 default 시작
                        default:
                            Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요.");
                            //for문을 다시 돌리기위한 index값을 --증감식 사용
                            index--;
                            break; //default 종료
                    } //switch문 종료
                    
                    //ConsoleKeyInfo 값 초기화 함수 호출
                    controller.Init();
                    Console.WriteLine();
                } //for문 종료
            } //while문 종료
            Console.WriteLine();
        } // main
    } // class
}
