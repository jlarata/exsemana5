/* 25.  	Escribir una función a la que se le pasa un array de enteros y un número. 
Debe buscar el número en el array e indicar si se encuentra o no..*/

using System;

namespace ejercicio25
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int numeroDePrueba = -456;
            int[] arrayDePrueba = { -100, 251, -456, 335, 946, 5, 7, -2};
            if (buscaIntEnArray(arrayDePrueba, numeroDePrueba)){
                Console.WriteLine("{0} se encuentra en el array", numeroDePrueba);
            } else {
                Console.WriteLine("{0} no se encuentra en el array", numeroDePrueba);
            }
        }

        static bool buscaIntEnArray(int[] array, int numero){
            bool hit = false;
            foreach (int entero in array)
            {
                if (entero == numero){
                    hit = true;
                }
            }

            return hit;
        }
    }
}