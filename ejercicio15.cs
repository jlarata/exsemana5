/* 15 Escribir una función que calcule el mínimo común múltiplo de dos números */

using System;

namespace ejercicio15
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            int num1, num2, factoresDistintos1, factoresDistintos2;//, MCM;
            int [] fact1, fact2, factoresRepetidos;
            int[][] factoresXCantidades1, factoresXCantidades2;


            Console.WriteLine("Ingrese el primer valor: ");
            num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el segundo valor: ");
            num2 = int.Parse(Console.ReadLine());

            fact1 = factoriza(num1);
            fact2 = factoriza(num2);

            factoresDistintos1 = calculaFactoresDistintos(fact1);
            factoresDistintos2 = calculaFactoresDistintos(fact2);

            factoresXCantidades1 = calculaFactoresPorCantidades(fact1, factoresDistintos1);
            factoresXCantidades2 = calculaFactoresPorCantidades(fact2, factoresDistintos2);

            imprimeArrayDeArraysCompleto(factoresXCantidades1);
            imprimeArrayDeArraysCompleto(factoresXCantidades2);

            factoresRepetidos = calculaFactoresRepetidos(factoresXCantidades1, factoresXCantidades2);
            Console.WriteLine("");
            //debug imprimeArrayCompleto(factoresRepetidos);

            int MCM = calculaMCM(factoresXCantidades1, factoresXCantidades2, factoresRepetidos);
            
            Console.WriteLine("El MCM es {0}", MCM);
        }   
            

            //PROBLEMA
            //la primera iteracion (todos los de la primera factoresXcantidades1) va a dar bien
            //pero si después hago una segunda iteracion con el segundo fxc se van a repetir los valores repetidos.
            //SOLUCION?
            //en la primera iteracion hacer una lista de cada valor repetido
            //de manera que en la segunda iteración se pueda comparar contra esa lista y descartar los casos.

            /* for debugging porpouse
            imprimeArrayCompleto(fact1);
            imprimeArrayCompleto(fact2);
            Console.WriteLine("{0} factores distintos", factoresDistintos1);
            Console.WriteLine("{0} factores distintos", factoresDistintos2);
            imprimeArrayDeArraysCompleto(factoresXCantidades1);
            imprimeArrayDeArraysCompleto(factoresXCantidades2);
            */

            //maxdiv = comparaArrays(arrayDeDiv1, arrayDeDiv2);
            //Console.WriteLine("El máximo común divisor es {0}", maxdiv);           
        

        

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

        static int calculaMCM(int[][] arrayDeArrays1, int[][] arrayDeArrays2, int[] repetidos) {

            int MCM = 1;
            int esRepetido = 0;
            int coincidencia = 0;          

            for (int i = 0; i<arrayDeArrays1.Length; i++){
                //debug
                 Console.WriteLine("revisión del numero {0}, valor {1} de la primera lista factorizada", i, arrayDeArrays1[i][0]);
                for (int j = 0; j<arrayDeArrays2.Length; j++){
                if (arrayDeArrays1[i][0] == arrayDeArrays2[j][0]){
                    esRepetido = 1;
                    coincidencia = j;
                    }
                }
                
                if (!(esRepetido == 1)) {
                    Console.WriteLine("{0} es un numero que no está en la otra lista. simplemente se suma al MCM",arrayDeArrays1[i][0]);                 
                        MCM *= devuelvePotencia(arrayDeArrays1[i][0], arrayDeArrays1[i][1]);
                        //debug
                        Console.WriteLine("el MCM ahora es {0}", MCM);
                        esRepetido = 0;
                } else {
                    Console.WriteLine("{0} en lista 1 coincide con {1} en la lista 2.", arrayDeArrays1[i][0], arrayDeArrays2[coincidencia][0]);
                        
                        //OJO ESTO FALLA SI SON 3 O MÁS. SI SON 3 O MÀS VA A HABER QUE HACER UNA LISTA DE UNICOS... UN EMBOLE

                        //debug
                         Console.WriteLine("se procede a ver cuál multiplicacion de factor por su cantidad es mayor, entre {0} y {1}", devuelvePotencia(arrayDeArrays1[i][0], arrayDeArrays1[i][1]), devuelvePotencia(arrayDeArrays2[coincidencia][0],arrayDeArrays2[coincidencia][1]));
                            if ((devuelvePotencia(arrayDeArrays1[i][0], arrayDeArrays1[i][1])) >= devuelvePotencia(arrayDeArrays2[coincidencia][0], arrayDeArrays2[coincidencia][1])){
                                //debug
                                 Console.WriteLine("era mayor o igual la primera");
                                MCM *= (devuelvePotencia(arrayDeArrays1[i][0], arrayDeArrays1[i][1]));
                                //debug
                                 Console.WriteLine("En este momento el MCM es {0}", MCM);
                            } else {
                                //debug
                                 Console.WriteLine("era mayor la segunda");
                                MCM *= (devuelvePotencia(arrayDeArrays2[coincidencia][0], arrayDeArrays2[coincidencia][1]));
                                //debug
                                 Console.WriteLine("En este momento el MCM es {0}", MCM);
                            }
                        esRepetido = 0;

                }
            }

            //en este caso cuando hay repetido sencillamente deberia detenerse ahi y pasar al siguiente factor

            for (int i = 0; i<arrayDeArrays2.Length; i++){
                //debug
                 Console.WriteLine("ahora al revés revisión del numero {0}, valor {1} de la segunda lista factorizada", i, arrayDeArrays2[i][0]);
                for (int j = 0; j<arrayDeArrays1.Length; j++){
                if (arrayDeArrays2[i][0] == arrayDeArrays1[j][0]){
                    esRepetido = 1;
                    }
                }
                
                if (!(esRepetido == 1)) {
                    Console.WriteLine("{0} es un numero que no está en la otra lista. se suma al MCM",arrayDeArrays2[i][0]);                 
                        MCM *= devuelvePotencia(arrayDeArrays2[i][0], arrayDeArrays2[i][1]);
                        //debug
                        Console.WriteLine("el MCM ahora es {0}", MCM);
                }
                esRepetido = 0;
            }
            return MCM;
        }
                
                
                
                
                
                
                
                
                
                
                /*
                
                //debug
                Console.WriteLine("chequeo del numero {0} contra los factores repetidos...", arrayDeArrays1[i][0]);
                for (int x = 0; x<repetidos.Length; x++){
                    //debug
                    Console.WriteLine("se chequea contra el repetido Nº {0} que es {1}...", x, factoresRepetidos[x]);
                    if (factoresXCantidades1[i][0] == factoresRepetidos[x]){
                        esRepetido = 1;
                        break;
                    }
                }
                if (esRepetido == 1){
                        //debug
                        Console.WriteLine("{0} está en lista de factores repetidos...", arrayDeArrays1[i][0]);
                        esRepetido = 0;
                        calculaMayorDeDosFactores()
                    } procede solo




                for (int j = 0; j<factoresXCantidades2.Length; j++){
                    
                 
                    
                    

                    for (int z = 0; z<factoresXCantidades2.Length; z++){
                        //debug
                        Console.WriteLine("como no era repetido comienza chequeo contra los numeros del segundo array: ahora con {0}...", factoresXCantidades2[z][0]);
                        if (factoresXCantidades1[i][0] == factoresXCantidades2[z][0]){
                                esNuevo = 0;
                                coincidencia = z;
                            }
                    }
                     
                    if (esNuevo == 1){
                        //debug
                        Console.WriteLine("{0} es un numero que no está en la otra lista. simplemente se suma al MCM",factoresXCantidades1[i][0]);                 
                        MCM *= devuelvePotencia(factoresXCantidades1[i][0], factoresXCantidades1[i][1]);
                        //debug
                        Console.WriteLine("el MCM ahora es {0}", MCM);
                        break;
                        } else {

                        //debug
                        Console.WriteLine("{0} (lista 1) coincide con {1} (lista 2) . se suma el numero a la lista de repetidos y se pasa al siguiente index de repetidos", factoresXCantidades1[i][0], factoresXCantidades2[coincidencia][0]);
                        
                        //OJO ESTO FALLA SI SON 3 O MÁS. SI SON 3 O MÀS VA A HABER QUE HACER UNA LISTA DE UNICOS... UN EMBOLE

                        factoresRepetidos[factorRepetidoIndex] = factoresXCantidades1[i][0];
                        //debug
                         Console.WriteLine("agregado a la lista");
                        factorRepetidoIndex++;
                        //debug
                         Console.WriteLine("sumado {0} al index, ahora se procede a ver cuál multiplicacion de factor por su cantidad es mayor, entre {1} y {2}", factoresXCantidades1[i][0], devuelvePotencia(factoresXCantidades1[i][0], factoresXCantidades1[i][1]), devuelvePotencia(factoresXCantidades2[coincidencia][0],factoresXCantidades2[coincidencia][1]));
                            if ((devuelvePotencia(factoresXCantidades1[i][0], factoresXCantidades1[i][1])) >= devuelvePotencia(factoresXCantidades2[coincidencia][0], factoresXCantidades2[coincidencia][1])){
                                //debug
                                 Console.WriteLine("era mayor o igual la primera");
                                MCM *= (devuelvePotencia(factoresXCantidades1[i][0], factoresXCantidades1[i][1]));
                                //debug
                                 Console.WriteLine("En este momento el MCM es {0}", MCM);
                            } else {
                                //debug
                                 Console.WriteLine("era mayor la segunda");
                                MCM *= (devuelvePotencia(factoresXCantidades2[coincidencia][0], factoresXCantidades2[coincidencia][1]));
                                //debug
                                 Console.WriteLine("En este momento el MCM es {0}", MCM);
                                
                            }
                        esNuevo = 1;
                        
                        }    
                    }
                } */
                
        static int[] calculaFactoresRepetidos(int[][] array1, int[][] array2){

            int factorRepetidoIndex = 0;
            int numeroDeFactoresRepetidos = 0;

            for (int i = 0; i<array1.Length; i++){
                for (int j = 0; j<array2.Length; j++){
                    if (array1[i][0] == array2[j][0]){
                        numeroDeFactoresRepetidos++;
                    }
                }
            }
            
            //debug Console.WriteLine("el numero de Factores Repetidos es {0}", numeroDeFactoresRepetidos);

            int[] factoresRepetidos = new int[numeroDeFactoresRepetidos];
                for (int i = 0; i<array1.Length; i++){
                    for (int j = 0; j<array2.Length; j++){
                        if (array1[i][0] == array2[j][0]){
                            factoresRepetidos[factorRepetidoIndex] = array1[i][0];
                            factorRepetidoIndex++;
                        }
                    }
                }

                return factoresRepetidos;
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