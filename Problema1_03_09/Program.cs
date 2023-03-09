/*
 * Se da un numar intreg.
 * Construiti numarul minim si numarul maxim care se poate forma cu cifrele acestuia.
 */

using System;

namespace Problema1_03_09
{
	class Program
	{
		private static void Main(String[] args)
		{
			int n = int.Parse(Console.ReadLine());
			Console.WriteLine($"n: {n}");
            //Metoda1(n);
            Metoda2(n);
			
        }

		private static void Metoda1(int n)
		{
            int[] fr = new int[10];

            //caz particular
            if (n == 0)
            {
                Console.WriteLine("maxim: 0, minim: 0");
                return;
            }

            //formam vectorul de frecventa
            while (n > 0)
            {
                fr[n % 10]++;
                n /= 10;
            }

            //maxim
            int nrMax = 0;
            Console.Write("maxim: ");
            for (int i = 9; i >= 0; i--)
                for (int j = 0; j < fr[i]; j++)
                    nrMax = nrMax * 10 + i;
            Console.WriteLine(nrMax);

            //minim
            int nrMin = 0;
            int k = 1;
            while (nrMin == 0 && k < 10)
            {
                if (fr[k] > 0)
                {
                    nrMin = k;
                    fr[k]--;
                }
                k++;
            }
            Console.Write("minim: ");
            for (int i = 0; i <= 9; i++)
                for (int j = 0; j < fr[i]; j++)
                    nrMin = nrMin * 10 + i;

            Console.Write(nrMin);
        }

        private static void Metoda2(int n)
        {
            int[] v = IntToArray(n);//transformam numarul in vector de cifre
            BubbleSort(v);//sortam cifrele din vector crescator
            int maxim = GetNumarMaxim(v);
            int minim = GetNumarMinim(v);

            Console.WriteLine($"Maxim: {maxim}");
            Console.WriteLine($"Minim: {minim}");
        }

        private static int GetNumarMinim(int[] v)
        {
            int ret = 0;
            //prima cifra trebuie sa fie diferita de 0
            int k = 0;
            while(ret==0 && k<v.Length)
            {
                if (v[k] != 0)
                {
                    ret = v[k];
                    (v[k], v[0]) = (v[0], v[k]);
                }
                k++;
            }
            //dupa ce gasim cifra minima diferita de 0, luam restul cifrelor in ordine crescatoare
            for(int i=1;i<v.Length;i++)
                ret = ret*10 + v[i];
            return ret;
        }

        private static int GetNumarMaxim(int[] v)
        {
            int ret = 0;
            //luam cifrele in ordine descrescatoare
            for(int i = v.Length-1;i>=0;i--)
                ret = ret * 10 + v[i];
            return ret;
        }

        private static void BubbleSort(int[] v)
        {
            bool ok;
            do
            {
                ok = true;
                for (int i = 0; i < v.Length - 1; i++)
                {
                    if (v[i] > v[i + 1])
                    {
                        (v[i], v[i + 1]) = (v[i + 1], v[i]);
                        ok = false;
                    }
                }
            } while (!ok);
        }

        private static int[] IntToArray(int n)
        {
            //formam un vector din cifrele unui numar
            List<int> cifre = new List<int>(); 
            while(n>0)
            {
                cifre.Add(n % 10);
                n /= 10;
            }
            return cifre.ToArray();
        }
    }
}
