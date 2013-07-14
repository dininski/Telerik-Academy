namespace Telelinkedin.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<Telelinkedin.Models.TelelinkedinDb>
    {
        private const string defaultConnection = "DefaultConnection";
        private const string userTable = "UserProfile";
        private const string userIdColumn = "UserId";
        private const string userNameColumn = "UserName";
        private const string adminRoleString = "Admin";
        private const string defaultAdminUsername = "admin";
        private const string defaultAdminPassword = "admin123";

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Telelinkedin.Models.TelelinkedinDb context)
        {
            SeedMembership();
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection(defaultConnection,
                userTable, userIdColumn, userNameColumn, autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists(adminRoleString))
            {
                roles.CreateRole(adminRoleString);
            }

            if (membership.GetUser(defaultAdminUsername, false) == null)
            {
                membership.CreateUserAndAccount(defaultAdminUsername, defaultAdminPassword);
            }

            if (!roles.GetRolesForUser(defaultAdminUsername).Contains(adminRoleString))
            {
                roles.AddUsersToRoles(new[] { defaultAdminUsername }, new[] { adminRoleString });
            }
        }
    }
}
