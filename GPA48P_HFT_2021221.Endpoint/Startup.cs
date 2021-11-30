using GPA48P_HFT_2021221.Data;
using GPA48P_HFT_2021221.Repository;
using GPA48P_HFT_2021221.Logic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GPA48P_HFT_2021221.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IAnimalShelterLogic, AnimalShelterLogic>();
            services.AddTransient<IOwnerLogic, OwnerLogic>();
            services.AddTransient<IPetLogic, PetLogic>();

            services.AddTransient<IAnimalShelterRepository, AnimalShelterRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IPetRepository, PetRepository>();

            services.AddTransient<AnimalShelterDbContext, AnimalShelterDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
