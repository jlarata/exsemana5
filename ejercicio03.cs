/* Diseñar una función que tenga como parámetros dos números, y que calcule el máximo.*/

using System;

namespace ejercicio03
{
    internal class Program
    {
        static void Main(string[] args)
        {                   
            var numeros = Tuple.Create(0, 0);
            numeros = pideNumeros();
            
            BuscaElMayor(numeros);
        }

        public static Tuple<int, int> pideNumeros() {
            
            int num1, num2;

            Console.WriteLine("Ingrese el primer número: ");
            num1 = int.Parse(Console.ReadLine());          
            Console.WriteLine("Ingrese el segundo número: ");
            num2 = int.Parse(Console.ReadLine());
            
            return Tuple.Create(num1, num2);
            }

        static void BuscaElMayor(Tuple<int, int> tuple) {
                if (tuple.Item1 > tuple.Item2){
                    Console.WriteLine("El mayor es el número "+(tuple.Item1));    
                } else if (tuple.Item2 > tuple.Item1) {
                    Console.WriteLine("El mayor es el número "+(tuple.Item2));    
                } else {
                    Console.WriteLine("Se ingresó dos veces el mismo número, son iguales");
                }
            }
    }
}