using System.Web;
using System.Web.Mvc;

namespace FTPShare.Controllers
{
    public class Chk_Authen : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["FTP_Auth"] == null && HttpContext.Current.Session["FTP_Partner"] == null)
            {
                string loginpath = "~/Home/Index";
                //if (HttpContext.Current.Request.Url != null)
                //{
                //    HttpContext.Current.Session["FTP_Redirect"] = HttpContext.Current.Request.Url;
                //}
                filterContext.Result = new RedirectResult(loginpath);
            }
        }
    }
}