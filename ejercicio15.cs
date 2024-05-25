/* 15 Escribir una función que calcule el mínimo común múltiplo de dos números */

using System;

namespace ejercicio15
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int num1, num2, factoresDistintos1, factoresDistintos2;//, MCM;
            int [] fact1, fact2;

            Console.WriteLine("Ingrese el primer valor: ");
            num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el segundo valor: ");
            num2 = int.Parse(Console.ReadLine());

            fact1 = factoriza(num1);
            fact2 = factoriza(num2);

            factoresDistintos1 = calculaFactoresDistintos(fact1);
            factoresDistintos2 = calculaFactoresDistintos(fact2);

            Console.WriteLine("{0} factores distintos", factoresDistintos1);
            Console.WriteLine("{0} factores distintos", factoresDistintos2);

            /* for debugging porpouse
            imprimeArrayCompleto(fact1);
            imprimeArrayCompleto(fact2);
            */



            // qué necesito? una lista de listas por cada array? tipo: [factor][cantidad]
            //primero la length esperada: o sea array[ESTE][] <-numero /done . es "factores distintos".
            //segundo crear el array de arrays. 
            //tercero crear los arrays de cantidades (uno por cada "factor distito")
            //cuarto poblar el array de arrays con esos arrays

            //primeras pistas:
            //[factor] va a ser igual a la cantidad de factores diferentes 
            //[cantidad va a ser igual a la cantidad de repeticiones de ese factor]

            


            //maxdiv = comparaArrays(arrayDeDiv1, arrayDeDiv2);
            //Console.WriteLine("El máximo común divisor es {0}", maxdiv);           
        }

        static int[] factoriza(int valor) {

            int copiaValor = valor;
            int cantidadParaArray = 0;
            
            //la factorización termina cuando el valor sea 1
            while(!(valor == 1)){
                
                //mientras tanto, y arrancando en 2 (y con máximo = a valor) el bucle
                int currentDivisor = 2;

                while (!(valor % currentDivisor == 0)) {
                    currentDivisor++;
                }
                valor = valor / currentDivisor;
                cantidadParaArray++;              
            }

            int[] arrayDeDivisores = new int[cantidadParaArray];
            int currentElementoDelArrayDeDivsores = 0;

        //repite el bucle, ahora para poblar el array
            while(!(copiaValor == 1)){
                
                int currentDivisor = 2;
            
                while (!(copiaValor % currentDivisor == 0)) {
                    currentDivisor++;
                }
                
                arrayDeDivisores[currentElementoDelArrayDeDivsores] = currentDivisor;
                currentElementoDelArrayDeDivsores++;

                copiaValor = copiaValor / currentDivisor;
            }

            return arrayDeDivisores;
        }

        static int calculaFactoresDistintos(int[] array){
            int currentFactor = 0;
            int factoresDistintos = 1;
            
            for (int i = 0; i<(array.Length-1);i++){
                if (array[currentFactor] != array[currentFactor+1]){
                    factoresDistintos++;
                    currentFactor++;
                } else {
                    currentFactor++;
                    }
            }
            //Console.Write("{0} factores distintos", factoresDistintos);
            return factoresDistintos;
        }

        static void imprimeArrayCompleto(int[] array){            
                Console.Write("[ ");
                for (int i = 0; i<array.Length; i++){
                    Console.Write(array[i]+" ");
                }
                Console.Write("]");
        }

        

         /*   
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

        }*/

        /*
        static int comparaArrays(int[] array1, int[] array2){

            //debug
            //for (int i = (array1.Length-1); i>=0; i--){
            //    Console.WriteLine(array1[i]);
            //}

            //for (int i = (array2.Length-1); i>=0; i--){
            //    Console.WriteLine(array2[i]);
            //}

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
            
            return 0; //esto no debería suceder nunca porque como mínimo salta el 1
        }*/   
    }
}