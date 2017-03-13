
using ShoeShop.Common;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShoeShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (UserLogin)Session["USER_SESSION"];
            if(session == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                  new RouteValueDictionary(new { controller = "Account", action = "Index", Areas = "Admin" }));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}