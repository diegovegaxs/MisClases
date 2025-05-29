// Esta clase implementa una Cola con nodos doblemente enlazados (con punteros a siguiente y anterior).
// Se usa en la simulación de servidores para manejar la fila de clientes.

using System;
using ElementType = System.Int64; // Alias para facilitar el cambio de tipo de datos si se desea

namespace SimulaServidor
{

    class Cola
    {
        private Node first; // Puntero al primer nodo (frente de la cola)
        private Node last;  // Puntero al último nodo (final de la cola)

        // Clase interna Node (Nodo de la lista doblemente enlazada)
        private class Node
        {
            public ElementType data; // Dato que contiene (1 = normal, 2 = discapacitado)
            public Node next, prev;  // Punteros al siguiente y anterior nodo

            public Node(ElementType i)
            {
                data = i;
                next = null;
                prev = null;
            }
        };

        // Constructor de la cola
        public Cola()
        {
            first = null;
            last = null;
        }

        // Inserta un cliente discapacitado al principio de la cola
        public void EnqueueDis()
        {
            Node nPtr = new Node(2); // 2 representa cliente discapacitado
            if (first == null)
            {
                // Si la cola está vacía, el nuevo nodo es el primero y último
                first = nPtr;
                last = nPtr;
            }
            else
            {
                // Inserta al inicio y ajusta los punteros
                Node seg = first;
                nPtr.next = seg;
                seg.prev = nPtr;
                first = nPtr;
            }
        }

        // Inserta un cliente normal al final de la cola
        public void Enqueue()
        {
            Node nPtr = new Node(1); // 1 representa cliente normal
            Node predPtr = first;

            if (first == null)
            {
                // Si la cola está vacía, este nodo es el primero y último
                nPtr.next = first;
                nPtr.prev = first;
                first = nPtr;
            }
            else
            {
                // Recorre hasta el final
                while (predPtr.next != null)
                {
                    predPtr = predPtr.next;
                }
                // Inserta al final
                nPtr.prev = predPtr;
                nPtr.next = predPtr.next;
                predPtr.next = nPtr;
            }

            // Actualiza el último nodo
            last = nPtr;
        }

        // Elimina el primer nodo (frente de la cola) y devuelve su valor
        public ElementType Dequeue()
        {
            Node dPtr = first;
            first = first?.next; // Avanza el puntero al siguiente
            return dPtr.data; // Retorna el valor del nodo eliminado
        }

        // Devuelve el valor en el frente de la cola sin eliminarlo
        public ElementType Front()
        {
            return first.data;
        }

        // Devuelve el número total de elementos en la cola
        public int GetSize()
        {
            int mySize = 0;
            Node ptr = first;
            while (ptr != null)
            {
                ptr = ptr.next;
                mySize++;
            }
            return mySize;
        }

        // Devuelve cuántos clientes normales hay en la cola
        public int GetSizeN()
        {
            int mySize = 0;
            Node ptr = first;
            while (ptr != null)
            {
                if (ptr.data == 1)
                { // 1 = normal
                    mySize++;
                }
                ptr = ptr.next;
            }
            return mySize;
        }

        // Devuelve cuántos clientes discapacitados hay en la cola
        public int GetSizeDis()
        {
            int mySize = 0;
            Node ptr = first;
            while (ptr != null)
            {
                if (ptr.data == 2)
                { // 2 = discapacitado
                    mySize++;
                }
                ptr = ptr.next;
            }
            return mySize;
        }
    }
}