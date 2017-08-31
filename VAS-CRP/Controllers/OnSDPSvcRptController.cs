using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnSDPSvc.Infrastructure;
using VAS_CRP.ViewModel;
using Auth.Security;

namespace VAS_CRP.Controllers
{
    [CustomAuthorizeAttribute(Roles = "VASTech,OGVAS")]
    public class OnSDPSvcRptController : Controller
    {
        SSReport SSR = new SSReport();
        public ActionResult OnSDPSvc()
        {
            OnSDPSvcs SDPsvc = new OnSDPSvcs();
            return View(SDPsvc);
        }
        [HttpPost]
        public ActionResult SplSvcDet(string Country,string Operator,string ReportType, string FromDate, string ToDate)
        {
            if(Country=="Kuwait" & Operator=="Zain")
            { ViewBag.Report = "Kuwait Zain OnSDP Services Report"; }
            else if (Country == "Kuwait" & Operator == "Operator")
            { ViewBag.Report = "Kuwait Ooredoo OnSDP Services Report"; }
            else if(Country == "Iraq" & Operator == "Zain")
            { ViewBag.Report = "Iraq Zain OnSDP Services Report"; }
            //SSR.GetSplSvcDet(Country, Operator, ReportType, FromDate, ToDate);
            return PartialView("_SplSvcDetails" , SSR.GetSplSvcDet(Country, Operator, ReportType, FromDate, ToDate));
        }

        public ActionResult KuwaitZainOnSDPReport()
        {
            ViewBag.Report = "Kuwait Zain OnSDP Services Report";
            //SplSvcDetails SS= SSR.GetSplSvcDetails("Kuwait", "Zain");
            return View("SplSvcDetails",SSR.GetSplSvcDetails("Kuwait", "Zain"));
        }
        public ActionResult KuwaitOoredooOnSDPReport()
        {
            ViewBag.Report = "Kuwait Ooredoo OnSDP Services Report";
            //SSR.GetSplSvcDetails("Kuwait", "Ooredoo");
            return View("SplSvcDetails", SSR.GetSplSvcDetails("Kuwait", "Ooredoo"));
        }
        public ActionResult IraqZainOnSDPReport()
        {
            ViewBag.Report = "Iraq Zain OnSDP Services Report";
            //SSR.GetSplSvcDetails("Iraq", "Zain");
            return View("SplSvcDetails", SSR.GetSplSvcDetails("Iraq", "Zain"));
        }
        //[HttpPost]
        //public PartialViewResult SSReportDetails(string Country, string Operator, string ReportType)
        //{
        //    //if (ReportType == "Special Services Details")
        //    //{
        //    //    return PartialView("_SSDetails", SSR.GetSpecialServiceDetails(Country, Operator));
        //    //}
        //    //else //(ReportType == "Special Services Subscribers")
        //    //{
        //    //    return PartialView("_SSSubscribers", SSR.GetSpecialServicesSubscribersDetails(Country, Operator));
        //    //}
        //    return PartialView();
        //}
        [HttpPost]
        public JsonResult GetOperatorList(string Country)
        {
            List<SelectListItem> OL = new List<SelectListItem>();
            switch (Country)
            {
                case "Kuwait":
                    OL.Add(new SelectListItem { Text = "Zain", Value = "Zain" });
                    OL.Add(new SelectListItem { Text = "Ooredoo", Value = "Ooredoo" });
                    return Json(OL, JsonRequestBehavior.AllowGet);
                case "Iraq":
                    OL.Add(new SelectListItem { Text = "Zain", Value = "Zain" });
                    return Json(OL, JsonRequestBehavior.AllowGet);
                default:
                    return Json("");
            }
        }
    }
}