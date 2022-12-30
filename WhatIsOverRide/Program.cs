using System;
namespace WhatIsOverRide
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Parent parent = new Parent();
            //parent.Say();
            //parent.Run();
            //parent.Walk();

            //Child child= new Child();
            //child.Say();
            //child.Run();
            //child.Walk();

            ////override 예제
            //Button button= new Button();
            //int userInPut = 0;
            //int.TryParse(Console.ReadLine(), out userInPut);
            //button.OnClickButton();
            //StoreButton storeButton = new StoreButton();
            //storeButton.OnClickButton();
            //QuestButton questButton = new QuestButton();
            //questButton.OnClickButton();
            ////override 예제끝

            Wolfs wolfs = new Wolfs();
            wolfs.Wolf();
            Console.WriteLine("{0}", wolfs.Name);

        }
    }
}