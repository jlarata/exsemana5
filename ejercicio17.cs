/* 17 Escribir una función que calcule el mínimo común múltiplo de los números contenidos en un array */

using System;

namespace ejercicio17
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            int MCM;
            int[] numeros = pideArrayDeNumeros();
            int[][] jaggedDeFactores = iteraFactorizaciones(numeros);
            //factores distintos: un array con la cantidad de factores distintos de cada
            // uno de los arrays en jaggedDeFactores. 
            int[] factoresDistintos = iteraFactoresDistintosPorNumero(jaggedDeFactores);
            int[][] factoresXCantidades = iteraFactoresPorCantidades(jaggedDeFactores, factoresDistintos);
            int[] factoresEnComun = iteraBuscaFactoresEnComun(factoresXCantidades); 
            int[] factoresIndividuales = iteraBuscaFactoresIndividuales(factoresEnComun, factoresXCantidades);

            if (factoresIndividuales.Length == 0){
                MCM = calculaMCMSimple(factoresEnComun);
            } else {
                MCM = calculaMCMComplejo(factoresEnComun, factoresIndividuales);
            }
            Console.WriteLine("El MCM es {0}", MCM);

            /*TODA LA INFORMACIÓN QUE LOS PIBES QUIEREN 
            Console.Write("\n\nEstos son los factores completos: ");
            imprimeArrayDeArraysCompleto(jaggedDeFactores);
            Console.WriteLine("\n\nEsta es la cantidad de factores distintos en cada factoreo: ");
            imprimeArrayCompleto(factoresDistintos);
            Console.WriteLine("\n\nEste es un array de factoreos expresado en pares de coefciente y potencia");
            imprimeArrayDeArraysCompleto(factoresXCantidades);
            Console.WriteLine("\n\nEstos son los factores en comun: ");
            imprimeArrayCompleto(factoresEnComun);
            Console.WriteLine("\n\nEstos son los factores individuales: ");
            imprimeArrayCompleto(factoresIndividuales);*/
        }
        static int[] pideArrayDeNumeros(){
            
            int cantNumeros = 0;
            
            Console.WriteLine("Ingrese un array de números enteros positivos separados por un espacio (ejempo 4 -2 513 1): ");
            string stringDeNumeros = Console.ReadLine();
            string[] arrayDeNumeros = stringDeNumeros.Split(' ', '"');
                        
            for (int i = 0; i<arrayDeNumeros.Length; i++){
                cantNumeros ++;
            }

            int [] numeros = new int [cantNumeros];

            for (int i = 0; i<arrayDeNumeros.Length; i++){
                numeros[i] = int.Parse(arrayDeNumeros[i]);
            }

            return numeros;
        }

        static int[][] iteraFactorizaciones(int[] numeros){
            
            int [][] factores = new int [numeros.Length][];
            int currentFactor = 0;

            foreach (int numero in numeros) {
                factores[currentFactor] = factoriza(numero);
                currentFactor++;
            }
            return factores;
        }

        static int[] iteraFactoresDistintosPorNumero(int[][] jaggedDeFactores){
            
            int [] factoresDistintos = new int [jaggedDeFactores.Length];
            int currentFactorizado = 0;

            foreach (int[] factor in jaggedDeFactores) {
                factoresDistintos[currentFactorizado] = calculaFactoresDistintos(factor);
                currentFactorizado++;
            }
            return factoresDistintos;
        }

        static int[][] iteraFactoresPorCantidades(int[][] jaggedDeFactores, int[] factoresDistintos){
            
            int [][] factoresXCantidades = new int [jaggedDeFactores.Length][];
            int currentFactorizado = 0;

            foreach (int[] factor in jaggedDeFactores) {
                factoresXCantidades[currentFactorizado] = calculaFactoresPorCantidades(jaggedDeFactores[currentFactorizado], factoresDistintos[currentFactorizado]);
                currentFactorizado++;
            }
            return factoresXCantidades;
        }

        static int[] iteraBuscaFactoresEnComun(int[][] factoresXCantidades){

            if (factoresXCantidades.Length == 1){
                Console.WriteLine("El MCM de un solo numero es el mismo número, felicidades!");
                Environment.Exit(0);
            }            
            
            int[] anteriorEnComun = devuelveFactoresEnComun(factoresXCantidades[0], factoresXCantidades[1]);
            
            for (int i=0;i<factoresXCantidades.Length;i++){
                //hay que frenar el loop cuando "i" esté en index del ante-último elemento
                if (i != (factoresXCantidades.Length-1)){
                    anteriorEnComun = devuelveFactoresEnComun(anteriorEnComun, factoresXCantidades[i+1]);
                    }
                }
                        
            int [] factoresEnComun = anteriorEnComun;
                        
            return factoresEnComun;
        }

        static int[] iteraBuscaFactoresIndividuales(int[] enComun, int[][] factoresXCantidades){

            int cantIndividuales = 0;
            
            for (int i=0;i<factoresXCantidades.Length;i++){
                int nuevosIndividuales = (devuelveFactoresIndividuales(enComun, factoresXCantidades[i]).Length);
                cantIndividuales += nuevosIndividuales;
            }
            int [] factoresIndividuales = new int[cantIndividuales];
            int currentFactorIndividual = 0;
            
            for (int i=0;i<factoresXCantidades.Length;i++){
                if ((devuelveFactoresIndividuales(enComun, factoresXCantidades[i]).Length) != 0){
                    
                    //todo es más simple ahora: al ser un array de int los puedo tratar uno por uno.
                    foreach (int factorIndividual in 
                    (devuelveFactoresIndividuales(enComun, factoresXCantidades[i]))
                            ){
                        factoresIndividuales[currentFactorIndividual] = factorIndividual;
                        currentFactorIndividual++;
                    }
                }
            }         
            return factoresIndividuales;
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

        static int[] calculaFactoresPorCantidades(int[] factor, int factoresDistintos) {
            
            //crea un array de arrays con una lenght igual a la cantida de factores distintos
            int[] arrayFactorporXCantidad = new int[factoresDistintos*2];
            //inicializa en el valor del primer factor y reserva en memoria el numero 0 como
            // indice del primer factor para la nueva arraya
            int currentFactor=factor[0], currentFactorIndex=0, currentCantidad=1;

            //la lógica es siempre comparar contra el que sigue
            for (int i=1; i<factor.Length; i++)
            {
                //si el que sigue es el mismo
                if (currentFactor == factor[i])
                    {
                        //nos mantenemos en el mismo factor, umamos uno a la cantidad
                        currentCantidad++;
                    } else {
                        //caso contrario, cerramos el primer factor como pareja de ints , 
                        //con su cantidad actualizada. la pareja la constituyen el numero y su coeficiente
                        arrayFactorporXCantidad[currentFactorIndex] = currentFactor;
                        arrayFactorporXCantidad[currentFactorIndex+1] = currentCantidad;
                        //pasamos al siguiente índice dos veces para el nuevo par de int
                        currentFactorIndex++;
                        currentFactorIndex++;
                        //actualizamos el valor del factor actual
                        currentFactor = factor[i];
                        //y reseteamos la cantidad
                        currentCantidad = 1;
                    }
            }

            //como la iteracion es hasta (i<último), hay que revisar el último item  x separado
            if (factor[factor.Length-1] == factor[factor.Length-2])
                {
                    arrayFactorporXCantidad[arrayFactorporXCantidad.Length-2] = currentFactor;
                    arrayFactorporXCantidad[arrayFactorporXCantidad.Length-1] = currentCantidad;
                } else {
                    arrayFactorporXCantidad[arrayFactorporXCantidad.Length-2] = factor[factor.Length-1];
                    arrayFactorporXCantidad[arrayFactorporXCantidad.Length-1] = currentCantidad;
                }

            return arrayFactorporXCantidad;
        }

        static int calculaMCMSimple(int[] array) {

            //para los casos en que no haya ningun factor no repetido.
            int MCM = 1;  
            for (int i=0; i<array.Length; i=i+2){
                MCM *= devuelvePotencia(array[i], array[i+1]);
            }

            return MCM;
        }

        static int calculaMCMComplejo(int[] array1, int[] array2) {

            int MCM = 1;  
            for (int i=0; i<array1.Length; i=i+2){
                MCM *= devuelvePotencia(array1[i], array1[i+1]);
            }
            for (int i=0; i<array2.Length; i=i+2){
                MCM *= devuelvePotencia(array2[i], array2[i+1]);
            }
            return MCM;
        }
        static int[] devuelveFactoresEnComun(int[] array1, int[] array2){
            
            int cantidadFactoresEnComun = 0;
            //primero hacer un array con todos los factores en comun
            for (int i=0; i<array1.Length; i=i+2){
                for (int j=0; j<array2.Length; j=j+2){
                    if ((array2[j]) == array1[i]){
                        cantidadFactoresEnComun++;
                        //debug Console.WriteLine("cantidad ahora: {0}", cantidadFactoresEnComun);
                        }
                    }
                }              
            //a poblar
            //debug Console.WriteLine("poblando");
            int[] factoresEnComun = new int[cantidadFactoresEnComun*2];
            int currentFactorComunIndex = 0;
                                
                //debug Console.WriteLine("lista 1 contra lista 2");
                for (int i=0; i<array1.Length; i=i+2){
                    for (int j=0; j<array2.Length; j=j+2){
                        if (array2[j] == array1[i]){
                        //una vez hallada la coincidencia, elijo la mayor potencia
                            if (array2[j+1] >= array1[i+1]){
                            //debug Console.WriteLine("{0} es mayor o igual que {1}", array2[j+1], array1[i+1]);
                                factoresEnComun[currentFactorComunIndex] = array2[j];
                                factoresEnComun[currentFactorComunIndex+1] = array2[j+1];
                            } else {
                                //debug Console.WriteLine("{0} es menor que {1}", array2[j+1], array1[i+1]);
                                factoresEnComun[currentFactorComunIndex] = array1[i];
                                factoresEnComun[currentFactorComunIndex+1] = array1[i+1];
                            } currentFactorComunIndex = currentFactorComunIndex +2;
                        }
                    }
                }
                                            
            //APARENTEMENTE AL HACER LAS COMPARACIONES DE A UNA YA NO SE GENERAN REPETIDOS Y PUEDO 
            //OBTENER LOS MAYORES EXPONENTES EN EL PROCESO SIN NECESIDAD DE UN PASO EXTRA.
            
            //ELIMINÉ EL MÉTODO OrderBay que los ordenaba y
            //ELIMINÉ LA FUNCIÓN devuelveSoloFactoresMayoresExponentes() ver ejercicio 16
            return factoresEnComun;
        }

        static int[] devuelveFactoresIndividuales(int[] enComun, int[] array){
            
            int cantidadFactoresIndividuales = 0;
            int hit = 0;
            
            for (int i=0; i<array.Length; i=i+2){
                hit = 1;
                for (int j=0; j<enComun.Length; j=j+2){    
                    if ((array[i] == enComun[j])){
                        //debug Console.WriteLine("hiteó el elemento: {0}, {1}", array[i], array[i+1]);
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

            //a poblar
            //debug Console.WriteLine("factores Individuales: {0}", cantidadFactoresIndividuales);
            int[] factoresIndividuales = new int[cantidadFactoresIndividuales*2];
            
            if (factoresIndividuales.Length == 0){
                return factoresIndividuales;
            } else {
                
                int currentFactorIndividualIndex = 0;
                
                for (int i=0; i<array.Length; i=i+2){
                    //debug Console.WriteLine("revisamos del array el numero {0}",array[i]);
                    hit = 0;
                    
                    for (int j=0; j<enComun.Length; j=j+2){
                        //debug Console.WriteLine("revisamos del EnComun el numero {0}",enComun[j]);
                        if ((array[i] == enComun[j])) {
                            hit =1;
                            }
                        }
                    if (hit == 0){
                        //debug Console.WriteLine("tenemos un ganador!");
                        factoresIndividuales[currentFactorIndividualIndex] = array[i];
                        factoresIndividuales[currentFactorIndividualIndex+1] = array[i+1];
                        currentFactorIndividualIndex = currentFactorIndividualIndex+2;
                        }
                    }
                }        
                return factoresIndividuales;
            }

        static int devuelvePotencia(int numero, int potencia){
            int resultado = 1;
            for (int i = 0; i<potencia; i++){
                resultado *= numero ;
                }
            return resultado;
            }

        static void imprimeArrayCompleto(int[] array){            
                Console.Write("\n [ ");
                for (int i = 0; i<array.Length; i++){
                    Console.Write(array[i]+" ");
                }
                Console.Write("]");
        }

        static void imprimeArrayDeArraysCompleto(int[][] arrayDeArrays){
            /*itera el array de arrays y los devuelve con la forma de array de factores [valor][coeficiente]*/
            Console.Write("\n [ ");
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