using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static Lap1.Map;

namespace Lap1
{
    public class Map
    {
        public struct BoardSet
        {
            public int boardSizeY;
            public int boardSizeX;
            public int peopleY;
            public int peopleX;
            public string people;
            public string[,] board;
            public bool loop;
            public string coin;
            public int coinY;
            public int coinX;
            public int cntCoin;
            public int mapCount;
            public int mapName;
        }
        BoardSet boardSet = new BoardSet();
        
        public Map()
        {
            Console.Write("보드의 Y축 길이를 입력하세요.: ");
            //보드의 크기를 정하기위한 Y축 string형식으로 입력받은걸 int형식으로 변환해서 저장
            int.TryParse(Console.ReadLine(), out boardSet.boardSizeY);
            Console.Write("보드의 X축 길이를 입력하세요.: ");
            //보드의 크기를 정하기위한 X축 string형식으로 입력받은걸 int형식으로 변환해서 저장
            int.TryParse(Console.ReadLine(), out boardSet.boardSizeX);

        }
        public BoardSet MapSet()
        {
            boardSet.coin = "$ ";
            boardSet.coinY = 0;
            boardSet.coinX = 0;
            boardSet.cntCoin = 0;
            boardSet.loop = false;

            boardSet.board = new string[boardSet.boardSizeY, boardSet.boardSizeX];
            //보드 ?X?배열 선언 (Y축,X축은 유저입력으로 받음)
            //사람을 "옷"으로 표시하기위해 선언
            boardSet.people = "옷";
            //w, a, s, d 입력받기위한 userInPut 선언
            string userInPut = default;

            //보드에 테두리는 "■"로 채우고 나머지 빈칸은 ". "로 채우기위한 첫번째 for문 loop: boardSizeY - 1 까지 루프
            for (int y = 0; y < boardSet.boardSizeY; y++)
            {
                //보드의 X축에 값을 입력하기위한 두번째 for문 loop: boardSizeX - 1 까지 루프
                for (int x = 0; x < boardSet.boardSizeX; x++)
                {
                    //board의 모든주소에 "■"를 채움
                    boardSet.board[y, x] = "■";
                    //눈으로 보기 위한 출력
                    //Console.Write("{0}", board[y, x]);
                    //테두리만 "■"로 채우고 안쪽으노 ". "로 채우기위한 첫번째 if문 조건: x값이 0보다 크고 boardSizeX - 1 보다 작음
                    if (0 < x && x < boardSet.boardSizeX - 1)
                    {
                        //양옆 테두리를 제외한 나머지칸에 ". " 저장
                        boardSet.board[y, x] = ". ";
                    } //첫번째 if문 종료
                    //맨위쪽은 테두리이므로 "■" 저장하기 위한 두번째 if문 조건: y값이 0 일때
                    if (y == 0)
                    {
                        //맨위쪽 테두리이므로 "■" 저장
                        boardSet.board[y, x] = "■";
                    } //두번째 if문 종료
                    //맨아래쪽 테두리이므로 "■" 저장하기 위한 세번째 if문 조건: y값이 boardSizeY - 1 일때
                    if (y == boardSet.boardSizeY - 1)
                    {
                        //맨아래쪽 테두리이므로 "■" 저장
                        boardSet.board[y, x] = "■";
                    } //세번째 if문 종료
                } //두번째 for문 종료
                //공백출력
            } //첫번째 for문 종료
            //공백출력
            Console.WriteLine();

            return boardSet;
        } //Map1

        public BoardSet CoinMap(BoardSet boardMap)
        {
            bool IsThereCoin = false;
            Random randomNum = new Random();
            //코인이 보드안에 있으면 true 없으면 false
            IsThereCoin = false;
            for (int i = 0; i <= boardMap.board.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= boardMap.board.GetUpperBound(1); j++)
                {
                    if (boardMap.board[i, j] == boardMap.coin)
                    {
                        //코인이 보드안에 존재하므로 true로 값변경 진행
                        IsThereCoin = true;
                    }
                }
            }
            //if문 시작 조건: IsThereCoin의 값이 반대일때
            //IsthereCoin은 필드에 코인이있으면 true, 없으면 false
            if (!IsThereCoin)
            {
                //보드안에 코인위치 선택을 위한 for문 시작 조건: 코인을 5개 둘거임
                for (int index = 0; index < 5; index++)
                {
                    //코인의 좌표값 랜덤설정
                    boardMap.coinY = randomNum.Next(1, boardMap.boardSizeY - 1);
                    boardMap.coinX = randomNum.Next(1, boardMap.boardSizeX - 1);
                    //코인위치 예외처리 if문 시작 조건: 보드위치에 코인값이 없을때
                    if (boardMap.board[boardMap.coinY, boardMap.coinX] != boardMap.coin)
                    {
                        //보드위치에 코인값이 없으므로 코인값저장
                        boardMap.board[boardMap.coinY, boardMap.coinX] = boardMap.coin;
                    }
                    else
                    {
                        //보드위치에 코인값이 이미 있으므로 for문 한번 더돌림
                        index--;
                    }
                    //if문 시작 조건: 배치된 코인위치 중 사람의 위치와 겹칠 때
                    if (boardMap.coinY == boardMap.peopleY && boardMap.coinX == boardMap.peopleX)
                    {
                        //사람의 위치가 코인과 겹치므로 사람으로 저장 for문 한번 더돌림
                        boardMap.board[boardMap.coinY, boardMap.coinX] = boardMap.people;
                        index--;
                    } //if문 종료
                } //for문 종료
                  //모든 예외처리가 완료되면 true로
                IsThereCoin = true;
            } //if문 종료
            return boardMap;
        }

        public BoardSet Map1()
        {
            BoardSet boardMap1 = new BoardSet();
            //bool IsThereCoin = false;
            //Random randomNum = new Random();
            boardMap1 = MapSet();
            for (int y = (boardMap1.boardSizeY / 2) - 1; y < (boardMap1.boardSizeY / 2); y++)
            {
                boardMap1.board[y, boardMap1.boardSizeX - 1] = "→";
            }
            for (int x = (boardMap1.boardSizeX / 2) - 1; x < (boardMap1.boardSizeX / 2); x++)
            {
                boardMap1.board[0, x] = "↑";
                boardMap1.peopleY = 1;
                boardMap1.peopleX = x;
                //boardMap1.board[boardMap1.peopleY, boardMap1.peopleX] = boardMap1.people;
            }
            //사람의 위치가 정중앙에서 시작하기위한 변수선언
            boardMap1.peopleY = boardMap1.boardSizeY / 2;
            boardMap1.peopleX = boardMap1.boardSizeX / 2;
            //board의 중앙위치에 people값("옷") 저장
            boardMap1.board[boardMap1.peopleY, boardMap1.peopleX] = boardMap1.people;

            return boardMap1;
        }

        public BoardSet Map2()
        {
            BoardSet boardMap2 = new BoardSet();
            boardMap2 = MapSet();
            for (int y = (boardMap2.boardSizeY / 2) - 1; y < (boardMap2.boardSizeY / 2); y++)
            {
                boardMap2.board[y, 0] = "←";
                boardMap2.peopleY = y;
                boardMap2.peopleX = 1;
                boardMap2.board[boardMap2.peopleY, boardMap2.peopleX] = boardMap2.people;
            }
            return boardMap2;
        }

        public BoardSet Map3()
        {
            BoardSet boardMap3 = new BoardSet();
            boardMap3 = MapSet();
            for (int x = (boardMap3.boardSizeX / 2) - 1; x < (boardMap3.boardSizeX / 2); x++)
            {
                boardMap3.board[0, x] = "↑";
                boardMap3.peopleY = 1;
                boardMap3.peopleX = x;
                boardMap3.board[boardMap3.peopleY, boardMap3.peopleX] = boardMap3.people;
            }
            return boardMap3;
        }
        
    } //Map
}
