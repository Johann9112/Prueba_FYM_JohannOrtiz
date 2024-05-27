using System;

class Program
{
    static Random generadorAleatorio = new Random(); // Crear instancia de Random para generar números aleatorios

    static bool EsPrimo(int numero)
    {
        if (numero <= 1)
            return false;

        for (int i = 2; i <= Math.Sqrt(numero); i++)
        {
            if (numero % i == 0)
                return false;
        }

        return true;
    }

    static int[,] CrearMatrizAleatoria(int filas, int columnas)
    {
        int[,] matriz = new int[filas, columnas];

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                matriz[i, j] = generadorAleatorio.Next(1, 50);
            }
        }

        return matriz;
    }

    static int[,] CrearMatrizManual(int filas, int columnas)
    {
        int[,] matriz = new int[filas, columnas];

        Console.WriteLine("\nIngrese los valores de la matriz:");

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                Console.Write($"Ingrese el valor para la posición [{i},{j}]: ");
                while (!int.TryParse(Console.ReadLine(), out matriz[i, j]))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    Console.Write($"Ingrese el valor para la posición [{i},{j}]: ");
                }
            }
        }

        return matriz;
    }

    static void ImprimirMatriz(int[,] matriz)
    {
        Console.WriteLine("\nLa matriz es:");
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Console.Write(matriz[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int opcion;
        int[,] matriz = null; // Inicializar matriz como null

        Console.WriteLine("\n********Crear Matriz********");
        Console.WriteLine("1. Crear matriz aleatoriamente");
        Console.WriteLine("2. Ingresar valores manualmente");
        Console.Write("Seleccione una opción: ");
        int opcionCrearMatriz = int.Parse(Console.ReadLine());

        switch (opcionCrearMatriz)
        {
            case 1:
                Console.Write("Ingrese el número de filas: ");
                int filasAleatorias = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el número de columnas: ");
                int columnasAleatorias = int.Parse(Console.ReadLine());

                matriz = CrearMatrizAleatoria(filasAleatorias, columnasAleatorias);
                Console.WriteLine("Matriz aleatoria creada exitosamente.");
                break;
            case 2:
                Console.Write("Ingrese el número de filas: ");
                int filasManual = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el número de columnas: ");
                int columnasManual = int.Parse(Console.ReadLine());

                matriz = CrearMatrizManual(filasManual, columnasManual);
                Console.WriteLine("Matriz manual creada exitosamente.");
                break;
            default:
                Console.WriteLine("Opción no válida. Saliendo del programa.");
                return;
        }

        do
        {
            Console.WriteLine("\n********Menu********");
            Console.WriteLine("1. Imprimir matriz");
            Console.WriteLine("2. Cantidad de filas y columnas");
            Console.WriteLine("3. Recorrido en ZigZag");
            Console.WriteLine("4. Números primos");
            Console.WriteLine("5. Números impares");
            Console.WriteLine("6. Números ordenados (ascendente y descendente)");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
                continue;
            }
            var them = 0;

            switch (opcion)
            {
                case 1:
                    if (matriz != null)
                    {
                        ImprimirMatriz(matriz);
                        them = 1;
                    }
                    else
                    {
                        Console.WriteLine("La matriz aún no ha sido creada.");
                    }
                    break;
                case 2:
                    if (matriz != null)
                    {
                        Console.WriteLine($"\nCantidad de filas: {matriz.GetLength(0)}");
                        Console.WriteLine($"Cantidad de columnas: {matriz.GetLength(1)}");
                        them = 2;
                    }
                    else
                    {
                        Console.WriteLine("La matriz aún no ha sido creada.");
                    }
                    break;
                case 3:
                    int filas = matriz.GetLength(0);
                    int columnas = matriz.GetLength(1);

                    Console.WriteLine("\nRecorrido en ZigZag:");
                    for (int j = 0; j < columnas; j++)
                    {
                        if (j % 2 == 0)
                        {
                            for (int i = filas - 1; i >= 0; i--)
                            {
                                Console.Write(matriz[i, j] + " ");
                            }
                        }
                        else
                        {
                            for (int i = 0; i < filas; i++)
                            {
                                Console.Write(matriz[i, j] + " ");
                            }
                        }

                    }

                    break;
                case 4:

                    int contadorPrimos = 0;
                    Console.WriteLine("\nNúmeros primos en la matriz:");
                    for (int i = 0; i < matriz.GetLength(0); i++)
                    {
                        for (int j = 0; j < matriz.GetLength(1); j++)
                        {
                            if (EsPrimo(matriz[i, j]))
                            {
                                Console.Write(matriz[i, j] + " ");
                                contadorPrimos++;
                            }
                        }
                    }
                    Console.WriteLine($"\nCantidad de números primos en la matriz: {contadorPrimos}");

                    break;
                case 5:
                    int contadorImpares = 0;
                    Console.WriteLine("\nNúmeros impares en la matriz:");
                    for (int i = 0; i < matriz.GetLength(0); i++)
                    {
                        for (int j = 0; j < matriz.GetLength(1); j++)
                        {
                            if (matriz[i, j] % 2 != 0)
                            {
                                Console.Write(matriz[i, j] + " ");
                                contadorImpares++;
                            }
                        }
                    }
                    Console.WriteLine($"\nCantidad de números impares en la matriz: {contadorImpares}");

                    break;
                case 6:
                    int[] numeros = new int[matriz.GetLength(0) * matriz.GetLength(1)];
                    int k = 0;
                    for (int i = 0; i < matriz.GetLength(0); i++)
                    {
                        for (int j = 0; j < matriz.GetLength(1); j++)
                        {
                            numeros[k++] = matriz[i, j];
                        }
                    }
                    Array.Sort(numeros);
                    Console.WriteLine("\nNúmeros ordenados de menor a mayor:");
                    foreach (int num in numeros)
                    {
                        Console.Write(num + " ");
                    }

                    Array.Reverse(numeros);
                    Console.WriteLine("\nNúmeros ordenados de mayor a menor:");
                    foreach (int num in numeros)
                    {
                        Console.Write(num + " ");
                    }

                    break;
                case 0:
                    Console.WriteLine("\nSaliendo del programa...");
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                    break;
            }
        } while (opcion != 0);
    }
}
