using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TextRpgMake
{
    //모든 캐릭터의 스탯 뼈대
    public class Character
    {
        protected string name;
        protected string _class;
        protected int level;
        protected int exp;
        protected int[] inventory;
        protected double hp;
        protected int mp;
        protected double damage;
        protected double defence;
        protected string mark;
        protected int playerY;
        protected int playerX;
        protected int monsterY;
        protected int monsterX;

        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public int Exp
        {
            get { return exp; }
            set { exp = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public double Hp
        {
            get { return this.hp; }
            set { this.hp = value; }
        }
        public int Mp
        {
            get { return this.mp; }
            set { this.mp = value; }
        }
        public double Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }
        public double Defence
        {
            get { return this.defence; }
            set { this.defence = value; }
        }
        public string Mark
        {
            get { return this.mark; }
            set { this.mark = value; }
        }
        public int PlayerY
        {
            get { return this.playerY; }
            set { this.playerY = value; }
        }
        public int PlayerX
        {
            get { return this.playerX; }
            set { this.playerX = value; }
        }
        public int MonsterY
        {
            get { return this.monsterY; }
            set { this.monsterY = value; }
        }
        public int MonsterX
        {
            get { return this.monsterX; }
            set { this.monsterX = value; }
        }
        public string _Class
        {
            get { return this._class; }
            set { this._class = value; }
        }

    } //character

    public class Player : Character
    {
        public Player()
        {
            Console.Write("플레이어의 이름을 정하세요.");
            Console.WriteLine();
            string nickName = Console.ReadLine();
            int userInPut = 0;
            for (int index = 0; index < 1; index++)
            {
                Console.WriteLine("클래스를 선택하세요.");
                Console.WriteLine("1 - 기사, 2 - 궁수, 3- 마법사");
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
        } //Player(생성자)

        public void Knight(string inPut)
        {
            this._class = "기사";
            this.name = inPut;
            this.level = 1;
            this.exp = 0;
            this.hp = 300;
            this.mp = 100;
            this.damage = 40;
            this.defence = 40;
            this.mark = "옷";
            this.playerY = 1;
            this.playerX = 1;
        } //Knight

        public void Archer(string inPut)
        {
            this._class = "궁수";
            this.name = inPut;
            this.level = 1;
            this.exp = 0;
            this.hp = 250;
            this.mp = 130;
            this.damage = 35;
            this.defence = 30;
            this.mark = "옷";
            this.playerY = 1;
            this.playerX = 1;
        } //Archer

        public void Mage(string inPut)
        {
            this._class = "마법사";
            this.name = inPut;
            this.level = 1;
            this.exp = 0;
            this.hp = 220;
            this.mp = 200;
            this.damage = 45;
            this.defence = 25;
            this.mark = "옷";
            this.playerY = 1;
            this.playerX = 1;
        } //Mage

    } //Player

    public class Monster : Character
    {
        public Monster SelectMonster()
        {
            OrcType orc = new OrcType();
            orc.OrcArcher();
            return orc;
        } //SelectMonster
    } //Monster

    public class OrcType : Monster
    {
        public void Orc()
        {
            this.name = "오크";
            this.level = 2;
            this.exp = 50;
            this.hp = 200;
            this.mp = 50;
            this.damage = 30;
            this.defence = 20;
            this.mark = "옼";
            this.monsterY = 1;
            this.monsterX = 1;
        } //Orc

        public void OrcArcher()
        {
            this.name = "오크 궁수";
            this.level = 3;
            this.exp = 120;
            this.hp = 300;
            this.mp = 80;
            this.damage = 45;
            this.defence = 30;
            this.mark =  "옼";
            this.monsterY = 1;
            this.monsterX = 1;
        } //Orc

        public void OrcMage()
        {
            this.name = "오크 법사";
            this.level = 5;
            this.exp = 0;
            this.hp = 400;
            this.mp = 300;
            this.damage = 60;
            this.defence = 20;
            this.mark = "옼";
            this.monsterY = 1;
            this.monsterX = 1;
        } //Orc
    } //OrcType

    public class GoblinType : Monster
    {
        public void Goblin()
        {
            this.name = "고블린";
            this.level = 1;
            this.exp = 40;
            this.hp = 100;
            this.mp = 0;
            this.damage = 20;
            this.defence = 0;
            this.mark = "곱";
            this.monsterY = 1;
            this.monsterX = 1;
        } //Orc
    } //GoblinType


} //namespace
