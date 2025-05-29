using System;
using ElementType = System.Int64; // Definición de tipo de dato para elementos en la cola

namespace SimulaServidor
{

    class Cola
    {
        private Node first;  // Nodo al frente de la cola (el primero en salir)
        private Node last;   // Nodo al final de la cola (el último en entrar)

        // Clase interna Node para representar cada elemento de la cola
        private class Node
        {
            public ElementType data;  // Dato almacenado en el nodo (1 o 2, tipo de cliente)
            public Node next, prev;   // Punteros al siguiente y anterior nodo en la lista

            // Constructor de nodo, recibe el dato
            public Node(ElementType i)
            {
                data = i;
                next = null;
                prev = null;
            }
        };

        // Constructor de la cola, inicialmente vacía
        public Cola()
        {
            first = null;
            last = null;
        }

        // Método que agrega un nodo con valor 2 al frente de la cola (clientes discapacitados)
        public void EnqueueDis()
        {
            Node nPtr = new Node(2); // Nodo nuevo con dato 2
            if (first == null)
            {     // Si la cola está vacía
                first = nPtr;
                last = nPtr;
            }
            else
            {
                Node seg = first;    // Nodo que actualmente está primero
                nPtr.next = seg;    // El nuevo nodo apunta al nodo actual primero
                seg.prev = nPtr;    // Nodo actual primero apunta hacia atrás al nuevo nodo
                first = nPtr;       // Ahora el nuevo nodo es el primero
            }
        }

        // Método que agrega un nodo con valor 1 al final de la cola (clientes normales)
        public void Enqueue()
        {
            Node nPtr = new Node(1); // Nodo nuevo con dato 1
            Node predPtr = first;

            if (first == null)
            {     // Si la cola está vacía
                // El nuevo nodo apunta a null, se vuelve primero y último
                nPtr.next = first;   // first es null aquí
                nPtr.prev = first;   // igual null
                first = nPtr;
                last = nPtr;
            }
            else
            {
                // Buscar el último nodo actual
                while (predPtr.next != null)
                {
                    predPtr = predPtr.next;
                }
                // Insertar el nuevo nodo después del último nodo
                nPtr.prev = predPtr;
                nPtr.next = predPtr.next; // que es null
                predPtr.next = nPtr;
                last = nPtr; // Actualizar último nodo
            }
        }

        // Método para eliminar y retornar el nodo al frente de la cola
        public ElementType Dequeue()
        {
            Node dPtr = first;    // Nodo a eliminar (el primero)
            first = first?.next;  // Avanzar el primero al siguiente nodo

            if (first != null)
            {
                first.prev = null; // El nuevo primero no tiene nodo previo
            }
            else
            {
                last = null;       // Si la cola queda vacía, actualizar last también
            }

            return dPtr.data;     // Retornar el dato del nodo eliminado
        }

        // Retorna el dato del primer nodo sin eliminarlo
        public ElementType Front()
        {
            Node ptr = first;
            return ptr.data;
        }

        // Retorna la cantidad total de nodos en la cola
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

        // Retorna la cantidad de nodos con dato = 1 (clientes normales)
        public int GetSizeN()
        {
            int mySize = 0;
            Node ptr = first;
            while (ptr != null)
            {
                if (ptr.data == 1)
                {
                    mySize++;
                }
                ptr = ptr.next;
            }
            return mySize;
        }

        // Retorna la cantidad de nodos con dato = 2 (clientes discapacitados)
        public int GetSizeDis()
        {
            int mySize = 0;
            Node ptr = first;
            while (ptr != null)
            {
                if (ptr.data == 2)
                {
                    mySize++;
                }
                ptr = ptr.next;
            }
            return mySize;
        }
    }
}
