/*21.   Escribir una función que muestre en binario un número entre 0 y 255.*/

using System;

namespace ejercicio21
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int num1;
            
            Console.WriteLine("Ingrese un número entre 0 y 255: ");
            num1 = int.Parse(Console.ReadLine());
            while ((num1 < 0) || (num1 > 255)){
                Console.WriteLine("Ingreso erroneo.\nPor favor ingrese un número entre 0 y 255: ");
                num1 = int.Parse(Console.ReadLine());
            }
         
            Console.WriteLine("{0} en decimal equivale a {1} en binario", num1, traduceABinario(num1));
        }

        static string traduceABinario(int numeroDecimal){
            
            int cociente;
            string binario = "", newBinario="";
            
            while ((numeroDecimal/2) >= 1){
                newBinario = (numeroDecimal%2).ToString();
                newBinario += binario;
                binario = newBinario;

                cociente = numeroDecimal/2;
                numeroDecimal = cociente;
            }
            newBinario = numeroDecimal.ToString();
            newBinario += binario;
            binario = newBinario;
            
            return binario;
        }
    }
}

