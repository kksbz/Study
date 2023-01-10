using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TextRpgMake
{
    public class ClassSkill
    {
        protected string skillName;
        protected string skillDesc;
        protected int uselevel;
        protected int skillDamage;
        protected int useMp;

        public string SkillName
        {
            get { return skillName; }
            set { skillName = value; }
        }
        public string SkillDesc
        {
            get { return skillDesc; }
            set { skillDesc = value; }
        }
        public int Uselevel
        {
            get { return uselevel; }
            set { uselevel = value; }
        }
        public int SkillDamage
        {
            get { return skillDamage; }
            set
            {
                skillDamage = value;
            }
        }
        public int UseMp
        {
            get { return useMp; }
            set { useMp = value; }
        }
        public void ShowSkillList(List<ClassSkill> skillList, Player player)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 2);
            int countNumber = 1;
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n┃\t\t\t\t\t\t\t\t\t\t     ┃");
            Console.WriteLine("┃\t\t\t\t【보유 스킬 목록】\t\t\t\t     ┃\n┃\t\t\t\t\t\t\t\t\t\t     ┃\n");
            foreach (var skill in skillList)
            {
                Console.WriteLine($"\t【{countNumber}】▶\t【스킬명】{skill.SkillName}\t【스킬데미지】{skill.SkillDamage}\t【소모마나】{skill.UseMp}\t\n\t\t【정보】{skill.skillDesc}\n");
                countNumber++;
            }
            Console.WriteLine("┃\t\t\t\t\t\t\t\t\t\t     ┃");
            if (player.findMonster == true)
            {
                Console.WriteLine("┃\t【스킬사용】▶ 스킬 번호 입력\t【뒤로】▶ 스킬 목록을 제외한 아무키\t     ┃");
            }
            else
            {
                Console.WriteLine("┃\t\t\t\t\t\t\t\t\t\t     ┃");
            }
            Console.WriteLine("┃\t\t\t\t\t\t\t\t\t\t     ┃\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
        } //ShowSkillList

        public void GetSkill(Player player)
        {
            switch (player._class)
            {
                case "기사":
                    if (player.Level == 3 && player.skillList.Count == 1)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 5);
                        player.skillList.Add(KnightSkill.Skill_2());
                        Console.WriteLine("\t【{0}】▶【{1}】을 습득했다!!", player.Name, KnightSkill.Skill_2().SkillName);
                        Console.ReadLine();
                    }
                    else if (player.Level == 5 && player.skillList.Count == 2)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 5);
                        player.skillList.Add(KnightSkill.Skill_3());
                        Console.WriteLine("\t【{0}】▶【{1}】을 습득했다!!", player.Name, KnightSkill.Skill_3().SkillName);
                        Console.ReadLine();
                    }

                    break;
                case "궁수":
                    if (player.Level == 3 && player.skillList.Count == 1)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 5);
                        player.skillList.Add(ArcherSkill.Skill_2());
                        Console.WriteLine("\t【{0}】▶【{1}】을 습득했다!!", player.Name, ArcherSkill.Skill_2().SkillName);
                        Console.ReadLine();
                    }
                    else if (player.Level == 5 && player.skillList.Count == 2)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 5);
                        player.skillList.Add(ArcherSkill.Skill_3());
                        Console.WriteLine("\t【{0}】▶【{1}】을 습득했다!!", player.Name, ArcherSkill.Skill_3().SkillName);
                        Console.ReadLine();
                    }
                    break;
                case "마법사":
                    if (player.Level == 3)
                    {
                        if (player.Level == 3 && player.skillList.Count == 1)
                        {
                            Console.Clear();
                            Console.SetCursorPosition(0, 5);
                            player.skillList.Add(MageSkill.Skill_2());
                            Console.WriteLine("\t【{0}】▶【{1}】을 습득했다!!", player.Name, MageSkill.Skill_2().SkillName);
                            Console.ReadLine();
                        }
                    }
                    else if (player.Level == 5 && player.skillList.Count == 2)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 5);
                        player.skillList.Add(MageSkill.Skill_3());
                        Console.WriteLine("\t【{0}】▶【{1}】을 습득했다!!", player.Name, MageSkill.Skill_3().SkillName);
                        Console.ReadLine();
                    }
                    break;
            }
        } //GetSkill
    } //ClassSkill


    public class KnightSkill : ClassSkill
    {
        public KnightSkill(int level, string skillName, string skillDesc, int skillDamage, int useMp)
        {
            this.uselevel = level;
            this.skillName = skillName;
            this.skillDesc = skillDesc;
            this.skillDamage = skillDamage;
            this.useMp = useMp;
        }

        public static KnightSkill Skill_1()
        {
            KnightSkill skill = new KnightSkill(1, "더블 어택", "빠르게 두번 벤다", 100, 30);
            return skill;
        } //Skill_1

        public static KnightSkill Skill_2()
        {
            KnightSkill skill = new KnightSkill(3, "차징 태클", "양손으로 검을쥐고 빠르게 돌진하여 찌른다", 170, 50);
            return skill;
        } //Skill_2

        public static KnightSkill Skill_3()
        {
            KnightSkill skill = new KnightSkill(5, "리프 어택", "공중으로 도약 후 있는 힘껏 내려찍는다", 230, 70);
            return skill;
        } //Skill_3
    } //KnightSkill

    public class ArcherSkill : ClassSkill
    {
        public ArcherSkill(int level, string skillName, string skillDesc, int skillDamage, int useMp)
        {
            this.uselevel = level;
            this.skillName = skillName;
            this.skillDesc = skillDesc;
            this.skillDamage = skillDamage;
            this.useMp = useMp;
        }

        public static ArcherSkill Skill_1()
        {
            ArcherSkill skill = new ArcherSkill(1, "더블 샷", "빠르게 두번 쏜다", 100, 30);
            return skill;
        } //Skill_1

        public static ArcherSkill Skill_2()
        {
            ArcherSkill skill = new ArcherSkill(3, "차징 샷", "있는 힘껏 활시위를 당겨 쏜다", 170, 50);
            return skill;
        } //Skill_2

        public static ArcherSkill Skill_3()
        {
            ArcherSkill skill = new ArcherSkill(5, "윈드 샷", "바람의 힘을 이용하여 적의 약점에 강력한 화살 한발을 쏜다", 240, 80);
            return skill;
        } //Skill_2
    } //ArcherSkill

    public class MageSkill : ClassSkill
    {
        public MageSkill(int level, string skillName, string skillDesc, int skillDamage, int useMp)
        {
            this.uselevel = level;
            this.skillName = skillName;
            this.skillDesc = skillDesc;
            this.skillDamage = skillDamage;
            this.useMp = useMp;
        }

        public static MageSkill Skill_1()
        {
            MageSkill skill = new MageSkill(1, "파이어볼", "화염을 응축해서 날린다", 150, 30);
            return skill;
        } // Skill_1

        public static MageSkill Skill_2()
        {
            MageSkill skill = new MageSkill(3, "익스플로젼", "거대한 화염을 응축하여 날린다", 200, 50);
            return skill;
        } //Skill_2

        public static MageSkill Skill_3()
        {
            MageSkill skill = new MageSkill(5, "메테오 폴", "거대한 운석을 소환하여 내리꽂는다", 300, 100);
            return skill;
        } //Skill_2
    } //ArcherSkill

    public class BossSkill : ClassSkill
    {
        public BossSkill(string skillName, int skillDamage, int useMp)
        {
            this.skillName = skillName;
            this.skillDamage = skillDamage;
            this.useMp = useMp;
        } //BossSkill(생성자)

        public static BossSkill Skill_1()
        {
            BossSkill skill = new BossSkill("불", 150, 80);
            return skill;
        } //Skill_1
        public static BossSkill Skill_2()
        {
            BossSkill skill = new BossSkill("물", 200, 120);
            return skill;
        } //Skill_2
        public static BossSkill Skill_3()
        {
            BossSkill skill = new BossSkill("땅", 300, 150);
            return skill;
        } //Skill_3
    } //BossSkill
}
