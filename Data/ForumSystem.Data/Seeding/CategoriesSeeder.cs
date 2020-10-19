namespace ForumSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ForumSystem.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new Dictionary<string, string>
            {
                { "Sport", @"https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Sport_balls.svg/200px-Sport_balls.svg.png" },
                { "Coronavirus", @"https://thediplomat.com/wp-content/uploads/2020/04/sizes/td-story-s-1/thediplomat-2020-04-01.png" },
                { "News", @"https://ubclubs.eu/wp-content/uploads/2017/10/news-3.jpg" },
                { "Music", @"https://9b16f79ca967fd0708d1-2713572fef44aa49ec323e813b06d2d9.ssl.cf2.rackcdn.com/1140x_a10-7_cTC/NS-WKMAG0730-1595944356.jpg" },
                { "Programming", @"https://softcaliber.com/wp-content/uploads/2019/04/programmingLanguages.jpg" },
                { "Cats", @"https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcR0n5V7lu71Ue35mpGTLCrXmtl3ZuB4ZPsT8Q&usqp=CAU" },
                { "Dogs", @"https://d17fnq9dkz9hgj.cloudfront.net/breed-uploads/2018/09/dog-landing-hero-sm.jpg?bust=1536935086" }
            };

            foreach (var kvp in categories)
            {
                var category = kvp.Key;
                var imageUrl = kvp.Value;
                await dbContext.Categories.AddAsync(new Category
                {
                    Name = category,
                    Description = category,
                    Title = category,
                    ImageUrl = imageUrl
                });
            }
        }
    }
}
