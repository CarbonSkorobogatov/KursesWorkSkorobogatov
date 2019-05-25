using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProxSenceProject.Models.EntityFramework
{
    public class IdentityEFDbContext : IdentityDbContext<IdentityUser>
    {
        public IdentityEFDbContext(DbContextOptions<IdentityEFDbContext> options) : base(options)
        {

        }

    }
}
