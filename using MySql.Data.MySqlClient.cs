using MySql.Data.MySqlClient;

class MysqlConnection
{
	string connectionString = "server=myserver;user=myusername;password=mypassword;database=mydatabase";
	using (MySqlConnection connection = new MySqlConnection(connectionString))
	{
	    connection.Open();

	    // Perform database operations here...

	    connection.Close();
	}
	string sql = "SELECT * FROM mytable";
	using (MySqlCommand command = new MySqlCommand(sql, connection))
	{
	    using (MySqlDataReader reader = command.ExecuteReader())
	    {
	        while (reader.Read())
	        {
	            // Retrieve data from the reader...
	        }
	    }
	}
}
