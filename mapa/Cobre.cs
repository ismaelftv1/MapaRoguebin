﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public class Cobre : Mineral
    {
        public override void Dibuja()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■");
        }
    }
}