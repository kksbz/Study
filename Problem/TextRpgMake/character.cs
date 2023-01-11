using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextRpgMake
{
    //모든 캐릭터의 스탯 뼈대
    public class Character
    {
        protected string name;
        protected int level;
        protected int exp;
        public int requiredExp = 300;
        protected int max_hp;
        protected int max_mp;
        protected int hp;
        protected int mp;
        protected int damage;
        protected int defence;

        ClassSkill classSkill = new ClassSkill();
        public int Level
        {
            get { return level; }
            set
            {
                //직업별 레벨보너스 설정
                if (level < value)
                {
                    int level = this.Level;
                    int hp = this.MaxHp;
                    int mp = this.MaxMp;
                    int damage = this.Damage;
                    int defence = this.Defence;
                    this.Damage = this.Damage + Player.knightDamage + Player.archerDamage + Player.mageDamage;
                    this.Defence = this.Defence + Player.knightDefence + Player.archerDefence + Player.mageDefence;
                    this.MaxHp = this.MaxHp + Player.knightMaxHp + Player.archerMaxHp + Player.mageMaxHp;
                    this.MaxMp = this.MaxMp + Player.knightMaxMp + Player.archerMaxMp + Player.mageMaxMp;
                    this.Hp = this.MaxHp;
                    this.Mp = this.MaxMp;
                    Console.Clear();
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("\t★★★★★★★★★★★★★★★★★★★★★★★★★★\n\n");
                    Console.WriteLine("\t\t\t【레   벨   업】\n");
                    Console.WriteLine("\t\t【레벨】\t(+{0})\t▶\t{1}\n\t\t【MaxHP】\t(+{2})\t▶\t{3}\n\t\t【MaxMP】\t(+{4})\t▶\t{5}" +
                        "\n\t\t【데미지】\t(+{6})\t▶\t{7}\n\t\t【방어력】\t(+{8})\t▶\t{9}\n",
                        this.Level, (this.Level + 1), (this.MaxHp - hp), this.MaxHp, (this.MaxMp - mp), this.MaxMp,
                        (this.Damage - damage), this.Damage, (this.Defence - defence), this.defence);
                    Console.WriteLine("\n\t★★★★★★★★★★★★★★★★★★★★★★★★★★");
                    Console.ReadLine();
                }
                level = value;
            }
        }
        public int Exp
        {
            get { return exp; }
            set
            {
                do
                {
                    if (value >= requiredExp)
                    {
                        Level++;
                        value -= requiredExp;
                        requiredExp += 100;
                    }
                } while (value >= requiredExp);
                exp = value;
            }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int MaxHp
        {
            get { return this.max_hp; }
            set { this.max_hp = value; }
        }
        public int MaxMp
        {
            get { return this.max_mp; }
            set { this.max_mp = value; }
        }
        public int Hp
        {
            get { return this.hp; }
            set
            {
                if (value >= this.MaxHp)
                {
                    value = this.MaxHp;
                }
                this.hp = value;
            }
        }
        public int Mp
        {
            get { return this.mp; }
            set
            {
                if (value >= this.MaxMp)
                {
                    value = this.MaxMp;
                }
                this.mp = value;
            }
        }
        public int Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }
        public int Defence
        {
            get { return this.defence; }
            set { this.defence = value; }
        }

        public void ShowHpMpPlayer(Player player)
        {
            int cut = player.MaxHp / 10;
            int heart = player.Hp / cut;
            int emptyHeart = 10 - heart;
            Console.Write("\t     ");
            for (int index = 0; index < heart; index++)
            {
                Console.Write("♥");
            }
            for (int index = 0; index < emptyHeart; index++)
            {
                Console.Write("♡");
            }
            Console.Write("\t");
            int cutmana = player.MaxMp / 10;
            int mana = player.Mp / cutmana;
            int emptyMana = 10 - mana;
            for (int index = 0; index < mana; index++)
            {
                Console.Write("◆");
            }
            for (int index = 0; index < emptyMana; index++)
            {
                Console.Write("◇");
            }
            Console.WriteLine();
        } //ShowHpMpInfo

        public void ShowHpMpMonster(Monster monster)
        {
            int cut = monster.MaxHp / 10;
            int heart = monster.Hp / cut;
            int emptyHeart = 10 - heart;
            Console.Write("\t     ");
            for (int index = 0; index < heart; index++)
            {
                Console.Write("♥");
            }
            for (int index = 0; index < emptyHeart; index++)
            {
                Console.Write("♡");
            }
            Console.Write("\t");
            int cutmana = monster.MaxMp / 10;
            int mana = monster.Mp / cutmana;
            int emptyMana = 10 - mana;
            for (int index = 0; index < mana; index++)
            {
                Console.Write("◆");
            }
            for (int index = 0; index < emptyMana; index++)
            {
                Console.Write("◇");
            }
            Console.WriteLine();
        }
    } //character

    public class Player : Character
    {
        public string _class;
        public List<ClassSkill> skillList = new List<ClassSkill>();
        public List<Item> itemList = new List<Item>();
        public List<Item> putOnItem = new List<Item>();
        public bool itemPutOn = false;
        public int gold = 0;
        public bool playerDead = false;
        public bool findMonster = false;
        public bool findBoss = false;
        public bool itemUse = false;
        public bool useWeapon = false;
        public bool bossKill = false;

        public static int knightDamage = 0;
        public static int knightDefence = 0;
        public static int knightMaxHp = 0;
        public static int knightMaxMp = 0;

        public static int archerDamage = 0;
        public static int archerDefence = 0;
        public static int archerMaxHp = 0;
        public static int archerMaxMp = 0;

        public static int mageDamage = 0;
        public static int mageDefence = 0;
        public static int mageMaxHp = 0;
        public static int mageMaxMp = 0;
        public void SelectPlayer()
        {
            for (int index = 0; index < 1; index++)
            {
                Console.Clear();
                Console.SetCursorPosition(25, 10);
                Console.WriteLine("【플레이어의 이름을 정하세요】");
                Console.SetCursorPosition(35, 12);
                string nickName = Console.ReadLine();
                int userInPut = 0;
                for (int index2 = 0; index2 < 1; index2++)
                {
                    Console.Clear();
                    ShowSelectClass();
                    int.TryParse(Console.ReadLine(), out userInPut);

                    switch (userInPut)
                    {
                        case 1:
                            Knight(nickName);
                            break;
                        case 2:
                            Archer(nickName);
                            break;
                        case 3:
                            Mage(nickName);
                            break;
                        case 4:
                            index--;
                            break;
                        default:
                            index2--;
                            break;
                    } //switch
                } //for
            } //for
        } //SelectPlayer

        public void ShowSelectClass()
        {
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n┃\t\t\t\t\t\t\t\t\t\t\t┃\n┃\t【1】【기 사】\t\t【2】【궁 수】\t\t【3】【마법사】\t\t\t┃\n┃\t\t\t\t\t\t\t\t\t\t\t┃");
            Console.WriteLine("\t【HP】    ▶ 300/300\t【HP】    ▶ 250/250\t【HP】    ▶ 240/240");
            Console.WriteLine("\t【MP】    ▶ 100/100\t【MP】    ▶ 150/150\t【MP】    ▶ 160/160");
            Console.WriteLine("\t【공격력】▶    40\t【공격력】▶    45\t【공격력】▶    50");
            Console.WriteLine("\t【방어력】▶    40\t【방어력】▶    30\t【방어력】▶    25");
            Console.WriteLine("\t【스킬】  ▶ 더블 어택\t【스킬】  ▶ 더블 샷\t【스킬】  ▶ 파이어볼");
            Console.WriteLine("\t【아이템】▶ 기본 검\t【아이템】▶ 기본 활\t【아이템】▶ 기본 스태프");
            Console.WriteLine("┃\t\t\t\t\t\t\t\t\t\t\t┃\n┃\t\t【클래스를 선택하세요】\t\t【4번】▶ 이름 재설정\t\t\t┃\n┃\t\t\t\t\t\t\t\t\t\t\t┃\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

        }

        public void ShowInfo(Player player)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n┃\t\t\t\t\t\t\t┃\n┃\t\t\t【상 태 창】\t\t\t┃\n┃\t\t\t\t\t\t\t┃");
            Console.WriteLine("\t\t【닉네임】   ▶ 【{0}】\n", player.name);
            Console.WriteLine("\t【직업】  ▶ {0}\t【레벨】  ▶ {1}\n\n\t【HP】    ▶ {2}/{3}\t【MP】    ▶ {4}/{5}\n", player._class,
                player.Level, player.Hp, player.MaxHp, player.Mp, player.MaxMp);
            if (player.itemPutOn == false)
            {
                Console.WriteLine("\t【공격력】▶ {0}\t\t【방어력】▶ {1}\n", player.Damage, player.Defence);
                Console.WriteLine("\t【무기】  ▶ 없음");
            }
            else
            {
                Console.WriteLine("\t【공격력】▶ {0} + {1}\t【방어력】▶ {1}\n", player.Damage - player.putOnItem[0].WeaponDamage,
                    player.putOnItem[0].WeaponDamage, player.Defence);
                Console.WriteLine("\t【무기】  ▶ {0}【장착중】\n\n\t【무기공격력】▶ {1}", player.putOnItem[0].Name, player.putOnItem[0].WeaponDamage);
            }
            Console.WriteLine("┃\t\t\t\t\t\t\t┃\n┃\t\t\t\t\t\t\t┃\n┃\t\t\t\t\t\t\t┃\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.ReadLine();
            Console.Clear();
        }
        public void Knight(string inPut)
        {
            skillList.Add(KnightSkill.Skill_1());
            itemList.Add(KnightWeapon.BasicSword());
            itemList.Add(Expendables.ThrowingDagger());
            itemList.Add(Expendables.HpPotion());
            itemList.Add(Expendables.MpPotion());
            this._class = "기사";
            this.name = inPut;
            this.level = 1;
            this.exp = 0;
            this.MaxHp = 300;
            this.MaxMp = 100;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 40;
            this.defence = 40;
            this.gold = 0;
            this.playerDead = false;
            this.itemPutOn = false;
            this.bossKill = false;
            knightDamage = 5;
            knightDefence = 4;
            knightMaxHp = 20;
            knightMaxMp = 10;
        } //Knight

        public void Archer(string inPut)
        {
            skillList.Add(ArcherSkill.Skill_1());
            itemList.Add(ArcherWeapon.BasicBow());
            itemList.Add(Expendables.ThrowingDagger());
            itemList.Add(Expendables.HpPotion());
            itemList.Add(Expendables.MpPotion());
            this._class = "궁수";
            this.name = inPut;
            this.level = 1;
            this.exp = 0;
            this.MaxHp = 270;
            this.MaxMp = 130;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 45;
            this.defence = 30;
            this.gold = 0;
            this.playerDead = false;
            this.itemPutOn = false;
            this.bossKill = false;
            archerDamage = 6;
            archerDefence = 3;
            archerMaxHp = 15;
            archerMaxMp = 15;
        } //Archer

        public void Mage(string inPut)
        {
            skillList.Add(MageSkill.Skill_1());
            skillList.Add(MageSkill.Skill_2());
            skillList.Add(MageSkill.Skill_3());
            itemList.Add(MageWeapon.BasicStaff());
            itemList.Add(Expendables.ThrowingDagger());
            itemList.Add(Expendables.HpPotion());
            itemList.Add(Expendables.MpPotion());
            this._class = "마법사";
            this.name = inPut;
            this.level = 1;
            this.exp = 0;
            this.MaxHp = 2400;
            this.MaxMp = 1600;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 50;
            this.defence = 25;
            this.gold = 0;
            this.playerDead = false;
            this.itemPutOn = false;
            this.bossKill = false;
            mageDamage = 7;
            mageDefence = 2;
            mageMaxHp = 10;
            mageMaxMp = 20;
        } //Mage

    } //Player
} //namespace
