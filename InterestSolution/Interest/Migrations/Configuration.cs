namespace Interest.Migrations
{
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Net;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<Interest.Models.InterestDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Interest.Models.InterestDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var client = new WebClient();
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("Password@123");
            context.Users.AddOrUpdate(
                x => x.UserName,
                new InterestUser
                {
                    UserName = "aaron@hudson.net",
                    PasswordHash = password
                },
                new InterestUser
                {
                    UserName = "scott@furgeson.net",
                    PasswordHash = password
                },
                new InterestUser
                {
                    UserName = "daniel@pollock.net",
                    PasswordHash = password
                },
                new InterestUser
                {
                    UserName = "brandon@goza.net",
                    PasswordHash = password
                },
                new InterestUser
                {
                    UserName = "mike@null.net",
                    PasswordHash = password
                },
                new InterestUser
                {
                    UserName = "jason@williams.net",
                    PasswordHash = password
                }
                );
            byte[] image1 = Pin.ResizeImage(client.DownloadData(@"http://www.fuelyourcreativity.com/files/Movie-Poster-Typography-8.jpeg"), 100, 100);
            byte[] image2 = Pin.ResizeImage(client.DownloadData(@"http://gdj.gdj.netdna-cdn.com/wp-content/uploads/2011/12/grey-movie-poster.jpg"), 100, 100);
            byte[] image3 = Pin.ResizeImage(client.DownloadData(@"http://movieheritage.com/image/data/24/avatar.jpg"), 100, 100);
            byte[] image4 = Pin.ResizeImage(client.DownloadData(@"http://images5.fanpop.com/image/photos/26200000/Real-Steel-movie-posters-26233237-1079-1600.jpg"), 100, 100);
            byte[] image5 = Pin.ResizeImage(client.DownloadData(@"http://www.impawards.com/1997/posters/titanic_ver2_xlg.jpg"), 100, 100);
            byte[] image6 = Pin.ResizeImage(client.DownloadData(@"http://images5.fanpop.com/image/photos/26500000/Robert-Downey-Jr-SH2-Movie-Posters-robert-downey-jr-26552473-800-1278.jpg"), 100, 100);
            byte[] image7 = Pin.ResizeImage(client.DownloadData(@"http://www.freedesign4.me/wp-content/gallery/posters/free-movie-film-poster-the_dark_knight_movie_poster.jpg"), 100, 100);

            context.Pins.AddOrUpdate(
            x => x.url,
            new Pin
            {
                Image = image1,
                Publisher = context.Users.FirstOrDefault(x => x.UserName == "aaron@hudson.net"),
                Notes = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer maximus rhoncus lorem sit amet semper. Mauris ut arcu id dui scelerisque cursus id nec dui. In hac habitasse platea dictumst.",
                url = @"http://www.imdb.com/title/tt1156398/?ref_=nv_sr_1"
            },
            new Pin
            {
                Image = image2,
                Publisher = context.Users.FirstOrDefault(x => x.Id == "scott@furgeson.net"),
                Notes = "In in sodales quam. Morbi sodales nisi semper pharetra iaculis. Fusce at erat lacus.",
                url = "http://www.imdb.com/title/tt1601913/?ref_=nv_sr_1"
            },
            new Pin
            {
                Image = image3,
                Publisher = context.Users.FirstOrDefault(x => x.Id == "daniel@pollock.net"),
                Notes = "Proin venenatis cursus neque sed porta.",
                url = "http://www.imdb.com/title/tt0499549/?ref_=nv_sr_1"
            },
            new Pin
            {
                Image = image4,
                Publisher = context.Users.FirstOrDefault(x => x.Id == "brandon@goza.net"),
                Notes = "Sed aliquam turpis varius, condimentum velit ut, ornare odio. Donec gravida posuere vehicula.",
                url = "http://www.imdb.com/title/tt0433035/?ref_=fn_al_tt_1"
            },
            new Pin
            {
                Image = image5,
                Publisher = context.Users.FirstOrDefault(x => x.Id == "mike@null.net"),
                Notes = "Nam maximus eu nisi vitae sollicitudin.",
                url = "http://www.imdb.com/title/tt0120338/?ref_=nv_sr_1"
            },
            new Pin
            {
                Image = image6,
                Publisher = context.Users.FirstOrDefault(x => x.Id == "aaron@hudson.net"),
                Notes = "Ut hendrerit at mauris ac dapibus. Nulla ullamcorper quam quam, vitae varius lectus laoreet nec.",
                url = "http://www.imdb.com/title/tt0988045/?ref_=nv_sr_1"
            },
            new Pin
            {
                Image = image7,
                Publisher = context.Users.FirstOrDefault(x => x.Id == "brandon@goza.net"),
                Notes = "Aenean aliquet neque augue, in molestie nisl interdum et. Aliquam nec faucibus elit. Etiam pharetra enim ut posuere porta.",
                url = "http://www.imdb.com/title/tt0468569/?ref_=nv_sr_1"
            }
            );
            context.SaveChanges(context);
        }
    }
}
