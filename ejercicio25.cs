/* 25.  	Escribir una función a la que se le pasa un array de enteros y un número. 
Debe buscar el número en el array e indicar si se encuentra o no..*/

using System;

namespace ejercicio25
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int numeroDePrueba = 745;
            int[] arrayDePrueba = { -100, 743, 744, 84, 16, 164, 251, -456, 335, 946, 5, 7, -2};

            Console.WriteLine("\n Caso 1. Array desordenado: ");
            imprimeArrayCompleto(arrayDePrueba);
            Console.WriteLine("\n\n Se buscará el {0} en el array de manera secuencial", numeroDePrueba);
          
            if (buscaIntEnArray(arrayDePrueba, numeroDePrueba)){
                Console.WriteLine("\n {0} se encuentra en el array", numeroDePrueba);
            } else {
                Console.WriteLine("\n {0} no se encuentra en el array", numeroDePrueba);
            }

            int[] arrayOrdenado = ordenaArray(arrayDePrueba);
            Console.WriteLine("\n Caso 2. Array ordenado: ");
            imprimeArrayCompleto(arrayOrdenado);
            Console.WriteLine("\n\n Se buscará el {0} en el array con búsqueda binaria", numeroDePrueba);


            if (buscaBinariaIntEnArray(arrayOrdenado, numeroDePrueba)){
                Console.WriteLine("\n {0} se encuentra en el array", numeroDePrueba);
            } else {
                Console.WriteLine("\n {0} no se encuentra en el array", numeroDePrueba);
            }

            for (int i = 0; i<arrayOrdenado.Length;i++){
                if (buscaBinariaIntEnArray(arrayOrdenado, arrayOrdenado[i])){
                Console.WriteLine("\n {0} se encuentra en el array", arrayOrdenado[i]);
                } else {
                Console.WriteLine("\n {0} no se encuentra en el array", arrayOrdenado[i]);
            }
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

        static bool buscaBinariaIntEnArray(int[] array, int numero){
            bool hit = false;
            int medio = (((array.Length)/2)), techo=(array.Length), piso=0, bufferMedio;

            
            while ((techo-piso) != 1){

                //debug Console.WriteLine("El piso es {0}, el techo es {1}", piso, techo);
                //debug Console.WriteLine(" Iteración con array Numero {0} = {1}", (medio), array[medio]);
                if (numero == array[medio]){
                    //debug Console.WriteLine(" Hit! {0} coincide con el elemento {1} del array", numero, medio);
                    hit = true;
                    return hit;
                } else {
                    if (numero < array[medio]){
                        
                        //debug Console.WriteLine("{0} es menor a {1} ", numero, array[medio]);
                        techo = medio;
                        bufferMedio = ((techo-piso)/2);
                        
                        medio = (piso+bufferMedio);
                        
                        
                        
                    } else {
                        //debug Console.WriteLine("{0} es mayor a {1} ", numero, array[medio]);
                        
                        piso = medio;
                        bufferMedio = (medio + (((techo-medio)/2)));
                        
                        medio = bufferMedio;
                    }
                }
                
            }
           
            //debug Console.WriteLine("probando contra array 0 = {0}", array[0]);
            if ( (numero == array[0])) {
                    Console.WriteLine("\n {0} se encuentra en el array (es el primer elemento!)", numero);
                    hit = true;
                    return hit;
                }
            return hit;
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