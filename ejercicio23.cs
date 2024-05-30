/*Escribir una función que calcule la distancia euclídea entre dos puntos del plano. Tener en cuenta que la
 función debe recibir 4 parámetros: las 2 coordenadas del primer punto y las 2 coordenadas del segundo punto. */

using System;


namespace ejercicio23
{
    internal class Program
    {
        
        

        static void Main(string[] args)
        {        

            /* primero se ingresan cuatro coordenadas x1, y1, x2, y2
            c1 = cateto 1 (el y mayor contra el y menor, o mejor, la diferencia entre sus valores absolutos)
            c2 = cateto 2
            distancia = raiz cuadrada (pow(c1)+pow(c2))*/

            double[][] paresDeCoordenadas = pideValores();
            double[] catetos = calculaCatetos(paresDeCoordenadas);
            double hipotenusa = calculaHipotenusa(catetos[0], catetos[1]);
            
            /*string cateto1 = catetos[0].ToString();
            string cateto2 = catetos[1].ToString();
            Console.WriteLine("cateto 1: "+cateto1);
            Console.WriteLine("cateto 2: "+cateto2);
            */
            
            string distancia = hipotenusa.ToString();
            Console.WriteLine("La distancia euclídea entre los dos puntos señalados es {0}: ",distancia);

            /*string resultado = (paresDeCoordenadas[0][0]*paresDeCoordenadas[0][1]).ToString();
            Console.WriteLine(resultado);*/
            
            /*probando math
            double numero = 9;
            double raiz = Math.Sqrt(numero);
            double potenciaCuadrada = Math.Pow(numero, 2);
            Console.WriteLine(raiz);
            Console.WriteLine(potenciaCuadrada);*/
        }

        static double[][] pideValores(){
            
            double [][] paresDeCoordenadas = new double [2][];
            paresDeCoordenadas[0] = new double[2];
            paresDeCoordenadas[1] = new double[2];

            Console.WriteLine("\n Primera coordenada: Ingrese X");
            paresDeCoordenadas[0][0] = double.Parse(Console.ReadLine());

            Console.WriteLine("Primera coordenada: Ingrese Y");
            paresDeCoordenadas[0][1] = double.Parse(Console.ReadLine());

            Console.WriteLine("Segunda coordenada: Ingrese X");
            paresDeCoordenadas[1][0] = double.Parse(Console.ReadLine());

            Console.WriteLine("Segunda coordenada: Ingrese Y");
            paresDeCoordenadas[1][1] = double.Parse(Console.ReadLine());

            return paresDeCoordenadas;
        }
        static double[] calculaCatetos(double[][] paresDeCoordenadas){
            double[] catetos = new double[2];

            catetos[0] = Math.Abs(paresDeCoordenadas[0][0] - paresDeCoordenadas[1][0]);
            catetos[1] = Math.Abs(paresDeCoordenadas[0][1] - paresDeCoordenadas[1][1]);

            return catetos;
        }
        static double calculaHipotenusa(double cateto1, double cateto2){

            double hipotenusa = Math.Sqrt(Math.Pow(cateto1, 2) + Math.Pow(cateto2, 2));
            return hipotenusa;
        }
    }
}