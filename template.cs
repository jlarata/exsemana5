using System;

namespace ejercicio
{
    internal class Program
    {
        static void Main(string[] args)
        {        
        
        int[] par = {1, 2};
        
        Console.WriteLine("{0}, {1}", par[0], par[1]); 

        par = intercambiar(par[0], par[1]);
        
        Console.WriteLine("{0}, {1}", par[0], par[1]); 
        }

        static int[] intercambiar (int a, int b){
            int[] parInvertido = {b, a};
            return parInvertido;
        }
    }
}