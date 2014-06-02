using System;

namespace FibonnaciRecursie17B
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine(" GIVE NUMBER for Fibona: \n ");
			long n = Convert.ToInt64(Console.ReadLine());

			long fact = Factorial (n);
			Console.WriteLine ();
			Console.WriteLine(" The factorial of given number is: " + fact);
            Console.ReadLine();
		}
		public static long Factorial(long n){
			if (n == 0)
				return 0;
			else if(n == 1)
				return 1;
			else
				return Factorial(n-1) + Factorial(n-2);
		}
	}
}
