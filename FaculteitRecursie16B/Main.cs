using System;

namespace FaculteitRecursie
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine(" GIVE NUMBER for factorial: \n ");
			long a = Convert.ToInt64(Console.ReadLine());
			long fact = Factorial (a);
			Console.WriteLine ();
			Console.WriteLine(" The factorial of given number is: " + fact);
            Console.ReadLine();
		}
		public static long Factorial(long number){
			long fac;
			if (number <= 1) {
				Console.Write("1");
				return 1;
			} else {
				fac = Factorial (number - 1);
				Console.Write ("x" + number);
				return number * fac;
			}
		}
	}
}
