// CALCULADORA
using Pilales;

double n1 = 0, n2 = 0;
PilaLES pila = new PilaLES();
string resp = "";
do
{
    Console.WriteLine("Ingrese número, +, -, /, *, o salir:");
    resp = Console.ReadLine();
    if (resp == @"+")
    {
        n2 = pila.Pop();
        n1 = pila.Pop();
        pila.Push(n1 + n2);
        Console.WriteLine($"Resultado: {pila.Top()}");
    }
    else if (resp == @"-")
    {
        n2 = pila.Pop();
        n1 = pila.Pop();
        pila.Push(n1 - n2);
        Console.WriteLine($"Resultado: {pila.Top()}");
    }
    else if (resp == @"/")
    {
        n2 = pila.Pop();
        n1 = pila.Pop();
        pila.Push(n1 / n2);
        Console.WriteLine($"Resultado: {pila.Top()}");
    }
    else if (resp == @"*")
    {
        n2 = pila.Pop();
        n1 = pila.Pop();
        pila.Push(n1 * n2);
        Console.WriteLine($"Resultado: {pila.Top()}");

    }
    else
    {
        double valor = Convert.ToDouble(resp);
        pila.Push(valor);
    }
} while (resp != "salir");
