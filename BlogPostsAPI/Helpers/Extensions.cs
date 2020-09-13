using BlogPostsAPI.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlogPostsAPI.Helpers
{
    public static class Extensions
    {
        public static IWebHost MigrateDatabase(this IWebHost webhost)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (env == "Production")
            {
                var serviceScopeFactory = (IServiceScopeFactory)webhost.Services.GetService(typeof(IServiceScopeFactory));

                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var dbContext = services.GetRequiredService<BlogPostsDbContext>();

                    dbContext.Database.Migrate();
                }
            }
            return webhost;
        }
    }
}
