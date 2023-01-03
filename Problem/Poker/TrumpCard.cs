using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lap3
{
    public struct PokerCards
    {
        public int cardNums;
        public string cardMark;
        public int cardNum;
    }
    public class PlayGame : TrumpCard
    {
        TrumpCard trumpCard = new TrumpCard();
        public void ShowCardSet(List<PokerCards> IntArray)
        {
            for (int i = 0; i < IntArray.Count; i++)
            {
                Console.Write("{0}{1} ", IntArray[i].cardMark, IntArray[i].cardNum);
            }
            Console.WriteLine();
        } //ShowCardSet
        public List<int> TurnCard(List<string> InPut)
        {
            List<int> cardSet = new List<int>(InPut.Count);
            for (int i = 0; i < InPut.Count; i++)
            {
                int number = default;
                number = trumpCard.Turn(InPut[i]);
                cardSet.Add(number);
                Console.Write("{0} ", cardSet[i]);
            }
            Console.WriteLine();
            return cardSet;
        } //TurnCard

        public List<int> BubbleSort(List<int> inPut)
        {
            for(int j = 0; j < inPut.Count; j++)
            {
                for(int i = 0; i < inPut.Count - 1; i++)
                {
                    if (inPut[i] > inPut[i + 1])
                    {
                        int temp = inPut[i + 1];
                        inPut[i +1] = inPut[i];
                        inPut[i] = temp;
                    }
                }
            }
            return inPut;
        }
        
    } //PlayGame


    public class TrumpCard
    {
        private int[] trumpCardSet; //내가 사용할 카드 세트
        private string[] trumpCardMark; //트럼프 카드의 마크
        public List<string> cardSet= new List<string>();
        public List<PokerCards> ComPickCards(List<PokerCards> intArray)
        {
            List<PokerCards> pickCard = new List<PokerCards>();
            for (int i = 0; i < 5; i++)
            {
                pickCard.Add(intArray[i]);
            }
            return pickCard;
        }
        public List<PokerCards> ComAddCards(List<PokerCards> intArray)
        {
            List<PokerCards> pickCard = new List<PokerCards>();
            pickCard.Add(intArray[5]);
            pickCard.Add(intArray[46]);
            return pickCard;
        }

        public List<PokerCards> changeCards(List<PokerCards> intArray)
        {
            List<PokerCards> pickCard = new List<PokerCards>();
            Random random = new Random();
            int rN = random.Next(6,46+1);
            pickCard.Add(intArray[rN]);
            return pickCard;
        }

        public List<PokerCards> PlayerPickCards(List<PokerCards> intArray)
        {
            List<PokerCards> pickCard = new List<PokerCards>();
            for (int i = intArray.Count - 1; i > intArray.Count - 6; i--)
            {
                pickCard.Add(intArray[i]);
            }
            return pickCard;
        }
        
        public List<PokerCards> SetupTrumpCards()
        {
            /**
             * 트펌프카드
             * 1~10 K, Q, J ->13개(하트,다이아몬드,스페이드,클로버)
             * 13*4->52개의 카드가 있음.
             */
            List<PokerCards> pokerCard = new List<PokerCards>();
            trumpCardSet = new int[52];
            trumpCardMark = new string[4] { "♥", "♠", "◆", "♣" };
            //for문시작 loop: 카드의 숫자를 셋업하는 루프
            for (int i = 0; i < trumpCardSet.Length; i++)
            {
                PokerCards card = new PokerCards();
                card.cardNums = i + 1;
                string cardMark = string.Empty;
                double cardNumber = default;
                cardMark = trumpCardMark[(card.cardNums - 1) / 13];
                cardNumber = Math.Ceiling(card.cardNums % 13.1);
                card.cardNum = (int)cardNumber;
                card.cardMark =  cardMark;
                pokerCard.Add(card);
                //Console.WriteLine("{0}, {1}-{2}",pokerCard[i].cardNums, pokerCard[i].cardMark, pokerCard[i].cardNum);
            } //for문 종료
            //트럼프카드의 마크를 셋업
            return pokerCard;
        } //SetupTrumpCards
       
        public List<PokerCards> RollCard(List<PokerCards> intArray)
        {
            for(int i = 0; i < intArray.Count; i++)
            {
                int num = 0;
                num = intArray[i].cardNum;
                string cNum = string.Empty;
                cNum = Convert.ToString(intArray[i].cardNum);
                switch (num)
                {
                    case 11:
                        cNum = "J";
                        break;
                    case 12:
                        cNum = "Q";
                        break;
                    case 13:
                        cNum = "K";
                        break;
                    default:
                        cNum = Convert.ToString(num);
                        break;
                } //switch
                Console.Write("{0} ", intArray[i].cardNum);
            }
            return intArray;
        } //RollCard

        public int Turn(string str)
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
        
        public List<PokerCards> shuffleOnce(List<PokerCards> intArray)
        {
            Random random = new Random();
            int firstN = random.Next(0, intArray.Count);
            int nextN = random.Next(0, intArray.Count);
            List<PokerCards> temp = new List<PokerCards>();
            PokerCards tempCard = new PokerCards();
            temp.Add(tempCard);
            temp[0] = intArray[firstN];
            intArray[firstN] = intArray[nextN];
            intArray[nextN] = temp[0];
            return intArray;
        } //ShuffleOnce

        public List<PokerCards> ShuffleCards(List<PokerCards> intArray)
        {
            for(int i = 0; i< 50; i++)
            {
                for (int j = 0; j < intArray.Count; j++)
                {
                    intArray = shuffleOnce(intArray);
                }
            }
            return intArray;
        } //ShuffleCards
    }
}
