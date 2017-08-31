using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auth.Model
{
    public class CustomAccountModel
    {
        public List<CustomAccount> Custaccts = new List<CustomAccount>();

        public CustomAccountModel()
        {
            Custaccts.Add(new CustomAccount
            {
                Username = "OGVAS",
                password = "OGVAS",
                Roles = new string[] { "OGVAS" }
            });
            Custaccts.Add(new CustomAccount
            {
                Username = "VT",
                password = "VT",
                Roles = new string[] { "VASTech", "OGVAS" }
            });
            //Custaccts.Add(new CustomAccount
            //{
            //    Username = "VAST",
            //    password = "VasT@123",
            //    Roles = new string[] { "CP", "OgBiz","VASTech" }
            //});
        }
        public CustomAccount finduseracct(string uname)
        {
            CustomAccount useracct = Custaccts.Find(u => u.Username.Equals(uname));
            return useracct;
        }

        public CustomAccount login(string uname, string pwd)
        {
            CustomAccount useracctl = Custaccts.Find(u => u.Username.Equals(uname) && u.password.Equals(pwd));
            return useracctl;
        }
        //Defined below method for Roles
        public  string[] GetRoles(string uname)
        {
            List<string> Roles=new List<string>();
            CustomAccount cust= Custaccts.Find(u => u.Username.Contains(uname));
            return cust.Roles;
        }
    }
}
