using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace WebApplication1.Model.ViewModelIdentity.SeedRole
{
    public class AppDBInitlization
    {
        public static async Task seedRoleDB(IApplicationBuilder applicationBuilder)
        {
            using(var servicesSocet=applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManger = servicesSocet.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManger.RoleExistsAsync(UserRole.Manager))
                {
                    await roleManger.CreateAsync(new IdentityRole(UserRole.Manager));
                }
                if (!await roleManger.RoleExistsAsync(UserRole.user))
                {
                    await roleManger.CreateAsync(new IdentityRole(UserRole.user));
                }
            }
        }
    }
}
