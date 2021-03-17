using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication3.Models;
using WebApplication3.Models.ResponseModels;

namespace WebApplication3.DAL
{
    public class DataAccessProvider
    {
        public bool fn_Register(string username, string password, string firstname, string lastname, int isActive)
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
            cmd.Parameters.AddWithValue("isactive", isActive = 1);
            cmd.Prepare();
            var res = cmd.ExecuteScalar();
            conn.Close();
            return (bool)res;
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
        public bool fn_ChangePassword(string newPassword,string deviceId, string token)
        {
            NpgsqlConnection conn = new NpgsqlConnection("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Acibadem_Chal;");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "public.fnc_changepassword";
            cmd.Parameters.AddWithValue("newpassword", newPassword);
            cmd.Parameters.AddWithValue("deviceid", deviceId);
            cmd.Parameters.AddWithValue("tokenvalue", token.ToString());
            cmd.Prepare();
            var res = cmd.ExecuteScalar();
            conn.Close();
            return (bool)res;
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

        public int fn_CheckToken(string deviceId, string token)
        {
            NpgsqlConnection conn = new NpgsqlConnection("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Acibadem_Chal;");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "public.fnc_checktoken";
            cmd.Parameters.AddWithValue("deviceid", deviceId);
            cmd.Parameters.AddWithValue("tokenvalue", token.ToString());
            cmd.Prepare();
            var res = cmd.ExecuteScalar();
            conn.Close();
            return (int)res;
        }

        public bool fn_CreateFacility(string facilityname,string deviceId, string token)
        {
            NpgsqlConnection conn = new NpgsqlConnection("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Acibadem_Chal;");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "public.fnc_createfacility";
            cmd.Parameters.AddWithValue("facilityname", facilityname);
            cmd.Parameters.AddWithValue("deviceid", deviceId);
            cmd.Parameters.AddWithValue("tokenvalue", token.ToString());
            cmd.Parameters.AddWithValue("logdate", DateTime.Now);
            cmd.Prepare();
            var res = cmd.ExecuteScalar();
            conn.Close();
            return (bool)res;
        }

        public bool fn_CreateMedicalService(string medicalservicename, string deviceId, string token)
        {
            NpgsqlConnection conn = new NpgsqlConnection("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Acibadem_Chal;");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "public.fnc_createmedicalservice";
            cmd.Parameters.AddWithValue("medicalservicename", medicalservicename);
            cmd.Parameters.AddWithValue("deviceid", deviceId);
            cmd.Parameters.AddWithValue("tokenvalue", token.ToString());
            cmd.Parameters.AddWithValue("logdate", DateTime.Now);
            cmd.Prepare();
            var res = cmd.ExecuteScalar();
            conn.Close();
            return (bool)res;
        }

        public bool fn_CreateFacilityMedicalService(int facilityid,int medicalserviceid, string deviceId, string token)
        {
            NpgsqlConnection conn = new NpgsqlConnection("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Acibadem_Chal;");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            /*facilityid integer medicalserviceid integer,deviceid text,tokenvalue text,logdate timestamp without time zone)*/
            cmd.CommandText = "public.fnc_createfacilitymedicalservice";
            cmd.Parameters.AddWithValue("facilityid", facilityid);
            cmd.Parameters.AddWithValue("medicalserviceid", medicalserviceid);
            cmd.Parameters.AddWithValue("deviceid", deviceId);
            cmd.Parameters.AddWithValue("tokenvalue", token.ToString());
            cmd.Parameters.AddWithValue("logdate", DateTime.Now);
            cmd.Prepare();
            var res = cmd.ExecuteScalar();
            conn.Close();
            return (bool)res;
        }

        public List<FacilityMedicalServices> fn_GetFacilities()
        {
            List<FacilityMedicalServices> facilityList = new List<FacilityMedicalServices>();

            NpgsqlConnection conn = new NpgsqlConnection("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Acibadem_Chal;");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "public.fnc_getfacilities";
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                FacilityMedicalServices facility = new FacilityMedicalServices();
                facility.Id = Convert.ToInt32(dr[0]);
                facility.FacilityId = Convert.ToInt32(dr[1]);
                facility.FacilityName = dr[2].ToString();
                facility.MedicalServiceId = Convert.ToInt32(dr[3]);
                facility.MedicalServiceName =dr[4].ToString();
                facilityList.Add(facility);
            }
            conn.Close();
            return facilityList;

        }


    }
}