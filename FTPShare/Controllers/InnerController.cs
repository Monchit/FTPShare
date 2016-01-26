using FTPShare.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

namespace FTPShare.Controllers
{
    public class InnerController : Controller
    {
        //
        // GET: /Inner/
        FTPShareEntities dbSys = new FTPShareEntities();

        [Chk_Authen]
        public ActionResult Index()
        {
            //var owner = Session["FTP_Auth"].ToString();
            //var folder = from a in dbSys.td_owner_folder
            //             where a.owner == owner
            //             select a;
            return View();
        }

        [HttpPost]
        public JsonResult FolderList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                var owner = Session["FTP_Auth"].ToString();
                var query = dbSys.td_owner_folder.Where(w => w.owner == owner);

                //Get data from database
                int TotalRecord = query.Count();

                // Paging
                var output = query
                    .Select(s => new
                    {
                        s.owner,
                        s.folder,
                        s.exp_dt
                    }).OrderBy(jtSorting).Skip(jtStartIndex).Take(jtPageSize);

                //Return result to jTable
                return Json(new { Result = "OK", Records = output, TotalRecordCount = TotalRecord });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult CreateFolder()
        {
            try
            {
                var owner = Session["FTP_Auth"].ToString();
                var formData = Request.Form["folder"];
                var dbData = dbSys.td_owner_folder.Where(w => w.owner == owner && w.folder == formData);
                if (dbData != null)
                {
                    DateTime dt = DateTime.ParseExact(Request.Form["exp_dt"], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    td_owner_folder data = new td_owner_folder();
                    data.folder = formData;
                    data.owner = owner;
                    data.exp_dt = dt;
                    data.create_dt = DateTime.Now;

                    dbSys.td_owner_folder.Add(data);
                }

                dbSys.SaveChanges();

                return Json(new { Result = "OK", Record = dbSys.td_owner_folder.OrderByDescending(o => o.create_dt).FirstOrDefault() });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UpdateFolder()
        {
            try
            {
                var owner = Session["FTP_Auth"].ToString();
                var formData = Request.Form["folder"];
                DateTime dt = DateTime.ParseExact(Request.Form["exp_dt"], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var data = dbSys.td_owner_folder.Find(owner, formData);
                data.exp_dt = dt;
                dbSys.SaveChanges();

                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DeleteFolder()
        {
            try
            {
                var owner = Session["FTP_Auth"].ToString();
                var formData = Request.Form["folder"];
                var data = dbSys.td_owner_folder.Find(owner, formData);
                dbSys.td_owner_folder.Remove(data);
                dbSys.SaveChanges();

                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [Chk_Authen]
        public ActionResult Detail(string id)
        {
            ViewBag.Folder = id;
            return View();
        }

        [Chk_Authen]
        public ActionResult Reader()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ReaderList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                var owner = Session["FTP_Auth"].ToString();
                var query = dbSys.td_reader_user.Where(w => w.owner == owner);

                //Get data from database
                int TotalRecord = query.Count();

                // Paging
                var output = query
                    .Select(s => new
                    {
                        s.owner,
                        s.reader,
                        s.pass,
                        s.exp_dt
                    }).OrderBy(jtSorting).Skip(jtStartIndex).Take(jtPageSize);

                //Return result to jTable
                return Json(new { Result = "OK", Records = output, TotalRecordCount = TotalRecord });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult CreateReader()
        {
            try
            {
                var owner = Session["FTP_Auth"].ToString();
                var formData = Request.Form["reader"];
                var dbData = dbSys.td_reader_user.Where(w => w.owner == owner && w.reader == formData);
                if (dbData != null)
                {
                    DateTime dt = DateTime.ParseExact(Request.Form["exp_dt"], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    td_reader_user data = new td_reader_user();
                    data.reader = formData;
                    data.owner = owner;
                    data.pass = Request.Form["pass"];
                    data.exp_dt = dt;

                    dbSys.td_reader_user.Add(data);
                }

                dbSys.SaveChanges();

                return Json(new { Result = "OK", Record = dbSys.td_reader_user.OrderByDescending(o => o.reader).FirstOrDefault() });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UpdateReader()
        {
            try
            {
                var owner = Session["FTP_Auth"].ToString();
                var formData = Request.Form["reader"];
                DateTime dt = DateTime.ParseExact(Request.Form["exp_dt"], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var data = dbSys.td_reader_user.Find(owner, formData);
                data.exp_dt = dt;
                data.pass = Request.Form["pass"];
                dbSys.SaveChanges();

                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DeleteReader()
        {
            try
            {
                var owner = Session["FTP_Auth"].ToString();
                var formData = Request.Form["reader"];
                var data = dbSys.td_reader_user.Find(owner, formData);
                dbSys.td_reader_user.Remove(data);
                dbSys.SaveChanges();

                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

    }
}
