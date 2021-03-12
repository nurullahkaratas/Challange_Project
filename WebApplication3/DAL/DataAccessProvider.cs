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
        public int fn_Register(string username, string password, string firstname, string lastname, int isActive)
        {

            NpgsqlConnection conn = new NpgsqlConnection("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Acibadem_Chal;");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "public.fnc_register2";
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password1", password);
            cmd.Parameters.AddWithValue("firstname", firstname);
            cmd.Parameters.AddWithValue("lastname", lastname);
            cmd.Parameters.AddWithValue("logdate", DateTime.Now);
            cmd.Parameters.AddWithValue("isactive", isActive);
            cmd.Prepare();
            var res = cmd.ExecuteScalar();
            conn.Close();
            return (int)res;
        }
        public int fn_Login(string username, string password)
        {
            NpgsqlConnection conn = new NpgsqlConnection("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Acibadem_Chal;");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "public.fnc_login";
            cmd.Parameters.AddWithValue("user_name", username);
            cmd.Parameters.AddWithValue("pw", password);

            cmd.Prepare();
            var res = cmd.ExecuteScalar();
            conn.Close();
            return (int)res;
        }

        public int fn_Logout(string deviceId, string token)
        {
            NpgsqlConnection conn = new NpgsqlConnection("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Acibadem_Chal;");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "public.fnc_logout";
            cmd.Parameters.AddWithValue("deviceid", deviceId);
            cmd.Parameters.AddWithValue("tokenvalue", token.ToString());

            cmd.Prepare();
            var res = cmd.ExecuteScalar();
            conn.Close();
            return (int)res;
        }

        // Sp_AddToken: Aldığı UserId, DeviceId ve TokenValue parametreleri ile UserToken tablosuna kayıt atmalıdır.
        public bool fn_AddToken(int userId, string token, string deviceId)
        {
            if (string.IsNullOrEmpty(token))
            { 
                token = System.Guid.NewGuid().ToString(); 
            }
            
            if (deviceId == null)
            { 
                deviceId = "unDefined";
            }
            
            NpgsqlConnection conn = new NpgsqlConnection("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Acibadem_Chal;");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "public.fnc_addtoken";
            cmd.Parameters.AddWithValue("userid", userId);
            cmd.Parameters.AddWithValue("deviceid", deviceId);
            cmd.Parameters.AddWithValue("tokenvalue", token);
            cmd.Parameters.AddWithValue("logdate", DateTime.Now);
            cmd.Parameters.AddWithValue("isactive", 1);
            cmd.Prepare();
            var res = cmd.ExecuteScalar();
            conn.Close();
            return (bool)res;



        }



    }
}