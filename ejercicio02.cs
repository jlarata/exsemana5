/* 2. Escribir una función que nos salude, pasándole un nombre por parámetro. Su salida debe decir por
 ejemplo ”Hola Aristoteles, ¿cómo estás?”..*/

using System;

namespace ejercicio02
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            string nombre;

            Console.WriteLine("Ingrese su nombre: ");

            nombre = Console.ReadLine();

            saluda(nombre);

            
        }

        static void saluda(string nombre) {
                
                Console.WriteLine("Hola, "+ nombre);
            }
    }
}