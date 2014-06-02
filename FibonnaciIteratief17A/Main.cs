using System;

namespace FibonnaciIteratief17A
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine(" GIVE NUMBER for Fibona: \n ");
			long n = Convert.ToInt64(Console.ReadLine());
			int getal1 = 0;
			int getal2 = 1;
			int teller = 1;
			int getal3;
			Console.Write(getal1 + ", " + getal2 + ", ");
			while (teller < n) {
				teller++;
				getal3 = getal1 + getal2;
				Console.Write(getal3 + ", ");
				getal1 = getal2;
				getal2 = getal3;
			}
            Console.ReadLine();
		}
	}
}
