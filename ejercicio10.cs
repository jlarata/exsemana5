/* 10. Crear una función a la que se le pasa un número entero y devuelve la cantidad de divisores primos que tiene. */

using System;

namespace ejercicio10
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int valor;
            int[] arrayDeDivisores;

            Console.WriteLine("Ingrese un valor: ");
            valor = int.Parse(Console.ReadLine());

            arrayDeDivisores = buscaDivisores(valor);
            
            comunicaArray(arrayDeDivisores);
            /*método de prueba para ver si funcionaba bien. ver más abajo
            comunicaContraste(valor);*/
            
        }

        static int[] buscaDivisores(int valor) {
            
            int cantidadParaArray = 0;

            for (int i=1; i<valor; i++){
            
                if (valor % i == 0){
                    if (esPrimo(i)) {
                        cantidadParaArray++;
                    }
                    
                }
            }

            int[] arrayDeDivisores = new int[cantidadParaArray];
            int currentDivisor=0;

            for (int i=1; i<valor; i++){
                if (valor % i == 0){
                    if (esPrimo(i)){
                        arrayDeDivisores[currentDivisor] = i;
                        currentDivisor++;
                    }
                    
                }
            }
            arrayDeDivisores[0] = 1;

            return arrayDeDivisores;
        }

        static bool esPrimo(int numero){
            bool esPrimo = true;
            for (int i=2; i<numero; i++){
                if (numero % i == 0){
                    esPrimo = false;
                }
            }
            return esPrimo;
        }

        static void comunicaArray(int[] array){


            for (int i = 0; i<array.Length; i++){
                Console.WriteLine(array[i]);
            }
        }


        /*este método lo probé para ver si funcionaba bien. tiene los numeros primos menores a 100 en un array.
        entonces, por ejemplo, si se ejecuta el programa con este método sin comentar y se ingresa "202" va a haber una 
        diferencia entre el método original y el contraste, porque 101 lo divide y es primo (pero no está en los primeros 100)

        static void comunicaContraste(int valor){
            int[] contraste = {1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97};
            
            for (int i = 0; i<contraste.Length; i++ ){
                if (valor%contraste[i] == 0) {
                    Console.WriteLine(contraste[i]);
                }
            }
        }*/

        
    }
}