using Domain;
namespace Persistence;


public class Seed
{
    public static void SeedData(DataContext context)
    {
        if (!context.Posts.Any())
        {
            var Posts = new List<Post>
            {
                new() {
                    Title = "First post",
                    Body =  "Est nisi excepteur ex ea incididunt",
                    Date = DateTime.Now.AddDays(-10)
                    },
                new() {
                    Title = "Second post",
                    Body =  "Quis consectetur ex fugiat qui.",
                    Date = DateTime.Now.AddDays(-10)
                    },
                new() {
                    Title = "Third post",
                    Body =  "Officia ea elit fugiat et esse aliqua dolore cillum in occaecat do nisi est.",
                    Date = DateTime.Now.AddDays(-10)
                    }
            };

            context.Posts.AddRange(Posts);
            context.SaveChanges();
        }
    }
}