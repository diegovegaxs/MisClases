using PracticaNodo;

Nodo n1 = new Nodo();
n1.Dato = 14;

Console.WriteLine("Ejercicio 1");
Console.WriteLine("n1.Dato: " + n1.Dato);
Console.WriteLine("n1: " + n1);

Console.WriteLine();

Nodo n2 = new Nodo(15);

Console.WriteLine("Ejercicio 2");
Console.WriteLine("n2.Dato: " + n2.Dato);
Console.WriteLine("n2: " + n2);

n1.Sig = n2;

Console.WriteLine("Ejercicio 3:");
Console.WriteLine("n1 apunta a: " + n1.Sig);
Console.WriteLine("Dato del siguiente nodo: " + n1.Sig.Dato);

Console.WriteLine();

Nodo n3 = new Nodo(30.7);
n2.Sig = n3;

Pila pila = new Pila();
pila.Primero = n1;

Console.WriteLine("Contenido de la pila:");
Console.WriteLine(pila);




