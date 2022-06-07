using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado
{
    internal class WordDriver
    {
        public string SearchWord()
        {
            StreamReader Leer = new StreamReader(@"L:\\Curso Introduccion a Net Core 6.0\\Juegos\\JuegoAhorcado\\lista_palabras_80383.txt");
            string palabra = "";
            int contador = 0;
            var nroPalabra = new Random();
            int nro = nroPalabra.Next(1, 80383);            

            while (!Leer.EndOfStream)
            {
                contador++;
                Leer.ReadLine();
                if (contador == nro)
                {
                    palabra = Leer.ReadLine();
                    break;
                }
            }            
            Leer.Close();
        
            return palabra;
        }

        public bool ExisteLetra(string word, char letterPlayer) // Si letra ingresada existe devuelve true
        {
            bool existe = false;
            int indice = word.IndexOf(letterPlayer);
            if (indice != -1) existe = true;
            //foreach (var item in word)
            //{
            //    if (item == letterPlayer) existe = true;
            //}

            return existe;
        }        

        public string ArmaPalabraParcial(string palabra, string palabraParcial, char letterPlayer)
        {            
            int posicion = 0;
            string[] auxiliar = new string[palabra.Length];

            foreach (var item in palabraParcial)
            {
                auxiliar[posicion] = item.ToString();
                posicion++;
            }
            palabraParcial = "";

            posicion = 0;
            foreach (var item in palabra)
            {
                if (letterPlayer == item)
                {
                    auxiliar[posicion] = letterPlayer.ToString();
                    palabraParcial += auxiliar[posicion];
                }
                else
                {
                    palabraParcial += auxiliar[posicion];
                }
                posicion++;
            }            
            return palabraParcial;
        }
    }
}
