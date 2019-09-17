using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace SistemaGCD.Security
{
    public class LoggedFilter: IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // our code before action executes
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Session == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                        { "controller", "Access" },
                        {"action","Index" }
                    });
            }
            // our code after action executes
        }
    }
}
