using System;
using Test;

namespace Method
{
	public class iMethod : ITest
	{
		public void PrintHello()
		{
			Console.WriteLine("Hello");
		}
		public void PrintHi()
		{
			Console.WriteLine("Hi");
		}
	}
}
