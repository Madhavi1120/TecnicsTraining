using System.Data.SQLite;


class SqlConnection 
{
    public static void Main(String[] args)
    {
        // Create a connection to the database
        var connectionString = "Data Source = C:/Users/Madhu/Training/JAVA/BankInterface.db";
        using var connection = new SQLiteConnection(connectionString);
        connection.Open();

        // Execute a query
        var sql = "SELECT * FROM Bank";
        using var command = new SQLiteCommand(sql, connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var column1 = reader["column1"];
            var column2 = reader["column2"];
            // ... 
        }
    }
}
