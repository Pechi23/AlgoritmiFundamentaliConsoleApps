/*
 * Se citesc numere intregi (-10^9 < n < 10^9)  dintr-un fisier file.in (cate un nr pe linie)
 * Sa se determine cele mai mari 2 numere de 3 cifre care nu apar in fisier
 */
using System.IO;

namespace Problema2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader Sr = new StreamReader("file.in");
            //vector caracteristic 
            bool[] boolArray = new bool[1000];

            //citim numerele din fisier
            string line;
            int n;
            while ((line = Sr.ReadLine()) != null)
            {
                n = int.Parse(line);
                if(n>99 && n<1000)//daca numarul aparut are 3 cifre il marcam ca aparut
                    boolArray[n] = true;
            }

            //cautam numerele cele mai mari care nu au aparut la citire
            Console.Write("Cele mai mari 2 numere de 3 cifre care nu apar la citire sunt: ");
            int k = 0;
            int i = 999;
            while(k<2 && i>=0)
            {
                if (!boolArray[i])
                {
                    Console.Write($"{i} ");
                    k++;
                }
                i--;
            }
        }
    }
}
