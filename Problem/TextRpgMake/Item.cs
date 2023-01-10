using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static TextRpgMake.Map;

namespace TextRpgMake
{
    public class Item
    {
        protected string name;
        protected string itemDesc;
        protected string itemType;
        protected int price;
        protected int weaponDamage;
        protected int hpMpPlus;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ItemDesc
        {
            get { return itemDesc; }
            set { itemDesc = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public int WeaponDamage
        {
            get { return weaponDamage; }
            set { weaponDamage = value; }
        }

        public string ItemType
        {
            get { return itemType; }
            set { itemType = value; }
        }

        public int HpMpPlus
        {
            get { return hpMpPlus; }
            set { hpMpPlus = value; }
        }

        public void ShowItemList(List<Item> itemList, Player player)
        {
            Console.Clear();
            Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣\n");
            int countNumber = 1;
            Console.WriteLine("\t【보유 아이템 목록】\t【보유골드】{0}\n", player.gold);
            foreach (var item in itemList)
            {
                if (item.ItemType == "무기")
                {
                    Console.WriteLine($"【{countNumber}】▶\t【아이템】{item.Name}\t【데미지】{item.weaponDamage}\t【가격】{item.Price}골드\n\t【정보】{item.itemDesc}\n");
                }
                else if (item.ItemType == "회복소모품")
                {
                    Console.WriteLine($"【{countNumber}】▶\t【아이템】{item.Name}\t【회복량】{item.HpMpPlus}\t【가격】{item.Price}골드\n\t【정보】{item.itemDesc}\n");
                }
                else if (item.ItemType == "투척소모품")
                {
                    Console.WriteLine($"【{countNumber}】▶\t【아이템】{item.Name}\t【데미지】{item.weaponDamage}\t【가격】{item.Price}골드\n\t【정보】{item.itemDesc}\n");
                }
                countNumber++;
            }
            Console.WriteLine("▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣\n");
        } //ShowItemList

        //아이템사용
        public void UseItem(Player player, Monster monster)
        {
            Console.Clear();
            for (int index = 0; index < 1; index++)
            {
                ShowItemList(player.itemList, player);
                Console.WriteLine("【선택】▶ 사용할 아이템 번호 /【뒤로】▶ 선택 목록을 제외한 아무키");
                int itemInPut = -1;
                int.TryParse(Console.ReadLine(), out itemInPut);
                if (0 < itemInPut && itemInPut <= player.itemList.Count)
                {
                    itemInPut = itemInPut - 1;
                    if (player.itemList[itemInPut].ItemType == "무기")
                    {
                        if (player.findMonster == false)
                        {
                            string putOnItem = "【장착중】";
                            Console.WriteLine("【{0}】▶ 장착 / 장착해제 【y/n】", player.itemList[itemInPut].Name);
                            string putOn = Console.ReadLine();
                            switch (putOn)
                            {
                                case "y":
                                    if (player.itemPutOn == false)
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
                                        player.itemList[itemInPut].Name = player.itemList[itemInPut].Name.Substring(0, putOnItem.Length - 1);
                                        player.putOnItem.Remove(player.itemList[itemInPut]);
                                        player.itemPutOn = false;
                                        Console.ReadLine();
                                    }
                                    break;
                            } //switch
                        }
                        else
                        {
                            Console.WriteLine("【전투 중 에는 사용할 수 없습니다】");
                            Console.ReadLine();
                        }
                        index--;
                    } //무기if
                    else if (player.itemList[itemInPut].Name == "HP포션" || player.itemList[itemInPut].Name == "상급HP포션")
                    {
                        if (player.Hp == player.MaxHp)
                        {
                            Console.WriteLine("【이미 체력이 가득 차 있습니다】");
                            index--;
                        }
                        else if (player.Hp < player.MaxHp)
                        {
                            player.Hp += player.itemList[itemInPut].HpMpPlus;
                            Console.WriteLine("【사용】▶ 【{0}】 HP + {1}", player.itemList[itemInPut].Name, player.itemList[itemInPut].HpMpPlus);
                            if (player.Hp >= player.MaxHp)
                            {
                                player.Hp = player.MaxHp;
                            }
                            player.itemList.Remove(player.itemList[itemInPut]);
                        }
                        Console.ReadLine();
                    }
                    else if (player.itemList[itemInPut].Name == "MP포션" || player.itemList[itemInPut].Name == "상급MP포션")
                    {
                        if (player.Mp == player.MaxMp)
                        {
                            Console.WriteLine("【이미 마나가 가득 차 있습니다】");
                            index--;
                        }
                        else if (player.Mp < player.MaxMp)
                        {
                            player.Mp += player.itemList[itemInPut].HpMpPlus;
                            Console.WriteLine("【사용】▶ 【{0}】 MP + {1}", player.itemList[itemInPut].Name, player.itemList[itemInPut].HpMpPlus);
                            if (player.Mp >= player.MaxMp)
                            {
                                player.Mp = player.MaxMp;
                            }
                            player.itemList.Remove(player.itemList[itemInPut]);
                        }
                        Console.ReadLine();
                    } //포션if
                    else if (player.itemList[itemInPut].ItemType == "투척소모품")
                    {
                        if (player.findMonster == true)
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
                            Console.WriteLine("【전투 중이 아닐 때는 사용할 수 없습니다】");
                            index--;
                            Console.ReadLine();
                        }
                    } //투척if
                } //if 입력조건
            }//for
        }
    } //Item


    public class KnightWeapon : Item
    {
        public KnightWeapon(string type, string name, string itemDesc, int price, int weaponDamage)
        {
            this.itemType = type;
            this.name = name;
            this.itemDesc = itemDesc;
            this.price = price;
            this.weaponDamage = weaponDamage;
        } //KnightWeapon(생성자)

        public static KnightWeapon BasicSword()
        {
            KnightWeapon sword = new KnightWeapon("무기", "기본 검", "밸런스가 잘 잡힌 기본적인 형태의 검", 500, 5);
            return sword;
        } //BasicSword

        public static KnightWeapon SteelSword()
        {
            KnightWeapon sword = new KnightWeapon("무기", "강철 검", "강철을 사용하여 만들어진 검 묵직한 맛이 일품이다.", 1000, 10);
            return sword;
        } //SteelSword

        public static KnightWeapon MithrilSword()
        {
            KnightWeapon sword = new KnightWeapon("무기", "미스릴 검", "강철보다 가볍고 마력전도율이 뛰어난 미스릴로 만들어진 검\n\t\t생각보다 가벼우니 사용에 주의!", 2000, 20);
            return sword;
        } //MithrilSword

        public static KnightWeapon Excalibur()
        {
            KnightWeapon sword = new KnightWeapon("무기", "엑스칼리버", "과거 전설의 용사가 마왕을 벨 때 사용했다고 알려진 검\n\t\t신비한 기운이 검신을 감돌고 있다.", 5000, 40);
            return sword;
        } //Excalibur
    } //KnightWeapon

    public class ArcherWeapon : Item
    {
        public ArcherWeapon(string type, string name, string itemDesc, int price, int weaponDamage)
        {
            this.itemType = type;
            this.name = name;
            this.itemDesc = itemDesc;
            this.price = price;
            this.weaponDamage = weaponDamage;
        } //ArcherWeapon(생성자)

        public static ArcherWeapon BasicBow()
        {
            ArcherWeapon bow = new ArcherWeapon("무기", "기본 활", "밸런스가 잘 잡힌 기본적인 형태의 활", 500, 5);
            return bow;
        } //BasicBow

        public static ArcherWeapon LongBow()
        {
            ArcherWeapon bow = new ArcherWeapon("무기", "롱보우", "활대를 길게 만든 형태의 활 일반활보다 사거리가 길다.", 1000, 10);
            return bow;
        } //LongBow

        public static ArcherWeapon MithrilBow()
        {
            ArcherWeapon bow = new ArcherWeapon("무기", "미스릴 보우", "강철보다 가볍고 마력전도율이 뛰어난 미스릴로 만들어진 활\n\t\t화살이 없으면 이걸로 내려쳐라!", 2000, 20);
            return bow;
        } //MithrilBow

        public static ArcherWeapon Windforce()
        {
            ArcherWeapon bow = new ArcherWeapon("무기", "윈드포스", "바람의 힘이 담긴 전설속의 활\n\t\t대충 쏴도 원하는 곳에 화살을 때려박을 수 있다.", 5000, 40);
            return bow;
        } //Windforce
    } //ArcherWeapon

    public class MageWeapon : Item
    {
        public MageWeapon(string type, string name, string itemDesc, int price, int weaponDamage)
        {
            this.itemType = type;
            this.name = name;
            this.itemDesc = itemDesc;
            this.price = price;
            this.weaponDamage = weaponDamage;
        } //MageWeapon(생성자)

        public static MageWeapon BasicStaff()
        {
            MageWeapon staff = new MageWeapon("무기", "기본 스태프", "밸런스가 잘 잡힌 기본적인 형태의 스태프", 500, 5);
            return staff;
        } //BasicStaff

        public static MageWeapon JewelStaff()
        {
            MageWeapon staff = new MageWeapon("무기", "보석 스태프", "보석이 박힌 스태프\n\t\t박힌 보석이 마나운용을 수월하게 해 준다", 1000, 10);
            return staff;
        } //JewelStaff

        public static MageWeapon WizardStaff()
        {
            MageWeapon staff = new MageWeapon("무기", "위자드 스태프", "마법아카데미 교수들이 즐겨 쓴다는 스태프\n\t\t사람들에게 아카데미 교수라고 구라 쳐보자!", 2000, 20);
            return staff;
        } //WizardStaff

        public static MageWeapon ArchonStaff()
        {
            MageWeapon staff = new MageWeapon("무기", "아콘 스태프", "과거 대마법사가 사용했다고 알려진 전설속의 스태프\n\t\t무엇을 상상하든 그이상이 실현된다", 5000, 40);
            return staff;
        } //ArchonStaff
    } //MageWeapon

    public class Expendables : Item
    {

        public Expendables(string type, string name, string itemDesc, int price, int damage, int heal)
        {
            this.itemType = type;
            this.name = name;
            this.itemDesc = itemDesc;
            this.price = price;
            this.weaponDamage = damage;
            this.hpMpPlus = heal;
        }

        public static Expendables HpPotion()
        {
            Expendables potion = new Expendables("회복소모품", "HP포션", "사용시 HP를 100 회복한다.", 300, 0, 100);
            return potion;
        } //HpPotion

        public static Expendables MpPotion()
        {
            Expendables potion = new Expendables("회복소모품", "MP포션", "사용시 MP를 100 회복한다.", 300, 0, 100);
            return potion;
        } //MpPotion

        public static Expendables HighHpPotion()
        {
            Expendables potion = new Expendables("회복소모품", "상급HP포션", "사용시 HP를 200 회복한다.", 700, 0, 200);
            return potion;
        } //HighHpPotion

        public static Expendables HighMpPotion()
        {
            Expendables potion = new Expendables("회복소모품", "상급MP포션", "사용시 MP를 200 회복한다.", 700, 0, 200);
            return potion;
        } //HighMpPotion

        public static Expendables ThrowingDagger()
        {
            Expendables throwing = new Expendables("투척소모품", "투척용 단검", "단검을 던져 80 고정데미지를 준다.", 300, 80, 0);
            return throwing;
        } //ThrowingDagger

        public static Expendables Bomb()
        {
            Expendables throwing = new Expendables("투척소모품", "다이너마이트", "다이너마이트를 던져 300 고정데미지를 준다.", 1500, 300, 0);
            return throwing;
        } //Bomb

    } //Expendables


}
