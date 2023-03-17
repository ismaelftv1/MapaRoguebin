using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public class Pico : Item
    {
        public int durabilidad;
        public int dano;

        public Pico(int durabilidad, int dano)
        {
            this.durabilidad = durabilidad;
            this.dano = dano;
        }
    }
}