using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsOverRide
{
    public class Description
    {
        public void OverrideDesc()
        {
            /**
             * 메서드 오버라이드
             * 부모 클래스에 만든 메서드를 자식 클래스에서 다시 새롭게 만들어 사용하는 것을 메서드 오버라이드라고 한다.
             * 
             * 메서드 오버라이드: 재정의
             * 클래스 관계를 따지는 상속 개념에서 부모 클래스에 이미 만든 메서드를 동일한 이름으로 자식 클래스에서
             * 다시 정의(재정의)해서 사용한다는 개념이 메서드 오버라이드라고 한다.
             * - 메서드 오버라이드는 메서드를 새롭게 정의하는 것
             * - 오버라이드(Override), 오버라이딩(Overriding)이라는 표현은 동일하다
             * - 부모 클래스에 virtual 키워드로 선언해 놓은 메서드는 자식 클래스에서 override 키워드로
             *   재정의해서 사용 가능하다.
             *   
             * 메서드 오버로드와 오버라이드(상속) *중요*
             * 처음 프로그래밍할 때 쉽게 혼동하는 단어가 바로 오버로드(Overload)와 오버라이드(Override)이다.
             * 오버로드는 여러 번 정의하는 것이고, 오버라이드는 다시 정의하는 것이다.
             * - c#이 virtual, override 키워드를 안써도 자동으로 오버라이드해주지만
             * - 명시적으로 키워드를 붙여야 디버깅할때나 코드를 볼 때 알기 좋다
             * 
             * 가상 메서드
             * 메서드 오버라이드는 다른 표현 방식으로 가상(Virtual) 메서드라고 한다.
             */
        } //OverrideDesc()

        public void PropertyDesc()
        {
            /**
             * 속성은 필드 값을 읽거나 쓰고 계산하는 방법을 제공하는 클래스 속성을 나타내는 멤버이다.
             * 아주 간단하게 클래스 속성을 변경하거나 알아보는 기능을 배워보자.
             * 
             * 속성
             * 클래스의 멤버 중에서 속성(Property)은 단어 그대로 클래스 속성(특징, 성격, 색상, 크기 등)을
             * 나타낸다. 속성은 괄호가 없는 메서드와 비슷하고 개체 필드 중에서 외부에 공개하고자 할 때
             * 사용하는 방법이다. 개체의 성질, 특징, 색상, 크기, 모양 등을 속성으로 외부에 공개할 수 있다.
             * 코드에서는 private 성격이 있는 필드를 public 속성으로 외부에 공개할 때 사용한다.
             * 
             * 클래스 안에 선언된 필드 내용을 설정(Set)하거나 참조(Get)할 때 사용하는 코드 블록을 속성이라고 한다.
             * 자동차 객체로 비유하자면 빨간색 스포츠카, 바퀴 4개 등으로 속성을 표현할 수 있다.
             * 
             * class [클래스 이름]
             * {
             *      public [리턴 타입] [속성 이름] {get; set;} <-기본형
             * }
             * Lab5 Creature 클래스에 Hp와 Name 을 속성적용함
             */
        } //PropertyDesc
    } //Description

    class Monster
    {
        protected string name;
        protected int hp;
        protected int damage;
        protected int defence;
        protected int speed;
    }
    class Wolfs : Monster
    {
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        //위에 Property와 동일하게 실행되는 함수
        //public string GetName() 
        //{
        //    return this.name;
        //}
        //public void SetName(string Value_)
        //{
        //    this.name = Value_;
        //}
        //위에 Property와 동일하게 실행되는 함수끝
        public void Wolf()
        {
            this.name = "늑대";
            this.hp = 100;
            this.damage = 50;
            this.defence = 10;
            this.speed = 24;
        }
    }

    //Override 예제
    public class Parent
    {
        protected int number = 100;
        public virtual void Say()
        {
            Console.WriteLine("[부모] 안녕하세요.");
        }
        //부모클래스의 함수명이랑 자식클래스의 함수명이랑 똑같이 쓰고싶으면 virtual을 붙이고
        //자식클래스에서는 Override 붙여서 써주는게 좋다
        public virtual void Run() //자식클래스에서 Run를 상속받으면 다시 쓸수있다
        {
            Console.WriteLine("[부모] 달리다.");
        }
        
        //오버로딩 예제 -> 상속하지않고 매개변수로 오버로딩함
        public virtual void Walk()
        {
            Console.WriteLine("[부모] 걷다.");
        }
        public virtual void WalK(int count)
        {
            Console.WriteLine("[부모] {0}번 걷다.");
        }
        public virtual void Walk(string where_)
        {
            Console.WriteLine("[부모] {0}에서 걷다.");
        }
        //오버로딩 예제 끝
    } //Parent

    public class Child : Parent
    {
        public override void Say()
        {
            Console.WriteLine("[자식] 안녕하세요.");
        }
        //부모클래스에 Run이란 동일한 함수명이 존재해서 override 붙임
        public override void Run()
        {
            //base.하면 부모의 메서드에 접근할수있다
            base.Run();
            Console.WriteLine("number : {0}",number);
        }
        public override void Walk()
        {
            base.Walk();
        }

        //부모클래스에게 오버라이드 받은 함수들을 오버로딩한 상태
        public override void WalK(int count)
        {
            Console.WriteLine("[자식] {0}번 걷다.");
        }
        public override void Walk(string where_)
        {
            Console.WriteLine("[자식] {0}에서 걷다.");
        }
        //부모클래스에게 오버라이드 받은 함수들을 오버로딩한 상태끝
    } //Child
    //Override 예제끝

    public class Button
    {
        protected int _index = 0;

        public virtual void OnClickButton()
        {
            
            Console.WriteLine("{0}번 버튼을 눌렀음.", this._index);
            
        } //OnClickButton
    } //Button

    public class StoreButton : Button
    {
        public override void OnClickButton()
        {
            //base.OnClickButton();
            Console.WriteLine("이 버튼을 누르면 상점 창이 열림",_index);
        } //OnClickButton
    } //StoreButton

    public class QuestButton : Button
    {
        public override void OnClickButton()
        {
            //base.OnClickButton();
            Console.WriteLine("이 버튼을 누르면 퀘스트 창이 열림",_index);
        } //OnClickButton
    } //QuestButton
}
