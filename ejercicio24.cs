/* 24.  	Escribir una función a la que se le pasa como parámetro un array que debe rellenar. 
Se leerá por teclado una serie de números: guardar en el array solo los pares e ignorar los impares.
 También hay que devolver la cantidad de impares ignorados.*/

using System;

namespace ejercicio24
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int totalNumerosAConsiderar;

            Console.WriteLine("Cuántos números vas a ingresar?: ");
            
            totalNumerosAConsiderar= int.Parse(Console.ReadLine());
            
            int[] arrayDePares = new int[totalNumerosAConsiderar];

            pueblaDePares(arrayDePares, totalNumerosAConsiderar);         
        }

        static void pueblaDePares(int[] array, int ingresos){

            int cantidadImpares=0;

            for (int i=0; i<ingresos; i++){
                Console.WriteLine("Ingresa valor número {0}", (i+1));
                int ingreso = int.Parse(Console.ReadLine());
                if (esPar(ingreso)){
                    array[i] = ingreso;
                } else {
                    cantidadImpares++;
                }
            }

            Console.WriteLine("Se ingresaron {0} números pares y se ignoraron {1} números impares", (ingresos-cantidadImpares), cantidadImpares);
            
            Console.WriteLine("El array quedó así: ");
            imprimeArrayCompleto(array);
        }


        static bool esPar(int valor){
            if (valor % 2 == 0){
                return true;
            }
            return false;
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