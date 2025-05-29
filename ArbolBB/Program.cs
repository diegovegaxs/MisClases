using ArbolBusBin; // Importa el namespace donde están definidas las clases Nodo y ArbolBB

// Crear una instancia del árbol binario de búsqueda
ArbolBB ar = new ArbolBB();

// Agregar nodos al árbol con diferentes valores
ar.Agrega(6); // Este será la raíz
ar.Agrega(4); // Va a la izquierda de 6
ar.Agrega(9); // Va a la derecha de 6
ar.Agrega(3); // Va a la izquierda de 4
ar.Agrega(5); // Va a la derecha de 4
ar.Agrega(8); // Va a la derecha de 7

// 📤 Imprimir en Preorden: Nodo - Izquierda - Derecha
ar.ImprimePre(); // Resultado esperado: 6, 4, 3, 5, 7, 8

// 📤 Imprimir en Inorden: Izquierda - Nodo - Derecha (de menor a mayor)
ar.ImprimeIn(); // Resultado esperado: 3, 4, 5, 6, 7, 8

// 📤 Imprimir en Postorden: Izquierda - Derecha - Nodo
ar.ImprimePos(); // Resultado esperado: 3, 5, 4, 8, 7, 6

// 🔍 Mostrar el mayor valor del árbol (el que está más a la derecha)
ar.MayorValor(); // Resultado esperado: Mayor valor del árbol: 8

Console.WriteLine();

bool consecutivos = ar.SonConsecutivos();
Console.WriteLine("¿Son consecutivos? " + (consecutivos ? "Sí" : "No"));