/* 27.  Escribir una función que ordene el array que se le pasa por parámetro.*/

using System;

namespace ejercicio27
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            var rand = new Random();

            int[] arrayDePrueba = new int[30];
            
            for (int i = 0; i<arrayDePrueba.Length; i++){
            int numAleatorio = rand.Next(-1000, 1000);
            arrayDePrueba[i] = numAleatorio;
            }
            
            Console.WriteLine("\nAntes de ordenar: ");
            imprimeArrayCompleto(arrayDePrueba);

            int[] arrayOrdenado = ordenaArray(arrayDePrueba);

            Console.WriteLine("\n\nDespués de ordenar: ");
            imprimeArrayCompleto(arrayOrdenado);
            Console.WriteLine("");
        }

        static int[] ordenaArray(int[] array){
            
            for (int i=0; i<array.Length-1; i++){
                for (int j=0; j<(array.Length-1-i);j++){
                    if (array[j] >array[j+1]) {
                        int[] parInvertido = intercambiar(array[j], array[j+1]);
                        array[j] = parInvertido[0];
                        array[j+1] = parInvertido[1];
                    }
                }
            } return array;

        }

        static int[] intercambiar (int a, int b){
            int[] parInvertido = {b, a};
            return parInvertido;
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