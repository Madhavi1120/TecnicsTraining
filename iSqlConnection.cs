using System.Data.SQLite;
using System;
using iCRUD;
namespace iSqlCRUD
{
    class SqlCRUD : iCRUD
{
    SQLiteConnection connection;
    SQLiteDataReader reader;
    public CRUD()
    {
        String connectionString = "Data Source=C:\\Users\\Madhu\\Training\\C#\\BankInterface.db";
        connection = new SQLiteConnection(connectionString);
        connection.Open();
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
            string sqlQuery = "Insert Into Bank Values(" + Data + ");";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection);
            reader = command.ExecuteReader();
            reader.Close();
        }
        catch(Exception)
        {

        }
    }

    public void ShowRecords()
    {
        try
        {
            var sqlQuery = "SELECT * FROM Bank";
            var command = new SQLiteCommand(sqlQuery, connection);
            reader = command.ExecuteReader();
            Console.WriteLine("AccountNumber\tName\tBalance");
            while (reader.Read())
            {
                Console.WriteLine(reader["AccountNumber"] + "\t\t" + reader["Name"] + "\t" + reader["Balance"]);
            }
            reader.Close();
        }
        catch (Exception )
        {

        }
    }

    public void SearchRecord()
    {
        try
        {
            Console.Write("Enter Account Number: ");
            string AccountNumber = Console.ReadLine();
            string sqlQuery = "Select * From Bank Where AccountNumber = " + AccountNumber + ";";
            var command = new SQLiteCommand(sqlQuery, connection);
            reader = command.ExecuteReader();
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
   
}
