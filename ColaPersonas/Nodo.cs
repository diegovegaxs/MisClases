namespace ColaPersonas
{
    public class Nodo
    {
        public int Edad;
        public Nodo Siguiente;

        public Nodo(int edad)
        {
            Edad = edad;
            Siguiente = null;
        }
    }
}