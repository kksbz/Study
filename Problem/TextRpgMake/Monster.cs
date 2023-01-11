using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextRpgMake
{
    public class Monster : Character
    {
        public int monsterGold;
        public int buffDefence;
        Random random = new Random();
        public Monster SelectMonster_1()
        {
            int num = random.Next(0, 9 + 1);
            if(num < 3)
            {
                OrcType orc = new OrcType();
                orc.Orc();
                return orc;
            }
            else if( 3 <= num && num < 6)
            {
                GoblinType goblin = new GoblinType();
                goblin.Goblin();
                return goblin;
            }
            else
            {
                SpiderType spider = new SpiderType();
                spider.Spider();
                return spider;
            }
        } //SelectMonster_1

        public Monster SelectMonster_2(Player player)
        {
            int num = random.Next(0, 9 + 1);
            if (num < 3)
            {
                OrcType orc = new OrcType();
                orc.OrcArcher(player);
                return orc;
            }
            else if (3 <= num && num < 6)
            {
                GoblinType goblin = new GoblinType();
                goblin.HobGoblin(player);
                return goblin;
            }
            else
            {
                SpiderType spider = new SpiderType();
                spider.PoisonSpider(player);
                return spider;
            }
        } //SelectMonster_2

        public Monster SelectMonster_3(Player player)
        {
            int num = random.Next(0, 9 + 1);
            if (num < 3)
            {
                OrcType orc = new OrcType();
                orc.OrcMage(player);
                return orc;
            }
            else if (3 <= num && num < 6)
            {
                GoblinType goblin = new GoblinType();
                goblin.GoblinLeader(player);
                return goblin;
            }
            else
            {
                SpiderType spider = new SpiderType();
                spider.Tarantula(player);
                return spider;
            }
        } //SelectMonster_3

        public Monster SelectBoss(Player player)
        {
            Boss boss = new Boss();
            boss.BossMonster(player);
            return boss;
        }
        //몬스터 드랍아이템
        public List<Item> dropItem = new List<Item>();
    } //Monster

    public class OrcType : Monster
    {
        Random random = new Random();
        public void Orc()
        {
            int bonus = 6;
            this.name = "오크";
            this.level = random.Next(1,4+1);
            this.exp = 100 + bonus * this.level;
            this.MaxHp = 200 + bonus * this.level;
            this.MaxMp = 50 + bonus * this.level;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 30 + bonus + this.level;
            this.defence = 20 + bonus + this.level;
            this.buffDefence = 20;
            this.monsterGold = 100 + bonus * this.level;
            dropItem.Add(Expendables.HpPotion());
            dropItem.Add(Expendables.MpPotion());
        } //Orc

        public void OrcArcher(Player player)
        {
            int bonus = 8;
            this.name = "오크 궁수";
            this.level = random.Next(3, 6 + 1);
            this.exp = 250 + bonus * this.level;
            this.MaxHp = 300 + bonus * this.level;
            this.MaxMp = 80 + bonus * this.level;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 30 + bonus + this.level;
            this.defence = 30 + bonus + this.level;
            this.buffDefence = 30;
            this.monsterGold = 150 + bonus * this.level;
            dropItem.Add(Expendables.HpPotion());
            dropItem.Add(Expendables.MpPotion());
            dropItem.Add(Expendables.HighHpPotion());
            dropItem.Add(Expendables.HighMpPotion());
            dropItem.Add(Expendables.ThrowingDagger());
            if (player._class == "기사")
            {
                dropItem.Add(KnightWeapon.SteelSword());
            }
            else if (player._class == "궁수")
            {
                dropItem.Add(ArcherWeapon.LongBow());
            }
            else if (player._class == "마법사")
            {
                dropItem.Add(MageWeapon.JewelStaff());
            }
        } //OrcArcher

        public void OrcMage(Player player)
        {
            int bonus = 10;
            this.name = "오크 법사";
            this.level = random.Next(5, 9 + 1);
            this.exp = 350 + bonus * this.level;
            this.MaxHp = 400 + bonus * this.level;
            this.MaxMp = 300 + bonus * this.level;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 50 + bonus + this.level;
            this.defence = 20 + bonus + this.level;
            this.buffDefence = 40;
            this.monsterGold = 380 + bonus * this.level;
            dropItem.Add(Expendables.HighHpPotion());
            dropItem.Add(Expendables.HighMpPotion());
            dropItem.Add(Expendables.ThrowingDagger());
            dropItem.Add(Expendables.Bomb());
            if (player._class == "기사")
            {
                dropItem.Add(KnightWeapon.MithrilSword());
            }
            else if (player._class == "궁수")
            {
                dropItem.Add(ArcherWeapon.MithrilBow());
            }
            else if (player._class == "마법사")
            {
                dropItem.Add(MageWeapon.WizardStaff());
            }
        } //OrcMage
    } //OrcType

    public class GoblinType : Monster
    {
        Random random = new Random();
        public void Goblin()
        {
            int bonus = 6;
            this.name = "고블린";
            this.level = random.Next(1, 3 + 1);
            this.exp = 70 + bonus * this.level;
            this.MaxHp = 100 + bonus * this.level;
            this.MaxMp = 50 + bonus * this.level;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 20 + bonus + this.level;
            this.defence = 5 + bonus + this.level;
            this.buffDefence = 10;
            this.monsterGold = 70 + bonus * this.level;
            dropItem.Add(Expendables.HpPotion());
            dropItem.Add(Expendables.MpPotion());
        } //Goblin

        public void HobGoblin(Player player)
        {
            int bonus = 8;
            this.name = "홉고블린";
            this.level = random.Next(3, 6 + 1);
            this.exp = 250 + bonus * this.level;
            this.MaxHp = 250 + bonus * this.level;
            this.MaxMp = 70 + bonus * this.level;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 35 + bonus + this.level;
            this.defence = 10 + bonus + this.level;
            this.buffDefence = 20;
            this.monsterGold = 150 + bonus * this.level;
            dropItem.Add(Expendables.HpPotion());
            dropItem.Add(Expendables.MpPotion());
            dropItem.Add(Expendables.HighHpPotion());
            dropItem.Add(Expendables.HighMpPotion());
            dropItem.Add(Expendables.ThrowingDagger());
            if (player._class == "기사")
            {
                dropItem.Add(KnightWeapon.SteelSword());
            }
            else if (player._class == "궁수")
            {
                dropItem.Add(ArcherWeapon.LongBow());
            }
            else if (player._class == "마법사")
            {
                dropItem.Add(MageWeapon.JewelStaff());
            }
        } //HobGoblin

        public void GoblinLeader(Player player)
        {
            int bonus = 10;
            this.name = "고블린 지도자";
            this.level = random.Next(6, 9 + 1);
            this.exp = 370 + bonus * this.level;
            this.MaxHp = 500 + bonus * this.level;
            this.MaxMp = 200 + bonus * this.level;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 55 + bonus + this.level;
            this.defence = 30 + bonus + this.level;
            this.buffDefence = 40;
            this.monsterGold = 400 + bonus * this.level;
            dropItem.Add(Expendables.HighHpPotion());
            dropItem.Add(Expendables.HighMpPotion());
            dropItem.Add(Expendables.ThrowingDagger());
            dropItem.Add(Expendables.Bomb());
            if (player._class == "기사")
            {
                dropItem.Add(KnightWeapon.MithrilSword());
            }
            else if (player._class == "궁수")
            {
                dropItem.Add(ArcherWeapon.MithrilBow());
            }
            else if (player._class == "마법사")
            {
                dropItem.Add(MageWeapon.WizardStaff());
            }
        } //GoblinLeader
    } //GoblinType

    public class SpiderType : Monster
    {
        Random random = new Random();
        public void Spider()
        {
            int bonus = 6;
            this.name = "거미";
            this.level = random.Next(1, 3 + 1);
            this.exp = 90 + bonus * this.level;
            this.MaxHp = 240 + bonus * this.level;
            this.MaxMp = 50 + bonus * this.level;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 32 + bonus + this.level;
            this.defence = 5 + bonus + this.level;
            this.buffDefence = 10;
            this.monsterGold = 90 + bonus * this.level;
            dropItem.Add(Expendables.HpPotion());
            dropItem.Add(Expendables.MpPotion());
        } //Spider

        public void PoisonSpider(Player player)
        {
            int bonus = 8;
            this.name = "독거미";
            this.level = random.Next(4, 7 + 1);
            this.exp = 270 + bonus * this.level;
            this.MaxHp = 370 + bonus * this.level;
            this.MaxMp = 100 + bonus * this.level;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 45 + bonus + this.level;
            this.defence = 20 + bonus + this.level;
            this.buffDefence = 10;
            this.monsterGold = 200 + bonus * this.level;
            dropItem.Add(Expendables.HpPotion());
            dropItem.Add(Expendables.MpPotion());
            dropItem.Add(Expendables.HighHpPotion());
            dropItem.Add(Expendables.HighMpPotion());
            dropItem.Add(Expendables.ThrowingDagger());
            if (player._class == "기사")
            {
                dropItem.Add(KnightWeapon.SteelSword());
            }
            else if (player._class == "궁수")
            {
                dropItem.Add(ArcherWeapon.LongBow());
            }
            else if (player._class == "마법사")
            {
                dropItem.Add(MageWeapon.JewelStaff());
            }
        } //PoisonSpider

        public void Tarantula(Player player)
        {
            int bonus = 10;
            this.name = "타란튤라";
            this.level = random.Next(7, 9 + 1);
            this.exp = 400 + bonus * this.level;
            this.MaxHp = 500 + bonus * this.level;
            this.MaxMp = 200 + bonus * this.level;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 55 + bonus + this.level;
            this.defence = 25 + bonus + this.level;
            this.buffDefence = 20;
            this.monsterGold = 400 + bonus * this.level;
            dropItem.Add(Expendables.HighHpPotion());
            dropItem.Add(Expendables.HighMpPotion());
            dropItem.Add(Expendables.Bomb());
            dropItem.Add(Expendables.ThrowingDagger());
            if (player._class == "기사")
            {
                dropItem.Add(KnightWeapon.MithrilSword());
            }
            else if (player._class == "궁수")
            {
                dropItem.Add(ArcherWeapon.MithrilBow());
            }
            else if (player._class == "마법사")
            {
                dropItem.Add(MageWeapon.WizardStaff());
            }
        } //Tarantula
    } //SpiderType

    public class Boss : Monster
    {
        Random random = new Random();
        List<ClassSkill> bossSkill = new List<ClassSkill>();
        public void BossMonster(Player player)
        {
            bossSkill.Add(BossSkill.Skill_1());
            bossSkill.Add(BossSkill.Skill_2());
            bossSkill.Add(BossSkill.Skill_3());
            int bonus = 14;
            this.name = "보스";
            this.level = random.Next(10, 13 + 1);
            this.exp = 1000 + bonus * this.level;
            this.MaxHp = 600 + bonus * this.level;
            this.MaxMp = 300 + bonus * this.level;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 60 + bonus + this.level;
            this.defence = 40 + bonus + this.level;
            this.buffDefence = 30;
            this.monsterGold = 1000 + bonus * this.level;
            dropItem.Add(Expendables.Ring());
            dropItem.Add(Expendables.HighHpPotion());
            dropItem.Add(Expendables.HighMpPotion());
            dropItem.Add(Expendables.Bomb());
            if (player._class == "기사")
            {
                dropItem.Add(KnightWeapon.Excalibur());
            }
            else if (player._class == "궁수")
            {
                dropItem.Add(ArcherWeapon.Windforce());
            }
            else if (player._class == "마법사")
            {
                dropItem.Add(MageWeapon.ArchonStaff());
            }
        } //BossMonster
    } //Boss
}
