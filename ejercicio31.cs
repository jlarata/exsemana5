/*31 Escribir una función que devuelva el número de la posición Fibonacci.
Nota: Elegí hacerlo con listas para aprender y practicar algo nuevo*/

using System;
using System.Collections.Generic; 


namespace ejercicio31
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int posicion, nuevoNumero = 0;

            List<int> secuencia = new List<int>() {
                0
            }; 

            Console.WriteLine("Ingrese el número de la posición fibonacci que desea obtener");
            posicion = int.Parse(Console.ReadLine());

            sumaElementos(secuencia, posicion, nuevoNumero);

            Console.WriteLine("En la posición {0} se la secuencia fibonacci se encuentra el número {1}.", posicion, secuencia[posicion-1]);
            imprimeResultado(secuencia);
        }


        static void sumaElementos(List<int> secuencia, int posicion, int nuevoNumero) {
            

                if (secuencia.Count == 1){
                    secuencia.Add(1);    
                }

                nuevoNumero = creaNuevoElemento(secuencia, nuevoNumero);
                secuencia.Add(nuevoNumero);

                if (secuencia.Count < (posicion)){
                    // debugger Console.WriteLine("probando con "+secuencia[secuencia.Count-1]);
                    sumaElementos(secuencia, posicion, nuevoNumero);
                }
        }
        static int creaNuevoElemento(List<int> secuencia, int nuevoNumero){
            nuevoNumero = ((secuencia[secuencia.Count-2])+(secuencia[secuencia.Count-1]));
            return nuevoNumero;
        }

        static void imprimeResultado(List<int> secuencia){
            Console.WriteLine("\n La secuencia Fibonacci hasta el número que ingresaste es: ");
            for(int i =0; i<secuencia.Count;i++){
                Console.WriteLine(" {0}: {1} ",(i+1), secuencia[i]);
            }
        }
        
    }
}