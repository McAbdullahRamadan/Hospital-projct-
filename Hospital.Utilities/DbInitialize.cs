
using Hospital.Model;
using Hospital.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Utilities
{
    public class DbInitialize : IDbInitialize
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public DbInitialize(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();

                }

            }
            catch (Exception)
            {

                throw;
            }
            if (!_roleManager.RoleExistsAsync(WebSiteRolse.WenSite_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRolse.WenSite_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRolse.WenSite_Patient)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRolse.WenSite_Doctor)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "abdullah",
                    Email = "abdullah@a.com"
                }, "abdullah123").GetAwaiter().GetResult();
                var appuser = _context.ApplicationUsers.FirstOrDefault(x => x.Email == "abdullah@a.com");
                if (appuser != null)
                {
                    _userManager.AddToRoleAsync(appuser, WebSiteRolse.WenSite_Admin).GetAwaiter().GetResult();
                }

            }
        }
    }
}
