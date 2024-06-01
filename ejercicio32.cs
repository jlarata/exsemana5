/*bir una función que dado un número natural, escriba por pantalla su secuencia de la Conjetura de Collatz
 y que devuelva la longitud o cantidad de pasos que tiene hasta llegar al primer 1.*/

using System;

namespace ejercicio32
{
    internal class Program
    {
        static void Main(string[] args)
        {        
        
        int numero, cantidadDePasos;
        
        Console.WriteLine("Ingrese un número entero positivo: ");
        numero = int.Parse(Console.ReadLine());
        cantidadDePasos = conjeturaCollatz(numero);
        Console.WriteLine("La longitud de la conjetura de Collatz para el número {0} es {1}.", numero, cantidadDePasos);
        }

        static int conjeturaCollatz(int numero){
            
            int numeroBuffer, cantidadDePasos = 0;
            
            while (numero > 1)
            {
                if (esPar(numero)){
                    Console.WriteLine("{0} es par, se lo divide por dos y se obtiene {1}", numero, (numero/2));
                    numeroBuffer = (numero/2);
                    numero = numeroBuffer;
                    cantidadDePasos ++;
                } else {
                    Console.WriteLine("{0} es impar, se lo multiplica por tres y se le suma 1, obteniéndose {1}", numero, ((numero*3)+1));
                    numeroBuffer = ((numero*3)+1);
                    numero = numeroBuffer;
                    cantidadDePasos ++;
                }
            }
            
            Console.WriteLine("\nEl número ha llegado a {0}, secuencia terminada.", numero);

            return cantidadDePasos;
        }

        static bool esPar(int valor){
            if (valor % 2 == 0){
                return true;
            }
            return false;
        }
        
    }
}