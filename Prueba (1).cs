using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace LYA1
{
    public class Prueba : IDisposable
    {
        private StreamReader archivo;
        private StreamWriter encriptado;
        public Prueba()
        {
            Console.WriteLine("Constructor sin argumentos");
            archivo = new StreamReader("prueba.cpp");
            encriptado = new StreamWriter("encriptado.cpp");
        }
        public Prueba(string nombre)
        {
            Console.WriteLine("Constructor con argumento");
            archivo = new StreamReader(nombre);
            encriptado = new StreamWriter("encriptado.cpp");
        }
        public void Dispose()
        {
            Console.WriteLine("Destructor");
            archivo.Close();
            encriptado.Close();
        }
        bool EsVocal(char c)
        {
            if(c=='a'||c=='e'||c=='i'||c=='o'||c=='u'){
                return true;
            }
            return false;
        }
         bool EsVocalMayus(char c)
        {
            if(c=='A'||c=='E'||c=='I'||c=='O'||c=='U'){
                return true;
            }
            return false;
        }
        public void Encripta(char vocal)
        {
            char c;
            while (!archivo.EndOfStream)
            {
                c = (char)archivo.Read();
                if ("aeiouAEIOU".IndexOf(c)>=0)
                {
                    c = vocal;
                }
                encriptado.Write(c);
            }
        }
        public void display()
        {
            char c;
            int  letras = 0;
            int  numeros = 0;
            int vocales=0;
            int vocalesm=0;
            while (!archivo.EndOfStream)
            {
                c = (char)archivo.Read();
                Console.Write(c);
                if(EsVocalMayus(c)){
                    vocalesm++;
                }
                if(EsVocal(c)){
                    vocales++;
                }
                if (char.IsLetter(c))
                {
                    letras++;
                }
                else if (char.IsDigit(c))
                {
                    numeros++;
                }
            }
            Console.WriteLine("Letras = "+letras);
            Console.WriteLine("Numeros = "+numeros);
            Console.WriteLine("Vocales = "+vocales);
            Console.WriteLine("Vocales mayusculas = "+vocalesm);
        }
    }
            
          


}
        
        
    