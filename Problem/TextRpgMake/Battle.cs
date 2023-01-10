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
            ClassSkill classSkill = new ClassSkill();
            Character character= new Character();
            Item item = new Item();
            Random random = new Random();
            bool battleWin = false;
            bool monsterDefence = false;
            int turnCount = 0;
            Console.Clear();
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("\t\t【{0}】▶ 【{1}】을(를) 보며 입맛을 다십니다!!\n\n", monster.Name, player.Name);
            Console.WriteLine("\t\t\t【 전    투    시    작 】\n");
            Console.ReadLine();
            while (battleWin == false)
            {
                int playerRun = 0;
                for (int index = 0; index < 1; index++)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine();
                    Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n┃\t\t\t      【플레이어】\t\t\t\t┃");
                    Console.WriteLine("\t\t【레벨】{0}\t\t   【{1}】", player.Level, player.Name);
                    Console.WriteLine("\t\t【공격력】{0}\t\t   【방어력】{1}", player.Damage, player.Defence);
                    Console.WriteLine("\t\t【HP】{0}/{1}\t\t   【MP】{2}/{3}", player.Hp, player.MaxHp, player.Mp, player.MaxMp);
                    character.ShowHpMpPlayer(player);
                    Console.WriteLine("┃\t\t\t\t\t\t\t\t\t┃\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\n");
                    Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n┃\t\t\t      【몬 스 터】\t\t\t\t┃");
                    Console.WriteLine("\t\t【레벨】{0}\t\t   【{1}】", monster.Level, monster.Name);
                    Console.WriteLine("\t\t【공격력】{0}\t\t   【방어력】{1}", monster.Damage, monster.Defence);
                    Console.WriteLine("\t\t【HP】{0}/{1}\t\t   【MP】{2}/{3}", monster.Hp, monster.MaxHp, monster.Mp, monster.MaxMp);
                    character.ShowHpMpMonster(monster);
                    Console.WriteLine("┃\t\t\t\t\t\t\t\t\t┃\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\n");
                    Console.WriteLine("\t\t\t【【{0}】의 턴 】\n\n\t\t\t【1】공   격\n\t\t\t【2】스킬 사용\n\t\t\t【3】아이템 사용\n\t\t\t【4】도   망", player.Name);
                    string inPut = Console.ReadLine();
                    Console.Clear();
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n┃\t\t\t     【플레이어 턴】\t\t\t\t┃\n┃\t\t\t\t\t\t\t\t\t┃");
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
                            classSkill.ShowSkillList(player.skillList, player);
                            int skillInPut = -1;
                            int.TryParse(Console.ReadLine(), out skillInPut);
                            if (0 < skillInPut && skillInPut <= player.skillList.Count)
                            {
                                skillInPut = skillInPut - 1;
                                if (player.Mp >= player.skillList[skillInPut].UseMp)
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition(0, 5);
                                    Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n┃\t\t\t     【플레이어 턴】\t\t\t\t┃\n┃\t\t\t\t\t\t\t\t\t┃");
                                    Console.WriteLine("\t【{0}】▶ 【{1}】사용【{2}】에게【{3}】데미지!!!", player.Name, player.skillList[skillInPut].SkillName,
                                        monster.Name, player.skillList[skillInPut].SkillDamage);
                                    monster.Hp -= player.skillList[skillInPut].SkillDamage - (monster.Defence / 2);
                                    player.Mp -= player.skillList[skillInPut].UseMp;
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
                            //아이템 사용
                            item.UseItem(player, monster);
                            if (player.itemUse == false)
                            {
                                index--;
                            }
                            break;
                        case "4":
                            //도망 실행
                            int dice = random.Next(0, 10);
                            if (dice >= 6)
                            {
                                Console.WriteLine("\t\t\t     【도망 성공!!】\n");
                                Console.WriteLine("\t【{0}】▶ 【{1}】새끼 니 얼굴 기억했다.\n\n\t【{2}】은(는)【{3}】의 눈에 흙을 뿌리며 전력으로 도망쳤다\n",
                                    player.Name, monster.Name, player.Name, monster.Name);
                                playerRun = 2;
                            }
                            else
                            {
                                Console.WriteLine("\t\t\t     【도망 실패!!】\n");
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
                Console.WriteLine("┃\t\t\t\t\t\t\t\t\t┃\n┃\t\t\t\t\t\t\t\t\t┃\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                Console.ReadLine();
                //몬스터 방어태세 확인
                if (monsterDefence == true)
                {
                    monster.Defence -= monster.buffDefence;
                    monsterDefence = false;
                }

                if (monster.Hp <= 0 && player.findBoss == true)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 5);
                    //보스템 3개 랜덤얻음
                    
                    Console.WriteLine("★★★★★★★★★★★★★★★★★★★★★★★★\n\n");
                    Console.WriteLine("\t【{0}】을(를) 해치웠다!!\n\n\t【EXP】{1}【골드】{2}\n", monster.Name,
                        monster.Exp, monster.monsterGold);
                    for (int index2 = 0; index2 < 3; index2++)
                    {
                        int bossDrop = 0;
                        bossDrop = random.Next(0, monster.dropItem.Count);
                        Console.WriteLine("\t【아이템】{0} 획득!!\n", monster.dropItem[bossDrop].Name);
                        player.itemList.Add(monster.dropItem[bossDrop]);
                        monster.dropItem.RemoveAt(bossDrop);
                    }
                    Console.WriteLine("\n★★★★★★★★★★★★★★★★★★★★★★★★");
                    Console.ReadLine();
                    player.Exp += monster.Exp;
                    player.gold += monster.monsterGold;
                    battleWin = true;
                }
                else if (monster.Hp <= 0 && player.findMonster == true)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 5);
                    int dropitem = random.Next(0, monster.dropItem.Count);
                    int getDrop = random.Next(0, 9 + 1);
                    if (getDrop >= 4)
                    {
                        Console.WriteLine("★★★★★★★★★★★★★★★★★★★★★★★★\n\n");
                        Console.WriteLine("\t【{0}】을(를) 해치웠다!!\n\n\t【EXP】{1}【골드】{2}\n\n\t【아이템】{3} 획득!!!\n\n", monster.Name,
                            monster.Exp, monster.monsterGold, monster.dropItem[dropitem].Name);
                        Console.WriteLine("★★★★★★★★★★★★★★★★★★★★★★★★");
                        player.itemList.Add(monster.dropItem[dropitem]);
                    }
                    else
                    {
                        Console.WriteLine("★★★★★★★★★★★★★★★★★★★★★★★★\n\n");
                        Console.WriteLine("\t【{0}】을(를) 해치웠다!!\n\n\t【EXP】{1}【골드】{2}\n\n", monster.Name,
                            monster.Exp, monster.monsterGold);
                        Console.WriteLine("★★★★★★★★★★★★★★★★★★★★★★★★");
                    }
                    Console.ReadLine();
                    player.Exp += monster.Exp;
                    player.gold += monster.monsterGold;
                    battleWin = true;
                }
                else if (playerRun == 1)
                {
                    player.Hp -= (monster.Damage * 2) - (player.Defence / 2);
                    playerRun = 0;
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
                else if (playerRun == 2)
                {
                    battleWin = true;
                }
                else if (player.findBoss == true)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("==========================================================================\n");
                    Console.WriteLine("\t\t\t【{0}】의 턴\n", monster.Name);
                    int monsterAction = random.Next(0, 10);
                    if (monsterAction >= 6)
                    {
                        Console.WriteLine("\t【{0}】▶ 【{1}】에게【{2}】데미지 공격!!\n", monster.Name, player.Name, monster.Damage);
                        player.Hp -= monster.Damage - (player.Defence / 2);
                    }
                    else if (2 < monsterAction && monsterAction < 6)
                    {
                        int randomSkill = random.Next(0, 10);
                        if (randomSkill <= 6)
                        {
                            if (monster.Mp >= BossSkill.Skill_1().UseMp)
                            {
                                Console.WriteLine("\t【{0}】▶【{1}】시전!!【{2}】에게 【{3}】데미지!!!\n", monster.Name, BossSkill.Skill_1().SkillName,
                                    player.Name, BossSkill.Skill_1().SkillDamage);
                                player.Hp -= BossSkill.Skill_1().SkillDamage - (player.Defence / 2);
                                monster.Mp -= BossSkill.Skill_1().UseMp;
                            }
                            else
                            {
                                Console.WriteLine("【{0}】▶【마나 회복】시전!! 【MP】+ 100", monster.Name);
                                monster.Mp += 100;
                            }
                        }
                        else if (2 < randomSkill && randomSkill < 6)
                        {
                            if (monster.Mp >= BossSkill.Skill_2().UseMp)
                            {
                                Console.WriteLine("\t【{0}】▶【{1}】시전!!【{2}】에게 【{3}】데미지!!!\n", monster.Name, BossSkill.Skill_2().SkillName,
                                    player.Name, BossSkill.Skill_2().SkillDamage);
                                player.Hp -= BossSkill.Skill_2().SkillDamage - (player.Defence / 2);
                                monster.Mp -= BossSkill.Skill_2().UseMp;
                            }
                            else
                            {
                                Console.WriteLine("【{0}】▶【마나 회복】시전!! 【MP】+ 100", monster.Name);
                                monster.Mp += 100;
                            }
                        }
                        else
                        {
                            if (monster.Mp >= BossSkill.Skill_3().UseMp)
                            {
                                Console.WriteLine("\t【{0}】▶【{1}】시전!!【{2}】에게 【{3}】데미지!!!\n", monster.Name, BossSkill.Skill_3().SkillName,
                                    player.Name, BossSkill.Skill_3().SkillDamage);
                                player.Hp -= BossSkill.Skill_3().SkillDamage - (player.Defence / 2);
                                monster.Mp -= BossSkill.Skill_3().UseMp;
                            }
                            else
                            {
                                Console.WriteLine("\t【{0}】▶【마나 회복】시전!! 【MP】+ 100", monster.Name);
                                monster.Mp += 100;
                            }
                        }
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
