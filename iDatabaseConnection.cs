using System;


class iDatabaseConnection
{
	public static void Main(String[] args)
	{
		string className = args[0];
		int choice;
		//ICRUD myInstance = new MyClass();
		ClassGet<T>(string blabla) where T : new()
    
        var InputOperation = new T();
    
		while(true)
		{
			Console.WriteLine("------------------------------------------------");
			Console.WriteLine("1.Create Record\n2.Show Records\n3.Search Record\n4.Delete Record\n5.Exit");
			Console.Write("Enter your choice: ");
			choice = Convert.ToInt32(Console.ReadLine());
			switch(choice)
			{
				case 1:
					InputOperation.CreateRecord();
					break;
				case 2:
					InputOperation.ShowRecords();
					break;
				case 3:
					InputOperation.SearchRecord();
					break;
				case 5:
					InputOperation.Exit();
					return;
				default:
					Console.WriteLine("Invalid Input!");
					break;
			}
		}
    		
	}
}