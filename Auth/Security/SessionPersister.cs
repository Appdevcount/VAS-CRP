using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auth.Security
{
    public class SessionPersister
    {
        static string usernamesessionvar = "username";
        public static string username
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionvar = HttpContext.Current.Session[usernamesessionvar];
                if (sessionvar != null)
                    return sessionvar as string;
                return null;

            }
            set
            {
                HttpContext.Current.Session[usernamesessionvar] = value;
            }
        }
    }
}
