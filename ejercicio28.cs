/* 28 Crear una función que devuelva la suma de un array*/

using System;

namespace ejercicio28
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int[] arrayDePrueba = { -100, 251, -456, 335, 946, 5, 7, -2};
            
            imprimeArrayCompleto(arrayDePrueba);

            int sumaDelArray = sumaArray(arrayDePrueba);

            Console.WriteLine("\nLa suma de los elementos del array es {0}: ", sumaDelArray);
            Console.WriteLine("");
        }

        static int sumaArray(int[] array){
            
            int sumaDelArray = 0;

            for (int i=0; i<array.Length; i++){
                    sumaDelArray = sumaDelArray += array[i];
                    }

             return sumaDelArray;

        }
        
        static void imprimeArrayCompleto(int[] array){            
                Console.Write("\n [ ");
                for (int i = 0; i<array.Length; i++){
                    Console.Write(array[i]+" ");
                }
                Console.Write("]");
        }

    }
}