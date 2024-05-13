using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NetTestCase
{
    internal class PlayerLayer
    {
        private string connectionString = string.Empty;

        public PlayerLayer(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Default") ?? throw new Exception("No Connection string found");
            CreatePlayersTable();
        }

        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            return con;
        }


        public void CreatePlayersTable()
        {
            SqlConnection con = null;
            try
            {
                con = GetConnection();
                SqlCommand cm = new SqlCommand("create table Player(id int not null, name varchar(100), petname varchar(100), DOB varchar(100))", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Table created Successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("Table already Exits");
            }
            // Closing the connection  
            finally
            {
                con?.Close();
            }
        }

        public void AddPlayer()
        {
            // Prompt the user to enter values for each field
            Console.WriteLine("Enter Player details:");

            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Pet Name: ");
            string petName = Console.ReadLine();

            Console.Write("Date of Birth (YYYY-MM-DD): ");
            string dob = Console.ReadLine();


            SqlConnection con;

            // Create a SqlConnection
            using (con = GetConnection())
            {
                try
                {
                    // Prepare the SQL query with parameters
                    string sqlQuery = "INSERT INTO Player (id, name, petname, DOB) VALUES (@Id, @Name, @PetName, @DOB)";

                    // Create a SqlCommand with parameters
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@PetName", petName);
                    cmd.Parameters.AddWithValue("@DOB", dob);

                    // Open the connection
                    con.Open();

                    // Execute the SQL query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Display success message
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("\nPlayer Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("\nPlayer could not be added.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nProblem occured while adding ");
                }
            }
        }

        public void DeletePlayer()
        {
            Console.Write("\nEnter the ID of the player you want to delete: ");
            int playerId = int.Parse(Console.ReadLine());

            // Create a SqlConnection
            using (SqlConnection con = GetConnection())
            {
                try
                {
                    // Prepare the SQL DELETE query with parameter
                    string sqlQuery = "DELETE FROM Player WHERE id = @Id";

                    // Create a SqlCommand with parameter
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@Id", playerId);

                    // Open the connection
                    con.Open();

                    // Execute the SQL query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Display success message
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("\nPlayer with ID " + playerId + " deleted successfully");
                    }
                    else
                    {
                        Console.WriteLine("\nNo player found with ID " + playerId);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nError Occured while deleting");
                }
            }
        }

        public void UpdatePlayer()
        {
            // Prompt the user for the ID of the player they want to update
            Console.Write("\nEnter the ID of the player you want to update: ");
            int playerId = int.Parse(Console.ReadLine());

            // Prompt the user for updated values
            Console.Write("Enter new name: ");
            string newName = Console.ReadLine();

            // Prompt the user for updated values
            Console.Write("Enter new pet name: ");
            string newPetName = Console.ReadLine();

            Console.Write("Enter new date of birth (YYYY-MM-DD): ");
            string newDOB = Console.ReadLine();

            // Create a SqlConnection
            using (SqlConnection con = GetConnection())
            {
                try
                {
                    // Prepare the SQL UPDATE query with parameters
                    string sqlQuery = "UPDATE Player SET petname = @PetName, DOB = @DOB, name=@Name WHERE id = @Id";

                    // Create a SqlCommand with parameters
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@PetName", newPetName);
                    cmd.Parameters.AddWithValue("@Name", newName);
                    cmd.Parameters.AddWithValue("@DOB", newDOB);
                    cmd.Parameters.AddWithValue("@Id", playerId);

                    // Open the connection
                    con.Open();

                    // Execute the SQL query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Display success or failure message
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("\nPlayer with ID " + playerId + " updated successfully");
                    }
                    else
                    {
                        Console.WriteLine("\nNo player found with ID " + playerId);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nError occured while Updating the player");
                }
            }
        }

        public void GetPlayers()
        {
            using (SqlConnection con = GetConnection())
            {
                
                SqlCommand cmd = new("Select * from Player", con);

                // Open the connection.           
                con.Open();
                
                SqlDataReader rdr = cmd.ExecuteReader(); // returns object of sqldatareader
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Console.WriteLine("{0} {1} {2} {3}", rdr["id"], rdr["name"], rdr["petname"], rdr["DOB"]);
                    }
                }
            }
        }
    }
}
