namespace ArbolBusBin
{
    class ArbolBB
    {
        // La raíz del árbol, punto de entrada principal
        private Nodo Raiz { get; set; }

        // Constructor que aparentemente no hace nada con el parámetro 'a' (puedes eliminarlo si no se usa)
        public ArbolBB(int a) { }

        // Constructor que inicializa la raíz como nula (árbol vacío)
        public ArbolBB()
        {
            Raiz = null;
        }

        // Contador (no se usa en este código, puedes quitarlo si no lo necesitas)
        public int cont = 0;

        // Método público para agregar un valor al árbol
        public void Agrega(int valor)
        {
            if (Raiz == null)
            {
                // Si el árbol está vacío, el nuevo valor se convierte en la raíz
                Raiz = new Nodo(valor);
            }
            else
            {
                // Si no, buscamos su posición adecuada recursivamente
                AgregaNodo(Raiz, valor);
            }
        }

        // Método recursivo privado para insertar un nodo en su lugar correcto
        private void AgregaNodo(Nodo actual, int valor)
        {
            if (actual.Dato == valor)
            {
                // No se permiten duplicados
                return;
            }
            else if (valor < actual.Dato)
            {
                // Si es menor, va a la izquierda
                if (actual.Izq == null)
                {
                    actual.Izq = new Nodo(valor);
                    return;
                }
                else
                {
                    AgregaNodo(actual.Izq, valor);
                }
            }
            else
            {
                // Si es mayor, va a la derecha
                if (actual.Der == null)
                {
                    actual.Der = new Nodo(valor);
                    return;
                }
                else
                {
                    AgregaNodo(actual.Der, valor);
                }
            }
        }

        // 🔁 Recorridos del árbol 🔁

        // Preorden: Nodo - Izquierda - Derecha
        public void ImprimePre()
        {
            ImprimePreNodo(Raiz);
            Console.WriteLine();
        }

        private void ImprimePreNodo(Nodo n)
        {
            if (n != null)
            {
                Console.Write(n.Dato + ", ");
                ImprimePreNodo(n.Izq);
                ImprimePreNodo(n.Der);
            }
        }

        // Inorden: Izquierda - Nodo - Derecha (devuelve los elementos ordenados)
        public void ImprimeIn()
        {
            ImprimeInNodo(Raiz);
            Console.WriteLine();
        }

        private void ImprimeInNodo(Nodo n)
        {
            if (n != null)
            {
                ImprimeInNodo(n.Izq);
                Console.Write(n.Dato + " ");
                ImprimeInNodo(n.Der);
            }
        }

        // Postorden: Izquierda - Derecha - Nodo
        public void ImprimePos()
        {
            ImprimePosNodo(Raiz);
            Console.WriteLine();
        }

        private void ImprimePosNodo(Nodo n)
        {
            if (n != null)
            {
                ImprimePosNodo(n.Izq);
                ImprimePosNodo(n.Der);
                Console.Write(n.Dato + " ");
            }
        }

        // 🔍 Encuentra el mayor valor del árbol (el más a la derecha)
        public void MayorValor()
        {
            int mayor = EncontrarMayor(Raiz);
            Console.Write("Mayor valor del árbol: " + mayor);
        }

        private int EncontrarMayor(Nodo n)
        {
            if (n == null)
                return int.MinValue;

            int valor = n.Dato;
            int maxDer = EncontrarMayor(n.Der);

            return Math.Max(valor, maxDer);
        }

        // 🌿 Cuenta cuántas hojas tiene el árbol (nodos sin hijos)
        public void MostrarCantidadHojas()
        {
            int cantidad = ContarHojas(Raiz);
            Console.Write("Cantidad de nodos hojas: " + cantidad);
        }

        private int ContarHojas(Nodo n)
        {
            if (n == null)
            {
                return 0;
            }

            if (n.Izq == null && n.Der == null)
            {
                return 1; // Es una hoja
            }

            return ContarHojas(n.Izq) + ContarHojas(n.Der); // Suma las hojas de ambos lados
        }
        // Método público para verificar si los nodos están en orden consecutivo
        public bool SonConsecutivos()
        {
            int? anterior = null; // Valor anterior (nullable para manejar el primer nodo)
            return SonConsecutivosInOrden(Raiz, ref anterior);
        }

        // Método recursivo privado que hace el recorrido inorden y compara
        private bool SonConsecutivosInOrden(Nodo actual, ref int? anterior)
        {
            if (actual == null)
                return true;

            // Recorre subárbol izquierdo
            if (!SonConsecutivosInOrden(actual.Izq, ref anterior))
                return false;

            // Compara con el valor anterior
            if (anterior.HasValue && actual.Dato != anterior.Value + 1)
                return false;

            // Actualiza valor anterior
            anterior = actual.Dato;

            // Recorre subárbol derecho
            return SonConsecutivosInOrden(actual.Der, ref anterior);
        }
    }
}