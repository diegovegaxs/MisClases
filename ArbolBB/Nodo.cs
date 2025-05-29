namespace ArbolBusBin
{
    class Nodo
    {
        // Propiedad para el hijo izquierdo del nodo
        public Nodo Izq { get; set; }

        // Propiedad para el hijo derecho del nodo
        public Nodo Der { get; set; }

        // Dato almacenado en el nodo (en este caso, un entero)
        public int Dato { get; set; }

        // Constructor que recibe un dato y lo asigna al nodo
        public Nodo(int dato)
        {
            Dato = dato;
        }

        // Constructor vacío por si deseas crear un nodo sin asignar datos aún
        public Nodo()
        {
        }
    }
}