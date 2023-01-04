using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using static Lap1.Controller;
using static Lap1.Map;

namespace Lap1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /**
             * 5x5보드(사이즈 줘도 ok)
             * □<ㅁ한자, '.(닷)'은 빈칸, □는 벽 을 의미
             * □ □ □ □ □
             * □. . .  □
             * □. . .  □
             * □. . .  □
             * □ □ □ □ □
             * 빈 곳중에 아무곳(ex-정중앙)이나 사람(이모티콘 또는 옷)을 초기화해서
             * w, a, s, d 입력 받아서 빈 곳을 자유롭게 이동하는 프로그램 작성. (유저입력받아서 이동)
             * - 사람은 빈 곳을 다닐 수 있음.
             * -사람은 벽을 넘어다닐 수 없음.
             */

            MoveKey moveKey = new MoveKey();
            moveKey.PlayGame();
        } // main
    } // class
}
