/*1. Armar una función, a la que se le pase como parámetro un número N, y muestre por pantalla N 
veces el mensaje: “Módulo ejecutándose”.*/

using System;

namespace ejercicio01
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int numeroVecesPrint;

            Console.WriteLine("Ingrese el número de repeticiones: ");

            numeroVecesPrint = int.Parse(Console.ReadLine());

            RepitePrint(numeroVecesPrint);

            
        }

        static void RepitePrint(int veces) {
                for (int i = 0; i < veces; i++){
                    Console.WriteLine("Módulo ejecutándose");
                }
            }
    }
}