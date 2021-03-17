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
        public IHttpActionResult CreateFacility(string facilityname)
        {
            var token=TokenHelper.FindToken(Request);
            var deviceid = TokenHelper.FindDeviceId(Request);
            if (!String.IsNullOrEmpty(deviceid)&&!String.IsNullOrEmpty(token))
            {
              var response= dataAccess.fn_CreateFacility(facilityname, deviceid, token);
                if (response==true)
                {
                    return Ok();
                }
                return BadRequest();
            }
            return Unauthorized();
        }


        [HttpPost]
        public IHttpActionResult CreateMedicalService(string medicalservice)
        {
            var token = TokenHelper.FindToken(Request);
            var deviceid = TokenHelper.FindDeviceId(Request);
            if (!String.IsNullOrEmpty(deviceid) && !String.IsNullOrEmpty(token))
            {
              var response= dataAccess.fn_CreateMedicalService(medicalservice, deviceid, token);
                if (response == true)
                {
                    return Ok();
                }
                return BadRequest();
            }
            return Unauthorized();
        }


        [HttpPost]
        public IHttpActionResult CreateFacilityMedicalService(int facilityid,int medicalservice)
        {
            var token = TokenHelper.FindToken(Request);
            var deviceid = TokenHelper.FindDeviceId(Request);
            if (!String.IsNullOrEmpty(deviceid) && !String.IsNullOrEmpty(token))
            {
               var response= dataAccess.fn_CreateFacilityMedicalService(facilityid, medicalservice, deviceid, token);
                if (response == true)
                {
                    return Ok();
                }
                return BadRequest();
            }
            return Unauthorized();
        }


        [HttpGet]
        public List<FacilityMedicalServices> GetFacilities()
        {
            return dataAccess.fn_GetFacilities();
        }



    }
}