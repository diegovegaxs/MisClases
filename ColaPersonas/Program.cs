using ColaPersonas;

Cola cola = new Cola(); // Creamos la cola de personas
int opcion;

// Menú que se repite hasta que el usuario elija salir (opción 5)
do
{
    // Mostramos opciones al usuario
    Console.WriteLine("\n--- MENÚ ---");
    Console.WriteLine("1. Agregar persona (edad)");
    Console.WriteLine("2. Eliminar persona");
    Console.WriteLine("3. Mostrar cola");
    Console.WriteLine("4. Mostrar estadísticas de edades");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción: ");
    opcion = Convert.ToInt32(Console.ReadLine());

    // Ejecutamos una acción según la opción elegida
    switch (opcion)
    {
        case 1:
            Console.Write("Ingrese edad de la persona: ");
            int edad = Convert.ToInt32(Console.ReadLine());
            cola.Encolar(edad); // Agregamos a la cola
            break;

        case 2:
            cola.Desencolar(); // Quitamos a la persona del frente
            break;

        case 3:
            cola.Mostrar(); // Mostramos todas las edades en la cola
            break;

        case 4:
            // Mostramos estadísticas: mayor, menor, jóvenes y ancianos
            Console.WriteLine($"Edad mayor: {cola.EdadMayor()}");
            Console.WriteLine($"Edad menor: {cola.EdadMenor()}");
            Console.WriteLine($"Cantidad de jóvenes (18-35): {cola.ContarJovenes()}");
            Console.WriteLine($"Cantidad de ancianos (60+): {cola.ContarAncianos()}");
            break;

        case 5:
            Console.WriteLine("Saliendo del programa.");
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }

} while (opcion != 5); // Repetimos el menú hasta que el usuario escriba 5
        
    

