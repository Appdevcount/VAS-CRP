using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnSDPSvc.Infrastructure.ResultModel
{

    public class SpecialServices
    {
        public string ProductID { get; set; }
        public string ServiceName { get; set; }
        public string ShortCode { get; set; }
        public string BillingStatus { get; set; }
        public Int32 Subscribers { get; set; }
    }
    public class SpecialServicesSubscribers
    {
        public string ProductID { get; set; }
        public string ServiceName { get; set; }
        public string ShortCode { get; set; }
        public string MSISDN { get; set; }
        public string BillingStatus { get; set; }
        public DateTime LastTranDate { get; set; }

    }
    public class SplSvcDetails
    {
        public IEnumerable<SpecialServices> SpecialServices { get; set; }
        public IEnumerable<SpecialServicesSubscribers> SpecialServicesSubscribers { get; set; }

    }
}
