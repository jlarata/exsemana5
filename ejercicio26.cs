/* 26.  	Escribir una función a la que se le pasa dos arrays, el número de elementos útiles y que
 operación se desea realizar: sumar, restar, multiplicar o dividir (mediante un carácter: ’s’, ’r’, ’m’, ’d’).
  La función debe devolver un array con los resultados. */

using System;

namespace ejercicio26
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            
            float[] arrayDePrueba = { -100, 251, -456, 335, 946, 5, 7, -2};
            float[] arrayDePrueba2 = { 40, 65, -4, 888, 1060, 9, 17, -1};

            Console.WriteLine(" \n Primer array: ");
            imprimeArrayCompleto(arrayDePrueba);
            Console.WriteLine("\n\n Segundo array: ");
            imprimeArrayCompleto(arrayDePrueba2);

            Console.WriteLine("\n\n Elija un N° del 1 al 8 del primer array: ");
            int nUtil1 = (int.Parse(Console.ReadLine())-1);
            Console.WriteLine("\n Elija un N° del 1 al 8 del segundo array: ");
            int nUtil2 = (int.Parse(Console.ReadLine())-1);
            Console.WriteLine("\n Elija el tipo de operación: sumar, restar, multiplicar o dividir (mediante un carácter: ’s’, ’r’, ’m’, ’d’): ");
            string op = Console.ReadLine();

            float resultado = operaSobreInts(arrayDePrueba[nUtil1], arrayDePrueba2[nUtil2], op);
            Console.WriteLine("\nEl resultado es {0}", resultado);
        }

        static float operaSobreInts(float valor1, float valor2, string op){            
                
                float resultado = 0;
                
                switch(op) 
                    {
                    case "s":
                        resultado = valor1+valor2;
                        Console.Write("Sumando {0} y {1}...", valor1, valor2);
                        break;
                    case "r":
                        resultado = valor1+valor2;
                        Console.Write("Restando {0} y {1}...", valor1, valor2);
                        break;
                    case "m":
                        resultado = valor1*valor2;
                        Console.Write("Multiplicando {0} y {1}...", valor1, valor2);
                        break;
                    case "d":
                        resultado = valor1/valor2;
                        Console.Write("Dividiendo {0} y {1}...", valor1, valor2);
                        break;
                    default:
                        Console.Write("operación no válida (ingresó mal operación)");
                        break;
                    }
                return resultado;
            
        }

        static void imprimeArrayCompleto(float[] array){            
                Console.Write("\n [ ");
                for (int i = 0; i<array.Length; i++){
                    Console.Write(array[i]+" ");
                }
                Console.Write("]");
        }

        
    }
}