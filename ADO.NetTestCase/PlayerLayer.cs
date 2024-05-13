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
        private string connectionString;

        public PlayerLayer(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Default");
        }


        public void CreatePlayersTable()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection(connectionString);
                // writing sql query  
                SqlCommand cm = new SqlCommand("create table Player(id int not null, name varchar(100), petname varchar(50), DOB date)", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Table created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }

        public void AddPlayer()
        {
            SqlConnection con = null;
            
                // Creating Connection  
            using (con = new SqlConnection(connectionString))
            {
                try { 
                    // writing sql query  
                    SqlCommand cm = new SqlCommand("INSERT INTO Player (id, name, petname, DOB) VALUES (1, 'Abraham Benjamin de Villiers', 'MR360', '1994-02-17');", con);
                    // Opening Connection  
                    con.Open();
                    // Executing the SQL query  
                    cm.ExecuteNonQuery();
                    // Displaying a message  
                    Console.WriteLine("Player Added Successfully");
                }
                catch (Exception e)
                {
                    Console.WriteLine("OOPs, something went wrong." + e);
                }
            }
            
        }

        public void RemovePlayer()
        {
            SqlConnection con = null;

            // Creating Connection  
            using (con = new SqlConnection(connectionString))
            {
                try
                {
                    // writing SQL query to delete a player
                    SqlCommand cmd = new SqlCommand("DELETE FROM Player WHERE name = 'Abraham Benjamin de Villiers';", con);

                    // Opening Connection  
                    con.Open();

                    // Executing the SQL query  
                    cmd.ExecuteNonQuery();

                    // Displaying a message  
                    Console.WriteLine("Player removed Successfully");
                }
                catch (Exception e)
                {
                    Console.WriteLine("OOPs, something went wrong." + e);
                }
            }
        }

        public void UpdatePlayer()
        {
            SqlConnection con = null;

            // Creating Connection  
            using (con = new SqlConnection(connectionString))
            {
                try
                {
                    // writing SQL query to update a player
                    SqlCommand cmd = new SqlCommand("UPDATE Player SET petname = 'Genius', DOB ='1984-02-17'  WHERE name = 'Abraham Benjamin de Villiers';", con);

                    // Opening Connection  
                    con.Open();

                    // Executing the SQL query  
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Displaying a message  
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Player updated Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Player not found");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("OOPs, something went wrong." + e);
                }
            }
        }

        public void GetPlayers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Pass the connection to the command object, so the command object knows on which
                // connection to execute the command
                SqlCommand cmd = new SqlCommand("Select * from Player", con);
                // Open the connection. Otherwise you get a runtime error. An open connection is
                // required to execute the command            
                con.Open();
                Console.WriteLine("connected");
                SqlDataReader rdr = cmd.ExecuteReader(); //returns object of sqldatareder
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Console.WriteLine("{0} {1} {2} {3}", rdr["id"],rdr["name"], rdr["petname"], rdr["DOB"]);
                    }
                }
            }

        }


    }
}
