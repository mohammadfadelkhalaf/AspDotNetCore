using Infrastructure.Context;
using Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Helpers
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(DataContext dbContext)
        {
            if (!dbContext.Courses.Any())
            {
                var CourseData = File.ReadAllText("../Infrastructure/DataSeed/Course.json");
                var Courses = JsonSerializer.Deserialize<List<CourseEntity>>(CourseData);
                if (Courses?.Count > 0)
                {
                    foreach (var course in Courses)

                        await dbContext.Set<CourseEntity>().AddAsync(course);

                    await dbContext.SaveChangesAsync();
                }

            }
          
         
        }

    }

}
