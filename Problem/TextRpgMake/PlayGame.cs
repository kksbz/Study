using System;
using System.Collections.Generic;
using System.Linq;
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
            Item item = new Item();
            Map map = new Map();
            MapSet board = new MapSet();
            MapSet lobby = new MapSet();
            MapSet map1 = new MapSet();
            MapSet map2 = new MapSet();
            board = map.Lobby();


            while (board.end == false)
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
                else if (board.mapName == map2.mapName)
                {
                    board = map.MonsterMap(board, 30);
                }

                map.MapShow(board);
                Console.WriteLine("【플레이방법】▶【w】↑【s】↓【a】←【d】→【b】인벤토리【k】스킬【x】게임종료");
                Console.WriteLine("【{0}】▶【레벨】{1}\t【HP】{2}/{3}\t【MP】{4}/{5}\t【보유골드】{6}\t【현재위치】{7}", player.Name, player.Level,
                    player.Hp, player.MaxHp, player.Mp, player.MaxMp, player.gold, board.mapName);
                Console.WriteLine();
                //플레이어 이동입력 함수 호출
                MoveKey moveKey = new MoveKey();
                board = moveKey.MoveInfo(board);

                if (board.monsterCount == true)
                {
                    Monster monster = new Monster();
                    monster = monster.SelectMonster();
                    Battle battle = new Battle(player, monster);
                    board.monsterCount = false;
                }

                if (player.playerDead == true)
                {
                    player.Hp = player.MaxHp;
                    player.Mp = player.MaxMp;
                    board = lobby;
                    player.playerDead = false;
                }

                if (board.showItem == true)
                {
                    item.ShowItemList(player.itemList);
                }

                if (board.showSkill == true)
                {
                    classSkill.ShowSkillList(player.skillList);
                }

                if (board.shopCount == true)
                {
                    Console.Clear();
                    Console.WriteLine("【상인】{0} 오랜만에 보는구먼\n【상인】필요한 물건있나 한번 보시게\n【상인】우리가게 상품은 최상품이라구!", player.Name);
                    Console.WriteLine();
                    Console.WriteLine("【1】오늘의 상품은 뭐가 있나 한번 볼까?\n【2】아이템을 팔러왔소\n【3】다음에 다시 온다");
                    string shopInPut = Console.ReadLine();
                    for (int index = 0; index < 1; index++)
                    {
                        switch (shopInPut)
                        {
                            case "1":
                                Npc npc = new Npc();
                                npc.ShopNpc();
                                Console.WriteLine("구매할 물건의 번호를 입력하세요.");
                                int buy = 0;
                                int.TryParse(Console.ReadLine(), out buy);
                                if(0 < buy && buy <= npc.shopItemList.Count)
                                {
                                    if(player.gold >= npc.shopItemList[buy - 1].Price)
                                    {
                                        player.itemList.Add(npc.shopItemList[buy - 1]);
                                        player.gold -= npc.shopItemList[buy - 1].Price;
                                    }
                                    else
                                    {
                                        Console.WriteLine("충분한 골드가 없습니다.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("잘못 입력했습니다. 다시 입력하세요.");
                                    index--;
                                }
                                break;
                            case "2":
                                item.ShowItemList(player.itemList);
                                Console.WriteLine();
                                Console.WriteLine("【판매시 물건가격의 절반을 받습니다.】\n판매할 물건의 번호를 입력하세요.");
                                int sell = 0;
                                int.TryParse(Console.ReadLine(), out sell);
                                if (0 < sell && sell <= player.itemList.Count)
                                {
                                    player.itemList.Remove(player.itemList[sell - 1]);
                                    player.gold += player.itemList[sell - 1].Price / 2;
                                    Console.WriteLine("【{0}】을(를) 판매했습니다 【{1}】골드 획득", player.itemList[sell - 1].Name, player.itemList[sell - 1].Price / 2);
                                }
                                else
                                {
                                    Console.WriteLine("잘못 입력했습니다. 다시 입력하세요.");
                                    index--;
                                }
                                break;
                            case "3":
                                Console.WriteLine("【{0}】다음에 다시 오겠소", player.Name);
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
                    board.shopCount = false;
                }

                if (board.motelCount == true)
                {
                    Console.Clear();
                    Console.WriteLine("【여관주인】자네 피곤해 보이는군 싸게줄테니 한숨 자고 가겠나? -200gold-");
                    Console.WriteLine("【1】여관에서 하루 쉬었다 간다.\n【2】다음에 쉰다.");
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
                                    Console.WriteLine("【{0}】하루 푹 쉬고나니 상쾌하군", player.Name);
                                    Console.WriteLine("【{0}】의 체력과 마나가 가득찼습니다.", player.Name);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("【여관주인】자네 200골드도 없나? 네고는 안된다네");
                                }
                                break;
                            case "2":
                                Console.WriteLine("【{0}】지금은 괜찮소 다음에 다시 오겠소.", player.Name);
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
                }

                if (board.potalCount == true)
                {
                    for (int index = 0; index < 1; index++)
                    {
                        Console.Clear();
                        Console.WriteLine("이동할 맵을 선택하세요.\n【1】▶필드1\n【2】▶필드2\n【0】▶마을");
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
                                board = map2;
                                break;
                            default:
                                Console.WriteLine("잘못 입력했습니다. 다시 입력하세요.");
                                index--;
                                break;
                        } //switch
                        board.potalCount = false;
                    } //for
                } //if
            } //while문 종료
        } //PlayGame(생성자)
    } //PlayGame
}
