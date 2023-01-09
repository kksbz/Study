using System;
using System.Collections.Generic;
using System.Linq;
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
                    Console.WriteLine("★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★\n");
                    Console.WriteLine("\t\t\t【레   벨   업】\n");
                    Console.WriteLine("\t\t【레벨】\t(+{0})\t▶\t{1}\n\t\t【MaxHP】\t(+{2})\t▶\t{3}\n\t\t【MaxMP】\t(+{4})\t▶\t{5}" +
                        "\n\t\t【데미지】\t(+{6})\t▶\t{7}\n\t\t【방어력】\t(+{8})\t▶\t{9}\n",
                        this.Level, (this.Level + 1), (this.MaxHp - hp), this.MaxHp, (this.MaxMp - mp), this.MaxMp,
                        (this.Damage - damage), this.Damage, (this.Defence - defence), this.defence);
                    Console.WriteLine("★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★");
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

    } //character

    public class Player : Character
    {
        public string _class;
        public List<ClassSkill> skillList = new List<ClassSkill>();
        public List<Item> itemList = new List<Item>();

        public int gold = 0;
        public bool playerDead = false;

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
            Console.Write("플레이어의 이름을 정하세요.");
            Console.WriteLine();
            string nickName = Console.ReadLine();
            int userInPut = 0;
            for (int index = 0; index < 1; index++)
            {
                Console.WriteLine("클래스를 선택하세요.\n【1】기사\n【2】궁수\n【3】마법사");
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
                    default:
                        Console.WriteLine("잘못 입력하셨습니다. 다시 입력하세요.");
                        index--;
                        Console.Clear();
                        break;
                } //switch
            } //for
        } //SelectPlayer

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
            this.gold = 100;
            this.playerDead = false;
            knightDamage = 1;
            knightDefence = 2;
            knightMaxHp = 10;
            knightMaxMp = 3;
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
            this.MaxHp = 250;
            this.MaxMp = 130;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 35;
            this.defence = 30;
            this.gold = 100;
            this.playerDead = false;
            archerDamage = 2;
            archerDefence = 1;
            archerMaxHp = 7;
            archerMaxMp = 5;
        } //Archer

        public void Mage(string inPut)
        {
            skillList.Add(MageSkill.Skill_1());
            itemList.Add(MageWeapon.BasicStaff());
            itemList.Add(Expendables.ThrowingDagger());
            itemList.Add(Expendables.HpPotion());
            itemList.Add(Expendables.MpPotion());
            this._class = "마법사";
            this.name = inPut;
            this.level = 1;
            this.exp = 0;
            this.MaxHp = 220;
            this.MaxMp = 200;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 45;
            this.defence = 25;
            this.gold = 100;
            this.playerDead = false;
            mageDamage = 1;
            mageDefence = 2;
            mageMaxHp = 5;
            mageMaxMp = 10;
        } //Mage


    } //Player

    public class Npc
    {
        public List<Item> shopItemList = new List<Item>();
        public void ShopNpc()
        {
            shopItemList.Add(Expendables.HpPotion());
            shopItemList.Add(Expendables.MpPotion());
            int num = 1;
            Console.WriteLine("\t【판매 목록】\n");
            foreach (Item item in shopItemList)
            {
                Console.WriteLine("【{0}】▶【아이템명】{1}【가격】{2}【정보】{3}", num, item.Name, item.Price, item.ItemDesc);
                num++;
            }
            Console.WriteLine();
        } //ShopNpc
    } //NPC

} //namespace
