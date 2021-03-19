using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        [Security]
        public HttpResponseMessage CreateFacility(string facilityname)
        {
            var token = TokenHelper.FindToken(Request);
            var deviceid = TokenHelper.FindDeviceId(Request);
            if (!String.IsNullOrEmpty(deviceid) && !String.IsNullOrEmpty(token))
            {
                var response = dataAccess.fn_CreateFacility(facilityname, deviceid, token);
                if (response == true)
                {
                    return DefaultResponse.GetResponse(HttpStatusCode.OK);
                }
                return DefaultResponse.GetResponse(HttpStatusCode.Unauthorized);
            }
            return DefaultResponse.GetResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Security]
        public HttpResponseMessage CreateMedicalService(string medicalservice)
        {
            var token = TokenHelper.FindToken(Request);
            var deviceid = TokenHelper.FindDeviceId(Request);
            if (!String.IsNullOrEmpty(deviceid) && !String.IsNullOrEmpty(token))
            {
                var response = dataAccess.fn_CreateMedicalService(medicalservice, deviceid, token);
                if (response == true)
                {
                    return DefaultResponse.GetResponse(HttpStatusCode.OK);
                }
                return DefaultResponse.GetResponse(HttpStatusCode.Unauthorized);
            }
            return DefaultResponse.GetResponse(HttpStatusCode.BadRequest);
        }


        [HttpPost]
        [Security]
        public HttpResponseMessage CreateFacilityMedicalService(int facilityid, int medicalservice)
        {
            var token = TokenHelper.FindToken(Request);
            var deviceid = TokenHelper.FindDeviceId(Request);
            if (!String.IsNullOrEmpty(deviceid) && !String.IsNullOrEmpty(token))
            {
                var response = dataAccess.fn_CreateFacilityMedicalService(facilityid, medicalservice, deviceid, token);
                if (response == true)
                {
                    return DefaultResponse.GetResponse(HttpStatusCode.OK);
                }
                return DefaultResponse.GetResponse(HttpStatusCode.Unauthorized);
            }
            return DefaultResponse.GetResponse(HttpStatusCode.BadRequest);
        }


        [HttpGet]
        [Security]
        public List<FacilityMedicalServices> GetFacilities()
        {
            return dataAccess.fn_GetFacilities();
        }
    }
}