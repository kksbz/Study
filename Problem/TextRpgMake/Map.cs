using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextRpgMake
{
    public class Map
    {
        public struct MapSet
        {
            public string mapName;
            public int mapSizeY;
            public int mapSizeX;
            public string mapEdgeMark;
            public string mapMark;
            public string monsterMark;
            public string playerMark;
            public string bossMark;
            public int playerY;
            public int playerX;
            public int monsterY;
            public int monsterX;
            public string motel;
            public int motelY;
            public int motelX;
            public bool motelCount;
            public string shop;
            public int shopY;
            public int shopX;
            public bool shopCount;
            public string potal;
            public int potalY;
            public int potalX;
            public string[,] map;
            public bool potalCount;
            public bool monsterCount;
            public bool bossCount;
            public bool chiefCount;
            public bool end;
            public bool showItem;
            public bool showSkill;
            public bool showInfo;
            public bool showQuest;
        }

        MapSet mapSet = new MapSet();

        public MapSet MapSetting(int sizeY, int sizeX)
        {
            mapSet.mapSizeY = sizeY;
            mapSet.mapSizeX = sizeX;
            mapSet.mapMark = "  ";
            mapSet.mapEdgeMark = "■";
            mapSet.monsterMark = "♀";
            mapSet.bossMark = "㈇";
            mapSet.motel = "옷";
            mapSet.shop = "⑧";
            mapSet.potal = "＠";
            mapSet.map = new string[mapSet.mapSizeY, mapSet.mapSizeX];

            for (int y = 0; y < mapSet.mapSizeY; y++)
            {
                for (int x = 0; x < mapSet.mapSizeX; x++)
                {
                    mapSet.map[y, x] = mapSet.mapMark;

                    if (y == 0 && 0 <= x && x < mapSet.mapSizeX)
                    {
                        mapSet.map[y, x] = mapSet.mapEdgeMark;
                    }
                    if (y == mapSet.mapSizeY - 1 && 0 <= x && x < mapSet.mapSizeX)
                    {
                        mapSet.map[y, x] = mapSet.mapEdgeMark;
                    }
                    if (x == 0 && 0 <= y && x < mapSet.mapSizeY)
                    {
                        mapSet.map[y, x] = mapSet.mapEdgeMark;
                    }
                    if (x == (mapSet.mapSizeX - 1) && 0 <= y && y < mapSet.mapSizeY)
                    {
                        mapSet.map[y, x] = mapSet.mapEdgeMark;
                    }
                }
            }
            return mapSet;
        } //MapSetting

        public MapSet MonsterMap(MapSet mapNumber, int howManyMonster)
        {
            bool IsThereMonster = false;
            Random randomNum = new Random();
            //몬스터가 맵안에 있으면 true 없으면 false
            IsThereMonster = false;
            for (int y = 1; y < mapNumber.mapSizeY; y++)
            {
                for (int x = 1; x < mapNumber.mapSizeX; x++)
                {
                    if (mapNumber.map[y, x] == mapNumber.monsterMark)
                    {
                        //몬스터가 보드안에 존재하므로 true로 값변경 진행
                        IsThereMonster = true;
                    }
                }
            }
            //IsthereCoin은 필드에 몬스터가있으면 true, 없으면 false
            if (!IsThereMonster)
            {
                //보드안에 몬스터위치 선택을 위한 for문 시작
                for (int index = 0; index < howManyMonster; index++)
                {
                    //몬스터의 좌표값 랜덤설정
                    mapNumber.monsterY = randomNum.Next(1, mapNumber.mapSizeY - 1);
                    mapNumber.monsterX = randomNum.Next(1, mapNumber.mapSizeX - 1);
                    //몬스터위치 예외처리 if문 시작 조건: 맵위치에 몬스터가 없을때
                    if (mapNumber.map[mapNumber.monsterY, mapNumber.monsterX] == mapNumber.mapMark)
                    {
                        mapNumber.map[mapNumber.monsterY, mapNumber.monsterX] = mapNumber.monsterMark;
                    }
                    else
                    {
                        //맵위치에 몬스터가 이미 있으므로 for문 한번 더돌림
                        index--;
                    }
                } //for문 종료
                //모든 예외처리가 완료되면 true로
                IsThereMonster = true;
            } //if문 종료
            return mapNumber;
        } //MonsterMap
        public void MapShow(MapSet mapSet)
        {
            Console.SetCursorPosition(0, 1);
            for (int y = 0; y < mapSet.mapSizeY; y++)
            {
                Console.Write("\t");
                for (int x = 0; x < mapSet.mapSizeX; x++)
                {
                    Console.Write("{0}", mapSet.map[y, x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\t【현재 위치】▶ {0}", mapSet.mapName);
        } //MapShow

        public MapSet Lobby(Player player)
        {
            MapSet lobby = new MapSet();
            int Y = 15, X = 15;
            lobby = MapSetting(Y, X);
            lobby.map[2, 3] = "□"; lobby.map[3, 2] = "□"; lobby.map[3, 4] = "□"; lobby.map[3, 3] = "♨"; lobby.map[4, 2] = "□"; lobby.map[4, 4] = "□";
            lobby.map[8, 10] = "□"; lobby.map[9, 9] = "□"; lobby.map[9, 11] = "□"; lobby.map[9, 10] = "$$"; lobby.map[10, 9] = "□"; lobby.map[10, 11] = "□";
            lobby.mapName = "마 을";
            lobby.motelY = 4;
            lobby.motelX = 3;
            lobby.map[4, 11] = "⑻";
            lobby.map[lobby.motelY, lobby.motelX] = lobby.motel;
            lobby.shopY = 10;
            lobby.shopX = 10;
            lobby.map[lobby.shopY, lobby.shopX] = lobby.shop;
            lobby.potalY = Y / 2;
            lobby.potalX = X - 1;
            lobby.map[lobby.potalY, lobby.potalX] = lobby.potal;
            lobby.playerY = Y / 2;
            lobby.playerX = X / 2;
            lobby.map[lobby.playerY, lobby.playerX] = player.classMark;
            return lobby;
        }

        public MapSet Map1(Player player)
        {
            MapSet map1 = new MapSet();
            int Y = 15, X = 40;
            map1 = MapSetting(Y, X);
            map1 = Fence(map1, 90, "■");
            map1.mapName = "암석 지대";
            map1.potalY = 0;
            map1.potalX = X - 2;
            map1.map[map1.potalY, map1.potalX] = map1.potal;
            map1.playerY = Y - 2;
            map1.playerX = 1;
            map1.map[map1.playerY, map1.playerX] = player.classMark;
            return map1;
        }

        public MapSet Map2(Player player)
        {
            MapSet map2 = new MapSet();
            int Y = 22, X = 30;
            map2 = MapSetting(Y, X);
            map2 = Fence(map2, 100, "♣");
            map2.mapName = "깊은 숲";
            map2.potalY = 0;
            map2.potalX = X - 4;
            map2.map[map2.potalY, map2.potalX] = map2.potal;
            map2.playerY = Y - 2;
            map2.playerX = 1;
            map2.map[map2.playerY, map2.playerX] = player.classMark;
            return map2;
        }

        public MapSet Map3(Player player)
        {
            MapSet map3 = new MapSet();
            int Y = 20, X = 40;
            map3 = MapSetting(Y, X);
            map3 = Fence(map3, 110, "♨");
            map3.mapName = "지옥불 반도";
            map3.potalY = Y / 3;
            map3.potalX = X - 1;
            map3.map[map3.potalY, map3.potalX] = map3.potal;
            map3.playerY = Y - 2;
            map3.playerX = 1;
            map3.map[map3.playerY, map3.playerX] = player.classMark;
            return map3;
        } //Map3

        public MapSet BossMap(Player player)
        {
            MapSet bossMap = new MapSet();
            int Y = 20, X = 20;
            bossMap = MapSetting(Y, X);
            bossMap.mapName = "소환의 제단";
            bossMap.potalY = Y - 1;
            bossMap.potalX = 10;
            bossMap.map[bossMap.potalY, bossMap.potalX] = bossMap.potal;
            bossMap.playerY = Y - 2;
            bossMap.playerX = 1;
            bossMap.map[bossMap.playerY, bossMap.playerX] = player.classMark;

            bossMap.map[9, 9] = bossMap.bossMark;
            bossMap.map[9, 10] = bossMap.bossMark;
            bossMap.map[10, 9] = bossMap.bossMark;
            bossMap.map[10, 10] = bossMap.bossMark;

            bossMap.map[7, 8] = "♨";
            bossMap.map[7, 11] = "♨";
            bossMap.map[8, 6] = "♨";
            bossMap.map[8, 8] = "♨";
            bossMap.map[8, 9] = "♨";
            bossMap.map[8, 10] = "♨";
            bossMap.map[8, 11] = "♨";
            bossMap.map[8, 13] = "♨";
            bossMap.map[9, 4] = "♨";
            bossMap.map[9, 6] = "♨";
            bossMap.map[9, 7] = "♨";
            bossMap.map[9, 8] = "♨";
            bossMap.map[9, 11] = "♨";
            bossMap.map[9, 12] = "♨";
            bossMap.map[9, 13] = "♨";
            bossMap.map[9, 15] = "♨";
            bossMap.map[10, 4] = "♨";
            bossMap.map[10, 5] = "♨";
            bossMap.map[10, 6] = "♨";
            bossMap.map[10, 13] = "♨";
            bossMap.map[10, 14] = "♨";
            bossMap.map[10, 15] = "♨";
            bossMap.map[11, 5] = "♨";
            bossMap.map[11, 8] = "♨";
            bossMap.map[11, 14] = "♨";
            bossMap.map[11, 11] = "♨";
            bossMap.map[12, 5] = "♨";
            bossMap.map[12, 6] = "♨";
            bossMap.map[12, 7] = "♨";
            bossMap.map[12, 8] = "♨";
            bossMap.map[12, 11] = "♨";
            bossMap.map[12, 12] = "♨";
            bossMap.map[12, 13] = "♨";
            bossMap.map[12, 14] = "♨";
            return bossMap;
        }

        public MapSet Fence(MapSet mapSet, int howManyFence, string mark)
        {
            Random random = new Random();
            for (int index = 0; index < howManyFence; index++)
            {
                int Y = random.Next(2, mapSet.mapSizeY - 2);
                int X = random.Next(2, mapSet.mapSizeX - 2);
                if (mapSet.map[Y, X] == mapSet.mapMark)
                {
                    mapSet.map[Y, X] = mark;
                }
                else
                {
                    index--;
                }
            }
            return mapSet;
        }
    } //Map


}
