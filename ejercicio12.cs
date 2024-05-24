/* 12 Escribir una función que calcule el máximo común divisor de dos números.  */

using System;

namespace ejercicio12
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int num1, num2, maxdiv;
            int[] arrayDeDiv1, arrayDeDiv2;

            Console.WriteLine("Ingrese el primer valor: ");
            num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el segundo valor: ");
            num2 = int.Parse(Console.ReadLine());

            arrayDeDiv1 = buscaDivisores(num1);
            arrayDeDiv2 = buscaDivisores(num2);
            
            maxdiv = comparaArrays(arrayDeDiv1, arrayDeDiv2);
            Console.WriteLine("El máximo común divisor es {0}", maxdiv);           
        }

        static int[] buscaDivisores(int valor) {
            
            int cantidadParaArray = 0;

            for (int i=1; i<valor; i++){
            
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
    }
}