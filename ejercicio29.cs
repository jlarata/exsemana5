/*21.   Crear una función que pasando un número decimal, lo devuelva en binario.
 Haz otra función que dado un binario binario , nos devuelva su número decimal. 
 
 Para representar un número en binario se puede usar por ejemplo una cadena de caracteres como el string ”0011”
  representa el número 3, aunque también se puede usar un número del tipo long.*/

using System;

namespace ejercicio29
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int num1;
            string num2;

            Console.WriteLine("Ingrese un número decimal: ");
            num1 = int.Parse(Console.ReadLine());
                     
            Console.WriteLine("{0} en decimal equivale a {1} en binario", num1, traduceABinario(num1));

            Console.WriteLine("Ingrese un número binario: ");
            num2 = Console.ReadLine();
                     
            Console.WriteLine("{0} en binario equivale a {1} en decimal", num2, traduceBinarioADecimal(num2));
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

        static int traduceBinarioADecimal(string numeroBinario){
            
            int enDecimal = 0;
            int potencia = 0;
            for (int i = (numeroBinario.Length-1); i>-1; i--)
            {
                /*numerobinario es un string, señalar un objeto con indice es señalar un char.
                por MOTIVOS no corresponde pasar de char a int, sino pasarlo primero a string.
                
                Use the GetNumericValue methods to convert a Char object that represents a number to a
                numeric value type. Use Parse and TryParse to convert a character in a string into a Char
                 object. Use ToString to convert a Char object to a String object.
                 
                 http://msdn.microsoft.com/en-us/library/system.char.aspx */

                int charAInt = int.Parse(numeroBinario[i].ToString());

                //uso mi propia funcion en lugar de Math.Pow para no tener que andar transformando entre
                //doubles y ints (todos los Math devuelven doubles y piden doubles)
                
                enDecimal += (charAInt*(devuelvePotencia(2, potencia)));

                potencia++;
            }
            
            return enDecimal;
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

