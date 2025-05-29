using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaNodo
{
    internal class Pila
    {
        public Nodo Primero { get; set; }

        public override string? ToString()
        {
            string todo = "";

            Nodo actual = this.Primero;

            while (actual != null)
            {
                todo += actual.Dato + ", ";

                actual = actual.Sig;
            }
            return todo;
        }
    }
}
