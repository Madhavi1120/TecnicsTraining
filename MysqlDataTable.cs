using MySql.Data.MySqlClient;
using System;
using System.Data;
class MySqlDataTable
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
            string SelectQuery = "SELECT * FROM Bank;";
			MySqlCommand command = new MySqlCommand(SelectQuery, connection);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(table);
            Console.WriteLine("AccountNumber\t\tName\tBalance");
            foreach (DataRow row in table.Rows) 
            {
                int AccountNumber = Convert.ToInt32(row["AccountNumber"]);
                string Name = row["Name"].ToString();
                int Balance = Convert.ToInt32(row["Balance"]);
                Console.WriteLine(AccountNumber + "\t" + Name + "\t\t" + Balance);
            }
        } 
        catch (MySqlException e) 
        {
            Console.WriteLine(e.Message);
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





//----------------------------------------------------------------------------------------------------------------------------------
/*
DataTable MysqlTable = new DataTable();
DataTable MyTableByName = new DataTable("MyTableName");
MysqlTable.Clear();
MysqlTable.Columns.Add("Name");
MysqlTable.Columns.Add("Marks");
object[] values = { "Ravi", 500 };
MysqlTable.Rows.Add(values);
*/


/*Create DataTable:
DataTable MyTable = new DataTable(); // 1
DataTable MyTableByName = new DataTable("MyTableName"); // 2
Add column to table:

 MyTable.Columns.Add("Id", typeof(int));
 MyTable.Columns.Add("Name", typeof(string));
Add row to DataTable method 1:

DataRow row = MyTable.NewRow();
row["Id"] = 1;
row["Name"] = "John";
MyTable.Rows.Add(row);
Add row to DataTable method 2:

MyTable.Rows.Add(2, "Ivan");
Add row to DataTable method 3 (Add row from another table by same structure):

MyTable.ImportRow(MyTableByName.Rows[0]);
Add row to DataTable method 4 (Add row from another table):

MyTable.Rows.Add(MyTable2.Rows[0]["Id"], MyTable2.Rows[0]["Name"]);
Add row to DataTable method 5 (Insert row at an index):

MyTable.Rows.InsertAt(row, 8);*/


//----------------------------------------------------------------------------------------------------------------------------------

/*
// Create a DataTable and add two Columns to it
DataTable dt=new DataTable();
dt.Columns.Add("Name",typeof(string));
dt.Columns.Add("Age",typeof(int));

// Create a DataRow, add Name and Age data, and add to the DataTable
DataRow dr=dt.NewRow();
dr["Name"]="Mohammad"; // or dr[0]="Mohammad";
dr["Age"]=24; // or dr[1]=24;
dt.Rows.Add(dr);

// Create another DataRow, add Name and Age data, and add to the DataTable
dr=dt.NewRow();
dr["Name"]="Shahnawaz"; // or dr[0]="Shahnawaz";
dr["Age"]=24; // or dr[1]=24;
dt.Rows.Add(dr);

// DataBind to your UI control, if necessary (a GridView, in this example)
GridView1.DataSource=dt;
GridView1.DataBind();*/
//-------------------------------------------------------------------------------------------------------------------------------------

/*var table = new DataTable();    
using (var da = new SqlDataAdapter("SELECT * FROM mytable", "connection string"))
{      
    da.Fill(table);
}*/