using System;
using DIO.Series.Classes;
using DIO.Series.Enum;

namespace DIO.Series
{
    class Program
    {
        static void Main(string[] args)
        {
            Serie serie = new Serie( 1, Genero.Comedia, "The good place", "string descricao", 2010);
            Console.WriteLine(serie.Titulo);
            
        }
    }
}
