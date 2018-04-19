using SignalR_SqlDepenciy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NeCoin.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Bitcoin> Bitcoin { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Exchange> Exchange { get; set; }
        public DbSet<Sell> Sell { get; set; }
        public DbSet<MyWallet> MyWallet { get; set; }




        public DatabaseContext()
        {
            Database.SetInitializer(new CreateFakeDatabase());
        }

    }
    public class CreateFakeDatabase : CreateDatabaseIfNotExists<DatabaseContext>
    {

        protected override void Seed(DatabaseContext context)
        {
            User oneUser = new User()
            {
                Name = "Necoin",
                Surname = "Necoinim",
                Email = "info@necoin.com",
                Password = "123"
            };
            context.User.Add(oneUser);

            for (int i = 0; i < 3; i++)
            {
                User user = new User()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    Password = "123"




                };
                context.User.Add(user);

            }

            for (int i = 0; i < 20; i++)
            {
                Bitcoin btc = new Bitcoin()
                {
                    Total = FakeData.NumberData.GetDouble() + 10,
                    quantity = FakeData.NumberData.GetDouble(),

                    Price=FakeData.NumberData.GetDouble()



                };

                context.Bitcoin.Add(btc);
            }




            for (int i = 0; i < 20; i++)
            {
                Sell sellling = new Sell()
                {
                    Total = FakeData.NumberData.GetDouble() + 10,
                    quantity = FakeData.NumberData.GetDouble(),            
                    Price = FakeData.NumberData.GetDouble() 



                };

                context.Sell.Add(sellling);
            }







            Exchange ex = new Exchange()
            {
                Name = "Btc",
                Stock_Exchange = FakeData.NumberData.GetDouble() + 1000.ToString()

            };
            Exchange exc = new Exchange()
            {
                Name = "Ltc",
                Stock_Exchange = FakeData.NumberData.GetDouble() + 10.ToString()

            };

            context.Exchange.Add(ex);
            context.Exchange.Add(exc);
            context.SaveChanges();

        }

    }







}