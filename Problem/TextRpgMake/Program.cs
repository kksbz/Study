﻿using System;
using static TextRpgMake.Map;

namespace TextRpgMake
{
    internal class Program
    {
        static Player mainPlayer = null;
        static void Main(string[] args)
        {
            mainPlayer = new Player();
            PlayGame playGame = new PlayGame(mainPlayer);
        } //Main
    } //Program
}