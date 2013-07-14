using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace Telelinkedin
{
    public class MembershipConfig
    {
        public static void Register()
        {
            InitializeMembershipDb();
        }

        private static void InitializeMembershipDb()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
        }
    }
}