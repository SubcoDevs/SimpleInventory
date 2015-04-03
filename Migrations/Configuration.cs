namespace InventoryManagement.Migrations
{
    using InventoryManagement.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<InventoryManagement.Models.ProductDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(InventoryManagement.Models.ProductDb context)
        {
            //  This method will be called after migrating to the latest version.

            //context.Products.AddOrUpdate(r => r.Name,
            //    new Product { Name = "ALMOST FAMOUS TEE", Description = "The ALMOST FAMOUS Tee is made from super light weight 80gsm 100% cotton loose knit single jersey, with a Black print on the front. Combined with heavy Enzyme wash to give the garment soft hand feel.", Brand = "Castle", Tags = "Winter 2012, T-shirts", WholesalePrice = 22.50f, RetailPrice = 90.00f, BuyPrice = 15.00f, InitialCostPrice = 16.50f, Stock = 45, Taxable = true, ManageStock = true, KeepSelling = true, PublishOnline = true, OnlineOrdering = false },
            //    new Product { Name = "Sneaky A Frame", Description = "Athletes have won more championships and medals with the Sneaky A Frame than with any other single sport product on earth.", Brand = "Sneaky", Tags = "Sunglasses, Sports", WholesalePrice = 22.50f, RetailPrice = 90.00f, BuyPrice = 15.00f, InitialCostPrice = 16.50f, Stock = 45, Taxable = true, ManageStock = false, KeepSelling = false, PublishOnline = true, OnlineOrdering = true }
            //    );

            context.Products.AddOrUpdate(r => r.Name,
                new Product { Name = "ALMOST FAMOUS TEE", Description = "The ALMOST FAMOUS Tee is made from super light weight 80gsm 100% cotton loose knit single jersey, with a Black print on the front. Combined with heavy Enzyme wash to give the garment soft hand feel.", Brand = "Castle", Tags = "Winter 2012, T-shirts", WholesalePrice = 22.50f, RetailPrice = 90.00f, BuyPrice = 15.00f, InitialCostPrice = 16.50f, Stock = 45,ClientId=1 },
                new Product { Name = "Sneaky A Frame", Description = "Athletes have won more championships and medals with the Sneaky A Frame than with any other single sport product on earth.", Brand = "Sneaky", Tags = "Sunglasses, Sports", WholesalePrice = 22.50f, RetailPrice = 90.00f, BuyPrice = 15.00f, InitialCostPrice = 16.50f, Stock = 45,ClientId=2 }
                );

            SeedMembership();
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }

            if(membership.GetUser("User123",false) == null)
            {
                membership.CreateUserAndAccount("User123", "password");
            }

            if (!roles.GetRolesForUser("User123").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "User123" }, new[] { "Admin" });
            }
        }
    }
}
