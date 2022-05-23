using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Notes.Application.Interfaces;


namespace Notes.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection service,
            IConfiguration configuration)
        {
            var ConnecionString = configuration["DbConnection"];
            service.AddDbContext<NotesDbContext>(options =>
            {
                options.UseSqlite(ConnecionString);
            });
            service.AddScoped<INotesDbContext>(provider => provider.GetService<NotesDbContext>());

            return service;
        } 
    }
}
