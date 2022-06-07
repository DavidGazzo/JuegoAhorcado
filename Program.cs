namespace JuegoAhorcado
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool continuar = true;
            bool playAgain = true;
            do
            {            
                WordDriver wordDriver = new WordDriver();   // Instancia manejador de procesos de palabras
                Tools tools = new Tools();                  // Herramientas Presentacion y control de errores de input            
                Graphics myGrafics = new Graphics();        // Imprime los gráficos

                string legend = "JUEGO DEL AHORCADO";   // Para cartel presentacion
                string cartelPalabraOculta = "";        // Arma la palabra con letras acertadas y algún otro caracter
                char letterPlayer= ' ';                 // Letra que ingresará el jugador            

                string palabra = wordDriver.SearchWord().ToUpper(); // Se ELIJE aleatoriamente una PALABRA desde lista_palabras_80383.txt
                int contErrores = 1;            // Identifica la cantidad de errores que va cometiendo el jugador
                                                // e indica que gráfico debe imprimirse

                int paraCentrar = (legend.Length+10)-(palabra.Length*2)+1;// Para CENTRAR palabra oculta respecto al cartel presentacio

                Console.ResetColor();
 
                for (int i = 0; i < palabra.Length; i++)
                {
                    cartelPalabraOculta += "*"; // Armo un string del mismo largo que la palabra elejida
                }
                string palabraVirgen = cartelPalabraOculta;

                do
                {
                    Console.Clear();

                    Console.WriteLine(tools.PresentationPoster(legend));    // Imprime presentacion
                                                                            // 
                    Console.WriteLine(myGrafics.Boxes(cartelPalabraOculta)+"\n");// Genera string con la letra ingresada por el jugador
                    
                    ManejaError(contErrores, cartelPalabraOculta);          // Imprime "madera" del ahorcado

                    //Console.SetCursorPosition(0, 3);    // BORRAR, SOLO PARA PRUEBAS
                    //Console.WriteLine(palabra);         // BORRAR, SOLO PARA PRUEBAS

                    Console.SetCursorPosition(0, 7);                        // Ubica el cursor sobre la "madera" del ahorcado
                    Console.Write("Ingrese una letra: ");

                    letterPlayer = char.Parse(Console.ReadLine().ToUpper());// Convierte string del ingreso a char
                    bool existe = wordDriver.ExisteLetra(palabra, letterPlayer);    // Busca la letra en la palabra elejida

                    if (existe)
                    {
                    
                        cartelPalabraOculta = wordDriver.ArmaPalabraParcial(palabra, cartelPalabraOculta, letterPlayer);
                        palabraVirgen = cartelPalabraOculta;
                        Console.SetCursorPosition(0, 4);
                        Console.WriteLine(myGrafics.Boxes(cartelPalabraOculta));    // Genera string con la letra ingresada por el jugador
                        existe = false;
                    }
                    else
                    {
                        contErrores++;
                        ManejaError(contErrores,cartelPalabraOculta);                    
                    }
                    if (contErrores == 7 || palabraVirgen==palabra)
                    {
                        GanaPierde(palabraVirgen, palabra, contErrores);
                        Console.WriteLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        break;
                    }
                    
                    
                } while (continuar);
                playAgain = ContinuarFinalizar();
                //string apa = "";        //BORRAR SOLO PARA CONTROL
                //Console.ReadKey();      //BORRAR SOLO PARA CONTROL
            } while (playAgain);
            Console.Clear();
        }   // End Main

        static void ManejaError(int nroError, string cartelPalabraOculta)
        {
            Graphics myGrafics = new Graphics();
            Console.SetCursorPosition(0, 9);
            switch (nroError)
            {
                case 1:
                    Console.WriteLine(myGrafics.Gallow());
                    break;
                case 2:
                    Console.WriteLine(myGrafics.Head());
                    break;
                case 3:
                    Console.WriteLine(myGrafics.Body());
                    break;
                case 4:
                    Console.WriteLine(myGrafics.LeftArm());
                    break;
                case 5:
                    Console.WriteLine(myGrafics.RightArm());
                    break;
                case 6:
                    Console.WriteLine(myGrafics.LeftLeg());
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(myGrafics.RightLeg());
                    break;
            }
        }   // End ManejaError

        static bool ContinuarFinalizar()
        {
            Tools tools = new Tools();      // Herramientas Presentacion y control de errores de input
            bool continuar = false;
            Console.Write("¿Quiere jugar nuevamente? S/N ");
            continuar = tools.OnlyYesNo(Console.ReadLine());
                
            return continuar;
        }

        static void GanaPierde(string palabraVirgen, string palabra, int contErrores)
        {
            Graphics myGrafics = new Graphics();    // Imprime los gráficos del ahorcado
            // GANA o PIERDE preguntar si continúa
            if (palabraVirgen == palabra)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.SetCursorPosition(0, contErrores + 12);
                    Console.WriteLine(myGrafics.Gana());
                    Thread.Sleep(250);
                }
                Console.ResetColor();
                Console.SetCursorPosition(0, contErrores + 17);
            }
            else if (contErrores == 7)  // Cuando el jugador pierde ...
            {
                Console.SetCursorPosition(0, 4);
                Console.ForegroundColor = ConsoleColor.White; // Primero a blanco

                Console.WriteLine(myGrafics.Boxes(palabra));
                for (int i = 0; i < 5; i++)
                {
                    if (i % 2 == 0) // secuencia de colores
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Primero a rojo
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed; // Luego a rojo oscuro
                    }
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine(myGrafics.Pierde());  // grafico "PERDIÓ"
                    Thread.Sleep(250);
                }
                //Console.SetCursorPosition(0, 21);
                //Console.WriteLine(myGrafics.Pierde());
                Console.ResetColor();
                Console.SetCursorPosition(0, 26);                
            }
        }
        
    }   // End class Program
}   //End namespace