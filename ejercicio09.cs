/* 9 Idem al anterior pero que devuelva un array con ambos cálculos: el área y el volumen. */

using System;
using System.Text.RegularExpressions;


namespace ejercicio09
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            float radio, altura;
            float[] ryH = new float[2];

            
            radio = pideRadio();
            altura = pideAltura();

            //volumen
            ryH[0] = calcVolumen(radio, altura);
            //area 
            ryH[1] = calcArea(radio, altura);
            
            informaResultados(ryH);

        }
                    
    

        

        static float calcVolumen(float r, float H) {
            float vol = 3.14159265359f * ((r)*(r)) * H;
            return vol;
        }
        
        static float calcArea(float r, float H) {
            float vol = ((2* 3.14159265359f * r* H)+(2* 3.14159265359f * ((r)*(r))));
            return vol;
        }

        static float pideRadio(){
            Console.WriteLine("Ingrese radio en centímetros (ejemplo \"24,2\"): ");
            float r = float.Parse(Console.ReadLine());
            return r;
        }
        static float pideAltura(){
            Console.WriteLine("Ingrese altura en centímetros (ejemplo \"40,0 o 40\"): ");
            float h = float.Parse(Console.ReadLine());
            return h;
        }
        
        static void informaResultados(float[] calculos){
            Console.WriteLine("El volumen es "+calculos[0]+" cm. y el área es "+calculos[1]+" cm.");
        }

    }
}