using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.ResponseModels
{
    public class FacilityMedicalServices
    {
        public int      Id{ get; set; }
        public int      FacilityId { get; set; }
        public string   FacilityName { get; set; }
        public int      MedicalServiceId { get; set; }
        public string   MedicalServiceName { get; set; }
        public int      MedicalServiceIsActive { get; set; }
    }
}