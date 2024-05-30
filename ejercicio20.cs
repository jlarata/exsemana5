/* 20 Escribir una función que reciba los parámetros a y n; y calcule la potencia n de a. (a  n). */

using System;

namespace ejercicio20
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            Console.WriteLine("Ingrese el número: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la potencia: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("{0}^{1} = {2}", num1, num2, devuelvePotencia(num1, num2));
        }
    
        static int devuelvePotencia(int numero, int potencia){
            int resultado = 1;
            for (int i = 0; i<potencia; i++){
                resultado *= numero ;
                }
            return resultado;
            }
    }
}