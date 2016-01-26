using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCommonFunction;
using FTPShare.Models;

namespace FTPShare.Controllers
{
    public class HomeController : Controller
    {
        TNCSecurity secure = new TNCSecurity();
        //TNCFileDirectory dir = new TNCFileDirectory();
        //TNCUtility util = new TNCUtility();

        //TNC_ADMINEntities dbTNC = new TNC_ADMINEntities();
        FTPShareEntities dbSys = new FTPShareEntities();

        [AllowAnonymous]
        public ActionResult Index()
        {
            //Login Page
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Login()
        {
            string loginType = Request.Form["loginType"];
            string username = Request.Form["Username"];
            string pass = Request.Form["Password"];

            if (loginType == "inner")
            {
                var chklogin = secure.Login(username, pass, false);//set false to true for Real

                var chkSysUser = dbSys.tm_sys_user.Where(w => w.emp_code == chklogin.emp_code).FirstOrDefault();
                if (chkSysUser != null)
                {
                    Session["FTP_SysAuthority"] = chkSysUser.tm_sys_utype.authority;
                }

                if (chklogin != null)
                {
                    Session["FTP_Auth"] = chklogin.emp_code;
                    return RedirectToAction("Index", "Inner");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else if (loginType == "outer")
            {
                var chklogin = this.PartnerLogin(username, pass, false);
                if (chklogin != null)
                {
                    Session["FTP_Partner"] = chklogin.reader;
                    Session["FTP_Owner"] = chklogin.owner;
                    return RedirectToAction("Index", "Outer");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("FTP_Auth");
            Session.Remove("FTP_Partner");
            Session.Remove("FTP_SysAuthority");
            Session.Remove("FTP_Owner");
            return RedirectToAction("Index", "Home");
        }

        private td_reader_user PartnerLogin(string username, string password, bool chkPassword)
        {
            IQueryable<td_reader_user> user;
            if (chkPassword)
                user = dbSys.td_reader_user.Where(w => w.reader == username && w.pass == password && w.exp_dt < DateTime.Now);
            else
                user = dbSys.td_reader_user.Where(w => w.reader == username);

            return user.FirstOrDefault();
        }


    }
}
