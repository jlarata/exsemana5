/* 22.  	Escribir una función que sume los n primeros números impares.*/

using System;

namespace ejercicio22
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int valorTecho, sumaDeImpares=0;
            Console.WriteLine("Ingrese el tope de números impares a sumar: ");
            //como por cada numero impar hay otro impar, el techo para iterar es el doble de los "N" a buscar.
            valorTecho = (int.Parse(Console.ReadLine())*2);
         
            for (int i=0; i<=valorTecho;i++){
                if (!(esPar(i))){
                    sumaDeImpares+=i;
                }
            }

            Console.WriteLine("La suma de los primeros {0} números impares es {1}", (valorTecho/2), sumaDeImpares);

         
        }

        static bool esPar(int valor){
            if (valor % 2 == 0){
                return true;
            }
            return false;
        }
    }
}