namespace SimulaServidor
{
    struct Cajero
    {
        public bool Ocupado;         // Indica si el cajero está atendiendo a un cliente
        public long TipoCliente;     // Tipo de cliente que atiende (1 = normal, 2 = discapacitado)
        public int Tiempo_Restante;  // Tiempo que queda para terminar de atender al cliente
    };

    class Program
    {
        static void Main(string[] args)
        {
            char runAgain = 'S'; // Controla si el usuario quiere volver a ejecutar la simulación

            while (runAgain != 'N')
            {  // Bucle principal para repetir la simulación mientras el usuario quiera
                // Variables principales
                int sim_Time, trans_Time, num_Serv, arriv_Time;
                int i = 0, c_Time = 0;  // Contadores para ciclos y tiempo actual
                int customers = 0, atendidos = 0; // Contadores de clientes totales y atendidos
                int wait_Time = 0;  // Acumulador de tiempo de espera (no usado actualmente)

                // Presentación y entrada de datos
                Console.Write("\n------------------------------------------"
                            + "\n- Bienvenido al la Simulacion de banco -"
                            + "\n------------------------------------------");

                Console.Write("\n\nIngrese los siguentes datos en minutos:\n");

                Console.Write("\nTiempo de la simulación: ");
                sim_Time = Convert.ToInt32(Console.ReadLine());   // Tiempo total a simular

                Console.Write("Tiempo de atención del servidor: ");
                trans_Time = Convert.ToInt32(Console.ReadLine()); // Tiempo que tarda cada cajero en atender un cliente

                Console.Write("Cantidad de servidores: ");
                num_Serv = Convert.ToInt32(Console.ReadLine());   // Número de cajeros disponibles

                Console.Write("Tiempo entre llegada de Clientes: ");
                arriv_Time = Convert.ToInt32(Console.ReadLine()); // Tiempo entre llegada de clientes nuevos

                // Declaración de arreglos de cajeros y colas para cada servidor
                Cajero[] tellArray = new Cajero[num_Serv];   // Arreglo de cajeros
                Cola[] bankQ = new Cola[num_Serv];           // Arreglo de colas, una por servidor

                // Inicialización de cajeros y colas vacías
                for (i = 0; i < num_Serv; i++)
                {
                    tellArray[i].Ocupado = false;       // Todos los cajeros libres al inicio
                    tellArray[i].TipoCliente = 0;       // Sin cliente asignado
                    tellArray[i].Tiempo_Restante = 0;   // Sin tiempo de atención pendiente
                    bankQ[i] = new Cola();               // Crear cola vacía para cada cajero
                }

                // Bucle de simulación por cada unidad de tiempo
                while (c_Time < sim_Time)
                {
                    // PASO 1: Llegada de nuevos clientes a las colas
                    if (c_Time % arriv_Time == 0)
                    {  // Cada 'arriv_Time' minutos llega un cliente nuevo
                        int colaMenPer = 0;           // Inicialmente se elige la cola 0 para poner al cliente

                        // Si la cola 0 está vacía, se encola ahí directamente
                        if (bankQ[colaMenPer].GetSize() == 0)
                        {
                            bankQ[colaMenPer].Enqueue();  // Añade un cliente tipo 1 (normal)
                            customers++;                  // Incrementa contador de clientes totales
                        }
                        else
                        {
                            // Busca la cola con menos personas para poner al cliente
                            for (i = 1; i < num_Serv; i++)
                            {
                                if (bankQ[i].GetSize() < bankQ[colaMenPer].GetSize())
                                {
                                    colaMenPer = i;
                                    if (bankQ[colaMenPer].GetSize() == 0)
                                    {
                                        break; // Si encuentra cola vacía, termina búsqueda
                                    }
                                }
                            }
                            bankQ[colaMenPer].Enqueue();  // Agrega cliente en la cola con menor tamaño
                            customers++;                  // Incrementa clientes totales
                        }
                    }

                    // PASO 2: Asignar clientes a cajeros disponibles
                    for (i = 0; i < num_Serv; i++)
                    {
                        if (bankQ[i].GetSize() > 0 && tellArray[i].Ocupado == false)
                        {
                            tellArray[i].TipoCliente = bankQ[i].Dequeue(); // Saca cliente de la cola del cajero i
                            tellArray[i].Ocupado = true;                    // Cajero pasa a estar ocupado
                            tellArray[i].Tiempo_Restante = trans_Time;      // Se establece tiempo de atención para ese cliente
                        }
                    }

                    // PASO 3: Actualizar tiempo de atención de los cajeros
                    for (i = 0; i < num_Serv; i++)
                    {
                        if (tellArray[i].Ocupado == true)
                        {
                            tellArray[i].Tiempo_Restante--; // Reduce 1 minuto de atención restante
                        }

                        // Cuando el tiempo llega a 0, el cajero termina de atender
                        if (tellArray[i].Tiempo_Restante == 0 && tellArray[i].Ocupado == true)
                        {
                            if (tellArray[i].TipoCliente == 1)
                            {   // Si cliente era normal
                                atendidos++;                        // Incrementa contador de clientes atendidos
                            }
                            tellArray[i].TipoCliente = 0;           // Cajero sin cliente
                            tellArray[i].Ocupado = false;            // Cajero queda libre
                        }
                    }

                    // Mostrar estado actual de colas y cajeros para los primeros 3 servidores (hardcodeado)
                    int cant1 = bankQ[0].GetSizeN();  // Número de clientes normales en cola 0
                    int cant2 = bankQ[1].GetSizeN();  // cola 1
                    int cant3 = bankQ[2].GetSizeN();  // cola 2

                    Console.Write($"\n{c_Time}-- en colas :{cant1} - {cant2} - {cant3} | s1:{tellArray[0].Ocupado} s2:{tellArray[1].Ocupado} s3:{tellArray[2].Ocupado} | atn N:{atendidos}");

                    wait_Time += 0;  // Aquí no se calcula tiempo de espera (puedes implementar esta lógica)
                    c_Time++;        // Avanza el tiempo de la simulación
                }

                // Reporte final después de la simulación
                Console.Write("\n---------------"
                            + "\n- REPORTE -"
                            + "\n---------------\n");

                Console.Write("Tiempo promedio de espera:");

                // Calcula el promedio (ahora mismo wait_Time es 0, es un placeholder)
                Console.Write("" + ((float)wait_Time / customers));
                Console.WriteLine(wait_Time);

                // Pregunta si se quiere ejecutar la simulación nuevamente
                Console.Write("\n\nEjecutar programa otra vez? (s/n): ");
                runAgain = Convert.ToChar(Console.ReadLine());
                runAgain = char.ToUpper(runAgain);
                while (runAgain != 'S' && runAgain != 'N')
                {
                    Console.Write("Letra inválida. Ejecutar programa otra vez? (s/n): ");
                    runAgain = Convert.ToChar(Console.ReadLine());
                    runAgain = char.ToUpper(runAgain);
                }
            }
        }
    }
}