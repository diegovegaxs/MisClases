using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilales
{
    class PilaLES
    {
        Nodo Primero { get; set; }

        public void Push(double valor)
        {
            Nodo nuevo = new Nodo(valor);
            if (this.Primero == null)//caso 1
            {
                this.Primero = nuevo;
            }
            else //caso 2
            {
                Nodo tmp = this.Primero;
                while (tmp.Sig != null)
                {
                    tmp = tmp.Sig;
                }
                tmp.Sig = nuevo;
            }
        }
        public double Pop()
        {
            double valor = Double.MinValue;
            if (this.Primero == null)
            { // Caso 1: La lista está vacía
                return valor;
            }

            if (this.Primero.Sig == null)
            { // Caso 2: Solo hay un vagón
                valor = this.Primero.Dato;
                this.Primero = null;
                return valor;
            }

            Nodo tmp = this.Primero;
            while (tmp.Sig.Sig != null)
            { // Recorremos hasta el penúltimo vagón
                tmp = tmp.Sig;
            }
            valor = tmp.Sig.Dato;
            tmp.Sig = null; // Eliminamos el último vagón
            return valor;
        }

        public double Top()
        {
            double valor = Double.MinValue;
            if (this.Primero == null)
            { // Caso 1: La lista está vacía
                return valor;
            }

            if (this.Primero.Sig == null)
            { // Caso 2: Solo hay un vagón
                valor = this.Primero.Dato;
                return valor;
            }

            Nodo tmp = this.Primero;
            while (tmp.Sig.Sig != null)
            { // Recorremos hasta el penúltimo vagón
                tmp = tmp.Sig;
            }
            valor = tmp.Sig.Dato;
            return valor;
        }

        public bool IsEmpty()
        {
            return this.Primero == null;
        }

        public int Size()
        {
            if (this.Primero == null)
            {
                return 0;
            }
            else
            {
                int cant = 0;
                Nodo tmp = this.Primero;
                while (tmp != null)
                {
                    cant++;
                    tmp = tmp.Sig;
                }
                return cant;
            }
        }

        public double GetValor(int pos)
        {
            int indice = 0;
            Nodo tmp = this.Primero;
            while (tmp != null)
            {
                if (indice == pos)
                {
                    return tmp.Dato;
                }
                indice++;
                tmp = tmp.Sig;
            }
            return Double.MinValue;
        }

        public void SetValor(int pos, double valor)
        {
            int indice = 0;
            Nodo tmp = this.Primero;
            while (tmp != null)
            {
                if (indice == pos)
                {
                    tmp.Dato = valor;
                }
                indice++;
                tmp = tmp.Sig;
            }
        }

        public override string? ToString()
        {
            string todo = "";
            Nodo tmp = this.Primero;
            while (tmp != null)
            {
                todo += tmp.Dato + ", ";
                tmp = tmp.Sig;
            }
            return todo;
        }
    }
}