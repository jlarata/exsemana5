/*21.   Crear una función que pasando un número decimal, lo devuelva en hexadecimal.
 Haz otra función que dado un número en hexadecimal, lo devuelva en decimal..*/

using System;

namespace ejercicio30
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int num1;
            string num2;

            Console.WriteLine("Ingrese un número decimal: ");
            num1 = int.Parse(Console.ReadLine());
                     
            Console.WriteLine("{0} en decimal equivale a {1} en hexadecimal", num1, traduceAHexa(num1));


            Console.WriteLine("Ahora ingrese un número en Hexadecimal (ejemplo: 3D): ");
            num2 = Console.ReadLine().ToUpper();
                     
            Console.WriteLine("{0} en hexadecimal equivale a {1} en decimal", num2, traduceADecimal(num2));
            
        }

        static string traduceAHexa(int numeroDecimal){
            
            int cociente;
            string hexa = "", newHexa="", resto="";
            
            while ((numeroDecimal/16) >= 15){
                newHexa = traduceMayores(((numeroDecimal%16).ToString()));
                hexa = newHexa += hexa;

                cociente = numeroDecimal/16;
                numeroDecimal = cociente;
            }
            
            resto = traduceMayores((numeroDecimal%16).ToString());
            
            if ((numeroDecimal/16)>0){
                newHexa = traduceMayores(((numeroDecimal/16).ToString()));
                newHexa += resto;
                newHexa += hexa;
                hexa = newHexa;
            } else {
                newHexa = resto;
                newHexa += hexa;
                hexa = newHexa;
            }
            

            return hexa;
        }

        static int traduceADecimal(string hexa){
            
            int numDecimal = 0;

            for (int i=(hexa.Length-1); i>-1;i--){
                
                /*Console.WriteLine("num");
                Console.WriteLine(traduceDeMayores(hexa[i].ToString()));
                Console.WriteLine("*16");
                Console.WriteLine(traduceDeMayores(hexa[i].ToString())*16);
                Console.WriteLine("a la {0}", (hexa.Length-(i+1)));
                Console.WriteLine((traduceDeMayores(hexa[i].ToString())*devuelvePotencia(16, (hexa.Length-(i+1)))));*/

                numDecimal += ((traduceDeMayores(hexa[i].ToString())*devuelvePotencia(16, (hexa.Length-(i+1)))));
                
            }

            return numDecimal;
        }

        static string traduceMayores(string hexa){

            string[] diccionario = {"A", "10", "B", "11", "C", "12", "D", "13", "E", "14", "F", "15", "G", "16"};
            
            for (int i=0; i<diccionario.Length; i++){
                if (diccionario[i] == hexa){
                    hexa = diccionario[i-1];
                }
                
            } return hexa;
            
        }
        

        static int traduceDeMayores(string hexa){

            string[] diccionario = {"A", "10", "B", "11", "C", "12", "D", "13", "E", "14", "F", "15", "G", "16"};
            int charAInt;

            for (int i=0; i<(diccionario.Length-1); i++){
                if (diccionario[i] == hexa){
                    hexa = diccionario[i+1];
                    charAInt = int.Parse(hexa.ToString());
                    //Console.WriteLine(charAInt);
                    return charAInt;
                }    
            }
            charAInt = int.Parse(hexa.ToString());
            return charAInt;
            
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

