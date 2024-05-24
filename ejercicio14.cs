/* 14 Escribir una función que calcule el máximo común divisor de los números contenidos en un array  */

using System;

namespace ejercicio14
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int maxdiv;
            int[] arrayDeDiv1, arrayDeDiv2, arrayDeDiv3;*/

            int[] arrayParaMCD = creaYPueblaArrayParaMCD();
            
            //crea array de arrays con tamanio igua a tamanio del array a analizar
            int[][] arrayDeArraysDeDivisores = new int[arrayParaMCD.Length][];
            
            //por cada elemento en el array a analizar
            for (int i=0; i<(arrayParaMCD.Length);i++)
            {
                //crea un array de divisores
                int[] arrayDeDivs;
                //lo puebla con los divisores del primer numero del array
                arrayDeDivs = buscaDivisores(arrayParaMCD[i]);
                //y lo inserta en un array de arrays
                arrayDeArraysDeDivisores[i] = arrayDeDivs;
            }

                       
            maxdiv = comparaArrays(arrayDeArraysDeDivisores);
            Console.WriteLine("El máximo común divisor es {0}", maxdiv);
        }

        static int[] creaYPueblaArrayParaMCD() {
            
            int tamanioArrayParaMCD;

            Console.WriteLine("¿Cuántos números tendrá el array? ");
            tamanioArrayParaMCD = int.Parse(Console.ReadLine());
            int[] arrayParaMCD = new int[tamanioArrayParaMCD];

            for (int i=0; i<tamanioArrayParaMCD; i++)
            {
                Console.WriteLine("Ingrese el valor número {0} del array: ", (i+1));
                arrayParaMCD[i] = int.Parse(Console.ReadLine());
            }

            /*imprime el array*//*
                Console.Write("[ ");
                for (int i = 0; i<arrayParaMCD.Length; i++){
                    Console.Write(arrayParaMCD[i]+" ");
                }
                Console.Write("]");*/

            return arrayParaMCD;
        }

        static int[] buscaDivisores(int valor) {
            
            int cantidadParaArray = 0;

            for (int i=1; i<(valor+1); i++){
            
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
            arrayDeDivisores[arrayDeDivisores.Length-1] = valor;
            return arrayDeDivisores;
        }

//ALTERNATIVA: hacer comparaciones binarias: cada array con el siguiente para obtener numeros en comun
//al final de ese proceso buscar el mayor

//HACER UN METODO BINARIO, SOLO UN ARRAY CONTRA OTRO: /done -< SIN CHEQUEAR

//AHORA TOCARÍA INVOCARLO. ¿CUÁNTAS VECES? EL TOTAL DE ARRAYS MENOS UNA. la primera vez se mandan el primer 
//segundo array. a partir de la segunda vez, se manda el resultado de la primera mas la que sigue /done ->SIN CHEQUEAR

//FINALMENTE AL ARRAY DE COINCIDENCIAS HACERLE UN MAX. 

        //primero esto:

    static int[] invocadorArrayDeCoincidencias()
        {
            int cantArrays = arrayDeDivisores.Length;
            int primeraComparacion = 0;

            for (int i=0, i<cantArrays;i++)
            {
            //la primera vez
            if (primeraComparacion = 0) {
            int[] arrayDeCoincidencias = creaArrayDeCoincidencias(arrayDeArraysDeDivisores[i], arrayDeArraysDeDivisores[i+1])
            primeraComparacion++;
            }
            //a partir de la segunda
            for (int i=0; i<(arrayDeArraysDeDivisores.Length-1); i++){
            int[] arrayDeCoincidencias = creaArrayDeCoincidencias(arrayDeCoincidencias, arrayDeArraysDeDivisores[i+2])
            }
            }
            return creaArrayDeCoincidencias;
        }

    static int[] creaArrayDeCoincidencias(int[] array1, int[] array2){
        
        int cantCoincidencias = 0

        for (int i=0 i<array1.Length; i++){
            for (int j=0 j<array2.Length; j++){
                if (array1[i] == array2[j]){
                    cantCoincidencias++;
                }
            }
        }

        int[] coincidencias = new int[cantCoincidencias];
        int currentCoincidencia = 0;
        for (int i=0 i<array1.Length; i++){
            for (int j=0 j<array2.Length; j++){
                if (array1[i] == array2[j]){
                    coincidencias[currentCoincidencia] = array1[i];
                    currentCoincidencia++
                }
            }
        }

        return coincidencias;
    }












        /*

        static int comparaArrays(int[][] arrayDeArraysParaMCD){

            //por cada array en el array de arrays...

            for (int i = 0; i < arrayDeArraysParaMCD.Length; i++)
            {
                //itera sobre cada numero de ese array
                for (int x=(arrayDeArraysParaMCD[i][].Length-1); x>=0; x--)
                    {

                        //si no es el ultimo array
                        if (!arrayDeArraysParaMCD[i][] == (arrayDeArraysParaMCD.Length-1))
                        {
                            //itera sobre el siguiente array
                            estamismafuncion+1();
                        }
                    }
            }
            return 0; //esto no debería suceder nunca porque como mínimo salta el 1
        }   */


/*        int cantidadRecursiva = 0; <- esto al llamar el metodo
        static void iteraSobreArrays(int[][] arrayDeArraysParaMCD, int cantidadRecursiva){
            
            cantidadRecursiva ++;
            //itera sobre cada numero del array
            for (int x=(arrayDeArraysParaMCD[i][].Length-1); x>=0; x--)
                {
                        //pero si no es el ultimo array 
                    if (!arrayDeArraysParaMCD[i][] == (arrayDeArraysParaMCD.Length-1))
                    {
                            // primero itera sobre el siguiente array recursivamente
                        iteraSobreArrays(arrayDeArraysParaMCD[i+1][], )
                    } else {
                            //?¡? aca irian las comparaciones
                            //es una funcion que es un  for: por cada elemento de esta iteracion, 
                            //comparar si es igual al elemento
                            //de cada anterior iteracion
                        comparaElementos(arrayDeArraysParaMCD[i][], cantidadRecursiva)
                    }                        
                }
        }
        static void comparaElementos(int[][] arrayDeArraysParaMCD, int cantidadRecursiva){
            for (int i = 0; i<cantidadRecursiva, i++){
                arrayDeArraysParaMCD[i][i] == arrayDeArraysParaMCD[i+1][i]
            }
        }


            /*debug*/
            /*for (int i = (array1.Length-1); i>=0; i--){
                Console.WriteLine(array1[i]);
            }

            for (int i = (array2.Length-1); i>=0; i--){
                Console.WriteLine(array2[i]);
            }

            for (int i = (array3.Length-1); i>=0; i--){
                Console.WriteLine(array3[i]);
            }*/


            /*ejercicio 13 for (int i = (array1.Length-1); i>=0; i--)
            {
                for (int j = (array2.Length-1); j>=0; j--)
                {
                    for (int k=(array3.Length-1); k>=0; k--)
                    {
                        if ((array1[i] == array2[j]) && (array1[i] == array3[k]))
                    {
                        return array1[i];
                    }
                    }
                    
                }        
            }*/
            
                
    }
}