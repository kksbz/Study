using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpgMake
{
    public class Monster : Character
    {
        public int monsterGold;
        public int buffDefence;
        public Monster SelectMonster()
        {
            OrcType orc = new OrcType();
            orc.OrcArcher();
            return orc;
        } //SelectMonster
    } //Monster

    public class OrcType : Monster
    {
        Random random = new Random();
        public void Orc()
        {

            this.name = "오크";
            this.level = random.Next(1,4+1);
            this.exp = 50;
            this.MaxHp = 200;
            this.MaxMp = 50;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 30;
            this.defence = 20;
            this.buffDefence = 20;
            this.monsterGold = 100;
        } //Orc

        public void OrcArcher()
        {
            this.name = "오크 궁수";
            this.level = random.Next(3, 6 + 1);
            this.exp = 300;
            this.MaxHp = 300;
            this.MaxMp = 80;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 30;
            this.defence = 30;
            this.buffDefence = 30;
            this.monsterGold = 150;
        } //Orc

        public void OrcMage()
        {
            this.name = "오크 법사";
            this.level = random.Next(5, 9 + 1);
            this.exp = 0;
            this.MaxHp = 400;
            this.MaxMp = 300;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 60;
            this.defence = 20;
            this.buffDefence = 40;
            this.monsterGold = 200;
        } //Orc
    } //OrcType

    public class GoblinType : Monster
    {
        Random random = new Random();
        public void Goblin()
        {
            this.name = "고블린";
            this.level = random.Next(1, 3 + 1);
            this.exp = 40;
            this.MaxHp = 100;
            this.MaxMp = 0;
            this.hp = this.MaxHp;
            this.mp = this.MaxMp;
            this.damage = 20;
            this.defence = 0;
            this.buffDefence = 10;
            this.monsterGold = 70;
        } //Orc
    } //GoblinType
}
