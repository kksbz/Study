using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lap3
{
    public class TrumpCard
    {
        private int[] trumpCardSet; //내가 사용할 카드 세트
        private string[] trumpCardMark; //트럼프 카드의 마크

        public void SetupTrumpCards()
        {
            /**
             * 트펌프카드
             * 1~10 K, Q, J ->13개(하트,다이아몬드,스페이드,클로버)
             * 13*4->52개의 카드가 있음.
             */
            trumpCardSet = new int[52];
            //for문시작 loop: 카드의 숫자를 셋업하는 루프
            for (int i = 0; i < trumpCardSet.Length; i++)
            {
                trumpCardSet[i] = i + 1;
            } //for문 종료 

            //트럼프카드의 마크를 셋업
            trumpCardMark = new string[4] { "♥", "♠", "◆", "♣" };

        } //SetupTrumpCards

        //카드를 섞는 함수
        public void ShuffleCards()
        {
            ShuffleCards(200);
        } //함수 오버로딩 함
        //카드를 섞는 함수

        //셔플 하고서 카드를 한 장 뽑아서 출력하는 함수
        public void ReRollCard()
        {
            ShuffleCards();
            RollCard();
        }
        //한장의 카드를 뽑아서 보여주는 함수
        public string RollCard()
        {
            int card = trumpCardSet[0];
            string cardMark = trumpCardMark[(card - 1) / 13]; //52를 13으로 나눈 몫이 trumpCardSet의 길이를 초과함 -1한 이유
            //cardNumber를 string형식으로 받는 이유: 11,12,13을 J,Q,K로 변환하기위함
            string cardNumber = Math.Ceiling(card % 13.1).ToString(); //숫자 0번 예외처리 Math.Ceiling(?) ?를 올림함
            //11, 12, 13을 J, Q, K로 변환하기위한 switch문 시작
            switch (cardNumber)
            {
                case "11":
                    cardNumber = "J";
                    break;
                case "12":
                    cardNumber = "Q";
                    break;
                case "13":
                    cardNumber = "K";
                    break;
            } //switch
            //Console.WriteLine("내가 뽑은 카드는 {0}{1} 입니다.", cardMark, cardNumber);
            //Console.WriteLine("-----");
            //Console.WriteLine("|{0}{1}|", cardMark, cardNumber);
            //Console.WriteLine("|   |");
            //Console.WriteLine("|{1}{0}|", cardMark, cardNumber);
            //Console.WriteLine("-----");
            return cardNumber;
        } //RollCard

        public static int turn(string str)
        {
            int i = default;
            switch (str)
            {
                case "J":
                    i = 11;
                    break;
                case "Q":
                    i = 12;
                    break;
                case "K":
                    i = 13;
                    break;
                default:
                    i = Convert.ToInt32(str);
                    break;
            }
            return i;
        }
        public void PrintCardSet()
        {
            foreach (int card in trumpCardSet)
            {
                Console.Write("{0} ", card);
            }
        } //PrintCardSet
        public int[] shuffleOnce(int[] intArray)
        {
            Random random = new Random();
            int sourIndex = random.Next(0, intArray.Length);
            int destIndex = random.Next(0, intArray.Length);

            int temp = intArray[sourIndex];
            intArray[sourIndex] = intArray[destIndex];
            intArray[destIndex] = temp;
            return intArray;
        } //ShuffleOnce

        public void ShuffleCards(int loopCount)
        {
            for (int i = 0; i < loopCount; i++)
            {
                trumpCardSet = shuffleOnce(trumpCardSet);
            }
        } //ShuffleCards
    }
}
