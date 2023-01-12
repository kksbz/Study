using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TextRpgMake
{
    public class Quest
    {
        public string questType;
        public string questName;
        public string questDesc;
        public string questTarget;
        public bool questClear;
        List<Quest> questClearList = new List<Quest>();
        public void ShowQuest(Player player)
        {
            for (int index = 0; index < 1; index++)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 2);
                int num = 1;
                Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n┃\t\t\t\t\t\t\t┃\n┃\t\t\t【퀘 스 트】\t\t\t┃\n┃\t\t\t\t\t\t\t┃\n");
                foreach (var q in player.questList)
                {
                    if (q.questClear == false)
                    {
                        Console.WriteLine("\t【{0}】▶ {1}\t{2}\n\t\t【목표】▶ {3}\n", num, q.questType, q.questName, q.questTarget);
                    }
                    num++;
                }
                Console.WriteLine("┃\t\t\t\t\t\t\t┃\n┃\t【정보보기】▶ 퀘스트 번호 【완료목록】▶ 9\t┃\n┃\t\t\t\t\t\t\t┃\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                
                int inPut = -1;
                int.TryParse(Console.ReadLine(), out inPut);
                if (0 < inPut && inPut <= player.questList.Count)
                {
                    inPut = inPut - 1;
                    Console.Clear();
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("\t\t\t\t【{0}】\n\n{1}", player.questList[inPut].questName, player.questList[inPut].questDesc);
                    Console.ReadLine();
                    index--;
                }
                else if (inPut == 9)
                {
                    for (int index2 = 0; index2 < 1; index2++)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 2);
                        Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n┃\t\t\t\t\t\t\t┃\n┃\t\t    【완 료 된 퀘 스 트】   \t\t┃\n┃\t\t\t\t\t\t\t┃\n");
                        foreach (var q in player.questClearList)
                        {
                            if (q.questClear == true)
                            {
                                Console.WriteLine("\t【{0}】▶ {1}\t{2}\n\t\t【목표】▶ {3}\n\t\t【퀘스트 클리어】\n", num, q.questType, q.questName, q.questTarget);
                            }
                            num++;
                        }
                        Console.WriteLine("┃\t\t\t\t\t\t\t┃\n┃\t\t【정보보기】▶ 퀘스트 번호\t\t┃\n┃\t\t\t\t\t\t\t┃\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                        int inPut2 = -1;
                        int.TryParse(Console.ReadLine(), out inPut);
                        if (0 < inPut2 && inPut2 <= player.questClearList.Count)
                        {
                            inPut2 = inPut2 - 1;
                            Console.Clear();
                            Console.SetCursorPosition(0, 5);
                            Console.WriteLine("\t\t\t\t【{0}】\n\n{1}", player.questClearList[inPut2].questName, player.questClearList[inPut2].questDesc);
                            Console.ReadLine();
                            index2--;
                        }

                    }
                }
            }
            Console.Clear();
        } //ShowQuest

    } //Quest

    public class MainQuest : Quest
    {
        public MainQuest(string type, string name, string desc, string target)
        {
            this.questType = type;
            this.questName = name;
            this.questDesc = desc;
            this.questTarget = target;
        } //MainQuest(생성자)

        public static MainQuest MainQ_1()
        {
            MainQuest mq = new MainQuest("【메인 퀘스트】", "어두운 마을",
                "\t평화롭던 마을 하지만 수개월 전부터\n\n\t마을 주변 곳곳에서 몬스터로 인한 피해가 속출하고 있자\n\n" +
                "\t마을사람들은 정찰대를 꾸려 정찰을 보내게된다\n\n\t수일 후 정찰대가 가져온 소식에 모두가 놀라게되는데\n\n" +
                "\t마을근처 바위산 너머에서 무언가를 소환하는 제단의 흔적이 발견된 것이다\n\n\t마을사람들을 대표해 촌장은 당신에게 도움을 구하고있다",
                "마왕 소환 저지");
            return mq;
        }
    } //MainQuest
}
