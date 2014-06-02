using System;

namespace FaculteitIteratief
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine(" GIVE NUMBER for factorial: \n ");
			long n = Convert.ToInt64(Console.ReadLine());
			int product = 1;
			int teller = 1;
			while (teller < n) {
				teller++;
				product = product*teller;
			}
			Console.WriteLine(" The factorial of given number is: " + product);
            Console.ReadLine();
		}
	}
}
