using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.DAL
{
    public class DataAccessProvider
    {      
        public void Register(string username, string password, string firstname, string lastname, int isActive)
        {

            NpgsqlConnection conn = new NpgsqlConnection("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Acibadem_Chal;");    
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "public.fnc_register";
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password1", password);
            cmd.Parameters.AddWithValue("firstname", firstname);
            cmd.Parameters.AddWithValue("lastname", lastname);
            cmd.Parameters.AddWithValue("logdate", DateTime.Now);
            cmd.Parameters.AddWithValue("isactive", isActive);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();          
        }

    
    }
}