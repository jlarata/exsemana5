/* 18 Escribir una función que indique si dos números enteros positivos son amigos. Dos números son amigos, si la 
suma de sus divisores (distintos de ellos mismos) son iguales. */

using System;

namespace ejercicio18
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int num1, num2, sumaDiv1, sumaDiv2;
            int[] arrayDeDiv1, arrayDeDiv2;

            Console.WriteLine("Ingrese el primer valor: ");
            num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el segundo valor: ");
            num2 = int.Parse(Console.ReadLine());

            arrayDeDiv1 = buscaDivisores(num1);
            arrayDeDiv2 = buscaDivisores(num2);
            
            sumaDiv1 = sumaDivisores(arrayDeDiv1);
            sumaDiv2 = sumaDivisores(arrayDeDiv2);
            

            if (sumaDiv1 == sumaDiv2){
                Console.WriteLine("{0} y {1} son números amigos (la suma los divisores de cada uno da {2})", num1, num2, sumaDiv1);
            } else {
                Console.WriteLine("{0} y {1} no son números amigos. La suma de sus divisores es {2} y {3}, respectivamente", num1, num2, sumaDiv1, sumaDiv2);
            }
        }

        static int sumaDivisores(int[] array) {
            int suma = 0;
            foreach (int divisor in array){
                suma += divisor;
            }
            return suma;
        }

        static int[] buscaDivisores(int valor) {
            
            int cantidadParaArray = 0;

            for (int i=1; i<(valor); i++){
            
                if (valor % i == 0){
                    cantidadParaArray++;
                }
            }

            int[] arrayDeDivisores = new int[cantidadParaArray];
            int currentDivisor=0;

            for (int i=1; i<valor; i++){
                if (valor % i == 0){
                    arrayDeDivisores[currentDivisor] = i;
                    currentDivisor++;
                }
            }

            arrayDeDivisores[0] = 1;
            
            return arrayDeDivisores;

        }

        static int comparaArrays(int[] array1, int[] array2){

            /*debug*/
            /*for (int i = (array1.Length-1); i>=0; i--){
                Console.WriteLine(array1[i]);
            }

            for (int i = (array2.Length-1); i>=0; i--){
                Console.WriteLine(array2[i]);
            }*/

            for (int i = (array1.Length-1); i>=0; i--)
            {
                for (int j = (array2.Length-1); j>=0; j--)
                {
                    if (array1[i] == array2[j])
                    {
                        return array1[i];
                    }
                }        
            }
            
            return 0; /*esto no debería suceder nunca porque como mínimo salta el 1*/
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