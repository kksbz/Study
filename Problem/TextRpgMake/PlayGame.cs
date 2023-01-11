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
    internal class PlayGame
    {
        public PlayGame(Player player)
        {
            player.SelectPlayer();
            ClassSkill classSkill = new ClassSkill();
            Monster monster = new Monster();
            Item item = new Item();
            Map map = new Map();
            List<Item> buyNpc = new List<Item>();
            buyNpc = item.SellNpc(player);
            MapSet board = new MapSet();
            MapSet lobby = new MapSet();
            MapSet map1 = new MapSet();
            MapSet map2 = new MapSet();
            MapSet map3 = new MapSet();
            MapSet bossMap = new MapSet();
            board = map.Lobby();
            bossMap = map.BossMap();

            Console.Clear();
            while (board.end == false)
            {
                //맵초기화
                lobby = map.Lobby();
                map1 = map.Map1();
                map2 = map.Map2();
                map3 = map.Map3();
                //0.5초 멈춤
                Thread.Sleep(50);
                //콘솔창 커서위치 초기화
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);

                if (board.mapName == map1.mapName)
                {
                    board = map.MonsterMap(board, 20);
                }
                else if (board.mapName == map2.mapName)
                {
                    board = map.MonsterMap(board, 30);
                }
                else if(board.mapName == map3.mapName)
                {
                    board = map.MonsterMap(board, 25);
                }

                map.MapShow(board);
                Console.WriteLine("\n\t【{0}】▶【레벨】{1}【HP】{2}/{3}【MP】{4}/{5}", player.Name, player.Level,
                    player.Hp, player.MaxHp, player.Mp, player.MaxMp);
                Console.WriteLine("\t┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("\t┃   【상태창】\t    ▶\t【 c 】 ┃\n\t┃   【인벤토리】    ▶\t【 b 】 ┃\n\t┃   【스킬】\t    ▶\t【 k 】 ┃\n\t┃   【게임종료】    ▶\t【 x 】 ┃");
                Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                
                Console.WriteLine();
                //플레이어 이동입력 함수 호출
                MoveKey moveKey = new MoveKey();
                board = moveKey.MoveInfo(board);
                //몬스터만나면 배틀시작
                if (board.monsterCount == true)
                {
                    player.findMonster = true;
                    if(board.mapName == map1.mapName)
                    {
                        monster = monster.SelectMonster_1();
                        Battle battle = new Battle(player, monster);
                    }
                    else if (board.mapName == map2.mapName)
                    {
                        monster = monster.SelectMonster_2(player);
                        Battle battle = new Battle(player, monster);
                    }
                    else if (board.mapName == map3.mapName)
                    {
                        monster = monster.SelectMonster_3(player);
                        Battle battle = new Battle(player, monster);
                    }
                    board.monsterCount = false;
                    player.findMonster = false;
                }
                //보스만나면 전투
                if(board.bossCount == true)
                {
                    player.findBoss = true;
                    player.findMonster = true;
                    monster = monster.SelectBoss(player);
                    Battle battle = new Battle(player, monster);
                    board.bossCount = false;
                    player.findBoss = false;
                    player.findMonster = false;
                    if (player.bossKill == true)
                    {
                        bossMap.map[9, 10] = board.potal;
                        bossMap.map[9, 9] = board.mapMark;
                        bossMap.map[10, 9] = board.mapMark;
                        bossMap.map[10, 10] = board.mapMark;
                    }
                }
                //플레이어 죽으면 로비로 이동
                if (player.playerDead == true)
                {
                    player.Hp = player.MaxHp;
                    player.Mp = player.MaxMp;
                    board = lobby;
                    player.playerDead = false;
                }
                //플레이어 정보보기
                if (board.showInfo == true)
                {
                    player.ShowInfo(player);
                }

                //가방열기 아이템사용
                if (board.showItem == true)
                {
                    item.UseItem(player, monster);
                    Console.Clear();
                } //if

                if (board.showSkill == true)
                {
                    classSkill.ShowSkillList(player.skillList, player);
                    Console.ReadLine();
                    Console.Clear();
                }

                if (board.shopCount == true)
                {
                    
                    for (int index = 0; index < 1; index++)
                    {
                        Console.Clear();
                        Console.WriteLine("【상인】▶【{0}】오랜만에 보는구먼\n【상인】▶필요한 물건 있나 한번 보게나\n【상인】▶우리가게 상품은 최상품이라구!", player.Name);
                        Console.WriteLine();
                        Console.WriteLine("【1】▶오늘의 상품은 뭐가 있나 한번 볼까?\n【2】▶아이템을 팔러왔소\n【3】▶다음에 다시 온다");
                        string shopInPut = Console.ReadLine();
                        switch (shopInPut)
                        {
                            case "1":
                                for (int index2 = 0; index2 < 1; index2++)
                                {
                                    int show = 1;
                                    item.ShowItemList(buyNpc, player, show);
                                    int buy = 0;
                                    int.TryParse(Console.ReadLine(), out buy);
                                    if (0 < buy && buy <= buyNpc.Count)
                                    {
                                        if (player.gold >= buyNpc[buy - 1].Price)
                                        {
                                            Console.WriteLine("\t\t【구매 완료】▶【{0}】", buyNpc[buy - 1].Name);
                                            player.gold -= buyNpc[buy - 1].Price;
                                            player.itemList.Add(buyNpc[buy - 1]);
                                            Console.ReadLine();
                                            index2--;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\t\t【충분한 골드가 없습니다】");
                                            Console.ReadLine();
                                            index2--;
                                        }
                                    }
                                    else
                                    {
                                        index--;
                                    }
                                }
                                break;
                            case "2":
                                for (int index3 = 0; index3 < 1; index3++)
                                {
                                    int showSell = 2;
                                    item.ShowItemList(player.itemList, player, showSell);
                                    int sell = -1;
                                    int.TryParse(Console.ReadLine(), out sell);
                                    if (0 < sell && sell <= player.itemList.Count)
                                    {
                                        sell = sell - 1;
                                        player.gold += (player.itemList[sell].Price / 2);
                                        Console.WriteLine("\t【판매 완료】▶【{0}】【{1}】골드 획득", player.itemList[sell].Name, player.itemList[sell].Price / 2);
                                        Console.ReadLine();
                                        player.itemList.Remove(player.itemList[sell]);
                                        index3--;
                                    }
                                    else
                                    {
                                        index--;
                                    }
                                }
                                break;
                            case "3":
                                Console.WriteLine("【{0}】▶다음에 다시 오겠소", player.Name);
                                break;
                            default:
                                index--;
                                break;
                        }
                    }
                    board.shopCount = false;
                    Console.Clear();
                }

                if (board.motelCount == true)
                {
                    Console.Clear();
                    Console.WriteLine("【여관주인】▶자네 피곤해 보이는군\n【여관주인】▶싸게줄테니 한숨 자고 가겠나? -200gold-\n\n");
                    Console.WriteLine("【1】▶여관에서 하루 쉬었다 간다.\n【2】▶다음에 쉰다.\n");
                    string motelInPut = Console.ReadLine();
                    for (int index = 0; index < 1; index++)
                    {
                        switch (motelInPut)
                        {
                            case "1":
                                if (player.gold >= 200)
                                {
                                    player.gold -= 200;
                                    player.Hp = player.MaxHp;
                                    player.Mp = player.MaxMp;
                                    Console.WriteLine("【{0}】▶하루 푹 쉬고나니 상쾌하군", player.Name);
                                    Console.WriteLine("【{0}】의 체력과 마나가 가득찼습니다.", player.Name);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("【여관주인】▶자네 200골드도 없나? 네고는 안된다네");
                                }
                                break;
                            case "2":
                                Console.WriteLine("【{0}】▶지금은 괜찮소 다음에 다시 오겠소.", player.Name);
                                break;
                            default:
                                Console.WriteLine("잘못 입력했습니다. 다시 입력하세요.");
                                index--;
                                break;
                        }
                        Console.WriteLine("아무키나 눌러 계속 진행.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    board.motelCount = false;
                } //if

                if (board.potalCount == true)
                {
                    for (int index = 0; index < 1; index++)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 5);
                        Console.WriteLine("\t\t【이동할 맵을 선택하세요】\n\n\t\t【1】▶필드1\n\t\t【2】▶필드2【제한레벨 3】\n\t\t【3】▶필드3【제한레벨 5】\n\t\t【4】▶마지막 필드\n\t\t【0】▶마을\n\t\t【9】▶뒤로");
                        string inPut = Console.ReadLine();
                        switch (inPut)
                        {
                            case "0":
                                board = lobby;
                                break;
                            case "1":
                                board = map1;
                                break;
                            case "2":
                                if(player.Level >= 5)
                                {
                                    board = map2;
                                }
                                else
                                {
                                    Console.WriteLine("\t\t【요구 레벨을 충족하지 못했습니다】\n\n\t\t【{0}의 제한레벨】▶ 5",map2.mapName);
                                    index--;
                                    Console.ReadLine();
                                }
                                break;
                            case "3":
                                if (player.Level >= 7)
                                {
                                    board = map3;
                                }
                                else
                                {
                                    Console.WriteLine("\t\t【요구 레벨을 충족하지 못했습니다】\n\n\t\t【{0}의 제한레벨】▶ 7", map3.mapName);
                                    index--;
                                    Console.ReadLine();
                                }
                                break;
                                case "4":
                                if (player.Level >= 0)
                                {
                                    if(player.bossKill == true)
                                    {
                                        bossMap.map[9, 9] = board.mapMark;
                                        bossMap.map[10, 9] = board.mapMark;
                                        bossMap.map[10, 10] = board.mapMark;
                                        bossMap.map[18, 10] = board.mapMark;
                                        bossMap.map[18, 1] = board.playerMark;
                                    }
                                    board = bossMap;
                                }
                                else
                                {
                                    Console.WriteLine("\t\t【요구 레벨을 충족하지 못했습니다】\n\n\t\t【{0}의 제한레벨】▶ 10", map3.mapName);
                                    index--;
                                    Console.ReadLine();
                                }
                                break;
                            case "9":
                                break;
                            default:
                                index--;
                                break;
                        } //switch
                        Console.Clear();
                        board.potalCount = false;
                    } //for
                } //if
            } //while문 종료
        } //PlayGame(생성자)
    } //PlayGame
}
