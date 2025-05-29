using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilales
{
    class Nodo
    {
        public double Dato { get; set; }
        public Nodo Sig { get; set; }

        public Nodo(double dato)
        {
            Dato = dato;
        }

        public Nodo()
        {
        }
    }
}
