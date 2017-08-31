using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Auth.Model;

namespace Auth.Security
{
    public class CustomPrincipal //: IPrincipal
    {
        public CustomAccount useracct;

        public CustomPrincipal(CustomAccount uact)
        {
            this.useracct = uact;
            this.Identity = new GenericIdentity(uact.Username);
        }
        public IIdentity Identity
        {
            get; set;
            //get
            //{
            //    throw new NotImplementedException();
            //}
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.useracct.Roles.Contains(r));
            //throw new NotImplementedException();
        }
    }
}

