﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public abstract class Mineral : Item
    {
        public int vida;

        public Mineral()
        {
            this.vida = 10;
        }
    }
}