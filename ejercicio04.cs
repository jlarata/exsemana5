/*  Idem al anterior pero que calcule el máximo de 3 números.*/

using System;

namespace ejercicio04
{
    internal class Program
    {
        static void Main(string[] args)
        {                   
            int[] numeros = new int[3];
            int max = 0;


            numeros = pideNumeros();
            max = BuscaElMayor(numeros);

            Console.WriteLine("El mayor número ingresado es "+max);
        }

        public static int[] pideNumeros() {
            
            int[] numeros = new int[3];
            
            Console.WriteLine("Ingrese el primer número: ");
            numeros[0] = int.Parse(Console.ReadLine());          
            Console.WriteLine("Ingrese el segundo número: ");
            numeros[1] = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el tercer número: ");
            numeros[2] = int.Parse(Console.ReadLine());
            
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