using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public abstract class Item
    {
        public int espacio;
        public int peso;

        public virtual void Dibuja()
        {

        }
    }

    
}