using Applicant_JOB_APP.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Applicant_JOB_APP.Startup))]
namespace Applicant_JOB_APP
{
    public partial class Startup
    {

       // private Model1 db = new Model1();
        ApplicationDbContext db = new ApplicationDbContext();


        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUsers();
        }




        public void CreateUsers()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var User = new ApplicationUser();
            User.Email = "aziza99@gmail.com";
            User.UserName = "Aziza";
            var check = userManager.Create(User, "aziza99@gmail.com");
            if (check.Succeeded)
            {

                userManager.AddToRole(User.Id, "admin");

            }





        }
    }
}
