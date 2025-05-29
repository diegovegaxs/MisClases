using System;

namespace ColaPersonas
{
    public class Cola
    {
        private Nodo frente;  // Referencia al primer nodo de la cola
        private Nodo final;   // Referencia al último nodo de la cola

        public Cola()
        {
            frente = final = null; // Inicialmente la cola está vacía
        }

        // Agrega una persona (nodo) al final de la cola
        public void Encolar(int edad)
        {
            Nodo nuevo = new Nodo(edad); // Creamos el nuevo nodo con la edad ingresada

            if (frente == null) // Si la cola está vacía
            {
                frente = final = nuevo; // El nuevo nodo será el primero y el último
            }
            else
            {
                final.Siguiente = nuevo; // Conectamos el nuevo nodo al final
                final = nuevo;           // Actualizamos el final de la cola
            }
        }

        // Elimina la persona del frente de la cola
        public void Desencolar()
        {
            if (frente == null)
            {
                Console.WriteLine("La cola está vacía.");
                return;
            }

            Console.WriteLine($"Persona con edad {frente.Edad} eliminada.");
            frente = frente.Siguiente; // El frente ahora apunta al siguiente nodo

            if (frente == null) // Si la cola quedó vacía después de eliminar
                final = null;
        }

        // Muestra todas las edades en la cola
        public void Mostrar()
        {
            if (frente == null)
            {
                Console.WriteLine("La cola está vacía.");
                return;
            }

            Nodo actual = frente;
            Console.Write("Cola: ");
            while (actual != null)
            {
                Console.Write(actual.Edad + " "); // Imprimimos la edad
                actual = actual.Siguiente;       // Avanzamos al siguiente nodo
            }
            Console.WriteLine();
        }

        // Devuelve la edad mayor en la cola
        public int EdadMayor()
        {
            if (frente == null) return -1;

            int mayor = frente.Edad;
            Nodo actual = frente;
            while (actual != null)
            {
                if (actual.Edad > mayor)
                    mayor = actual.Edad;
                actual = actual.Siguiente;
            }
            return mayor;
        }

        // Devuelve la edad menor en la cola
        public int EdadMenor()
        {
            if (frente == null) return -1;

            int menor = frente.Edad;
            Nodo actual = frente;
            while (actual != null)
            {
                if (actual.Edad < menor)
                    menor = actual.Edad;
                actual = actual.Siguiente;
            }
            return menor;
        }

        // Cuenta cuántas personas tienen entre 18 y 35 años
        public int ContarJovenes()
        {
            int contador = 0;
            Nodo actual = frente;
            while (actual != null)
            {
                if (actual.Edad >= 18 && actual.Edad <= 35)
                    contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }

        // Cuenta cuántas personas tienen 60 años o más
        public int ContarAncianos()
        {
            int contador = 0;
            Nodo actual = frente;
            while (actual != null)
            {
                if (actual.Edad >= 60)
                    contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }
    }
}