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

			int[] fr = new int[10];

			//caz particular
			if(n==0)
			{
				Console.WriteLine("maxim: 0, minim: 0");
				return;
			}

			//formam vectorul de frecventa
			while(n>0)
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
			while(nrMin==0 && k<10)
			{
				if (fr[k] > 0)
				{
					nrMin = k;
					fr[k]--;
				}
				k++;
			}
            Console.Write("minim: ");
            for (int i = 0; i<=9; i++)
                for (int j = 0; j < fr[i]; j++)
                    nrMin = nrMin * 10 + i;

			Console.Write(nrMin);
        }
	}
}
