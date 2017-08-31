using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnSDPSvc.Core;
using OnSDPSvc.Infrastructure.ResultModel;

namespace OnSDPSvc.Infrastructure
{
    public class SSReport
    {
        ZainKuwaitEntities KZdbctx = new ZainKuwaitEntities();
        OoredooKWTEntities KOdbctx = new OoredooKWTEntities();
        IrawZainEntities IZdbctx = new IrawZainEntities();

        SplSvcDetails sd = new SplSvcDetails();
        IEnumerable<SpecialServices> SSD;
        IEnumerable<SpecialServicesSubscribers> SSS;

        public SplSvcDetails GetSplSvcDetails(string Country, string Operator)//, string ReportType)
        {
            if (Country + Operator == "KuwaitZain")
            {
                string SpecialServicesQ = " select ProductID, " +
                 " case ProductID " +
                 " when '2000008477' then 'HealthyLife' " +
                 " when '2000018457' then 'Mazajak'  " +
                 " when '2000022517' then 'GoingUp'  " +
                 " else '  ' end as 'ServiceName',case ProductID  " +
                 " when '2000008477' then 'HealthyLife' " +
                 " when '2000018457' then 'Mazajak'  " +
                 " when '2000022517' then 'GoingUp'  " +
                 " else '  ' end as 'ShortCode', " +
                 " case RentSuccess  " +
                 " when '0' then 'Billing Success' " +
                 " when '1' then 'Billing Failed' end as 'BillingStatus',count(*) 'Subscribers' from ZainSplServices_Subscribers  " +
                 " where updatedesc not like 'Deletion' " +
                 " group by ProductID,(case ProductID  " +
                 " when '2000008477' then 'HealthyLife' " +
                 " when '2000018457' then 'Mazajak'  " +
                 " when '2000022517' then 'GoingUp'  " +
                 " else '  ' end ),( case ProductID  " +
                 " when '2000008477' then 'HealthyLife' " +
                 " when '2000018457' then 'Mazajak'  " +
                 " when '2000022517' then 'GoingUp'  " +
                 " else '  ' end ),(case RentSuccess  " +
                 " when '0' then 'Billing Success' " +
                 " when '1' then 'Billing Failed' end ) order by ProductID,ServiceName,ShortCode,BillingStatus ";

                string SpecialServicesSubscribersQ = " select Top 1000  ProductID,case ProductID  " +
                " when '2000008477' then 'HealthyLife' " +
                " when '2000018457' then 'Mazajak'  " +
                " when '2000022517' then 'GoingUp'  " +
                " else '  ' end as 'ServiceName',case ProductID  " +
                " when '2000008477' then 'HealthyLife' " +
                " when '2000018457' then 'Mazajak'  " +
                " when '2000022517' then 'GoingUp'  " +
                " else '  ' end as 'ShortCode', UserID 'MSISDN',case RentSuccess  " +
                " when '0' then 'Billing Success' " +
                " when '1' then 'Billing Failed' end as 'BillingStatus',max(TranDate) 'LastTranDate'  " +
                " from ZainSplServices_Subscribers  " +
                " where updatedesc not like 'Deletion' " +
                " group by ProductID,(case ProductID  " +
                " when '0' then 'SSSS' " +
                " when '1' then 'TTTT'  " +
                " else 'ELSE' end),(case ProductID  " +
                " when '0' then 'SSSS' " +
                " when '1' then 'TTTT'  " +
                " else 'ELSE' end ), UserID ,(case RentSuccess  " +
                " when '0' then 'Billing Success' " +
                " when '1' then 'Billing Failed' end ) order by ProductID,ShortCode,UserID,BillingStatus  ";

                sd.SpecialServices = KZdbctx.Database.SqlQuery<SpecialServices>(SpecialServicesQ).ToList<SpecialServices>();

                sd.SpecialServicesSubscribers = KZdbctx.Database.SqlQuery<SpecialServicesSubscribers>(SpecialServicesSubscribersQ).ToList();
                return sd;
            }

            else if (Country + Operator == "KuwaitOoredoo")
            {
                string SpecialServicesQ = "Select ServiceID as ProductID " +
                 " ,case ServiceID " +
                 " when 'S-FcY2zvEwMY2' then 'ALAFASY-MMS'  " +
                 " when 'S-rgY2zvEwMY2' then 'Golden Club'  " +
                 " when 'S-TfY2zvEwMY2' then 'EsamChawali'  " +
                 " when 'S-OeY2zvEwMY2' then 'islamicgreetingCards' " +
                 " when 'S-keY2zvEwMY2' then 'AlKharraz'  " +
                 " when 'S-fbY2zvEwMY2' then 'AlMaaref'  " +
                 " when 'S-mbY2zvEwMY2' then 'Al Arabiya News' " +
                 " when 'S-lbY2zvEwMY2' then 'Al Arabiya Newss'  " +
                 " when 'S-pbY2zvEwMY2' then 'AlArNews'  " +
                 " when 'S-chY2zvEwMY2' then 'Dr Fahad Charity' " +
                 " when 'S-UfY2zvEwMY2' then 'FaisalAlbasry'  " +
                 " when 'S-ubY2zvEwMY2' then 'Sky News'  " +
                                 " else '  ' end as 'ServiceName' ,case ServiceID" +
                 " when 'S-FcY2zvEwMY2' then 'ALAFASY-MMS'  " +
                 " when 'S-rgY2zvEwMY2' then 'Golden Club'  " +
                 " when 'S-TfY2zvEwMY2' then 'EsamChawali'  " +
                 " when 'S-OeY2zvEwMY2' then 'islamicgreetingCards' " +
                 " when 'S-keY2zvEwMY2' then 'AlKharraz'  " +
                 " when 'S-fbY2zvEwMY2' then 'AlMaaref'  " +
                 " when 'S-mbY2zvEwMY2' then 'Al Arabiya News' " +
                 " when 'S-lbY2zvEwMY2' then 'Al Arabiya Newss'  " +
                 " when 'S-pbY2zvEwMY2' then 'AlArNews'  " +
                 " when 'S-chY2zvEwMY2' then 'Dr Fahad Charity' " +
                 " when 'S-UfY2zvEwMY2' then 'FaisalAlbasry'  " +
                 " when 'S-ubY2zvEwMY2' then 'Sky News'  " +
                 " else '  ' end as 'ShortCode'," +
                 " case when operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR' ) then 'Billing Success'" +
                 " when operationid in ('PS','YP', 'YG') then 'Billing Failure'" +
                 " when operationid in ('SP') then 'Billing Pending' end as BillingStatus" +
                 " ,count(*) 'Subscribers' from OoredooCurrSubsStatus" +
                 " where operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR', 'PS','YP', 'YG','SP')" +
                 " group by ServiceID,(case ServiceID" +
                 " when 'S-FcY2zvEwMY2' then 'ALAFASY-MMS'  " +
                " when 'S-rgY2zvEwMY2' then 'Golden Club'   " +
                " when 'S-TfY2zvEwMY2' then 'EsamChawali'   " +
                " when 'S-OeY2zvEwMY2' then 'islamicgreetingCards'  " +
                " when 'S-keY2zvEwMY2' then 'AlKharraz'   " +
                " when 'S-fbY2zvEwMY2' then 'AlMaaref'   " +
                " when 'S-mbY2zvEwMY2' then 'Al Arabiya News'  " +
                " when 'S-lbY2zvEwMY2' then 'Al Arabiya Newss'   " +
                " when 'S-pbY2zvEwMY2' then 'AlArNews'   " +
                " when 'S-chY2zvEwMY2' then 'Dr Fahad Charity'  " +
                " when 'S-UfY2zvEwMY2' then 'FaisalAlbasry'   " +
                " when 'S-ubY2zvEwMY2' then 'Sky News'   " +
                " else '  ' end )," +
                " (case ServiceID when 'S-FcY2zvEwMY2' then 'ALAFASY-MMS'  " +
                " when 'S-rgY2zvEwMY2' then 'Golden Club'  " +
                " when 'S-TfY2zvEwMY2' then 'EsamChawali'  " +
                " when 'S-OeY2zvEwMY2' then 'islamicgreetingCards' " +
                " when 'S-keY2zvEwMY2' then 'AlKharraz'  " +
                " when 'S-fbY2zvEwMY2' then 'AlMaaref'  " +
                " when 'S-mbY2zvEwMY2' then 'Al Arabiya News' " +
                " when 'S-lbY2zvEwMY2' then 'Al Arabiya Newss'  " +
                " when 'S-pbY2zvEwMY2' then 'AlArNews'  " +
                " when 'S-chY2zvEwMY2' then 'Dr Fahad Charity' " +
                " when 'S-UfY2zvEwMY2' then 'FaisalAlbasry'  " +
                " when 'S-ubY2zvEwMY2' then 'Sky News'  " +
                " else '  ' end )," +
                " (case when operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR' ) then 'Billing Success'" +
                " when operationid in ('PS','YP', 'YG') then 'Billing Failure'" +
                " when operationid in ('SP') then 'Billing Pending' end )" +
                " order by   ProductID ,ServiceName,ShortCode,BillingStatus";
                string SpecialServicesSubscribersQ = " Select Top 1000 ServiceID as ProductID " +
                " ,case ServiceID" +
                " when 'S-FcY2zvEwMY2' then 'ALAFASY-MMS'  " +
                " when 'S-rgY2zvEwMY2' then 'Golden Club'  " +
                " when 'S-TfY2zvEwMY2' then 'EsamChawali'  " +
                " when 'S-OeY2zvEwMY2' then 'islamicgreetingCards' " +
                " when 'S-keY2zvEwMY2' then 'AlKharraz'  " +
                " when 'S-fbY2zvEwMY2' then 'AlMaaref'  " +
                " when 'S-mbY2zvEwMY2' then 'Al Arabiya News' " +
                " when 'S-lbY2zvEwMY2' then 'Al Arabiya Newss'  " +
                " when 'S-pbY2zvEwMY2' then 'AlArNews'  " +
                " when 'S-chY2zvEwMY2' then 'Dr Fahad Charity' " +
                " when 'S-UfY2zvEwMY2' then 'FaisalAlbasry'  " +
                " when 'S-ubY2zvEwMY2' then 'Sky News'  " +
                " else '  ' end as 'ServiceName'" +
                " ,case ServiceID when 'S-FcY2zvEwMY2' then 'ALAFASY-MMS' " +
                " when 'S-rgY2zvEwMY2' then 'Golden Club'  " +
                " when 'S-TfY2zvEwMY2' then 'EsamChawali'  " +
                " when 'S-OeY2zvEwMY2' then 'islamicgreetingCards' " +
                " when 'S-keY2zvEwMY2' then 'AlKharraz'  " +
                " when 'S-fbY2zvEwMY2' then 'AlMaaref'  " +
                " when 'S-mbY2zvEwMY2' then 'Al Arabiya News' " +
                " when 'S-lbY2zvEwMY2' then 'Al Arabiya Newss'  " +
                " when 'S-pbY2zvEwMY2' then 'AlArNews'  " +
                " when 'S-chY2zvEwMY2' then 'Dr Fahad Charity' " +
                " when 'S-UfY2zvEwMY2' then 'FaisalAlbasry'  " +
                " when 'S-ubY2zvEwMY2' then 'Sky News'  " +
                " else '  ' end as 'ShortCode',Callingparty 'MSISDN'," +
                " case when operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR' ) then 'Billing Success'" +
                " when operationid in ('PS','YP', 'YG') then 'Billing Failure'" +
                " when operationid in ('SP') then 'Billing Pending' end as BillingStatus," +
                " max(UpdatedDate) 'LastTranDate'" +
                "  from OoredooCurrSubsStatus" +
                " where operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR', 'PS','YP', 'YG','SP')" +
                " group by ServiceID" +
                " ,(case ServiceID" +
               " when 'S-FcY2zvEwMY2' then 'ALAFASY-MMS'  " +
                " when 'S-rgY2zvEwMY2' then 'Golden Club'  " +
                " when 'S-TfY2zvEwMY2' then 'EsamChawali'  " +
                " when 'S-OeY2zvEwMY2' then 'islamicgreetingCards' " +
                " when 'S-keY2zvEwMY2' then 'AlKharraz' " +
                " when 'S-fbY2zvEwMY2' then 'AlMaaref'  " +
                " when 'S-mbY2zvEwMY2' then 'Al Arabiya News' " +
                " when 'S-lbY2zvEwMY2' then 'Al Arabiya Newss'  " +
                " when 'S-pbY2zvEwMY2' then 'AlArNews'  " +
                " when 'S-chY2zvEwMY2' then 'Dr Fahad Charity' " +
                " when 'S-UfY2zvEwMY2' then 'FaisalAlbasry'  " +
                " when 'S-ubY2zvEwMY2' then 'Sky News'  " +
                " else '  ' end)" +
                " ,(case ServiceID when 'S-FcY2zvEwMY2' then 'ALAFASY-MMS'  " +
                " when 'S-rgY2zvEwMY2' then 'Golden Club'  " +
                " when 'S-TfY2zvEwMY2' then 'EsamChawali'  " +
                " when 'S-OeY2zvEwMY2' then 'islamicgreetingCards' " +
                " when 'S-keY2zvEwMY2' then 'AlKharraz'  " +
                " when 'S-fbY2zvEwMY2' then 'AlMaaref'  " +
                " when 'S-mbY2zvEwMY2' then 'Al Arabiya News' " +
                " when 'S-lbY2zvEwMY2' then 'Al Arabiya Newss'  " +
                " when 'S-pbY2zvEwMY2' then 'AlArNews'  " +
                " when 'S-chY2zvEwMY2' then 'Dr Fahad Charity' " +
                " when 'S-UfY2zvEwMY2' then 'FaisalAlbasry'  " +
                " when 'S-ubY2zvEwMY2' then 'Sky News'  " +
                " else '  ' end),CallingParty,(" +
                " case when operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR' ) then 'Billing Success'" +
                " when operationid in ('PS','YP', 'YG') then 'Billing Failure'" +
                " when operationid in ('SP') then 'Billing Pending' end )" +
                "  order by   ProductID  ,ServiceName,ShortCode,MSISDN,BillingStatus,LastTranDate";

                sd.SpecialServices = KOdbctx.Database.SqlQuery<SpecialServices>(SpecialServicesQ).ToList<SpecialServices>();

                sd.SpecialServicesSubscribers = KOdbctx.Database.SqlQuery<SpecialServicesSubscribers>(SpecialServicesSubscribersQ).ToList();
                return sd;
            }

            else //if (Country + Operator == "IraqZain")
            {

                string SpecialServicesQ = " select ProductID, " +
                " case ProductID " +
                " when '1000004547' then 'Alafasy' " +
                " when '1000003507' then 'Khabar Ajil'  " +
                " else '  ' end as 'ServiceName',case ProductID  " +
                " when '1000004547' then '2885' " +
                " when '1000003507' then '3232'  " +
                " else '  ' end as 'ShortCode',case RentSuccess  " +
                " when '0' then 'Billing Success' " +
                " when '1' then 'Billing Failed' end as 'BillingStatus',count(*) 'Subscribers' from ZainSplServices_Subscribers  " +
                " where updatedesc not like 'Deletion' " +
                " group by ProductID,(case ProductID  " +
                " when '1000004547' then 'Alafasy' " +
                " when '1000003507' then 'Khabar Ajil'  " +
                " else '  ' end ),( case ProductID  " +
                " when '1000004547' then '2885' " +
                " when '1000003507' then '3232'  " +
                " else '  ' end ),(case RentSuccess  " +
                " when '0' then 'Billing Success' " +
                " when '1' then 'Billing Failed' end ) order by ProductID,ServiceName,ShortCode,BillingStatus ";
                string SpecialServicesSubscribersQ = " select Top 1000  ProductID,case ProductID  " +
                " when '1000004547' then 'Alafasy' " +
                " when '1000003507' then 'Khabar Ajil'  " +
                " else '  ' end as 'ServiceName',case ProductID  " +
                " when '1000004547' then '2885' " +
                " when '1000003507' then '3232'  " +
                " else '  ' end as 'ShortCode', UserID 'MSISDN',case RentSuccess  " +
                " when '0' then 'Billing Success' " +
                " when '1' then 'Billing Failed' end as 'BillingStatus',max(TranDate) 'LastTranDate'  " +
                " from ZainSplServices_Subscribers  " +
                " where updatedesc not like 'Deletion' " +
                " group by ProductID,(case ProductID  " +
                " when '1000004547' then 'Alafasy' " +
                " when '1000003507' then 'Khabar Ajil'  " +
                " else '  ' end),(case ProductID  " +
                " when '1000004547' then '2885' " +
                " when '1000003507' then '3232'  " +
                " else '  ' end ), UserID ,(case RentSuccess  " +
                " when '0' then 'Billing Success' " +
                " when '1' then 'Billing Failed' end ) order by ProductID,ShortCode,UserID,BillingStatus,LastTranDate  ";


                sd.SpecialServices = IZdbctx.Database.SqlQuery<SpecialServices>(SpecialServicesQ).ToList<SpecialServices>();

                sd.SpecialServicesSubscribers = IZdbctx.Database.SqlQuery<SpecialServicesSubscribers>(SpecialServicesSubscribersQ).ToList();
                return sd;
            }

        }

        public SplSvcDetails GetSplSvcDet(string Country, string Operator,string ReportType, string FromDate, string ToDate)//, string ReportType)
        {
            if (Country + Operator == "KuwaitZain")
            {
                string SpecialServicesQ = " select ProductID, " +
                 " case ProductID " +
                 " when '2000008477' then 'HealthyLife' " +
                 " when '2000018457' then 'Mazajak'  " +
                 " when '2000022517' then 'GoingUp'  " +
                 " else '  ' end as 'ServiceName',case ProductID  " +
                 " when '2000008477' then 'HealthyLife' " +
                 " when '2000018457' then 'Mazajak'  " +
                 " when '2000022517' then 'GoingUp'  " +
                 " else '  ' end as 'ShortCode', " +
                 " case RentSuccess  " +
                 " when '0' then 'Billing Success' " +
                 " when '1' then 'Billing Failed' end as 'BillingStatus',count(*) 'Subscribers' from ZainSplServices_Subscribers  " +
                 " where updatedesc not like 'Deletion' " +
                 " and TranDate>='"+FromDate+ "' and TranDate<='"+ToDate+"' " + //Date Condition
                 " group by ProductID,(case ProductID  " +
                 " when '2000008477' then 'HealthyLife' " +
                 " when '2000018457' then 'Mazajak'  " +
                 " when '2000022517' then 'GoingUp'  " +
                 " else '  ' end ),( case ProductID  " +
                 " when '2000008477' then 'HealthyLife' " +
                 " when '2000018457' then 'Mazajak'  " +
                 " when '2000022517' then 'GoingUp'  " +
                 " else '  ' end ),(case RentSuccess  " +
                 " when '0' then 'Billing Success' " +
                 " when '1' then 'Billing Failed' end ) order by ProductID,ServiceName,ShortCode,BillingStatus ";

                string SpecialServicesSubscribersQ = " select Top 1000  ProductID,case ProductID  " +
                " when '2000008477' then 'HealthyLife' " +
                " when '2000018457' then 'Mazajak'  " +
                " when '2000022517' then 'GoingUp'  " +
                " else '  ' end as 'ServiceName',case ProductID  " +
                " when '2000008477' then 'HealthyLife' " +
                " when '2000018457' then 'Mazajak'  " +
                " when '2000022517' then 'GoingUp'  " +
                " else '  ' end as 'ShortCode', UserID 'MSISDN',case RentSuccess  " +
                " when '0' then 'Billing Success' " +
                " when '1' then 'Billing Failed' end as 'BillingStatus',max(TranDate) 'LastTranDate'  " +
                " from ZainSplServices_Subscribers  " +
                " where updatedesc not like 'Deletion' " +
                 " and TranDate>='" + FromDate + "' and TranDate<='" + ToDate + "' " + //Date Condition
                " group by ProductID,(case ProductID  " +
                " when '0' then 'SSSS' " +
                " when '1' then 'TTTT'  " +
                " else 'ELSE' end),(case ProductID  " +
                " when '0' then 'SSSS' " +
                " when '1' then 'TTTT'  " +
                " else 'ELSE' end ), UserID ,(case RentSuccess  " +
                " when '0' then 'Billing Success' " +
                " when '1' then 'Billing Failed' end ) order by ProductID,ShortCode,UserID,BillingStatus  ";

                sd.SpecialServices = KZdbctx.Database.SqlQuery<SpecialServices>(SpecialServicesQ).ToList<SpecialServices>();

                sd.SpecialServicesSubscribers = KZdbctx.Database.SqlQuery<SpecialServicesSubscribers>(SpecialServicesSubscribersQ).ToList();
                return sd;
            }

            else if (Country + Operator == "KuwaitOoredoo")
            {
                string SpecialServicesQ = "Select ServiceID as ProductID " +
                 " ,case ServiceID " +
                 " when 'S-FcY2zvEwMY2' then 'ALAFASY-MMS'  " +
                 " when 'S-rgY2zvEwMY2' then 'Golden Club'  " +
                 " when 'S-TfY2zvEwMY2' then 'EsamChawali'  " +
                 " when 'S-OeY2zvEwMY2' then 'islamicgreetingCards' " +
                 " when 'S-keY2zvEwMY2' then 'AlKharraz'  " +
                 " when 'S-fbY2zvEwMY2' then 'AlMaaref'  " +
                 " when 'S-mbY2zvEwMY2' then 'Al Arabiya News' " +
                 " when 'S-lbY2zvEwMY2' then 'Al Arabiya Newss'  " +
                 " when 'S-pbY2zvEwMY2' then 'AlArNews'  " +
                 " when 'S-chY2zvEwMY2' then 'Dr Fahad Charity' " +
                 " when 'S-UfY2zvEwMY2' then 'FaisalAlbasry'  " +
                 " when 'S-ubY2zvEwMY2' then 'Sky News'  " +
                 " else '  ' end as 'ServiceName' ,case ServiceID" +
                 " when 'S-FcY2zvEwMY2' then 'ALAFASY-MMS'  " +
                 " when 'S-rgY2zvEwMY2' then 'Golden Club'  " +
                 " when 'S-TfY2zvEwMY2' then 'EsamChawali'  " +
                 " when 'S-OeY2zvEwMY2' then 'islamicgreetingCards' " +
                 " when 'S-keY2zvEwMY2' then 'AlKharraz'  " +
                 " when 'S-fbY2zvEwMY2' then 'AlMaaref'  " +
                 " when 'S-mbY2zvEwMY2' then 'Al Arabiya News' " +
                 " when 'S-lbY2zvEwMY2' then 'Al Arabiya Newss'  " +
                 " when 'S-pbY2zvEwMY2' then 'AlArNews'  " +
                 " when 'S-chY2zvEwMY2' then 'Dr Fahad Charity' " +
                 " when 'S-UfY2zvEwMY2' then 'FaisalAlbasry'  " +
                 " when 'S-ubY2zvEwMY2' then 'Sky News'  " +
                 " else '  ' end as 'ShortCode'," +
                 " case when operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR' ) then 'Billing Success'" +
                 " when operationid in ('PS','YP', 'YG') then 'Billing Failure'" +
                 " when operationid in ('SP') then 'Billing Pending' end as BillingStatus" +
                 " ,count(*) 'Subscribers' from OoredooCurrSubsStatus" +
                 " where operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR', 'PS','YP', 'YG','SP')" +
                 " and UpdatedDate>='" + FromDate + "' and UpdatedDate<='" + ToDate + "' " + //Date Condition
                 " group by ServiceID,(case ServiceID" +
                 " when 'S-FcY2zvEwMY2' then 'ALAFASY-MMS'  " +
                " when 'S-rgY2zvEwMY2' then 'Golden Club'   " +
                " when 'S-TfY2zvEwMY2' then 'EsamChawali'   " +
                " when 'S-OeY2zvEwMY2' then 'islamicgreetingCards'  " +
                " when 'S-keY2zvEwMY2' then 'AlKharraz'   " +
                " when 'S-fbY2zvEwMY2' then 'AlMaaref'   " +
                " when 'S-mbY2zvEwMY2' then 'Al Arabiya News'  " +
                " when 'S-lbY2zvEwMY2' then 'Al Arabiya Newss'   " +
                " when 'S-pbY2zvEwMY2' then 'AlArNews'   " +
                " when 'S-chY2zvEwMY2' then 'Dr Fahad Charity'  " +
                " when 'S-UfY2zvEwMY2' then 'FaisalAlbasry'   " +
                " when 'S-ubY2zvEwMY2' then 'Sky News'   " +
                " else '  ' end )," +
                " (case ServiceID when 'S-FcY2zvEwMY2' then 'ALAFASY-MMS'  " +
                " when 'S-rgY2zvEwMY2' then 'Golden Club'  " +
                " when 'S-TfY2zvEwMY2' then 'EsamChawali'  " +
                " when 'S-OeY2zvEwMY2' then 'islamicgreetingCards' " +
                " when 'S-keY2zvEwMY2' then 'AlKharraz'  " +
                " when 'S-fbY2zvEwMY2' then 'AlMaaref'  " +
                " when 'S-mbY2zvEwMY2' then 'Al Arabiya News' " +
                " when 'S-lbY2zvEwMY2' then 'Al Arabiya Newss'  " +
                " when 'S-pbY2zvEwMY2' then 'AlArNews'  " +
                " when 'S-chY2zvEwMY2' then 'Dr Fahad Charity' " +
                " when 'S-UfY2zvEwMY2' then 'FaisalAlbasry'  " +
                " when 'S-ubY2zvEwMY2' then 'Sky News'  " +
                " else '  ' end )," +
                " (case when operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR' ) then 'Billing Success'" +
                " when operationid in ('PS','YP', 'YG') then 'Billing Failure'" +
                " when operationid in ('SP') then 'Billing Pending' end )" +
                " order by   ProductID ,ServiceName,ShortCode,BillingStatus";
                string SpecialServicesSubscribersQ = " Select Top 1000 ServiceID as ProductID " +
                " ,case ServiceID" +
                " when 'S-FcY2zvEwMY2' then 'ALAFASY-MMS'  " +
                " when 'S-rgY2zvEwMY2' then 'Golden Club'  " +
                " when 'S-TfY2zvEwMY2' then 'EsamChawali'  " +
                " when 'S-OeY2zvEwMY2' then 'islamicgreetingCards' " +
                " when 'S-keY2zvEwMY2' then 'AlKharraz'  " +
                " when 'S-fbY2zvEwMY2' then 'AlMaaref'  " +
                " when 'S-mbY2zvEwMY2' then 'Al Arabiya News' " +
                " when 'S-lbY2zvEwMY2' then 'Al Arabiya Newss'  " +
                " when 'S-pbY2zvEwMY2' then 'AlArNews'  " +
                " when 'S-chY2zvEwMY2' then 'Dr Fahad Charity' " +
                " when 'S-UfY2zvEwMY2' then 'FaisalAlbasry'  " +
                " when 'S-ubY2zvEwMY2' then 'Sky News'  " +
                " else '  ' end as 'ServiceName'" +
                " ,case ServiceID when 'S-FcY2zvEwMY2' then 'ALAFASY-MMS' " +
                " when 'S-rgY2zvEwMY2' then 'Golden Club'  " +
                " when 'S-TfY2zvEwMY2' then 'EsamChawali'  " +
                " when 'S-OeY2zvEwMY2' then 'islamicgreetingCards' " +
                " when 'S-keY2zvEwMY2' then 'AlKharraz'  " +
                " when 'S-fbY2zvEwMY2' then 'AlMaaref'  " +
                " when 'S-mbY2zvEwMY2' then 'Al Arabiya News' " +
                " when 'S-lbY2zvEwMY2' then 'Al Arabiya Newss'  " +
                " when 'S-pbY2zvEwMY2' then 'AlArNews'  " +
                " when 'S-chY2zvEwMY2' then 'Dr Fahad Charity' " +
                " when 'S-UfY2zvEwMY2' then 'FaisalAlbasry'  " +
                " when 'S-ubY2zvEwMY2' then 'Sky News'  " +
                " else '  ' end as 'ShortCode',Callingparty 'MSISDN'," +
                " case when operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR' ) then 'Billing Success'" +
                " when operationid in ('PS','YP', 'YG') then 'Billing Failure'" +
                " when operationid in ('SP') then 'Billing Pending' end as BillingStatus," +
                " max(UpdatedDate) 'LastTranDate'" +
                "  from OoredooCurrSubsStatus" +
                " where operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR', 'PS','YP', 'YG','SP')" +
                 " and UpdatedDate>='" + FromDate + "' and UpdatedDate<='" + ToDate + "' " + //Date Condition
                " group by ServiceID" +
                " ,(case ServiceID" +
               " when 'S-FcY2zvEwMY2' then 'ALAFASY-MMS'  " +
                " when 'S-rgY2zvEwMY2' then 'Golden Club'  " +
                " when 'S-TfY2zvEwMY2' then 'EsamChawali'  " +
                " when 'S-OeY2zvEwMY2' then 'islamicgreetingCards' " +
                " when 'S-keY2zvEwMY2' then 'AlKharraz' " +
                " when 'S-fbY2zvEwMY2' then 'AlMaaref'  " +
                " when 'S-mbY2zvEwMY2' then 'Al Arabiya News' " +
                " when 'S-lbY2zvEwMY2' then 'Al Arabiya Newss'  " +
                " when 'S-pbY2zvEwMY2' then 'AlArNews'  " +
                " when 'S-chY2zvEwMY2' then 'Dr Fahad Charity' " +
                " when 'S-UfY2zvEwMY2' then 'FaisalAlbasry'  " +
                " when 'S-ubY2zvEwMY2' then 'Sky News'  " +
                " else '  ' end)" +
                " ,(case ServiceID when 'S-FcY2zvEwMY2' then 'ALAFASY-MMS'  " +
                " when 'S-rgY2zvEwMY2' then 'Golden Club'  " +
                " when 'S-TfY2zvEwMY2' then 'EsamChawali'  " +
                " when 'S-OeY2zvEwMY2' then 'islamicgreetingCards' " +
                " when 'S-keY2zvEwMY2' then 'AlKharraz'  " +
                " when 'S-fbY2zvEwMY2' then 'AlMaaref'  " +
                " when 'S-mbY2zvEwMY2' then 'Al Arabiya News' " +
                " when 'S-lbY2zvEwMY2' then 'Al Arabiya Newss'  " +
                " when 'S-pbY2zvEwMY2' then 'AlArNews'  " +
                " when 'S-chY2zvEwMY2' then 'Dr Fahad Charity' " +
                " when 'S-UfY2zvEwMY2' then 'FaisalAlbasry'  " +
                " when 'S-ubY2zvEwMY2' then 'Sky News'  " +
                " else '  ' end),CallingParty,(" +
                " case when operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR' ) then 'Billing Success'" +
                " when operationid in ('PS','YP', 'YG') then 'Billing Failure'" +
                " when operationid in ('SP') then 'Billing Pending' end )" +
                "  order by   ProductID  ,ServiceName,ShortCode,MSISDN,BillingStatus,LastTranDate";

                sd.SpecialServices = KOdbctx.Database.SqlQuery<SpecialServices>(SpecialServicesQ).ToList<SpecialServices>();

                sd.SpecialServicesSubscribers = KOdbctx.Database.SqlQuery<SpecialServicesSubscribers>(SpecialServicesSubscribersQ).ToList();
                return sd;
            }

            else //if (Country + Operator == "IraqZain")
            {

                string SpecialServicesQ = " select ProductID, " +
                " case ProductID " +
                " when '1000004547' then 'Alafasy' " +
                " when '1000003507' then 'Khabar Ajil'  " +
                " else '  ' end as 'ServiceName',case ProductID  " +
                " when '1000004547' then '2885' " +
                " when '1000003507' then '3232'  " +
                " else '  ' end as 'ShortCode',case RentSuccess  " +
                " when '0' then 'Billing Success' " +
                " when '1' then 'Billing Failed' end as 'BillingStatus',count(*) 'Subscribers' from ZainSplServices_Subscribers  " +
                " where updatedesc not like 'Deletion' " +
                 " and TranDate>='" + FromDate + "' and TranDate<='" + ToDate + "' " + //Date Condition
                " group by ProductID,(case ProductID  " +
                " when '1000004547' then 'Alafasy' " +
                " when '1000003507' then 'Khabar Ajil'  " +
                " else '  ' end ),( case ProductID  " +
                " when '1000004547' then '2885' " +
                " when '1000003507' then '3232'  " +
                " else '  ' end ),(case RentSuccess  " +
                " when '0' then 'Billing Success' " +
                " when '1' then 'Billing Failed' end ) order by ProductID,ServiceName,ShortCode,BillingStatus ";
                string SpecialServicesSubscribersQ = " select Top 1000  ProductID,case ProductID  " +
                " when '1000004547' then 'Alafasy' " +
                " when '1000003507' then 'Khabar Ajil'  " +
                " else '  ' end as 'ServiceName',case ProductID  " +
                " when '1000004547' then '2885' " +
                " when '1000003507' then '3232'  " +
                " else '  ' end as 'ShortCode', UserID 'MSISDN',case RentSuccess  " +
                " when '0' then 'Billing Success' " +
                " when '1' then 'Billing Failed' end as 'BillingStatus',max(TranDate) 'LastTranDate'  " +
                " from ZainSplServices_Subscribers  " +
                " where updatedesc not like 'Deletion' " +
                 " and TranDate>='" + FromDate + "' and TranDate<='" + ToDate + "' " + //Date Condition
                " group by ProductID,(case ProductID  " +
                " when '1000004547' then 'Alafasy' " +
                " when '1000003507' then 'Khabar Ajil'  " +
                " else '  ' end),(case ProductID  " +
                " when '1000004547' then '2885' " +
                " when '1000003507' then '3232'  " +
                " else '  ' end ), UserID ,(case RentSuccess  " +
                " when '0' then 'Billing Success' " +
                " when '1' then 'Billing Failed' end ) order by ProductID,ShortCode,UserID,BillingStatus,LastTranDate  ";


                sd.SpecialServices = IZdbctx.Database.SqlQuery<SpecialServices>(SpecialServicesQ).ToList<SpecialServices>();

                sd.SpecialServicesSubscribers = IZdbctx.Database.SqlQuery<SpecialServicesSubscribers>(SpecialServicesSubscribersQ).ToList();
                return sd;
            }

        }
        //public IEnumerable<SpecialServices> GetSpecialServiceDetails(string Country, string Operator)
        //{

        //    if (Country + Operator == "KuwaitZain")
        //    {
        //        string SpecialServicesQ = " select ProductID, case ProductID " +
        //        " when '0' then 'SSSS' " +
        //        " when '1' then 'TTTT'  " +
        //        " else 'ELSE' end as 'ServiceName',case ProductID  " +
        //        " when '0' then 'SSSS' " +
        //        " when '1' then 'TTTT'  " +
        //        " else 'ELSE' end as 'ShortCode',case RentSuccess  " +
        //        " when '0' then 'Billing Success' " +
        //        " when '1' then 'Billing Failed' end as 'BillingStatus',count(*) 'Subscribers' from ZainSplServices_Subscribers  " +
        //        " where updatedesc not like 'Deletion' " +
        //        " group by ProductID,(case ProductID  " +
        //        " when '0' then 'SSSS' " +
        //        " when '1' then 'TTTT'  " +
        //        " else 'ELSE' end ),( case ProductID  " +
        //        " when '0' then 'SSSS' " +
        //        " when '1' then 'TTTT'  " +
        //        " else 'ELSE' end ),(case RentSuccess  " +
        //        " when '0' then 'Billing Success' " +
        //        " when '1' then 'Billing Failed' end ) order by ProductID,ServiceName,ShortCode,BillingStatus ";

        //        SSD = KZdbctx.Database.SqlQuery<SpecialServices>(SpecialServicesQ).ToList<SpecialServices>();

        //    }
        //    else if (Country + Operator == "KuwaitOoredoo")
        //    {

        //        string SpecialServicesQ = "Select ServiceID" +
        //        " ,case ServiceID" +
        //        " when 'S-FcY2zvEwMY2' then 'Afasy -123'" +
        //        " when 'S-OeY2zvEwMY2' then 'Dar Al Ebada - 1421'" +
        //        " else 'SNAME' end as 'ServiceName'" +
        //        " ,case ServiceID when 'S-FcY2zvEwMY2' then 'Afasy -123'" +
        //        " when 'S-OeY2zvEwMY2' then 'Dar Al Ebada - 1421'" +
        //        " else 'SHORT CODE' end as 'Short Code'," +
        //        " case when operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR' ) then 'Billing Success'" +
        //        " when operationid in ('PS','YP', 'YG') then 'Billing Failure'" +
        //        " when operationid in ('SP') then 'Billing Pending' end as BillingStatus" +
        //        " ,count(*) 'Subscribers' from OoredooCurrSubsStatus" +
        //        " where operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR', 'PS','YP', 'YG','SP')" +
        //        " group by ServiceID,(case ServiceID" +
        //        " when 'S-FcY2zvEwMY2' then 'Afasy -123'" +
        //        " when 'S-OeY2zvEwMY2' then 'Dar Al Ebada - 1421'" +
        //        " else 'SNAME' end )," +
        //        " (case ServiceID when 'S-FcY2zvEwMY2' then 'Afasy -123'" +
        //        " when 'S-OeY2zvEwMY2' then 'Dar Al Ebada - 1421'" +
        //        " else 'SHORT CODE' end )," +
        //        " (case when operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR' ) then 'Billing Success'" +
        //        " when operationid in ('PS','YP', 'YG') then 'Billing Failure'" +
        //        " when operationid in ('SP') then 'Billing Pending' end )" +
        //        " order by ServiceID,ServiceName,BillingStatus";

        //        SSD = KOdbctx.Database.SqlQuery<SpecialServices>(SpecialServicesQ).ToList<SpecialServices>();

        //    }
        //    else if (Country + Operator == "IraqZain")

        //    {
        //        string SpecialServicesQ = " select ProductID, case ProductID " +
        //        " when '0' then 'SSSS' " +
        //        " when '1' then 'TTTT'  " +
        //        " else 'ELSE' end as 'ServiceName',case ProductID  " +
        //        " when '0' then 'SSSS' " +
        //        " when '1' then 'TTTT'  " +
        //        " else 'ELSE' end as 'ShortCode',case RentSuccess  " +
        //        " when '0' then 'Billing Success' " +
        //        " when '1' then 'Billing Failed' end as 'BillingStatus',count(*) 'Subscribers' from ZainSplServices_Subscribers  " +
        //        " where updatedesc not like 'Deletion' " +
        //        " group by ProductID,(case ProductID  " +
        //        " when '0' then 'SSSS' " +
        //        " when '1' then 'TTTT'  " +
        //        " else 'ELSE' end ),( case ProductID  " +
        //        " when '0' then 'SSSS' " +
        //        " when '1' then 'TTTT'  " +
        //        " else 'ELSE' end ),(case RentSuccess  " +
        //        " when '0' then 'Billing Success' " +
        //        " when '1' then 'Billing Failed' end ) order by ProductID,ServiceName,ShortCode,BillingStatus ";
        //        SSD = IZdbctx.Database.SqlQuery<SpecialServices>(SpecialServicesQ).ToList<SpecialServices>();
        //    }
        //    return SSD;
        //}
        //public IEnumerable<SpecialServicesSubscribers> GetSpecialServicesSubscribersDetails(string Country, string Operator)
        //{

        //    if (Country + Operator == "KuwaitZain")
        //    {

        //        string SpecialServicesSubscribersQ = " select ProductID,case ProductID  " +
        //        " when '0' then 'SSSS' " +
        //        " when '1' then 'TTTT'  " +
        //        " else 'ELSE' end as 'ServiceName',case ProductID  " +
        //        " when '0' then 'SSSS' " +
        //        " when '1' then 'TTTT'  " +
        //        " else 'ELSE' end as 'ShortCode', UserID 'MSISDN',case RentSuccess  " +
        //        " when '0' then 'Billing Success' " +
        //        " when '1' then 'Billing Failed' end as 'BillingStatus',max(TranDate) 'LastTranDate'  " +
        //        " from ZainSplServices_Subscribers  " +
        //        " where updatedesc not like 'Deletion' " +
        //        " group by ProductID,(case ProductID  " +
        //        " when '0' then 'SSSS' " +
        //        " when '1' then 'TTTT'  " +
        //        " else 'ELSE' end),(case ProductID  " +
        //        " when '0' then 'SSSS' " +
        //        " when '1' then 'TTTT'  " +
        //        " else 'ELSE' end ), UserID ,(case RentSuccess  " +
        //        " when '0' then 'Billing Success' " +
        //        " when '1' then 'Billing Failed' end ) order by ProductID,ShortCode,UserID,BillingStatus  ";

        //        SSS = KZdbctx.Database.SqlQuery<SpecialServicesSubscribers>(SpecialServicesSubscribersQ).ToList<SpecialServicesSubscribers>();

        //    }
        //    else if (Country + Operator == "KuwaitOoredoo")
        //    {


        //        string SpecialServicesSubscribersQ = " Select ServiceID" +
        //        " ,case ServiceID" +
        //        " when 'S-FcY2zvEwMY2' then 'Afasy -123'" +
        //        " when 'S-OeY2zvEwMY2' then 'Dar Al Ebada - 1421'" +
        //        " else 'SNAME' end as 'ServiceName'" +
        //        " ,case ServiceID when 'S-FcY2zvEwMY2' then 'Afasy -123'" +
        //        " when 'S-OeY2zvEwMY2' then 'Dar Al Ebada - 1421'" +
        //        " else 'SHORT CODE' end as 'ShortCode',Callingparty 'MSISDN'," +
        //        " case when operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR' ) then 'Billing Success'" +
        //        " when operationid in ('PS','YP', 'YG') then 'Billing Failure'" +
        //        " when operationid in ('SP') then 'Billing Pending' end as BillingStatus," +
        //        " max(UpdatedDate) 'TranDate'" +
        //        "  from OoredooCurrSubsStatus" +
        //        " where operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR', 'PS','YP', 'YG','SP')" +
        //        " group by ServiceID" +
        //        " ,(case ServiceID" +
        //        " when 'S-FcY2zvEwMY2' then 'Afasy -123'" +
        //        " when 'S-OeY2zvEwMY2' then 'Dar Al Ebada - 1421'" +
        //        " else 'SNAME' end )" +
        //        " ,(case ServiceID when 'S-FcY2zvEwMY2' then 'Afasy -123'" +
        //        " when 'S-OeY2zvEwMY2' then 'Dar Al Ebada - 1421'" +
        //        " else 'SHORT CODE' end),CallingParty,(" +
        //        " case when operationid in ('SN', 'SR', 'RN', 'YR', 'GR', 'RR' ) then 'Billing Success'" +
        //        " when operationid in ('PS','YP', 'YG') then 'Billing Failure'" +
        //        " when operationid in ('SP') then 'Billing Pending' end )" +
        //        "  order by ServiceID ,ServiceName,ShortCode,MSISDN,BillingStatus,TranDate";

        //        SSS = KOdbctx.Database.SqlQuery<SpecialServicesSubscribers>(SpecialServicesSubscribersQ).ToList<SpecialServicesSubscribers>();

        //    }
        //    else if (Country + Operator == "IraqZain")

        //    {

        //        string SpecialServicesSubscribersQ = " select ProductID,case ProductID  " +
        //        " when '0' then 'SSSS' " +
        //        " when '1' then 'TTTT'  " +
        //        " else 'ELSE' end as 'ServiceName',case ProductID  " +
        //        " when '0' then 'SSSS' " +
        //        " when '1' then 'TTTT'  " +
        //        " else 'ELSE' end as 'ShortCode', UserID 'MSISDN',case RentSuccess  " +
        //        " when '0' then 'Billing Success' " +
        //        " when '1' then 'Billing Failed' end as 'BillingStatus',max(TranDate) 'LastTranDate'  " +
        //        " from ZainSplServices_Subscribers  " +
        //        " where updatedesc not like 'Deletion' " +
        //        " group by ProductID,(case ProductID  " +
        //        " when '0' then 'SSSS' " +
        //        " when '1' then 'TTTT'  " +
        //        " else 'ELSE' end),(case ProductID  " +
        //        " when '0' then 'SSSS' " +
        //        " when '1' then 'TTTT'  " +
        //        " else 'ELSE' end ), UserID ,(case RentSuccess  " +
        //        " when '0' then 'Billing Success' " +
        //        " when '1' then 'Billing Failed' end ) order by ProductID,ShortCode,UserID,BillingStatus  ";

        //        SSS = IZdbctx.Database.SqlQuery<SpecialServicesSubscribers>(SpecialServicesSubscribersQ).ToList<SpecialServicesSubscribers>();
        //    }
        //    return SSS;
        //}



    }

}
