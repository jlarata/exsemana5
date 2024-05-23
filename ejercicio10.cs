/* 10. Crear una función a la que se le pasa un número entero y devuelve la cantidad de divisores primos 
que tiene. */

using System;

namespace ejercicio10
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int valor, cantidadDivisores;
            

            Console.WriteLine("Ingrese un valor: ");
            valor = int.Parse(Console.ReadLine());

            cantidadDivisores = buscaDivisores(valor);
            
            comunicaCantidad(cantidadDivisores);
            
        }

        static int buscaDivisores(int valor) {
            
            int cantidadDivisores = 0;

            for (int i=1; i<valor; i++){
            
                if (valor % i == 0){
                    if (esPrimo(i)) {
                        cantidadDivisores++;
                    }
                    
                }
            }

            return cantidadDivisores;
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

        static void comunicaCantidad(int cantidad){
                Console.WriteLine(cantidad);
            }
    
    }
}