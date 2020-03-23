using System;
using System.Data.Entity;
using dotnet.Services;

namespace dotnet.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<AppDBContext>
    {
        protected override void Seed(AppDBContext db)
        {
            db.UserTypes.Add(new UserType { Id = UserType.USER, Name = "User" });
            db.UserTypes.Add(new UserType { Id = UserType.ADMIN, Name = "Admin" });

            db.Users.Add(new User
            {
                Email = "admin@admin.admin",
                Password = Hash.HashPass("admin@admin.admin"),
                UserTypeId = UserType.ADMIN
            });

            db.Genres.Add(new Genre { Id = 1, Name = "Adventure" });
            db.Genres.Add(new Genre { Id = 2, Name = "Comedy" });
            db.Genres.Add(new Genre { Id = 3, Name = "Gangster" });

            string[] names = {
                "Maggie",
                "Penny",
                "Saya",
                "Princess",
                "Abby",
                "Laila",
                "Sadie",
                "Olivia",
                "Starlight",
                "Talla",
                "Rufus",
                "Bear",
                "Dakota",
                "Fido",
                "Vanya",
                "Samuel",
                "Koani",
                "Volodya",
                "Prince",
                "Yiska"
            };


            var random = new Random();

            for (int i = 0; i < 35; i++)
            {
                var name = names[random.Next(names.Length)];

                db.Films.Add(new Film
                {
                    Name = "Adventures of " + name,
                    Description = "Sed ut perspiciatis unde omnis iste natus error "
                        + "sit voluptatem accusantium doloremque laudantium, totam rem aperiam, "
                        + "eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae "
                        + "vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit "
                        + "aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui "
                        + "ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem "
                        + "ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam "
                        + "eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat "
                        + "voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam "
                        + "corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? "
                        + "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam "
                        + "nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas "
                        + "nulla pariatur?",
                    Link = "http://films.storage.com/Adventures+of+" + name,
                    GenreId = random.Next(1, 3),
                });
            }

            base.Seed(db);
        }
    }
}
