using System;

namespace SimulaServidor
{
    struct Cajero
    {
        public bool Ocupado;           // Indica si el cajero está ocupado o no
        public long TipoCliente;       // Tipo de cliente atendido (1 o 2)
        public int Tiempo_Restante;    // Tiempo que le queda para terminar de atender al cliente
    };

    class Program
    {
        static void Main(string[] args)
        {
            char runAgain = 'S'; // Variable para controlar si el programa se repite

            while (runAgain != 'N')
            { // Bucle principal que permite repetir la simulación
                // Variables de simulación
                int sim_Time, trans_Time, num_Serv, arriv_Time;
                int i = 0, c_Time = 0; // Contadores de tiempo y ciclos
                int customers = 0, atendidos = 0, atendidosDis = 0, left, wait_Time = 0;

                Cola bankQ = new Cola(); // Creamos la cola para clientes

                // Mensajes de bienvenida y captura de datos
                Console.Write("\n------------------------------------------"
                              + "\n- Bienvenido a la Simulación de banco -"
                              + "\n------------------------------------------");

                Console.Write("\n\nIngrese los siguientes datos en minutos:\n");
                Console.Write("\nTiempo de la simulación: ");
                sim_Time = Convert.ToInt32(Console.ReadLine());  // Tiempo total a simular
                Console.Write("Tiempo de atención del servidor: ");
                trans_Time = Convert.ToInt32(Console.ReadLine()); // Tiempo que tarda un cajero en atender un cliente
                Console.Write("Cantidad de servidores: ");
                num_Serv = Convert.ToInt32(Console.ReadLine());  // Número de cajeros disponibles
                Console.Write("Tiempo entre llegada de Clientes: ");
                arriv_Time = Convert.ToInt32(Console.ReadLine()); // Tiempo entre llegada de clientes a la cola

                Cajero[] tellArray = new Cajero[num_Serv]; // Creamos arreglo de cajeros

                // Inicializamos todos los cajeros como libres
                for (i = 0; i < num_Serv; i++)
                {
                    tellArray[i].Ocupado = false;
                    tellArray[i].TipoCliente = 0;
                    tellArray[i].Tiempo_Restante = 0;
                }

                // Ciclo principal que simula cada minuto hasta que termina el tiempo de simulación
                while (c_Time < sim_Time)
                {

                    // PASO 1: Llegada de clientes según el tiempo especificado
                    if (c_Time % arriv_Time == 0)
                    {
                        bankQ.Enqueue(); // Añadimos cliente a la cola
                        customers++;     // Contamos un cliente más
                    }

                    // PASO 2: Asignar clientes a cajeros disponibles
                    for (i = 0; i < num_Serv; i++)
                    {
                        if (bankQ.GetSize() > 0)
                        {        // Si hay clientes en cola
                            if (tellArray[i].Ocupado == false)
                            { // Si el cajero está libre
                                tellArray[i].TipoCliente = bankQ.Dequeue(); // Sacamos un cliente de la cola
                                tellArray[i].Ocupado = true;  // Marcamos cajero ocupado
                                tellArray[i].Tiempo_Restante = trans_Time; // Tiempo que tomará atenderlo
                            }
                        }
                    }

                    // PASO 3: Reducir tiempo de atención de cada cajero ocupado
                    for (i = 0; i < num_Serv; i++)
                    {
                        if (tellArray[i].Ocupado == true)
                        {
                            tellArray[i].Tiempo_Restante--; // Reducimos tiempo restante
                        }
                        // Si el tiempo llega a 0, el cajero queda libre y se cuenta como atendido
                        if (tellArray[i].Tiempo_Restante == 0 && tellArray[i].Ocupado == true)
                        {
                            if (tellArray[i].TipoCliente == 1)
                            {
                                atendidos++; // Contamos un cliente atendido
                            }
                            // Reseteamos datos del cajero
                            tellArray[i].TipoCliente = 0;
                            tellArray[i].Ocupado = false;
                        }
                    }

                    // Contamos cuántos clientes están esperando en la cola
                    left = bankQ.GetSize();

                    // Mostramos estado actual por consola
                    Console.Write($"\n{c_Time} -- en cola: {left}  ");
                    for (i = 0; i < num_Serv; i++)
                    {
                        Console.Write($"s{i + 1}: {tellArray[i].Ocupado}  ");
                    }
                    Console.Write($"Atendidos: {atendidos}");

                    wait_Time += left; // Sumamos clientes en espera para calcular promedio al final
                    c_Time++;          // Avanzamos el tiempo un minuto
                }

                // Al terminar la simulación, mostramos reporte
                Console.Write("\n---------------"
                              + "\n- REPORTE -"
                              + "\n---------------\n");
                Console.WriteLine("Wait_Time: " + wait_Time);
                Console.Write("Tiempo promedio de espera: ");
                Console.WriteLine(((float)wait_Time / customers));

                // Preguntamos si quiere ejecutar el programa otra vez
                Console.Write("\n\nEjecutar programa otra vez? (s/n): ");
                runAgain = Convert.ToChar(Console.ReadLine());
                runAgain = char.ToUpper(runAgain);

                // Validamos la respuesta
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