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
        //플레이어 움직임입력 함수
        public MapSet MoveInfo(MapSet mapNumber, Player player)
        {
            ClassSkill classSkill = new ClassSkill();
            Item item = new Item();
            mapNumber.showItem = false;
            mapNumber.showSkill = false;
            mapNumber.showInfo = false;
            mapNumber.monsterCount = false;
            mapNumber.bossCount = false;
            mapNumber.potalCount = false;
            mapNumber.end = false;
            //Controller 클래스 인스턴스화
            Controller controller = new Controller();
            //Moving함수 호출
            controller.Moving();

            //Moving함수에서 처리한 결과값 예외처리 함수 호출
            if (controller.isRightInput()) { }

            //w, a, s, d 입력을 받았을때 플레이어의 위치변경을 위한 switch문 시작 조건: userInPut값이 들어왔을때
            switch (controller.userInPut.Key)
            {
                //"w"를 입력받을 때 시작
                case ConsoleKey.W:
                    if (mapNumber.map[mapNumber.playerY - 1, mapNumber.playerX] != mapNumber.mapMark)
                    {
                        if (mapNumber.map[mapNumber.playerY - 1, mapNumber.playerX] == mapNumber.monsterMark)
                        {
                            mapNumber.monsterCount = true;
                            mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.mapMark;
                            mapNumber.map[mapNumber.playerY - 1, mapNumber.playerX] = player.classMark;
                            mapNumber.playerY--;
                        }
                        else if (mapNumber.map[mapNumber.playerY - 1, mapNumber.playerX] == mapNumber.shop)
                        {
                            mapNumber.shopCount = true;
                        }
                        else if (mapNumber.map[mapNumber.playerY - 1, mapNumber.playerX] == mapNumber.motel)
                        {
                            mapNumber.motelCount = true;
                        }
                        else if (mapNumber.map[mapNumber.playerY - 1, mapNumber.playerX] == mapNumber.potal)
                        {
                            mapNumber.potalCount = true;
                        }
                        else if (mapNumber.map[mapNumber.playerY - 1, mapNumber.playerX] == mapNumber.bossMark)
                        {
                            mapNumber.bossCount = true;
                        }
                        else if (mapNumber.map[mapNumber.playerY - 1, mapNumber.playerX] == "⑻")
                        {
                            mapNumber.chiefCount = true;
                        }
                    }
                    else
                    {
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.mapMark;
                        mapNumber.map[mapNumber.playerY - 1, mapNumber.playerX] = player.classMark;
                        mapNumber.playerY--;
                    }
                    break; //case 종료
                //"a"를 입력받을 때 시작
                case ConsoleKey.A:
                    if (mapNumber.map[mapNumber.playerY, mapNumber.playerX - 1] != mapNumber.mapMark)
                    {
                        if (mapNumber.map[mapNumber.playerY, mapNumber.playerX - 1] == mapNumber.monsterMark)
                        {
                            mapNumber.monsterCount = true;
                            mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.mapMark;
                            mapNumber.map[mapNumber.playerY, mapNumber.playerX - 1] = player.classMark;
                            mapNumber.playerX--;
                        }
                        else if (mapNumber.map[mapNumber.playerY, mapNumber.playerX - 1] == mapNumber.shop)
                        {
                            mapNumber.shopCount = true;
                        }
                        else if (mapNumber.map[mapNumber.playerY, mapNumber.playerX - 1] == mapNumber.motel)
                        {
                            mapNumber.motelCount = true;
                        }
                        else if (mapNumber.map[mapNumber.playerY, mapNumber.playerX - 1] == mapNumber.potal)
                        {
                            mapNumber.potalCount = true;
                        }
                        else if (mapNumber.map[mapNumber.playerY, mapNumber.playerX - 1] == mapNumber.bossMark)
                        {
                            mapNumber.bossCount = true;
                        }
                        else if (mapNumber.map[mapNumber.playerY, mapNumber.playerX - 1] == "⑻")
                        {
                            mapNumber.chiefCount = true;
                        }
                    }
                    else
                    {
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.mapMark;
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX - 1] = player.classMark;
                        mapNumber.playerX--;
                    }
                    break; //case 종료
                //"s"를 입력받을 때 시작           
                case ConsoleKey.S:
                    if (mapNumber.map[mapNumber.playerY + 1, mapNumber.playerX] != mapNumber.mapMark)
                    {
                        if (mapNumber.map[mapNumber.playerY + 1, mapNumber.playerX] == mapNumber.monsterMark)
                        {
                            mapNumber.monsterCount = true;
                            mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.mapMark;
                            mapNumber.map[mapNumber.playerY + 1, mapNumber.playerX] = player.classMark;
                            mapNumber.playerY++;
                        }
                        else if (mapNumber.map[mapNumber.playerY + 1, mapNumber.playerX] == mapNumber.shop)
                        {
                            mapNumber.shopCount = true;
                        }
                        else if (mapNumber.map[mapNumber.playerY + 1, mapNumber.playerX] == mapNumber.motel)
                        {
                            mapNumber.motelCount = true;
                        }
                        else if (mapNumber.map[mapNumber.playerY + 1, mapNumber.playerX] == mapNumber.potal)
                        {
                            mapNumber.potalCount = true;
                        }
                        else if (mapNumber.map[mapNumber.playerY + 1, mapNumber.playerX] == mapNumber.bossMark)
                        {
                            mapNumber.bossCount = true;
                        }
                        else if (mapNumber.map[mapNumber.playerY + 1, mapNumber.playerX] == "⑻")
                        {
                            mapNumber.chiefCount = true;
                        }
                    }
                    else
                    {
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.mapMark;
                        mapNumber.map[mapNumber.playerY + 1, mapNumber.playerX] = player.classMark;
                        mapNumber.playerY++;
                    }
                    break; //case 종료
                //"d"를 입력받을 때 시작
                case ConsoleKey.D:
                    if (mapNumber.map[mapNumber.playerY, mapNumber.playerX + 1] != mapNumber.mapMark)
                    {
                        if (mapNumber.map[mapNumber.playerY, mapNumber.playerX + 1] == mapNumber.monsterMark)
                        {
                            mapNumber.monsterCount = true;
                            mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.mapMark;
                            mapNumber.map[mapNumber.playerY, mapNumber.playerX + 1] = player.classMark;
                            mapNumber.playerX++;
                        }
                        else if (mapNumber.map[mapNumber.playerY, mapNumber.playerX + 1] == mapNumber.shop)
                        {
                            mapNumber.shopCount = true;
                        }
                        else if (mapNumber.map[mapNumber.playerY, mapNumber.playerX + 1] == mapNumber.motel)
                        {
                            mapNumber.motelCount = true;
                        }
                        else if (mapNumber.map[mapNumber.playerY, mapNumber.playerX + 1] == mapNumber.potal)
                        {
                            mapNumber.potalCount = true;
                        }
                        else if (mapNumber.map[mapNumber.playerY, mapNumber.playerX + 1] == mapNumber.bossMark)
                        {
                            mapNumber.bossCount = true;
                        }
                        else if (mapNumber.map[mapNumber.playerY, mapNumber.playerX + 1] == "⑻")
                        {
                            mapNumber.chiefCount = true;
                        }
                    }
                    else
                    {
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX] = mapNumber.mapMark;
                        mapNumber.map[mapNumber.playerY, mapNumber.playerX + 1] = player.classMark;
                        mapNumber.playerX++;
                    }
                    break;
                case ConsoleKey.B:
                    mapNumber.showItem = true;
                    break;
                case ConsoleKey.C:
                    mapNumber.showInfo = true;
                    break;
                case ConsoleKey.K:
                    mapNumber.showSkill = true;
                    break;
                case ConsoleKey.X:
                    int num = 3;
                    Console.Clear();
                    for(int index = 0; index < 4; index++)
                    {
                        Console.SetCursorPosition(0, 5);
                        Console.WriteLine("\t\t【{0}초 뒤 게임을 종료합니다】", num);
                        Thread.Sleep(1000);
                        num--;
                    }
                    //게임종료를 입력했으므로 while문을 빠져나가기위한 조건인 end값을 true로 저장
                    mapNumber.end = true;
                    break;
            } //switch문 종료
            //ConsoleKeyInfo 값 초기화 함수 호출
            //controller.Init();
            return mapNumber;
        } //MoveInfo

    } //MoveKey
}
