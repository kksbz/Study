using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpgMake
{
    public class Item
    {
        protected string name;
        protected string itemDesc;
        protected int price;
        protected int weaponDamage;

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
        public void ShowItemList(List<Item> itemList)
        {
            int countNumber = 1;
            Console.WriteLine();
            Console.WriteLine("보유 아이템 목록");
            foreach (var item in itemList)
            {
                Console.WriteLine($"【{countNumber}】▶【아이템】{item.Name}\t【아이템 정보】데미지: {item.WeaponDamage}\t【가격】{item.Price}원");
                countNumber++;
            }
        } //ShowItemList
    } //Item


    public class KnightWeapon : Item
    {
        public KnightWeapon(string name, string itemDesc, int price, int weaponDamage)
        {
            this.name = name;
            this.itemDesc = itemDesc;
            this.price = price;
            this.weaponDamage = weaponDamage;
        } //KnightWeapon(생성자)

        public static KnightWeapon BasicSword()
        {
            KnightWeapon sword = new KnightWeapon("기본 검", "밸런스가 잘 잡힌 기본적인 형태의 검", 500, 5);
            return sword;
        } //BasicSword

        public static KnightWeapon SteelSword()
        {
            KnightWeapon sword = new KnightWeapon("강철 검", "강철을 사용하여 만들어진 검 묵직한 맛이 일품이다.", 1000, 10);
            return sword;
        } //SteelSword

        public static KnightWeapon MithrilSword()
        {
            KnightWeapon sword = new KnightWeapon("미스릴 검", "강철보다 가볍고 마력전도율이 뛰어난 미스릴로 만들어진 검\n생각보다 가벼우니 사용에 주의!", 2000, 20);
            return sword;
        } //MithrilSword

        public static KnightWeapon Excalibur()
        {
            KnightWeapon sword = new KnightWeapon("엑스칼리버", "과거 전설의 용사가 마왕을 벨 때 사용했다고 알려진 검\n신비한 기운이 검신을 감돌고 있다.", 5000, 40);
            return sword;
        } //Excalibur
    } //KnightWeapon

    public class ArcherWeapon : Item
    {
        public ArcherWeapon(string name, string itemDesc, int price, int weaponDamage)
        {
            this.name = name;
            this.itemDesc = itemDesc;
            this.price = price;
            this.weaponDamage = weaponDamage;
        } //ArcherWeapon(생성자)

        public static ArcherWeapon BasicBow()
        {
            ArcherWeapon bow = new ArcherWeapon("기본 활", "밸런스가 잘 잡힌 기본적인 형태의 활", 500, 5);
            return bow;
        } //BasicBow

        public static ArcherWeapon LongBow() 
        {
            ArcherWeapon bow = new ArcherWeapon("롱보우", "활대를 길게 만든 형태의 활 일반활보다 사거리가 길다.", 1000, 10);
            return bow;
        } //LongBow

        public static ArcherWeapon MithrilBow() 
        {
            ArcherWeapon bow = new ArcherWeapon("미스릴 보우", "강철보다 가볍고 마력전도율이 뛰어난 미스릴로 만들어진 활\n화살이 없으면 이걸로 내려쳐라!", 2000, 20);
            return bow;
        } //MithrilBow

        public static ArcherWeapon Windforce()
        {
            ArcherWeapon bow = new ArcherWeapon("윈드포스", "바람의 힘이 담긴 전설속의 활\n대충 쏴도 원하는 곳에 화살을 때려박을 수 있다.", 5000, 40);
            return bow;
        } //Windforce
    } //ArcherWeapon

    public class MageWeapon : Item
    {
        public MageWeapon(string name, string itemDesc, int price, int weaponDamage)
        {
            this.name = name;
            this.itemDesc = itemDesc;
            this.price = price;
            this.weaponDamage = weaponDamage;
        } //MageWeapon(생성자)

        public static MageWeapon BasicStaff()
        {
            MageWeapon staff = new MageWeapon("기본 스태프", "밸런스가 잘 잡힌 기본적인 형태의 스태프", 500, 5);
            return staff;
        } //BasicStaff

        public static MageWeapon JewelStaff() 
        {
            MageWeapon staff = new MageWeapon("보석 스태프", "보석이 박힌 스태프, 보석 덕에 마력전달이 그나마 낫다.", 1000, 10);
            return staff;
        } //JewelStaff

        public static MageWeapon WizardStaff() 
        {
            MageWeapon staff = new MageWeapon("위자드 스태프", "마법아카데미 교수들이 즐겨쓴다는 스태프\n사람들에게 아카데미 교수라고 구라 쳐보자!", 2000, 20);
            return staff;
        } //WizardStaff

        public static MageWeapon ArchonStaff()
        {
            MageWeapon staff = new MageWeapon("아콘 스태프", "과거 대마법사가 사용했다고 알려진 전설속의 스태프\n무엇을 상상하든 그이상이 실현된다", 5000, 40);
            return staff;
        } //ArchonStaff
    } //MageWeapon

    public class Expendables : Item
    {
        public static int hpMpPlus = 0;
        public Expendables(string name, string itemDesc, int price )
        {
            this.name = name;
            this.itemDesc = itemDesc;
            this.price = price;
        }

        public static Expendables HpPotion()
        {
            Expendables potion = new Expendables("HP포션", "사용시 HP를 100 회복한다.", 300);
            hpMpPlus = 100;
            return potion;
        } //HpPotion

        public static Expendables MpPotion() 
        {
            Expendables potion = new Expendables("MP포션", "사용시 MP를 100 회복한다.", 300);
            hpMpPlus = 100;
            return potion;
        } //MpPotion

    } //Expendables


}
