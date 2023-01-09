using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static TextRpgMake.Map;

namespace TextRpgMake
{
    public class Battle
    {
        public Battle(Player player, Monster monster)
        {
            //Map map = new Map();
            //MapSet lobby = new MapSet();
            //lobby = map.Lobby();
            ClassSkill classSkill = new ClassSkill();
            Item item = new Item();
            Random random = new Random();
            bool battleWin = false;
            bool monsterDefence = false;
            int turnCount = 0;
            Console.Clear();
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣\n");
            Console.WriteLine("\t【{0}】▶\t【{1}】을(를) 보며 입맛을 다십니다!!", monster.Name, player.Name);
            Console.WriteLine();
            Console.WriteLine("\t\t\t전\t투\t시\t작\n");
            Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣");
            Console.ReadLine();
            while (battleWin == false)
            {
                int playerRun = 0;
                for (int index = 0; index < 1; index++)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("\t\t\t【{0}】", player.Name);
                    Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣");
                    Console.WriteLine("▣\t\t\t\t\t\t\t\t▣");
                    Console.WriteLine("▣【HP】{0}/{1}\t【MP】{2}/{3}\t【공격력】{4}\t【방어력】{5}    ▣", player.Hp, player.MaxHp,
                        player.Mp, player.MaxMp, player.Damage, player.Defence);
                    Console.WriteLine("▣\t\t\t\t\t\t\t\t▣");
                    Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣");
                    Console.WriteLine();
                    Console.WriteLine("\t\t\t【{0}】", monster.Name);
                    Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣");
                    Console.WriteLine("▣\t\t\t\t\t\t\t\t▣");
                    Console.WriteLine("▣【HP】{0}/{1}\t【MP】{2}/{3}\t【공격력】{4}\t【방어력】{5}    ▣", monster.Hp, monster.MaxHp,
                        monster.Mp, monster.MaxMp, monster.Damage, monster.Defence);
                    Console.WriteLine("▣\t\t\t\t\t\t\t\t▣");
                    Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣");
                    Console.WriteLine();
                    Console.WriteLine("\t【【{0}】의 턴 】\n\n【1】공   격\n【2】스킬 사용\n【3】아이템 사용\n【4】도   망", player.Name);
                    string inPut = Console.ReadLine();
                    Console.Clear();
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣\n");
                    Console.WriteLine("\t\t\t【{0}】의 턴\n", player.Name);
                    switch (inPut)
                    {
                        case "1":
                            //기본공격 실행
                            Console.WriteLine("\t【{0}】▶ 【{1}】에게【{2}】데미지 공격!", player.Name, monster.Name, player.Damage);
                            monster.Hp -= player.Damage - (monster.Defence / 2);
                            break;
                        case "2":
                            //스킬 사용 예외처리 및 실행
                            int number1 = -1;
                            Console.Clear();
                            Console.SetCursorPosition(0, 5);
                            classSkill.ShowSkillList(player.skillList);
                            Console.WriteLine("【스킬사용】▶ 스킬 번호 /【뒤로】▶ 스킬 목록을 제외한 아무키");
                            int skillInPut = -1;
                            int.TryParse(Console.ReadLine(), out skillInPut);
                            if (0 < skillInPut && skillInPut <= player.skillList.Count)
                            {
                                switch (skillInPut)
                                {
                                    case 1:
                                        number1 = 0;
                                        break;
                                    case 2:
                                        number1 = 1;
                                        break;
                                    case 3:
                                        number1 = 2;
                                        break;
                                } //switch

                                if (player.Mp >= player.skillList[number1].UseMp)
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition(0, 5);
                                    Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣\n");
                                    Console.WriteLine("\t\t\t\t【{0}】의 턴\n", player.Name);
                                    Console.WriteLine("\t【{0}】▶ 【{1}】사용【{2}】에게【{3}】데미지!!!", player.Name, player.skillList[number1].SkillName,
                                        monster.Name, player.skillList[number1].SkillDamage);
                                    monster.Hp -= player.skillList[number1].SkillDamage - (monster.Defence / 2);
                                    player.Mp -= player.skillList[number1].UseMp;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition(0, 5);
                                    Console.WriteLine("\t\t\t【마나가 부족합니다】\n");
                                    index--;
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                index--;
                            } //if
                            break;
                        case "3":
                            //아이템 사용 선택지 예외처리 및 실행
                            for (int index2 = 0; index2 < 1; index2++)
                            {
                                Console.Clear();
                                Console.SetCursorPosition(0, 5);
                                item.ShowItemList(player.itemList, player);
                                Console.WriteLine("【사용하기】▶ 사용할 아이템 번호 /【뒤로】▶ 아이템 목록을 제외한 아무키\n");
                                int itemInPut = -1;
                                int.TryParse(Console.ReadLine(), out itemInPut);
                                if (0 < itemInPut && itemInPut <= player.itemList.Count)
                                {
                                    itemInPut = itemInPut - 1;
                                    if (player.itemList[itemInPut].ItemType == "회복소모품")
                                    {
                                        Console.WriteLine("【사용】▶ 【{0}】", player.itemList[itemInPut].Name);
                                        if (player.itemList[itemInPut].Name == "HP포션" || player.itemList[itemInPut].Name == "상급HP포션")
                                        {
                                            player.Hp += player.itemList[itemInPut].HpMpPlus;
                                            if (player.Hp >= player.MaxHp)
                                            {
                                                player.Hp = player.MaxHp;
                                            }
                                            player.itemList.Remove(player.itemList[itemInPut]);
                                        }
                                        else if (player.itemList[itemInPut].Name == "MP포션" || player.itemList[itemInPut].Name == "상급MP포션")
                                        {
                                            player.Mp += player.itemList[itemInPut].HpMpPlus;
                                            if (player.Mp >= player.MaxMp)
                                            {
                                                player.Mp = player.MaxMp;
                                            }
                                            player.itemList.Remove(player.itemList[itemInPut]);
                                        } //if
                                    }
                                    else if (player.itemList[itemInPut].ItemType == "투척소모품")
                                    {
                                        Console.Clear();
                                        Console.SetCursorPosition(0, 5);
                                        Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣\n");
                                        Console.WriteLine("\t\t\t【사용】▶ 【{0}】\n", player.itemList[itemInPut].Name);
                                        Console.WriteLine("\t【{0}】▶ 【{1}】사용! 【{2}】에게 【{3}】고정피해!!", player.Name, player.itemList[itemInPut].Name,
                                            monster.Name, player.itemList[itemInPut].WeaponDamage);
                                        monster.Hp -= player.itemList[itemInPut].WeaponDamage;
                                        player.itemList.Remove(player.itemList[itemInPut]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("【장비아이템은 사용할 수 없습니다】");
                                        Console.ReadLine();
                                        index2--;
                                    }
                                }
                                else
                                {
                                    index--;
                                } //if
                            } //for
                            break;
                        case "4":
                            //도망 실행
                            int dice = random.Next(0, 10);
                            if (dice >= 6)
                            {
                                Console.WriteLine("\t\t\t【도망 성공!!】\n");
                                Console.WriteLine("\t【{0}】▶ 【{1}】새끼 니 얼굴 기억했다.\n\n\t【{2}】은(는)【{3}】의 눈에 흙을 뿌리며 전력으로 도망쳤다\n",
                                    player.Name, monster.Name, player.Name, monster.Name);
                                playerRun = 2;
                            }
                            else
                            {
                                Console.WriteLine("\t\t\t【도망 실패!!】\n");
                                Console.WriteLine("\t\t【{0}】▶ 등짝.. 등짝을 보자!!\n\n\t\t【{1}】▶ 아..아...안....안돼!!!!!\n", monster.Name, player.Name);
                                Console.WriteLine("\t\t【{0}】▶ 공격력 2배 상승!!\n\n\t\t【{1}】의 눈가가 촉촉해진다..", monster.Name, player.Name);
                                playerRun = 1;
                            }
                            break;
                        default:
                            index--;
                            break;
                    } //switch
                } //for
                Console.WriteLine();
                Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣\n");
                Console.ReadLine();
                //몬스터 방어태세 확인
                if (monsterDefence == true)
                {
                    monster.Defence -= monster.buffDefence;
                    monsterDefence = false;
                }

                if (monster.Hp <= 0)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("★★★★★★★★★★★★★★★★★★★★★★★★\n\n");
                    Console.WriteLine("\t【{0}】을(를) 해치웠다!!\n\n\t【EXP】{1}【골드】{2} 획득!!\n\n", monster.Name, monster.Exp, monster.monsterGold);
                    Console.WriteLine("★★★★★★★★★★★★★★★★★★★★★★★★");
                    Console.ReadLine();
                    player.Exp += monster.Exp;
                    player.gold += monster.monsterGold;
                    battleWin = true;
                }
                else if (playerRun == 1)
                {
                    player.Hp -= (monster.Damage * 2) - (player.Defence / 2);
                    playerRun = 0;

                }
                else if (playerRun == 2)
                {
                    battleWin = true;
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("==========================================================================\n");
                    Console.WriteLine("\t\t\t【{0}】의 턴\n", monster.Name);
                    int monsterAction = random.Next(0, 10);
                    if (monsterAction >= 3)
                    {
                        Console.WriteLine("\t【{0}】▶ 【{1}】에게【{2}】데미지 공격!!\n", monster.Name, player.Name, monster.Damage);
                        player.Hp -= monster.Damage - (player.Defence / 2);
                    }
                    else
                    {
                        Console.WriteLine("\t【{0}】▶ 방어자세를 취했다! 다음턴【방어력】{1}증가!!\n", monster.Name, monster.buffDefence);
                        monster.Defence += monster.buffDefence;
                        monsterDefence = true;
                    }
                    Console.WriteLine("==========================================================================");

                    if (player.Hp <= 0)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 5);
                        Console.WriteLine("==========================================================================\n\n");
                        Console.WriteLine("\t【{0}】에게 패배! 마을로 돌아갑니다.\n\n", monster.Name);
                        Console.WriteLine("==========================================================================");
                        player.playerDead = true;
                        battleWin = true;
                    }
                }
                turnCount++;
                Console.WriteLine();
                Console.WriteLine("\t\t\t【{0}】턴 종료\n\n\t\t  아무키나 눌러 다음 턴으로", turnCount);
                Console.ReadLine();
            } //while
            //전투끝나고 레벨체크해서 스킬획득
            classSkill.GetSkill(player);
            Console.Clear();

        } //Battle(생성자)


    } //Battle
}
