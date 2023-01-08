using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
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
            public bool end;
            public bool showItem;
            public bool showSkill;
        }

        MapSet mapSet = new MapSet();

        public MapSet MapSetting(int sizeY, int sizeX)
        {
            mapSet.mapSizeY = sizeY;
            mapSet.mapSizeX = sizeX;
            mapSet.mapMark = "  ";
            mapSet.mapEdgeMark = "■";
            mapSet.monsterMark = "♀";
            mapSet.playerMark = "위";
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
            //if문 시작 조건: IsThereCoin의 값이 반대일때
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
            Console.WriteLine("현재 위치: {0}", mapSet.mapName);
            for (int y = 0; y < mapSet.mapSizeY; y++)
            {
                for (int x = 0; x < mapSet.mapSizeX; x++)
                {
                    Console.Write("{0}", mapSet.map[y, x]);
                }
                Console.WriteLine();
            }
        } //MapShow

        public MapSet Lobby()
        {
            MapSet lobby = new MapSet();
            int Y = 15, X = 15;
            lobby = MapSetting(Y, X);
            lobby.map[2, 3] = "□"; lobby.map[3, 2] = "□"; lobby.map[3, 4] = "□"; lobby.map[3, 3] = "♨"; lobby.map[4, 2] = "□"; lobby.map[4, 4] = "□";
            lobby.map[8, 10] = "□"; lobby.map[9, 9] = "□"; lobby.map[9, 11] = "□"; lobby.map[9, 10] = "$$"; lobby.map[10, 9] = "□"; lobby.map[10, 11] = "□";
            lobby.mapName = "마 을";
            lobby.motelY = 4;
            lobby.motelX = 3;
            lobby.map[lobby.motelY, lobby.motelX] = lobby.motel;
            lobby.shopY = 10;
            lobby.shopX = 10;
            lobby.map[lobby.shopY, lobby.shopX] = lobby.shop;
            lobby.potalY = Y / 2;
            lobby.potalX = X - 1;
            lobby.map[lobby.potalY, lobby.potalX] = lobby.potal;
            lobby.playerY = Y / 2;
            lobby.playerX = X / 2;
            lobby.map[lobby.playerY, lobby.playerX] = lobby.playerMark;
            return lobby;
        }

        public MapSet Map1()
        {
            MapSet map1 = new MapSet();
            int Y = 15, X = 40;
            map1 = MapSetting(Y, X);
            map1 = Fence(map1, 30);
            map1.mapName = "첫번째 필드";
            map1.potalY = 0;
            map1.potalX = X - 2;
            map1.map[map1.potalY, map1.potalX] = map1.potal;
            map1.playerY = Y - 2;
            map1.playerX = 1;
            map1.map[map1.playerY, map1.playerX] = map1.playerMark;
            return map1;
        }

        public MapSet Map2()
        {
            MapSet map2 = new MapSet();
            int Y = 35, X = 30;
            map2 = MapSetting(Y, X);
            map2 = Fence(map2, 60);
            map2.mapName = "두번째 필드";
            map2.potalY = 0;
            map2.potalX = X - 4;
            map2.map[map2.potalY, map2.potalX] = map2.potal;
            map2.playerY = Y - 2;
            map2.playerX = 1;
            map2.map[map2.playerY, map2.playerX] = map2.playerMark;
            return map2;
        }

        public MapSet Fence(MapSet mapSet, int howManyFence)
        {
            Random random = new Random();
            for(int index = 0; index < howManyFence; index++)
            {
                int Y = random.Next(2, mapSet.mapSizeY - 2);
                int X = random.Next(2, mapSet.mapSizeX - 2);
                if(mapSet.map[Y, X] == mapSet.mapMark)
                {
                    mapSet.map[Y, X] = "■";
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
