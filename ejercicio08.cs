/* 8. Se necesita una función que calcule y muestre en pantalla el área o el volumen de un cilindro,
 según se especifique. Para distinguir un caso de otro, además de pasarle por parámetro el radio y la altura,
  se le pasará el carácter ’a’ (para área) o ’v’ (para el volumen). */

using System;
using System.Text.RegularExpressions;


namespace ejercicio08
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            float area, volumen;
            string eleccion;

            eleccion = decideMedicion();

            if (eleccion == "v") {
                volumen = calcVolumen();
                Console.WriteLine("El volumen es "+volumen+" cm.");
            } else {
                area = calcArea();
                Console.WriteLine("El área es "+area+" cm.");
            }
                    
        }

        static string decideMedicion() {
            string eleccion = "f";
            string regexPattern = "a|v";
            Regex regex = new Regex(regexPattern);
            
    
            Console.WriteLine("Se calculará el área o el volumen de un cilindro.");
            Console.WriteLine("Ingrese \"v\" para volumen o \"a\" para el área de su superficie: ");
            eleccion = Console.ReadLine().ToLower();
            Match match = regex.Match(eleccion);

            while (!match.Success) {
                Console.WriteLine("Ingreso incorrecto. Pruebe de nuevo");
                Console.WriteLine("Ingrese \"v\" para volumen o \"a\" para el área de su superficie: ");
                eleccion = Console.ReadLine().ToLower();
                match = regex.Match(eleccion);
            }

            return eleccion;
            }

        static float calcVolumen() {
            float r = pideRadio();
            float H = pideAltura();
            float vol = 3.14159265359f * ((r)*(r)) * H;
            return vol;
        }
        
        static float calcArea() {
            float r = pideRadio();
            float H = pideAltura();
            float vol = (2* 3.14159265359f * r* H)+ (2* 3.14159265359f * ((r)*(r)));
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
        
    }
}