using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lap3
{
    //구조체로 카드구성요소 정함
    public struct PokerCards
    {
        public int cardNums;
        public string cardMark;
        public int cardNum;
    }
    public class PlayGame : TrumpCard
    {
        TrumpCard trumpCard = new TrumpCard();
        //카드 출력 함수
        public void ShowCardSet(List<PokerCards> list)
        {
            //카드 출력 for문
            for (int i = 0; i < list.Count; i++)
            {
                //카드 출력 카드숫자가 11, 12, 13일때 J Q K로 출력
                switch (list[i].cardNum)
                {
                    case 1:
                        Console.Write("{0}A ", list[i].cardMark);
                        break;
                    case 11:
                        Console.Write("{0}J ", list[i].cardMark);
                        break;
                    case 12:
                        Console.Write("{0}Q ", list[i].cardMark);
                        break;
                    case 13:
                        Console.Write("{0}K ", list[i].cardMark);
                        break;
                    default:
                        Console.Write("{0}{1} ", list[i].cardMark, list[i].cardNum);
                        break;
                }
            }
            Console.WriteLine();
        } //ShowCardSet
    } //PlayGame


    public class TrumpCard
    {
        private int[] trumpCardSet; //내가 사용할 카드 세트
        private string[] trumpCardMark; //트럼프 카드의 마크
        public List<string> cardSet = new List<string>();

        //카드 1~52개까지 순차적으로 세팅하는 함수
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
                card.cardMark = cardMark;
                pokerCard.Add(card);
            } //for문 종료
            //트럼프카드 셋업
            return pokerCard;
        } //SetupTrumpCards

        //플레이할 카드 뽑기
        public List<PokerCards> PickCards(List<PokerCards> list)
        {
            List<PokerCards> pickCard = new List<PokerCards>();
            for (int i = 0; i < 5; i++)
            {
                pickCard.Add(list[i]);
                list.Remove(list[i]);
            }
            return pickCard;
        }

        //컴퓨터 추가카드, 플레이어 교체 카드 뽑기
        public List<PokerCards> onePickCard(List<PokerCards> list)
        {
            List<PokerCards> pickCard = new List<PokerCards>();

            pickCard.Add(list[0]);
            list.Remove(list[0]);

            return pickCard;
        }

        //셋팅된 카드 섞는 함수
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

        //셋팅된 카드 여러번 섞는 함수
        public List<PokerCards> ShuffleCards(List<PokerCards> list)
        {
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    list = shuffleOnce(list);
                }
            }
            return list;
        } //ShuffleCards
    }
}
