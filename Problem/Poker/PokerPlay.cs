using Lap3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public enum CardType
    {
        None,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        Flush,
        FullHouse,
        FourOfAKind,
    }
    public class PokerPlay
    {
        public CardType PlayPoker(List<PokerCards> list)
        {
            bool OnePair = false;
            bool TwoPair = false;
            bool ThreeOfAKind = false;
            bool FourOfAKind = false;
            bool Flush = false;
            bool Fullhouse = false;

            //원,쓰리,포 카드조건
            int matchNumber = 0;
            int maxCount = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int count = 0;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i].cardNum == list[j].cardNum)
                    {
                        count++;
                        matchNumber++;
                    }
                    switch (count)
                    {
                        case 1:
                            OnePair = true;
                            break;
                        case 2:
                            ThreeOfAKind = true;
                            break;
                        case 3:
                            FourOfAKind = true;
                            break;
                    }
                } //원,쓰리,포 카드조건
                if (maxCount < count)
                {
                    maxCount = count;
                }
            } //for

            //투페어 카드조건
            if (OnePair == true && matchNumber > maxCount)
            {
                TwoPair = true;
            }//투페어 카드조건

            //풀하우스 카드조건
            if (ThreeOfAKind == true && matchNumber > maxCount)
            {
                Fullhouse = true;
            }//풀하우스 카드조건

            //플러시 카드조건
            int markCount = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i].cardMark == list[j].cardMark)
                    {
                        markCount++;
                    }
                    if (markCount == 4)
                    {
                        Flush = true;
                    }
                }
            } //플러시 확인

            CardType cardType = CardType.None;

            if (FourOfAKind == true)
            {
                cardType = CardType.FourOfAKind;
            }
            else if (Fullhouse == true)
            {
                cardType = CardType.FullHouse;
            }
            else if (Flush == true)
            {
                cardType = CardType.Flush;
            }
            else if (ThreeOfAKind == true)
            {
                cardType = CardType.ThreeOfAKind;
            }
            else if (TwoPair == true)
            {
                cardType = CardType.TwoPair;
            }
            else if (OnePair == true)
            {
                cardType = CardType.OnePair;
            }
            return cardType;
        } //PlayPoker
    }
}
