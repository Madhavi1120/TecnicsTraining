using MySql.Data.MySqlClient;
using System;
class MysqlConnection
{
	public static void Main(String[] args)
	{
		int choice;
		CRUD methodObject = new CRUD();
		while(true)
		{
			Console.WriteLine("------------------------------------------------");
			Console.WriteLine("1.Create Record\n2.Show Records\n3.Search Record\n4.Delete Record\n5.Exit");
			Console.Write("Enter your choice: ");
			choice = Convert.ToInt32(Console.ReadLine());
			switch(choice)
			{
				case 1:
					methodObject.CreateRecord();
					break;
				case 2:
					methodObject.ShowRecords();
					break;
				case 3:
					methodObject.SearchRecord();
					break;
				case 5:
					methodObject.Exit();
					return;
				default:
					Console.WriteLine("Invalid Input!");
					break;
			}
		}
    		
	}
}

class CRUD
{
	MySqlConnection connection;
	MySqlCommand command = new MySqlCommand();
	public CRUD()
	{
		try
		{
			string connectionString = "server = 138.68.140.83;user = Madhu;password = Madhu@123;database = dbMadhavi";
			connection = new MySqlConnection(connectionString);
			connection.Open();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}

	public void ShowRecords() 
	{
		try
		{
			string sql = "SELECT * FROM Bank";
			Console.WriteLine("AccountNumber\tName\tBalance");
		    MySqlDataReader reader = command.ExecuteReader();
        	while (reader.Read())
        	{
            	//var column2 = reader["Name"];
            	Console.WriteLine(reader["AccountNumber"] + "\t\t" + reader["Name"] + "\t" + reader["Balance"]);
            	//Console.WriteLine("Hello");
        	}
        	reader.Close();
		}
		catch(Exception e)
		{
			Console.WriteLine(e);
		}
	}

	public void CreateRecord()
	{
		try
		{
			Console.Write("Enter Account Number: ");
			string AccountNumber = Console.ReadLine();
			Console.Write("Enter Name: ");
			string Name = Console.ReadLine();
			Console.Write("Enter Balance: ");
			string Balance = Console.ReadLine();
			string Data = "'" + AccountNumber + "', '" + Name + "', '" + Balance + "'";
			//connection.Open();
			string sqlQuery = "Insert Into Bank Values(" + Data + ");";
			MySqlCommand command = new MySqlCommand(sqlQuery, connection);
		    MySqlDataReader reader = command.ExecuteReader();
		    reader.Close();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}

	}

	public void SearchRecord()
	{
		try
		{
			Console.Write("Enter Account Number: ");
			string AccountNumber = Console.ReadLine();
			string sqlQuery = "Select * From Bank Where AccountNumber = " + AccountNumber + ";";
			MySqlCommand command = new MySqlCommand(sqlQuery, connection);
			MySqlDataReader reader = command.ExecuteReader();
			while(reader.Read())
			{
            	Console.WriteLine(reader["AccountNumber"] + "\t\t" + reader["Name"] + "\t" + reader["Balance"]);
			}
			reader.Close();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}

	public void Exit()
	{
		connection.Close();
	}

}

