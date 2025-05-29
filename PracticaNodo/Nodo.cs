using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PracticaNodo
{
    internal class Nodo
    {
        public double Dato { get; set; }
        public Nodo Sig {  get; set; }

        public Nodo() 
        {

        }

        public Nodo(double dato)
        {
            Dato = dato;
        }



    }
}
