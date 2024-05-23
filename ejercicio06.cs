/* 6. Se necesita crear una función a la que se le pasan por parámetro dos enteros y muestra todos
 los números comprendidos entre ellos, inclusive.*/

using System;

namespace ejercicio06
{
    internal class Program
    {
        static void Main(string[] args)
        {                   
            int[] numeros = new int[2];//los polos entre los que revisar son 2
            int cantidad;
            
            numeros = pideNumeros();

            cantidad = calculaCantidad(numeros);
            int[] incluidos = new int[cantidad];

            incluidos = buscaNumerosIncluidos(numeros, cantidad);
            comunicaResultado(incluidos);

        }

        public static int[] pideNumeros() {
                        int[] numeros = new int[2];

            for (int i=0; i<2; i++){
                Console.WriteLine("Ingrese el número #"+ (i+1));
                numeros[i] = int.Parse(Console.ReadLine());             
                }
            return numeros;
            }
        
        public static int calculaCantidad(int[] numeros) {
            int cantidad = (numeros[1]-numeros[0])+1;
            return cantidad;
        }

        public static int[] buscaNumerosIncluidos(int[] numeros, int cantidad) {

            int iniciador = numeros[0];
            int[] incluidos = new int[cantidad];
            
            for (int i=0; i<cantidad; i++){
                    
                    incluidos[i] = iniciador;
                    iniciador++;
                    
                }

            return incluidos;
        }

        static void comunicaResultado(int[] incluidos){
            for (int i = 0; i<incluidos.Length; i++){
                Console.Write(incluidos[i]+" ");
            }
        }
    }
}