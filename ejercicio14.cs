/* 14 Escribir una función que calcule el máximo común divisor de los números contenidos en un array  */

using System;

namespace ejercicio14
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int maxdiv;
            int[] arrayDeCoincidencias;
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

            arrayDeCoincidencias = invocadorArrayDeCoincidencias(arrayDeArraysDeDivisores);
                       
            maxdiv = buscaMaximoValor(arrayDeCoincidencias);
            Console.WriteLine("El máximo común divisor los {0} arrays es {1}", arrayParaMCD.Length, maxdiv);

             /*esto imprime el array completo*/
             /*
                Console.Write("[ ");
                for (int i = 0; i<arrayDeCoincidencias.Length; i++){
                    Console.Write(arrayDeCoincidencias[i]+" ");
                }
                Console.Write("]");*/

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

        static int[] invocadorArrayDeCoincidencias(int[][] arrayDeArraysDeDivisores)
        {           
            int[] antArrayDeCoincidencias, nuevoArrayDeCoincidencias;

            //crea un primer array de coincidencias con los primeros dos arrays de la lista
            antArrayDeCoincidencias = creaArrayDeCoincidencias(arrayDeArraysDeDivisores[0], arrayDeArraysDeDivisores[1]);

            //luego itera sobre los demás, siempre usando el array anterior, creando cadaa vez un nuevo array de coincidencias
            for (int i=2; i<arrayDeArraysDeDivisores.Length; i++)
            {
                nuevoArrayDeCoincidencias = creaArrayDeCoincidencias(antArrayDeCoincidencias, arrayDeArraysDeDivisores[i]);
                if (i == arrayDeArraysDeDivisores.Length-1) {
                    return nuevoArrayDeCoincidencias;        
                }
            }
            return antArrayDeCoincidencias; //esto no deberia retornar nunca pero si acá ponia el nuevoarray tiraba error
        }

        static int[] creaArrayDeCoincidencias(int[] array1, int[] array2){
        
        int cantCoincidencias = 0;

        for (int i=0; i<array1.Length; i++){
            for (int j=0; j<array2.Length; j++){
                if (array1[i] == array2[j]){
                    cantCoincidencias++;
                }
            }
        }

        int[] coincidencias = new int[cantCoincidencias];
        int currentCoincidencia = 0;
        for (int i=0; i<array1.Length; i++){
            for (int j=0; j<array2.Length; j++){
                if (array1[i] == array2[j]){
                    coincidencias[currentCoincidencia] = array1[i];
                    currentCoincidencia++;
                }
            }
        }

        return coincidencias;
        }

        static int buscaMaximoValor(int[] arrayDeCoincidenciasFinal) {
            
            int maxValor = 0;
            
            for (int i=0; i<arrayDeCoincidenciasFinal.Length;i++) {
                if (arrayDeCoincidenciasFinal[i] > maxValor) {
                    maxValor = arrayDeCoincidenciasFinal[i];
                }
            }

            return maxValor;
        }                 
    }
}