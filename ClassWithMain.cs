using System;

class ClassWithMain
{
	public static void Main(String[] args)
	{
		PrintHello hello = new PrintHello();
	}
}

class PrintHello
{
	public PrintHello()
	{
		Console.WriteLine("Hello");
	}
}