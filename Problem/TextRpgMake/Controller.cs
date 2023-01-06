using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static TextRpgMake.Map;

namespace TextRpgMake
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
    } //Controller

    public class MoveKey
    {
        public MapSet MoveInfo(MapSet mapNumber)
        {
            mapNumber.monsterCount = false;
            mapNumber.potalCount = false;
            mapNumber.end = false;
            //Controller 클래스 인스턴스화
            Controller controller = new Controller();
            //Map map= new Map();
            //Moving함수 호출
            controller.Moving();
            //공백출력
            Console.WriteLine();

            //Moving함수에서 처리한 결과값 예외처리 함수 호출
            if (controller.isRightInput()) { }

            //w, a, s, d 입력을 받았을때 플레이어의 위치변경을 위한 switch문 시작 조건: userInPut값이 들어왔을때
            switch (controller.userInPut.Key)
            {
                //"w"를 입력받을 때 시작
                case ConsoleKey.W:
                    if (mapNumber.map[mapNumber.playerY - 1, mapNumber.playerX] == mapNumber.monsterMark)
                    {
                        mapNumber.monsterCount = true;
                    }
                    //Console.WriteLine("w입력 위로 이동합니다. ");
                    //사람의 기존위치값에 ". "을 입력하여 빈칸임을 표시하기함
                    mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.mapMark;
                    //board의 Y축 위로 이동하므로 peopleY - 1 시킴 이동한칸에 people값 저장
                    mapNumber.map[mapNumber.playerY - 1, mapNumber.playerX] = mapNumber.playerMark;
                    //Y축으로 - 1만큼 이동했으므로 --증감식을 사용해 플레이어의 이동위치 저장
                    mapNumber.playerY--;


                    //여기서부터 수정 상점이랑 모텔 좌표수정해야됨 01-06 학원끝
                    if (mapNumber.map[mapNumber.playerY -1, mapNumber.playerX] == mapNumber.map[mapNumber.shopY, mapNumber.shopX])
                    {
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.shop;
                        mapNumber.map[mapNumber.playerY + 1, mapNumber.playerX] = mapNumber.playerMark;
                        mapNumber.playerY++;
                        mapNumber.shopCount = true;
                    }
                    if (mapNumber.map[mapNumber.playerY - 1, mapNumber.playerX] == mapNumber.map[mapNumber.motelY, mapNumber.motelX])
                    {
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.motel;
                        mapNumber.map[mapNumber.playerY + 1, mapNumber.playerX] = mapNumber.playerMark;
                        mapNumber.playerY++;
                        mapNumber.motelCount = true;
                    }

                    //맨위쪽 테두리에 막히면 이동불가하다를 구현하기위한 if문 시작
                    if (mapNumber.playerY == 0 && 0 <= mapNumber.playerX && mapNumber.playerX < mapNumber.mapSizeX)
                    {
                        //포탈에 닿았을 때
                        if (mapNumber.map[mapNumber.playerY, mapNumber.playerX] == mapNumber.map[mapNumber.potalY, mapNumber.potalX])
                        {
                            mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.potal;
                            mapNumber.map[mapNumber.playerY + 1, mapNumber.playerX] = mapNumber.mapMark;
                            mapNumber.playerY++;
                            mapNumber.potalCount = true;
                            break;
                        }
                        //맨위쪽 테두리에 막혔으므로 벽쪽으로 이동한 people의 위치에 "■" 값을 저장하여 테두리를 다시채움
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.mapEdgeMark;
                        //테두리에 막혀 이동불가능하므로 전에 있던 위치에 다시 people값 저장
                        mapNumber.map[mapNumber.playerY + 1, mapNumber.playerX] = mapNumber.playerMark;
                        //위쪽에서 --증감식으로 - 1 된값을 ++증감식으로 다시 복구시킴
                        mapNumber.playerY++;
                        //Console.WriteLine("위쪽벽에 막혔습니다. 다시 입력하세요.");
                    }
                    break; //case 종료
                //"a"를 입력받을 때 시작
                case ConsoleKey.A:
                    //Console.WriteLine("a입력 왼쪽으로 이동합니다. ");
                    if (mapNumber.map[mapNumber.playerY, mapNumber.playerX - 1] == mapNumber.monsterMark)
                    {
                        mapNumber.monsterCount = true;
                    }
                    //사람의 기존위치값에 ". "을 입력하여 빈칸임을 표시하기함
                    mapNumber.map[mapNumber.playerY, mapNumber.playerX] = ". ";
                    //board의 X축 왼쪽으로 이동하므로 peopleX - 1 시킴 이동한칸에 people값 저장
                    mapNumber.map[mapNumber.playerY, mapNumber.playerX - 1] = mapNumber.playerMark;
                    //X축으로 - 1만큼 이동했으므로 --증감식을 사용해 people의 이동위치 저장
                    mapNumber.playerX--;

                    if (mapNumber.map[mapNumber.playerY, mapNumber.playerX - 1] == mapNumber.map[mapNumber.shopY, mapNumber.shopX])
                    {
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.shop;
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX + 1] = mapNumber.playerMark;
                        mapNumber.playerX++;
                        mapNumber.shopCount = true;
                    }
                    if (mapNumber.map[mapNumber.playerY, mapNumber.playerX - 1] == mapNumber.map[mapNumber.motelY, mapNumber.motelX])
                    {
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.motel;
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX + 1] = mapNumber.playerMark;
                        mapNumber.playerX++;
                        mapNumber.motelCount = true;
                    }

                    //맨왼쪽 테두리에 막히면 이동불가하다를 구현하기위한 if문 시작
                    if (mapNumber.playerX == 0 && 0 <= mapNumber.playerY && mapNumber.playerY < mapNumber.mapSizeY)
                    {
                        if (mapNumber.map[mapNumber.playerY, mapNumber.playerX] == mapNumber.map[mapNumber.potalY, mapNumber.potalX])
                        {
                            mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.potal;
                            mapNumber.map[mapNumber.playerY, mapNumber.playerX + 1] = mapNumber.mapMark;
                            mapNumber.playerX++;
                            mapNumber.potalCount = true;
                            break;
                        }
                        //맨왼쪽 테두리에 막혔으므로 벽쪽으로 이동한 people의 위치에 "■" 값을 저장하여 테두리를 다시채움
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.mapEdgeMark;
                        //테두리에 막혀 이동불가능하므로 전에 있던 위치에 다시 people값 저장
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX + 1] = mapNumber.playerMark;
                        //위쪽에서 --증감식으로 - 1 된값을 ++증감식으로 다시 복구시킴
                        mapNumber.playerX++;
                        //Console.WriteLine("왼쪽벽에 막혔습니다. 다시 입력하세요.");

                    } //if문 종료
                    break; //case 종료
                //"s"를 입력받을 때 시작           
                case ConsoleKey.S:
                    if (mapNumber.map[mapNumber.playerY + 1, mapNumber.playerX] == mapNumber.monsterMark)
                    {
                        mapNumber.monsterCount = true;
                    }
                    //Console.WriteLine("s입력 밑으로 이동합니다. ");
                    //사람의 기존위치값에 ". "을 입력하여 빈칸임을 표시하기함
                    mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.mapMark;
                    //board의 Y축 밑쪽으로 이동하므로 peopleY + 1 시킴 이동한칸에 people값 저장
                    mapNumber.map[mapNumber.playerY + 1, mapNumber.playerX] = mapNumber.playerMark;
                    //Y축으로 + 1만큼 이동했으므로 ++증감식을 사용해 people의 이동위치 저장
                    mapNumber.playerY++;

                    if (mapNumber.map[mapNumber.playerY + 1, mapNumber.playerX] == mapNumber.map[mapNumber.shopY, mapNumber.shopX])
                    {
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.shop;
                        mapNumber.map[mapNumber.playerY - 1, mapNumber.playerX] = mapNumber.playerMark;
                        mapNumber.playerY--;
                        mapNumber.shopCount = true;
                    }
                    if (mapNumber.map[mapNumber.playerY + 1, mapNumber.playerX] == mapNumber.map[mapNumber.motelY, mapNumber.motelX])
                    {
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.motel;
                        mapNumber.map[mapNumber.playerY - 1, mapNumber.playerX] = mapNumber.playerMark;
                        mapNumber.playerY--;
                        mapNumber.motelCount = true;
                    }

                    //맨밑쪽 테두리에 막히면 이동불가하다를 구현하기위한 if문 시작 조건: peopleY값이 boardSizeY - 1 일때 peopleX값이 0~boardSizeX - 1까지
                    if (mapNumber.playerY == mapNumber.mapSizeY - 1 && 0 <= mapNumber.playerX && mapNumber.playerX < mapNumber.mapSizeX)
                    {
                        if (mapNumber.map[mapNumber.playerY, mapNumber.playerX] == mapNumber.map[mapNumber.potalY, mapNumber.potalX])
                        {
                            mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.potal;
                            mapNumber.map[mapNumber.playerY - 1, mapNumber.playerX] = mapNumber.mapMark;
                            mapNumber.playerY--;
                            mapNumber.potalCount = true;
                            break;
                        }
                        //맨밑쪽 테두리에 막혔으므로 벽쪽으로 이동한 people의 위치에 "■" 값을 저장하여 테두리를 다시채움
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.mapEdgeMark;
                        //테두리에 막혀 이동불가능하므로 전에 있던 위치에 다시 people값 저장
                        mapNumber.map[mapNumber.playerY - 1, mapNumber.playerX] = mapNumber.playerMark;
                        //위쪽에서 ++증감식으로 + 1 된값을 --증감식으로 다시 복구시킴
                        mapNumber.playerY--;
                        //Console.WriteLine("밑쪽벽에 막혔습니다. 다시 입력하세요.");
                    } //if문 종료
                    break; //case 종료
                //"d"를 입력받을 때 시작
                case ConsoleKey.D:
                    if (mapNumber.map[mapNumber.playerY, mapNumber.playerX + 1] == mapNumber.monsterMark)
                    {
                        mapNumber.monsterCount = true;
                    }
                    //Console.WriteLine("d입력 오른쪽으로 이동합니다. ");
                    //사람의 기존위치값에 ". "을 입력하여 빈칸임을 표시하기함
                    mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.mapMark;
                    //board의 X축 오른쪽으로 이동하므로 peopleX + 1 시킴 이동한칸에 people값 저장
                    mapNumber.map[mapNumber.playerY, mapNumber.playerX + 1] = mapNumber.playerMark;
                    //X축으로 + 1만큼 이동했으므로 ++증감식을 사용해 people의 이동위치 저장
                    mapNumber.playerX++;

                    if (mapNumber.map[mapNumber.playerY, mapNumber.playerX + 1] == mapNumber.map[mapNumber.shopY, mapNumber.shopX])
                    {
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.shop;
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX - 1] = mapNumber.playerMark;
                        mapNumber.playerX--;
                        mapNumber.shopCount = true;
                    }
                    if (mapNumber.map[mapNumber.playerY, mapNumber.playerX + 1] == mapNumber.map[mapNumber.motelY, mapNumber.motelX])
                    {
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.motel;
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX - 1] = mapNumber.playerMark;
                        mapNumber.playerX--;
                        mapNumber.motelCount = true;
                    }

                    //맨오른쪽 테두리에 막히면 이동불가하다를 구현하기위한 if문 시작 조건: peopleX값이 boardSizeX - 1 일때 peopleY값이 0~boardSizeY - 1까지
                    if (mapNumber.playerX == mapNumber.mapSizeX - 1 && 0 <= mapNumber.playerY && mapNumber.playerY < mapNumber.mapSizeY)
                    {
                        if (mapNumber.map[mapNumber.playerY, mapNumber.playerX] == mapNumber.map[mapNumber.potalY, mapNumber.potalX])
                        {
                            mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.potal;
                            mapNumber.map[mapNumber.playerY, mapNumber.playerX - 1] = mapNumber.mapMark;
                            mapNumber.playerX--;
                            mapNumber.potalCount = true;
                            break;
                        }
                        //맨오른쪽 테두리에 막혔으므로 벽쪽으로 이동한 people의 위치에 "■" 값을 저장하여 테두리를 다시채움
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.mapEdgeMark;
                        //테두리에 막혀 이동불가능하므로 전에 있던 위치에 다시 people값 저장
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX - 1] = mapNumber.playerMark;
                        //위쪽에서 ++증감식으로 + 1 된값을 --증감식으로 다시 복구시킴
                        mapNumber.playerX--;
                        //Console.WriteLine("오른쪽벽에 막혔습니다. 다시 입력하세요.");

                    } //if문 종료
                    break; //case 종료
                           //"X"를 입력받을 때 시작
                case ConsoleKey.X:
                    Console.WriteLine("2초 뒤 게임을 종료합니다.");
                    Thread.Sleep(2000);
                    //게임종료를 입력했으므로 while문을 빠져나가기위한 조건인 loop값을 true로 저장
                    mapNumber.end = true;
                    break; //case 종료
                           //w, a, s, d, X를 제외한 입력들을 예외처리하기위한 default 시작
            } //switch문 종료
            //ConsoleKeyInfo 값 초기화 함수 호출
            controller.Init();
            Console.WriteLine();
            return mapNumber;
        } //MoveInfo

        public void PlayGame()
        {
            Map map = new Map();
            Player player = new Player();
            MapSet board = new MapSet();
            MapSet lobby = new MapSet();
            MapSet map1 = new MapSet();
            MapSet map2 = new MapSet();
            board = map.Lobby();
            

            while ( board.end == false)
            {
                //맵초기화
                lobby = map.Lobby();
                map1 = map.Map1();
                map2 = map.Map2();
                //0.5초 멈춤
                Thread.Sleep(50);
                //콘솔창 커서위치 초기화
                Console.SetCursorPosition(0, 0);

                if (board.mapName == map1.mapName)
                {
                    board = map.MonsterMap(board, 10);
                }
                else if(board.mapName == map2.mapName)
                {
                    board = map.MonsterMap(board, 30);
                }
                Console.WriteLine("플레이방법: w-위, s-아래, a-왼, d-오른, x-게임종료");
                Console.WriteLine("마주한 몬스터: {0} 현재 위치한 맵: {1}번방", board.monsterCount, board.mapName);

                map.MapShow(board);
                
                Console.WriteLine();
                MoveKey moveKey = new MoveKey();
                board = moveKey.MoveInfo(board);
                
                if(board.monsterCount == true)
                {
                    Monster monster = new Monster();
                    monster = monster.SelectMonster();
                    Battle battle = new Battle(player, monster);
                    board.monsterCount = false;
                }

                if(board.shopCount == true)
                {
                    Console.WriteLine("상인: 어서오시게");
                    Console.ReadLine();
                    board.shopCount = false;
                }

                if(board.motelCount == true)
                {
                    Console.WriteLine("모텔주인: 어서오시게");
                    Console.ReadLine();
                    board.motelCount = false;
                }

                if(board.potalCount == true)
                {
                    for(int index = 0; index < 1; index++)
                    {
                        int inPut = 0;
                        Console.WriteLine("이동할 맵을 선택하세요.\n1번 => 필드1\n2번 => 필드2\n0번 => 마을");
                        int.TryParse(Console.ReadLine(), out inPut);

                        switch (inPut)
                        {
                            case 0:
                                board = lobby;
                                break;
                            case 1:
                                board = map1;
                                break;
                            case 2:
                                board = map2;
                                break;
                            default:
                                Console.WriteLine("잘못 입력했습니다. 다시 입력하세요.");
                                index--;
                                break;
                        } //switch
                        board.potalCount = false;
                    } //for
                Console.Clear();
                } //if
            } //while문 종료
        } //PlayGame

    } //MoveKey

}
