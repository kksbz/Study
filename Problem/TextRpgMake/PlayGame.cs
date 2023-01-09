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

            Console.Clear();
            while (board.end == false)
            {
                //맵초기화
                lobby = map.Lobby();
                map1 = map.Map1();
                map2 = map.Map2();
                //0.5초 멈춤
                Thread.Sleep(50);
                //콘솔창 커서위치 초기화
                Console.CursorVisible = false;
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
                Console.WriteLine("【플레이방법】▶【w】↑【s】↓【a】←【d】→\n【인벤토리】  ▶【b】【스킬】▶【k】【상태창】▶【c】【게임종료】▶【x】\n");
                Console.WriteLine("【{0}】▶【레벨】{1}【HP】{2}/{3}【MP】{4}/{5}【보유골드】{6}", player.Name, player.Level,
                    player.Hp, player.MaxHp, player.Mp, player.MaxMp, player.gold);
                Console.WriteLine();
                //플레이어 이동입력 함수 호출
                MoveKey moveKey = new MoveKey();
                board = moveKey.MoveInfo(board);
                //몬스터만나면 배틀시작
                if (board.monsterCount == true)
                {
                    Monster monster = new Monster();
                    monster = monster.SelectMonster();
                    Battle battle = new Battle(player, monster);
                    board.monsterCount = false;
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
                    for(int index = 0; index < 1; index++)
                    {
                        item.ShowItemList(player.itemList, player);
                        Console.WriteLine("【선택】▶ 사용할 아이템 번호 /【뒤로】▶ 선택 목록을 제외한 아무키");
                        int itemInPut = -1;
                        int.TryParse(Console.ReadLine(), out itemInPut);
                        if (0 < itemInPut && itemInPut <= player.itemList.Count)
                        {
                            itemInPut = itemInPut - 1;
                            if (player.itemList[itemInPut].ItemType == "무기")
                            {
                                string putOnItem = "【장착중】";
                                Console.WriteLine("【{0}】▶ 장착 / 장착해제 【y/n】", player.itemList[itemInPut].Name);
                                string putOn = Console.ReadLine();
                                switch (putOn)
                                {
                                    case "y":
                                        if(player.itemPutOn == false)
                                        {
                                            Console.WriteLine("【{0}】▶ 장착 완료 【데미지】+{1}", player.itemList[itemInPut].Name, player.itemList[itemInPut].WeaponDamage);
                                            player.Damage += player.itemList[itemInPut].WeaponDamage;
                                            player.itemList[itemInPut].Name += putOnItem;
                                            player.putOnItem.Add(player.itemList[itemInPut]);
                                            player.itemPutOn = true;
                                            Console.ReadLine();
                                        }
                                        break;
                                    case "n":
                                        if (player.itemPutOn == true)
                                        {
                                            player.Damage -= player.itemList[itemInPut].WeaponDamage;
                                            Console.WriteLine("【{0}】▶ 장착해제 완료 【데미지】-{1}", player.itemList[itemInPut].Name, player.itemList[itemInPut].WeaponDamage);
                                            player.itemList[itemInPut].Name = player.itemList[itemInPut].Name.Substring(0 , putOnItem.Length - 1);
                                            player.putOnItem.Remove(player.itemList[itemInPut]);
                                            player.itemPutOn = false;
                                            Console.ReadLine();
                                        }
                                        break;
                                } //switch
                                index--;
                            } //if
                        } //if
                    }//for
                    Console.Clear();
                } //if

                if (board.showSkill == true)
                {
                    classSkill.ShowSkillList(player.skillList);
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
                        Console.Clear();
                        switch (shopInPut)
                        {
                            case "1":
                                for (int index2 = 0; index2 < 1; index2++)
                                {
                                    Console.Clear();
                                    Npc npc = new Npc();
                                    npc.ShopNpc();
                                    Console.WriteLine("\t\t【보유 골드】{0}골드\n【구매】▶구매할 물건 번호 /【뒤로】▶상점 목록을 제외한 아무키", player.gold);
                                    int buy = 0;
                                    int.TryParse(Console.ReadLine(), out buy);
                                    if (0 < buy && buy <= npc.shopItemList.Count)
                                    {
                                        if (player.gold >= npc.shopItemList[buy - 1].Price)
                                        {
                                            Console.WriteLine("【구매 완료】▶【{0}】", npc.shopItemList[buy - 1].Name);
                                            player.gold -= npc.shopItemList[buy - 1].Price;
                                            player.itemList.Add(npc.shopItemList[buy - 1]);
                                            Console.ReadLine();
                                            index2--;
                                        }
                                        else
                                        {
                                            Console.WriteLine("【충분한 골드가 없습니다】");
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
                                    Console.Clear();
                                    item.ShowItemList(player.itemList, player);
                                    Console.WriteLine();
                                    Console.WriteLine("【판매시 물건가격의 절반을 받습니다】【보유 골드】{0}\n\n【판매】▶판매할 물건 번호 /【뒤로】▶인벤토리 목록을 제외한 아무키", player.gold);
                                    int sell = -1;
                                    int.TryParse(Console.ReadLine(), out sell);
                                    if (0 < sell && sell <= player.itemList.Count)
                                    {
                                        sell = sell - 1;
                                        player.gold += (player.itemList[sell].Price / 2);
                                        Console.WriteLine("【판매 완료】▶【{0}】【{1}】골드 획득", player.itemList[sell].Name, player.itemList[sell].Price / 2);
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
                    Console.WriteLine("【여관주인】▶자네 피곤해 보이는군 싸게줄테니 한숨 자고 가겠나? -200gold-\n\n");
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
