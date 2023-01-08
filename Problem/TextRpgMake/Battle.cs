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
            Console.Clear();
            Console.SetCursorPosition(10, 10);
            Console.WriteLine("【{0}】\t이(가)【{1}】을(를) 보며 입맛을 다십니다!!", monster.Name, player.Name);
            Console.WriteLine();
            Console.WriteLine("\t\t\t전\t투\t시\t작");
            Console.ReadLine();
            while (battleWin == false)
            {
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
                    //Console.WriteLine("【{0}】▶【HP】{1}/{2} 【공격력】{2} 【방어력】{3}", monster.Name, monster.Hp, monster.MaxHp, monster.Damage, monster.Defence);
                    Console.WriteLine();
                    Console.WriteLine("【{0}】의턴입니다\n【1】공   격\n【2】스킬 사용\n【3】아이템 사용\n【4】도   망", player.Name);
                    string inPut = Console.ReadLine();
                    switch (inPut)
                    {
                        case "1":
                            Console.WriteLine("【{0}】이(가)【{1}】에게【{2}】데미지 공격!", player.Name, monster.Name, player.Damage);
                            monster.Hp -= player.Damage - (monster.Defence / 2);
                            break;
                        case "2":
                            int number1 = -1;
                            for (int index2 = 0; index2 <= player.skillList.Count; index2++)
                            {
                                classSkill.ShowSkillList(player.skillList);
                                Console.WriteLine();
                                Console.WriteLine("스킬을 선택하세요.");
                                string str1 = Console.ReadLine();
                                switch (str1)
                                {
                                    case "1":
                                        number1 = 0;
                                        break;
                                    case "2":
                                        number1 = 1;
                                        break;
                                    case "3":
                                        number1 = 2;
                                        break;
                                    default:
                                        index2--;
                                        break;
                                }
                            }
                            if (player.Mp >= player.skillList[number1].UseMp)
                            {
                                Console.WriteLine("【{0}】이(가)【{1}】사용【{2}】에게【{3}】데미지!!!", player.Name, player.skillList[number1].SkillName,
                                    monster.Name, player.skillList[number1].SkillDamage);
                                monster.Hp -= player.skillList[number1].SkillDamage - (monster.Defence / 2);
                                player.Mp -= player.skillList[number1].UseMp;
                            }
                            else
                            {
                                Console.Clear();
                                Console.SetCursorPosition(30, 10);
                                Console.WriteLine("마나가 부족합니다.");
                                Console.ReadLine();
                                index--;
                            }
                            break;
                        case "3":
                            item.ShowItemList(player.itemList);
                            Console.WriteLine("사용할 아이템을 선택하세요.");
                            string str2 = Console.ReadLine();
                            switch (str2)
                            {
                                case "1":
                                    break;
                                case "2":
                                    break;
                            }
                            break;
                        case "4":
                            int dice = random.Next(0, 10);
                            if (dice >= 6)
                            {
                                Console.WriteLine("{0}: {1}새끼 니 얼굴 기억했다.\n{2}은(는) {3}의 눈에 흙을 뿌리며 전력으로 도망쳤다.", player.Name, monster.Name, player.Name, monster.Name);
                                Console.WriteLine("도망 성공!");
                                battleWin = true;
                            }
                            else
                            {
                                Console.WriteLine("도망 실패!");
                                Console.WriteLine("{0}: 등짝.. 등짝을 보자!!\n{1}: 아..아...안....안돼!!!!!", monster.Name, player.Name);
                                Console.WriteLine("{0}의 눈가가 촉촉해진다..", player.Name);
                            }
                            break;
                        default:
                            index--;
                            break;
                    } //switch
                } //for
                Console.WriteLine();
                Console.WriteLine("==================================================================");
                Console.WriteLine();
                if (monsterDefence == true)
                {
                    monster.Defence -= monster.buffDefence;
                    monsterDefence = false;
                }

                if (monster.Hp <= 0)
                {
                    Console.WriteLine("【{0}】을(를) 해치웠다!!\n【EXP】{1}【골드】{2} 획득!", monster.Name, monster.Exp, monster.monsterGold);
                    player.Exp += monster.Exp;
                    player.gold += monster.monsterGold;
                    battleWin = true;
                }
                else
                {
                    Console.WriteLine("==================================================================");
                    Console.WriteLine();
                    Console.WriteLine("【{0}】의 턴", monster.Name);
                    int monsterAction = random.Next(0, 10);
                    if (monsterAction >= 3)
                    {
                        Console.WriteLine("【{0}】▶【{1}】에게【{2}】데미지 공격!", monster.Name, player.Name, monster.Damage);
                        player.Hp -= monster.Damage - (player.Defence / 2);
                    }
                    else
                    {
                        Console.WriteLine("【{0}】은(는) 방어자세를 취했다! 다음턴 【방어력】{1}증가!!", monster.Name, monster.buffDefence);
                        monster.Defence += monster.buffDefence;
                        monsterDefence = true;
                    }
                    Console.WriteLine();
                    Console.WriteLine("==================================================================");

                    if (player.Hp <= 0)
                    {
                        Console.WriteLine("【{0}】에게 패배! 마을로 돌아갑니다.", monster.Name);
                        player.playerDead = true;
                        battleWin = true;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("【{0}】의 남은【HP】{1}/{2} 【MP】{3}/{4}", player.Name, player.Hp, player.MaxHp, player.Mp, player.MaxMp);
                Console.WriteLine();
                Console.WriteLine("【{0}】의 남은【HP】{1}/{2} 【MP】{3}/{4}", monster.Name, monster.Hp, monster.MaxHp, monster.Mp, monster.MaxMp);
                Console.WriteLine("아무키나 눌러 계속 진행");
                Console.ReadLine();
                Console.Clear();

            } //while
            classSkill.GetSkill(player);

        } //Battle(생성자)


    } //Battle
}
