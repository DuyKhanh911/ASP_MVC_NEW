using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SaleWeb.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Login" ,action = "Index", id = UrlParameter.Optional },
                  new[] { "SaleWeb.Areas.Admin.Controllers" }
            );
        }
    }
}