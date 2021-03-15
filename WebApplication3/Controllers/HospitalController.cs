using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication3.DAL;
using WebApplication3.Models;
using WebApplication3.Models.ResponseModels;


namespace WebApplication3.Controllers
{
    public class HospitalController : ApiController
    {
        DAL.DataAccessProvider dataAccess = new DataAccessProvider();

        [HttpPost]
        public bool CreateFacility(string facilityname,string token,string deviceid)
        {

            return dataAccess.fn_CreateFacility(facilityname, deviceid, token);
        }


        [HttpPost]
        public bool CreateMedicalService(string medicalservice, string token, string deviceid)
        {

            return dataAccess.fn_CreateMedicalService(medicalservice, deviceid, token);
        }


        [HttpPost]
        public bool CreateFacilityMedicalService(int facilityid,int medicalservice, string token, string deviceid)
        {

            return dataAccess.fn_CreateFacilityMedicalService(facilityid,medicalservice, deviceid, token);
        }


        [HttpGet]
        public List<FacilityMedicalServices> GetFacilities()
        {
            return dataAccess.fn_GetFacilities();
        }



    }
}