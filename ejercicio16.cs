/* 16 Escribir una función que calcule el mínimo común múltiplo de tres números.  */

using System;
using System.Linq;

namespace ejercicio16
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int num1, num2, num3, factoresDistintos1, factoresDistintos2, factoresDistintos3, MCM;
            int [] fact1, fact2, fact3;

            int[][] factoresXCantidades1, factoresXCantidades2, factoresXCantidades3, factoresEnComun, factoresIndividuales;


            Console.WriteLine("Ingrese el primer valor: ");
            num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el segundo valor: ");
            num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el tercer valor: ");
            num3 = int.Parse(Console.ReadLine());

            fact1 = factoriza(num1);
            fact2 = factoriza(num2);
            fact3 = factoriza(num3);

            factoresDistintos1 = calculaFactoresDistintos(fact1);
            factoresDistintos2 = calculaFactoresDistintos(fact2);
            factoresDistintos3 = calculaFactoresDistintos(fact3);

            factoresXCantidades1 = calculaFactoresPorCantidades(fact1, factoresDistintos1);
            factoresXCantidades2 = calculaFactoresPorCantidades(fact2, factoresDistintos2);
            factoresXCantidades3 = calculaFactoresPorCantidades(fact3, factoresDistintos3);
            
            factoresEnComun = devuelveFactoresEnComun(factoresXCantidades1, factoresXCantidades2, factoresXCantidades3);                        
            factoresIndividuales = devuelveFactoresIndividuales(factoresEnComun, factoresXCantidades1, factoresXCantidades2, factoresXCantidades3);
            
            if (factoresIndividuales.Length == 0){
                MCM = calculaMCMSimple(factoresEnComun);
            } else {
                MCM = calculaMCMComplejo(factoresEnComun, factoresIndividuales);
            }
            
            Console.WriteLine("El MCM es {0}", MCM);
            

            /* algunos print utiles
            imprimeArrayDeArraysCompleto(factoresXCantidades1);
            imprimeArrayDeArraysCompleto(factoresXCantidades2);
            imprimeArrayDeArraysCompleto(factoresXCantidades3);
            imprimeArrayDeArraysCompleto(factoresEnComun);
            imprimeArrayDeArraysCompleto(factoresIndividuales);
            */
        }          

        static int[] factoriza(int valor) {
            int copiaValor = valor;
            int cantidadParaArray = 0;
            
            //la factorización termina cuando el valor sea 1
            while(!(valor == 1)){
                
                //mientras tanto, y arrancando en 2 (y con máximo = a valor) el bucle
                int currentDivisor = 2;

                while (!(valor % currentDivisor == 0)) {
                    currentDivisor++;
                }
                valor = valor / currentDivisor;
                cantidadParaArray++;              
            }

            int[] arrayDeDivisores = new int[cantidadParaArray];
            int currentElementoDelArrayDeDivsores = 0;

        //repite el bucle, ahora para poblar el array
            while(!(copiaValor == 1)){
                
                int currentDivisor = 2;
            
                while (!(copiaValor % currentDivisor == 0)) {
                    currentDivisor++;
                }
                
                arrayDeDivisores[currentElementoDelArrayDeDivsores] = currentDivisor;
                currentElementoDelArrayDeDivsores++;

                copiaValor = copiaValor / currentDivisor;
            }

            return arrayDeDivisores;
        }

        static int calculaFactoresDistintos(int[] array){
            int currentFactor = 0;
            int factoresDistintos = 1;
            
            for (int i = 0; i<(array.Length-1);i++){
                if (array[currentFactor] != array[currentFactor+1]){
                    factoresDistintos++;
                    currentFactor++;
                } else {
                    currentFactor++;
                    }
            }
            //Console.Write("{0} factores distintos", factoresDistintos);
            return factoresDistintos;
        }

        static int[][] calculaFactoresPorCantidades(int[] factor, int factoresDistintos) {
            
            //crea un array de arrays con una lenght igual a la cantida de factores distintos
            int[][] arrayFactorporXCantidad = new int[factoresDistintos][];
            //inicializa en el valor del primer factor y reserva en memoria el numero 0 como indice del primer factor para la nueva arraya
            int currentFactor=factor[0], currentFactorIndex=0, currentCantidad=1;

            //la lógica es siempre comparar contra el que sigue
            for (int i=1; i<factor.Length; i++)
            {
                //si el que sigue es el mismo
                if (currentFactor == factor[i])
                    {
                        //nos mantenemos en el mismo factor, umamos uno a la cantidad
                        currentCantidad++;
                    } else { //caso contrario, cerramos el primer factor, con su cantidad actualizada
                        //el array siempre va a tener lenght 2: el numero y su coeficiente
                        arrayFactorporXCantidad[currentFactorIndex] = new int[2] {currentFactor, currentCantidad};
                        //pasamos al siguiente índice factor para el nuevo arraya
                        currentFactorIndex++;
                        //actualizamos el valor del factor actual
                        currentFactor = factor[i];
                        //y reseteamos la cantidad
                        currentCantidad = 1;
                    }
            }

            //como la iteracion es hasta (i<último), hay que revisar el último item del array x separado
            if (factor[factor.Length-1] == factor[factor.Length-2])
                {
                    arrayFactorporXCantidad[arrayFactorporXCantidad.Length-1] = new int[2] {currentFactor, currentCantidad};
                } else {
                    arrayFactorporXCantidad[arrayFactorporXCantidad.Length-1] = new int[2] {factor[factor.Length-1], currentCantidad};
                }

            return arrayFactorporXCantidad;
        }

        static int calculaMCMSimple(int[][] array) {

            //para los casos en que no haya ningun factor no repetido.
            int MCM = 1;  
            for (int i=0; i<array.Length; i++){
                MCM *= devuelvePotencia(array[i][0], array[i][1]);
            }

            return MCM;
        }

        static int calculaMCMComplejo(int[][] array1, int[][] array2) {

            int MCM = 1;  
            for (int i=0; i<array1.Length; i++){
                MCM *= devuelvePotencia(array1[i][0], array1[i][1]);
            }
            for (int i=0; i<array2.Length; i++){
                MCM *= devuelvePotencia(array2[i][0], array2[i][1]);
            }

            return MCM;
        }
                

        static int[][] devuelveFactoresEnComun(int[][] array1, int[][] array2, int[][] array3){
            int cantidadFactoresEnComun = 0;
            //primero hacer un array con todos los factores en comun, aunque se repitan
            //luego revisar repeticiones, no hay otra
            for (int i=0; i<array1.Length; i++){
                for (int j=0; j<array2.Length; j++){
                    if ((array2[j][0]) == array1[i][0]){
                        cantidadFactoresEnComun++;
                        //debug Console.WriteLine("cantidad ahora: {0}", cantidadFactoresEnComun);
                        }
                    }
                }
            for (int i=0; i<array1.Length; i++){
                for (int k=0; k<array3.Length; k++){
                    //debug Console.WriteLine("probando {0}", array3[k][0]);
                    if (array3[k][0] == array1[i][0]){
                        cantidadFactoresEnComun++;
                        //debug Console.WriteLine("cantidad ahora: {0}", cantidadFactoresEnComun);
                    }
                }
            }

            for (int i=0; i<array2.Length; i++){
                for (int k=0; k<array3.Length; k++){
                    //debug Console.WriteLine("probando {0}", array3[k][0]);
                    if (array2[i][0] == array3[k][0]){
                        cantidadFactoresEnComun++;
                        //debug Console.WriteLine("cantidad ahora: {0}", cantidadFactoresEnComun);
                    }
                }
            }
            //debug Console.WriteLine("\ncantidad factores comun {0}", cantidadFactoresEnComun);
                

            //a poblar
            //debug Console.WriteLine("poblando");
            int[][] factoresEnComun = new int[cantidadFactoresEnComun][];
            int currentFactorComunIndex = 0;

                
                //debug Console.WriteLine("\nlista 2 contra lista 3");
                for (int j=0; j<array2.Length; j++){
                    for (int k=0; k<array3.Length; k++){
                        //debug Console.WriteLine("{0} array3 y {1} array 2", array3[k][0], array2[j][0]);
                        if (array3[k][0] == array2[j][0]){
                            //una vez hallada la coincidencia, elijo la mayor potencia
                            if (array3[k][1] >= array2[j][1]){
                                //debug Console.WriteLine("{0} es mayor o igual que {1}", array3[k][1], array2[j][1]);
                                factoresEnComun[currentFactorComunIndex] = array3[k];
                                currentFactorComunIndex++;
                                } else {
                                //debug Console.WriteLine("{0} es menor que {1}", array3[k][1], array2[j][1]);
                                //Console.WriteLine("pim");
                                factoresEnComun[currentFactorComunIndex] = array2[j];
                                currentFactorComunIndex++;
                                }
                            }
                        }
                    }
                
                //debug Console.WriteLine("lista 1 contra lista 2");
                for (int i=0; i<array1.Length; i++){
                    for (int j=0; j<array2.Length; j++){
                        if (array2[j][0] == array1[i][0]){
                        //una vez hallada la coincidencia, elijo la mayor potencia
                            if (array2[j][1] >= array1[i][1]){
                            //debug Console.WriteLine("{0} es mayor o igual que {1}", array2[j][1], array1[i][1]);
                                factoresEnComun[currentFactorComunIndex] = array2[j];
                                currentFactorComunIndex++;
                            } else {
                                //debug Console.WriteLine("{0} es menor que {1}", array2[j][1], array1[i][1]);
                                factoresEnComun[currentFactorComunIndex] = array1[i];
                                currentFactorComunIndex++;
                            }
                        }
                    }
                }
                                 
                //debug Console.WriteLine("lista 1 contra lista 3");
                for (int i=0; i<array1.Length; i++){
                    for (int j=0; j<array3.Length; j++){
                        //debug Console.WriteLine("{0} array 3, {1} array 1", array3[j][0], array1[i][0]);
                        if (array3[j][0] == array1[i][0]){
                            //una vez hallada la coincidencia, elijo la mayor potencia
                            if (array3[j][1] >= array1[i][1]){
                                //Console.WriteLine("{0} es mayor o igual que {1}", array3[j][1], array1[i][1]);
                                factoresEnComun[currentFactorComunIndex] = array3[j];
                                currentFactorComunIndex++;
                                } else {
                                //debug Console.WriteLine("{0} es menor que {1}", array3[j][1], array1[i][1]);
                                factoresEnComun[currentFactorComunIndex] = array1[i];
                                currentFactorComunIndex++;
                                }
                            }
                    }
                }

            //me falta limpiar los factores en comun para que solo quede el mayor exponente de cada uno.
            
            //debug Console.WriteLine("\n Cantidad de factores en comun: {0}", cantidadFactoresEnComun);
            //los ordena
            factoresEnComun = factoresEnComun.OrderBy(j=>j.Skip(0).First()).ToArray(); 
            
            //debug imprimeArrayDeArraysCompleto(factoresEnComun);
        
            int[][] factoresMayores = devuelveSoloFactoresMayoresExponentes(factoresEnComun);
            return factoresMayores;
        }

        static int[][] devuelveSoloFactoresMayoresExponentes(int[][] array){
            int cantidadFactores = 1;

            //debug Console.WriteLine("\ncalculando cantidad de factores");
            for (int i=0; i<(array.Length-1);i++){
                //debug Console.WriteLine("elemento {0}", array[i][0]);
                if (array[i+1][0] != array[i][0])
                {
                    cantidadFactores ++;
                }
            }
            //debug onsole.WriteLine("cantidad de factores: {0}", cantidadFactores);
            int[][] factoresMayores = new int[cantidadFactores][];
            int currentArrayIndex = 0;
            
            //debug Console.WriteLine("poblando");
            for (int i=0; i<(array.Length-1);i++){
                //debug Console.WriteLine("probando {0}, {1}", array[i+1][0], array[i+1][1]);
                if (array[i+1][0] != array[i][0]){
                    currentArrayIndex ++;
                } else {
                    if (array[i+1][1] >= array[i][1]){
                        factoresMayores[currentArrayIndex] = array[i+1];
                    } else {
                        factoresMayores[currentArrayIndex] = array[i];
                    }
                }
            }
            return factoresMayores;
        }


        static int[][] devuelveFactoresIndividuales(int[][] enComun, int[][] array1, int[][] array2, int[][] array3){
            
            int cantidadFactoresIndividuales = 0;
            int hit = 0;

            for (int i=0; i<array1.Length; i++){
                hit = 1;
                for (int j=0; j<enComun.Length; j++){    
                    if ((array1[i][0] == enComun[j][0])){
                        //debug Console.WriteLine("hiteó el elemento: {0}, {1}", array1[i][0], array1[i][1]);
                        hit = 0;
                        }
                    }
                    if (hit == 1){
                    cantidadFactoresIndividuales++;
                    //debug Console.WriteLine("se suma 1");
                    hit = 0;
                    }
                }
                //debug Console.WriteLine("a factores Individuales: {0}", cantidadFactoresIndividuales);

            for (int i=0; i<array2.Length; i++){
                hit = 1;
                for (int j=0; j<enComun.Length; j++){
                        if ((array2[i][0] == enComun[j][0])){
                            //debug Console.WriteLine("hiteó el elemento: {0}, {1}", enComun[j][0], enComun[j][1]);
                            hit = 0;
                        }
                    }
                if (hit == 1){
                    cantidadFactoresIndividuales++;
                    hit = 0;
                    }
                }
                    //debug Console.WriteLine("bfactores Individuales: {0}", cantidadFactoresIndividuales);

            for (int i=0; i<array3.Length; i++){
                hit = 1;
                for (int j=0; j<enComun.Length; j++){
                        if ((array3[i][0] == enComun[j][0])){
                            hit = 0;
                        //debug Console.WriteLine("hiteó el elemento: {0}, {1}", enComun[j][0], enComun[j][1]);
                        }
                    }
                if (hit == 1){
                    cantidadFactoresIndividuales++;
                    hit = 0;
                    }
                }    
                    //debug Console.WriteLine("bfactores Individuales: {0}", cantidadFactoresIndividuales);

            //a poblar
            //debug Console.WriteLine("factores Individuales: {0}", cantidadFactoresIndividuales);
            int[][] factoresIndividuales = new int[cantidadFactoresIndividuales][];
            
            if (factoresIndividuales.Length == 0){
                return factoresIndividuales;
            } else {
                
                int currentFactorIndividualIndex = 0;

                for (int i=0; i<array1.Length; i++){
                    for (int j=0; j<enComun.Length; j++){    
                    if ((array1[i][0] != enComun[j][0])){
                        factoresIndividuales[currentFactorIndividualIndex] = array1[i];
                        currentFactorIndividualIndex++;
                        }
                    }  
                }
                for (int i=0; i<array2.Length; i++){
                    for (int j=0; j<enComun.Length; j++){    
                    if ((array2[i][0] != enComun[j][0])){
                        factoresIndividuales[currentFactorIndividualIndex] = array2[i];
                        currentFactorIndividualIndex++;
                        }
                    }  
                }
                for (int i=0; i<array3.Length; i++){
                    for (int j=0; j<enComun.Length; j++){    
                    if ((array3[i][0] != enComun[j][0])){
                        factoresIndividuales[currentFactorIndividualIndex] = array3[i];
                        currentFactorIndividualIndex++;
                        }
                    }  
                }
                return factoresIndividuales;
            }
        }


        static int devuelvePotencia(int numero, int potencia){
            int resultado = 1;
            for (int i = 0; i<potencia; i++){
                resultado *= numero ;
                }
            return resultado;
            }

        static void imprimeArrayCompleto(int[] array){            
                Console.Write("[ ");
                for (int i = 0; i<array.Length; i++){
                    Console.Write(array[i]+" ");
                }
                Console.Write("]");
        }

        static void imprimeArrayDeArraysCompleto(int[][] arrayDeArrays){
            /*itera el array de arrays y los devuelve con la forma de array de factores [valor][coeficiente]*/

            Console.WriteLine("");
            Console.Write("[ ");
            for (int i=0;i<arrayDeArrays.Length;i++){
                for (int j = 0; j<arrayDeArrays[i].Length;j++){
                    Console.Write(arrayDeArrays[i][j]);

                    if (j<(arrayDeArrays[i].Length-1)){
                        Console.Write(", ");
                    }
                    
                }
                if (i < (arrayDeArrays.Length-1)){
                    Console.Write(" ], [ ");
                }                
            }
            Console.Write(" ]");
        }
    }
}