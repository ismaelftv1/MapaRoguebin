using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public abstract class Enemigo
    {
        public int vida;
        public int dano;
        public int x;
        public int y;

        public virtual void dibuja()
        {
        }
    }
}