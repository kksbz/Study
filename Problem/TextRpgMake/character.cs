using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        public List<Item> putOnItem = new List<Item>();
        public bool itemPutOn = false;
        public int gold = 0;
        public bool playerDead = false;
        public bool findMonster = false;
        public bool findBoss = false;

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

        public void ShowInfo(Player player)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣\n");
            Console.WriteLine("\t\t\t【{0}】의 정보\n",player.Name);
            Console.WriteLine("\t【직업】  ▶ {0}\t【레벨】  ▶ {1}\n\n\t【HP】    ▶ {2}/{3}\t【MP】    ▶ {4}/{5}\n", player._class,
                player.Level, player.Hp, player.MaxHp, player.Mp, player.MaxMp);
            if(player.itemPutOn == false)
            {
                Console.WriteLine("\t【공격력】▶ {0}\t\t【방어력】▶ {1}\n", player.Damage, player.Defence);
                Console.WriteLine("\t【무기】  ▶ 없음\n");
            }
            else
            {
                Console.WriteLine("\t【공격력】▶ {0} + {1}\t【방어력】▶ {1}\n", player.Damage - player.putOnItem[0].WeaponDamage,
                    player.putOnItem[0].WeaponDamage, player.Defence);
                Console.WriteLine("\t【무기】  ▶ {0}【무기공격력】▶ {1}\n", player.putOnItem[0].Name, player.putOnItem[0].WeaponDamage);
            }
            Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣");
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
            this.gold = 100;
            this.playerDead = false;
            this.itemPutOn = false;
            knightDamage = 3;
            knightDefence = 3;
            knightMaxHp = 13;
            knightMaxMp = 5;
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
            this.damage = 45;
            this.defence = 30;
            this.gold = 100;
            this.playerDead = false;
            this.itemPutOn = false;
            archerDamage = 5;
            archerDefence = 2;
            archerMaxHp = 10;
            archerMaxMp = 8;
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
            this.damage = 50;
            this.defence = 25;
            this.gold = 100;
            this.playerDead = false;
            this.itemPutOn = false;
            mageDamage = 7;
            mageDefence = 1;
            mageMaxHp = 7;
            mageMaxMp = 15;
        } //Mage


    } //Player

    public class Npc
    {
        public List<Item> shopItemList = new List<Item>();
        public List<Item> sellKnight = new List<Item>();
        public List<Item> sellArcher = new List<Item>();
        public List<Item> sellMage = new List<Item>();

        public void SellItem(List<Item> shopItemList, Player player)
        {
            if (player._class == "기사")
            {
                shopItemList.Add(KnightWeapon.SteelSword());
                shopItemList.Add(KnightWeapon.MithrilSword());
                shopItemList.Add(KnightWeapon.Excalibur());
            }
            else if (player._class == "궁수")
            {
                shopItemList.Add(ArcherWeapon.LongBow());
                shopItemList.Add(ArcherWeapon.MithrilBow());
                shopItemList.Add(ArcherWeapon.Windforce());
            }
            else if (player._class == "마법사")
            {
                shopItemList.Add(MageWeapon.JewelStaff());
                shopItemList.Add(MageWeapon.WizardStaff());
                shopItemList.Add(MageWeapon.ArchonStaff());
            }
        } //SellItem
        public void ShopNpc(Player player)
        {
            shopItemList.Add(Expendables.HpPotion());
            shopItemList.Add(Expendables.MpPotion());
            shopItemList.Add(Expendables.HighHpPotion());
            shopItemList.Add(Expendables.HighMpPotion());
            //직업별로 판매목록 구분
            SellItem(shopItemList, player);
            
            int num = 1;
            Console.WriteLine("\t【판매 목록】\n");
            foreach (Item item in shopItemList)
            {
                if (item.ItemType == "무기")
                {
                    Console.WriteLine($"【{num}】▶\t【아이템】{item.Name}\t【데미지】{item.WeaponDamage}\t【가격】{item.Price}골드\n\t【정보】{item.ItemDesc}\n");
                }
                else if (item.ItemType == "회복소모품")
                {
                    Console.WriteLine($"【{num}】▶\t【아이템】{item.Name}\t【회복량】{item.HpMpPlus}\t【가격】{item.Price}골드\n\t【정보】{item.ItemDesc}\n");
                }
                else if (item.ItemType == "투척소모품")
                {
                    Console.WriteLine($"【{num}】▶\t【아이템】{item.Name}\t【데미지】{item.WeaponDamage}\t【가격】{item.Price}골드\n\t【정보】{item.ItemDesc}\n");
                }
                num++;
            }
            Console.WriteLine();
        } //ShopNpc
    } //NPC

} //namespace
