/* 7. Armar una función que muestre en pantalla el doble del valor que se le pasa como parámetro.*/

using System;

namespace ejercicio07
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int valor, duplicado;

            Console.WriteLine("Ingrese un valor: ");
            valor = int.Parse(Console.ReadLine());

            duplicado = duplica(valor);

            Console.WriteLine("El valor duplicado equivale a "+duplicado);
            
        }

        static int duplica(int valor) {
            int duplicado;
            duplicado = valor * 2;
            return duplicado;
        }
    }
}