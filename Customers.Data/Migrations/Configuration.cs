using Customers.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
namespace Customers.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Customers.Data.CustomerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Customers.Data.CustomerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var c = new Customer
            {
                FullName = "Reymond Villaluz",
                Age = 28,
                DOB = DateTime.Parse("1991-11-27"),
                AddressList = new List<Address>
                {
                    new Address { Addressline1 = "Wawa Taguig", Addressline2 = "", City = "Manila", State = "Philippines" }
                }
            };

            var cList = new List<Customer>
            {
                new Customer
                {
                    FullName = "Reymond Villaluz",
                    Age = 28,
                    DOB = DateTime.Parse("1991-11-27"),
                    AddressList = new List<Address>
                    {
                        new Address { Addressline1 = "Wawa", Addressline2 = "", City = "Taguig", State = "Manila" }
                    }
                },
                new Customer
                {
                    FullName = "PetSure Global",
                    Age = 5,
                    DOB = DateTime.Parse("2014-01-01"),
                    AddressList = new List<Address>
                    {
                        new Address { Addressline1 = "BGC", Addressline2 = "", City = "Taguig", State = "Manila" }
                    }
                },
            };
            foreach (var item in cList)
            {
                context.Customers.Add(item);
            }
            context.SaveChanges();
        }
    }
}
