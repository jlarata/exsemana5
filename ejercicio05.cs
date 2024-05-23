/* Idem al anterior pero que calcule el máximo de un array de n elementos.*/

using System;

namespace ejercicio05
{
    internal class Program
    {
        static void Main(string[] args)
        {                   
            int[] numeros = new int[3];
            int max = 0;
            int arraySize;


            arraySize = pidetamanio();

            numeros = pideNumeros(arraySize);
            max = BuscaElMayor(numeros);

            Console.WriteLine("El mayor número ingresado es "+max);
        }

        public static int pidetamanio(){
            int tamanio;
            Console.WriteLine("¿Cuántos números quiere que tenga el array?: ");
            tamanio = int.Parse(Console.ReadLine());             
            return tamanio;
        }        

        public static int[] pideNumeros(int tamano) {
            
            int[] numeros = new int[tamano];

            for (int i=0; i<tamano; i++){
                Console.WriteLine("Ingrese el número #"+ (i+1));
                numeros[i] = int.Parse(Console.ReadLine());             
                }
            
            return numeros;
            }
        public static int BuscaElMayor(int[] numeros) {

                int max = 0;

                for (int i=0; i<numeros.Length; i++){
                    if (numeros[i]>max){
                        max = numeros[i];
                    }
                }

                return max;
        }
    }
}