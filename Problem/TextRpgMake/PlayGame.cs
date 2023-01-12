using System;
using System.Collections;
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
            Title();
            player.SelectPlayer();
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("\t\t【{0}】▶ 젠장 여긴 뭔데 몬스터가 이리 많어\n\n\t\t【{0}】▶ 시도 때도 없이 덤벼드니 피곤하구먼" +
                "\n\n\t\t【{0}】▶ 어디 쉴만한 곳 없나?\n\n\t\t【{0}】▶ 마침 불빛이 보이는군 마을이였으면 좋겠는데\n\n\t\t【{0}】▶ 저기로 가봐야겠어", player.Name);
            Console.ReadLine();
            Console.Clear();
            ClassSkill classSkill = new ClassSkill();
            Character character = new Character();
            Quest quest = new Quest();
            List<Quest> tempQuest = new List<Quest>();
            Monster monster = new Monster();
            Item item = new Item();
            Item item2 = new Item();
            Map map = new Map();
            List<Item> buyNpc = new List<Item>();
            buyNpc = item.SellNpc(player);
            MapSet board = new MapSet();
            MapSet lobby = new MapSet();
            MapSet map1 = new MapSet();
            MapSet map2 = new MapSet();
            MapSet map3 = new MapSet();
            MapSet bossMap = new MapSet();
            board = map.Lobby(player);
            bossMap = map.BossMap(player);
            quest = MainQuest.MainQ_1();
            quest.questClear = false;
            item2 = Expendables.Mail();
            tempQuest.Add(quest);

            while (board.end == false)
            {
                //맵초기화
                lobby = map.Lobby(player);
                map1 = map.Map1(player);
                map2 = map.Map2(player);
                map3 = map.Map3(player);
                if (player.questList.Contains(quest) == true || player.questClearList.Contains(quest))
                {
                    if (board.playerY == 3 && board.playerX == 11)
                    {
                        board.map[3, 11] = player.classMark;
                    }
                    else
                    {
                        board.map[3, 11] = board.mapMark;
                    }
                }
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
                else if (board.mapName == map3.mapName)
                {
                    board = map.MonsterMap(board, 25);
                }

                map.MapShow(board);

                Console.WriteLine("\n\t   【{0}】▶【레벨】{1}\n\t   【HP】{2}/{3}\t   【MP】{4}/{5}", player.Name, player.Level,
                    player.Hp, player.MaxHp, player.Mp, player.MaxMp);
                character.ShowHpMpPlayer(player);
                Console.WriteLine("\t     ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("\t     ┃   【상태창】    ▶   【 C 】  ┃\n\t     ┃   【인벤토리】  ▶   【 B 】  ┃\n\t     ┃   【스킬】      ▶   【 K 】  ┃\n\t     ┃   【퀘스트】    ▶   【 L 】  ┃\n\t     ┃   【게임종료】  ▶   【 X 】  ┃");
                Console.WriteLine("\t     ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                //플레이어 이동입력 함수 호출
                MoveKey moveKey = new MoveKey();
                board = moveKey.MoveInfo(board, player);
                //몬스터만나면 배틀시작
                if (board.monsterCount == true)
                {
                    player.findMonster = true;
                    if (board.mapName == map1.mapName)
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
                if (board.bossCount == true)
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
                    else
                    {
                        bossMap.map[11, 9] = board.mapMark;
                        bossMap.map[11, 10] = board.mapMark;
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
                }
                //스킬창 열기
                if (board.showSkill == true)
                {
                    classSkill.ShowSkillList(player.skillList, player);
                    Console.ReadLine();
                    Console.Clear();
                }
                //퀘스트창 열기
                if (board.showQuest == true)
                {
                    quest.ShowQuest(player);
                }
                //촌장
                if (board.chiefCount == true)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 5);
                    if (player.questList.Contains(quest) == false && player.questClearList.Contains(quest) == false)
                    {
                        Console.WriteLine("\t\t【마을촌장】▶ 모험가 양반\n\n\t\t【마을촌장】▶ 제발 우리 마을좀 도와주게나\n\n" +
                            "\t\t【마을촌장】▶ 최근 들어 몬스터에게 당한 피해가 너무 크다네\n\n\t\t【마을촌장】▶ 몸 성한 마을 사람이 손에 꼽을 지경이야" +
                            "\n\n\t\t【마을촌장】▶ 부디 우리 마을을 외면하지 말아 주게나\n");
                        Console.WriteLine("\t\t【퀘스트】▶ {0}\n\n\t\t【1】▶ 수락\n\t\t【2】▶ 거절", quest.questName);
                        string accept = Console.ReadLine();
                        if (accept == "1")
                        {
                            Console.Clear();
                            Console.SetCursorPosition(0, 5);
                            Console.WriteLine("\t\t【{0}】▶ 수락하지", player.Name);
                            Console.ReadLine();
                            player.questList.Add(quest);
                        }
                        else if (accept == "2")
                        {
                            Console.Clear();
                            Console.SetCursorPosition(0, 5);
                            Console.WriteLine("\t\t【{0}】▶ 갈 길이 멀어서 이만", player.Name);
                            Console.ReadLine();
                        }
                    }
                    else if (player.questList.Contains(quest) == true)
                    {
                        foreach (var temp in tempQuest)
                        {
                            if (temp.questName == quest.questName)
                            {
                                if (temp.questClear == false)
                                {
                                    item = Expendables.Ring();
                                    Console.WriteLine("\t\t【마을촌장】▶ 기다리고 있었다네\n\n\t\t【마을촌장】▶ 일은 어떻게 되었나?\n\n");
                                    Console.WriteLine("\t\t【1】▶ {0}를 촌장에게 보여준다\n\t\t【2】▶ 진행중이오", item.Name);
                                    int inPutNum = -1;
                                    int.TryParse(Console.ReadLine(), out inPutNum);
                                    bool checkItem = false;
                                    foreach (var temp2 in player.itemList)
                                    {
                                        if (temp2.Name == "마왕의 증표")
                                        {
                                            checkItem = true;
                                        }
                                    }
                                    if (inPutNum == 1)
                                    {
                                        Console.Clear();
                                        Console.SetCursorPosition(0, 5);
                                        if (checkItem == true)
                                        {
                                            Console.WriteLine("\t\t【마을촌장】▶ {0}!!!\n\n\t\t【마을촌장】▶ 몬스터들이 마왕을 소환하고 있었던겐가..." +
                                                "\n\n\t\t【마을촌장】▶ 【{1}】 자네가 우리 마을을 살렸네\n\n\t\t【마을촌장】▶ 【{1}】 정말 고마우이 고마워" +
                                                "\n\n\t\t【마을촌장】▶ 이건 약소하지만 부디 받게나\n\n\t\t【마을촌장】▶ 다시 한번 정말 고맙네 【{1}】", item.Name, player.Name);
                                            Console.ReadLine();
                                            Console.Clear();
                                            Console.SetCursorPosition(0, 5);
                                            Console.WriteLine("\t\t\t【{0} 완료】\n", quest.questName);
                                            Console.WriteLine("\t\t【EXP】3000【골드】5000\n");
                                            if (player._class == "기사")
                                            {
                                                item = KnightWeapon.Excalibur();
                                                Console.WriteLine("\t\t【아이템】{0} 획득!!", item.Name);
                                                player.itemList.Add(item);
                                            }
                                            else if (player._class == "궁수")
                                            {
                                                item = MageWeapon.ArchonStaff();
                                                Console.WriteLine("\t\t【아이템】{0} 획득!!", item.Name);
                                                player.itemList.Add(item);
                                            }
                                            else if (player._class == "마법사")
                                            {
                                                item = MageWeapon.ArchonStaff();
                                                Console.WriteLine("\t\t【아이템】{0} 획득!!", item.Name);
                                                player.itemList.Add(item);
                                            }
                                            Console.WriteLine("\n\t\t【아이템】{0} 획득!!", item2.Name);
                                            player.itemList.Add(item2);
                                            Console.ReadLine();
                                            player.Exp += 3000;
                                            player.gold += 5000;
                                            player.questClearList.Add(temp);
                                            foreach (var itemNum in player.questClearList)
                                            {
                                                if (itemNum.questName == quest.questName)
                                                {
                                                    itemNum.questClear = true;
                                                }
                                            }
                                            classSkill.GetSkill(player);
                                            player.questList.Remove(temp);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\t\t【마을촌장】▶ 자네 보여줄 만한 증거 없나?\n\n\t\t【마을촌장】▶ 해결되고 나면 다시 찾아주게나");
                                            Console.ReadLine();
                                        }
                                    }
                                    else if (inPutNum == 2)
                                    {
                                        Console.Clear();
                                        Console.SetCursorPosition(0, 5);
                                        Console.WriteLine("\t\t【{0}】▶ 아직 진행중이오", player.Name);
                                        Console.ReadLine();
                                    }
                                }
                            }
                        }
                    }
                    else if (player.questClearList.Contains(quest) == true)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 5);
                        Console.WriteLine("\t\t【마을촌장】▶ 자네 덕에 마을이 활기를 되찾았네\n\n\t\t【마을촌장】▶ 【{0}】정말 고맙네 고마워" +
                            "\n\n\t\t【마을촌장】▶ 자네는 마을의 영웅일세!!\n\n\t\t【마을촌장】▶ 우리 마을은 언제나 자네를 환영하네", player.Name);
                        Console.ReadLine();
                        Console.Clear();
                        Console.SetCursorPosition(0, 5);
                        Console.WriteLine("\t\t당신은 마을의 영웅으로 추앙받습니다!\n\n\t\t마을 사람들은 당신을 영원히 기억할 것입니다\n\n" +
                            "\t\t【여관주인】과【상인】이 특별한 혜택을 준비했습니다");
                    }
                    Console.Clear();
                    board.chiefCount = false;
                }

                //상인
                if (board.shopCount == true)
                {

                    for (int index = 0; index < 1; index++)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 5);
                        if (player.questClearList.Contains(quest) == true)
                        {
                            Console.WriteLine("\t\t【상인】▶【{0}】어서오게나!\n\n\t\t【상인】▶ 마을을 구한 영웅이 찾아오다니\n\n\t\t【상인】▶ 오늘 운이 좋구만 껄껄" +
                                "\n\n\t\t【상인】▶ 자 오늘도 최상품의 물건만 있다네\n\n\t\t【상인】▶ 영웅에게는 특별히 싸게 드리지 껄껄\n\n", player.Name);
                        }
                        else
                        {
                            Console.WriteLine("\t\t【상인】▶【{0}】오랜만에 보는구먼\n\n\t\t【상인】▶ 필요한 물건 있나 한번 보게나\n\n\t\t【상인】▶ 우리 가게 상품은 최상품이라구!\n\n", player.Name);
                        }
                        Console.WriteLine("\t\t【1】▶ 오늘의 상품은 뭐가 있나 한번 볼까?\n\t\t【2】▶ 아이템을 팔러왔소\n\t\t【3】▶ 다음에 다시 온다");
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
                                            Console.WriteLine("\t\t【구매 완료】▶ 【{0}】", buyNpc[buy - 1].Name);
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
                                        if (player.itemList[sell].ItemType == "장착중")
                                        {
                                            Console.WriteLine("\t\t【장착중인 무기는 팔 수 없습니다】");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            player.gold += (player.itemList[sell].Price / 2);
                                            Console.WriteLine("\t\t【판매 완료】▶【{0}】【{1}】골드 획득", player.itemList[sell].Name, player.itemList[sell].Price / 2);
                                            Console.ReadLine();
                                            player.itemList.Remove(player.itemList[sell]);
                                        }
                                        index3--;
                                    }
                                    else
                                    {
                                        index--;
                                    }
                                }
                                break;
                            case "3":
                                Console.Clear();
                                Console.SetCursorPosition(0, 5);
                                Console.WriteLine("\t\t【{0}】▶ 지금은 괜찮소 다음에 다시 오겠소", player.Name);
                                Console.WriteLine("\n\t\t\t아무키나 눌러 계속 진행");
                                Console.ReadLine();
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
                    for (int index = 0; index < 1; index++)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 5);
                        if (player.questClearList.Contains(quest) == true)
                        {
                            Console.WriteLine("\t\t【여관주인】▶【{0}】!! 어서오게나\n\n\t\t【여관주인】▶ 마을의 영웅은 언제나 환영이지!\n\n\t\t【여관주인】▶【{0}】 자네는 우리 여관 평생 무료라네!" +
                                "\n\n\t\t【여관주인】▶ 쉬고싶으면 말만하게나 바로 안내하지\n\n", player.Name);
                        }
                        else
                        {
                            Console.WriteLine("\t\t【여관주인】▶ 자네 피곤해 보이는군\n\n\t\t【여관주인】▶ 싸게줄테니 한숨 자고 가겠나?\n\n\t\t【여관주인】▶【200골드】에 방 한칸 내주지\n\n");
                        }
                        Console.WriteLine("\t\t【1】▶ 여관에서 하루 쉬었다 간다.\n\t\t【2】▶ 다음에 쉰다.\n");
                        string motelInPut = Console.ReadLine();
                        switch (motelInPut)
                        {
                            case "1":
                                if (player.questClearList.Contains(quest) == true)
                                {
                                    player.Hp = player.MaxHp;
                                    player.Mp = player.MaxMp;
                                    Console.Clear();
                                    Console.SetCursorPosition(0, 5);
                                    Console.WriteLine("\t\t【{0}】▶ 하루 푹 쉬고나니 상쾌하군\n\n\t\t【{0}】▶ 역시 공짜가 최고야!!\n", player.Name);
                                    Console.WriteLine("\t\t【{0}】의 체력과 마나가 가득찼습니다.", player.Name);
                                    Console.ReadLine();
                                }
                                else if (player.gold >= 200)
                                {
                                    player.gold -= 200;
                                    player.Hp = player.MaxHp;
                                    player.Mp = player.MaxMp;
                                    Console.Clear();
                                    Console.SetCursorPosition(0, 5);
                                    Console.WriteLine("\t\t【{0}】▶ 하루 푹 쉬고나니 상쾌하군\n\n", player.Name);
                                    Console.WriteLine("\t\t【{0}】의 체력과 마나가 가득찼습니다.", player.Name);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition(0, 5);
                                    Console.WriteLine("\t\t【여관주인】▶ 자네【200골드】도 없나?\n\n\t\t【여관주인】▶ 네고는 안된다네");
                                    Console.ReadLine();
                                }
                                break;
                            case "2":
                                Console.Clear();
                                Console.SetCursorPosition(0, 5);
                                Console.WriteLine("\t\t【{0}】▶ 지금은 괜찮소 다음에 다시 오겠소.", player.Name);
                                Console.ReadLine();
                                break;
                            default:
                                index--;
                                break;
                        }
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
                        Console.WriteLine("\t\t【이동할 맵을 선택하세요】\n\n\t\t【1】▶ {0}\n\t\t【2】▶ {1}\t\t【제한레벨 3】\n\t\t【3】▶ {2}\t【제한레벨 5】\n\t\t【4】▶ {3}\t【제한레벨 7】\n\t\t【0】▶ 마을\n\t\t【9】▶ 뒤로",
                            map1.mapName, map2.mapName, map3.mapName, bossMap.mapName);
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
                                if (player.Level >= 3)
                                {
                                    board = map2;
                                }
                                else
                                {
                                    Console.WriteLine("\t\t【요구 레벨을 충족하지 못했습니다】\n\n\t\t【{0}의 제한레벨】▶ 3", map2.mapName);
                                    index--;
                                    Console.ReadLine();
                                }
                                break;
                            case "3":
                                if (player.Level >= 5)
                                {
                                    board = map3;
                                }
                                else
                                {
                                    Console.WriteLine("\t\t【요구 레벨을 충족하지 못했습니다】\n\n\t\t【{0}의 제한레벨】▶ 5", map3.mapName);
                                    index--;
                                    Console.ReadLine();
                                }
                                break;
                            case "4":
                                if (player.Level >= 0)
                                {
                                    if (player.bossKill == true)
                                    {
                                        bossMap.map[9, 9] = board.mapMark;
                                        bossMap.map[10, 9] = board.mapMark;
                                        bossMap.map[10, 10] = board.mapMark;
                                    }
                                    bossMap.map[18, 1] = player.classMark;
                                    bossMap.map[18, 10] = board.mapMark;
                                    board = bossMap;
                                }
                                else
                                {
                                    Console.WriteLine("\t\t【요구 레벨을 충족하지 못했습니다】\n\n\t\t【{0}의 제한레벨】▶ 7", bossMap.mapName);
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

        public void Title()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("\t ,ggg, ,ggggggg,   ,ggg,         gg        ,gggg,         ,gggg,  \r\n\tdP\"\"Y8,8P\"\"\"\"\"Y8b dP\"\"Y8a        88       d8\" \"8I        d8\" \"8I  \r\n\tYb, `8dP'     `88 Yb, `88        88       88  ,dP        88  ,dP  \r\n\t `\"  88'       88  `\"  88        88    8888888P\"      8888888P\"   \r\n\t     88        88      88        88       88             88       \r\n\t     88        88      88        88       88             88       \r\n\t     88        88      88        88  ,aa,_88        ,aa,_88       \r\n\t     88        88      88        88 dP\" \"88P       dP\" \"88P       \r\n\t     88        Y8,     Y8b,____,d88,Yb,_,d88b,,_   Yb,_,d88b,,_   \r\n\t     88        `Y8      \"Y888888P\"Y8 \"Y8P\"  \"Y88888 \"Y8P\"  \"Y88888\r\n\t                                                                  \r\n\t                                                                  \r\n");
            Console.WriteLine("\t\t\t     아무키나 눌러 계속 진행");
            Console.ReadLine();
            Console.Clear();
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("\t\t대륙에서 이름을 날리고 있는 한 모험가가 있다" +
                "\n\n\t\t모험가는 대륙 이곳저곳을 모험하며 몬스터를 퇴치하고" +
                "\n\n\t\t위기에 빠진 사람들을 도와주는 것에 큰 보람을 느낀다" +
                "\n\n\t\t모험가는 안도하는 사람들을 뒤로하며\n\n\t\t또 다른 모험을 떠나게 되는데..\n\n");
            Console.WriteLine("\t\t\t아무키나 눌러 계속 진행");
            Console.ReadLine();
            Console.Clear();
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("\t\t\t이건 그 모험가의 이야기다");
            Console.ReadLine();
        } //Title
    } //PlayGame
}
