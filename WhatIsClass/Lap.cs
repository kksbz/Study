using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsClass
{
    public class Lap
    {
        public static void Main()
        {
            /**카드 뽑기 게임
             *카드 뽑기 게임을 작성해서 제출
             *- 컴퓨터가 2장을 뽑아서 보여줌.
             *- 플레이어가 베팅을 함. (패스하려면 0포인트 베팅)
             *-플레이어가 뽑은 카드가 컴퓨터가 뽑은 2장의 카드 사이에 있는 카드라면 플레이어가 2배 벌어감
             *-플레이어가 뽑은 카드가 컴퓨터가 뽑은 2장의 카드 사이에 없다면 플레이어는 베팅금액을 잃음
             *- 플레이어는 10,000 포인트 들고 게임을 시작함.
             *-카드의 대,소 비교는 오직 숫자로만. (컴퓨터가 중복숫자를 뽑으면 0포인트 베팅하고 패스하자)
             *-게임 종료는 100,.000 포인트를 벌거나, 모두 잃을 때
             *-썻던 카드는 버리지말고 걍 52개카드 모두에서 다시 뽑음
             */
            Console.WriteLine("qrq");
            TrumpCard trumpCard = new TrumpCard();
            trumpCard.ReRollCard();

        }
    }
}
