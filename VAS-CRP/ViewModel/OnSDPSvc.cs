using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VAS_CRP.ViewModel
{

    public class OnSDPSvcs
    {
        [Required(ErrorMessage = "Country Field is required")]
        public string Country { get; set; }
        public List<SelectListItem> CountryList
        {
            get
            {
                List<SelectListItem> LI = new List<SelectListItem>();
                LI.Add(new SelectListItem { Text = "Kuwait", Value = "Kuwait" });
                LI.Add(new SelectListItem { Text = "Iraq", Value = "Iraq" });
                return LI;
            }
        }
        [Required(ErrorMessage = "Operator Field is required")]
        public string Operator { get; set; }
        [Required(ErrorMessage = "Report Type Field is required")]
        public string ReportType { get; set; }
        [Required(ErrorMessage = "From Date Field is required")]
        public string FromDate { get; set; }
        [Required(ErrorMessage = "To Date Field is required")]
        public string ToDate { get; set; }
        
    }





    //public class SpecialServices
    //{
    //    public string ProductID { get; set; }
    //    public string ServiceName { get; set; }
    //    public string ShortCode { get; set; }
    //    public string BillingStatus { get; set; }
    //    public Int32 Subscribers { get; set; }
    //}
    //public class SpecialServicesSubscribers
    //{
    //    public string ProductID { get; set; }
    //    public string ServiceName { get; set; }
    //    public string ShortCode { get; set; }
    //    public string MSISDN { get; set; }
    //    public string BillingStatus { get; set; }
    //    public DateTime LastTranDate { get; set; }
    //}
    //public class SplSvcDetails
    //{
    //    public IEnumerable<SpecialServices> SpecialServices { get; set; }
    //    public IEnumerable<SpecialServicesSubscribers> SpecialServicesSubscribers { get; set; }
    //}
}