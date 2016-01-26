using FTPShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

namespace FTPShare.Controllers
{
    public class OuterController : Controller
    {
        //
        // GET: /Outer/
        FTPShareEntities dbSys = new FTPShareEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ShareFolderList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                var owner = Session["FTP_Owner"].ToString();
                var reader = Session["FTP_Partner"].ToString();
                var query = dbSys.tr_reader_folder.Where(w => w.owner == owner && w.reader == reader);
                //var query = dbSys.td_owner_folder.Where(w => w.owner == owner);

                //Get data from database
                int TotalRecord = query.Count();

                // Paging
                var output = query
                    .Select(s => new
                    {
                        s.owner,
                        s.folder
                    }).OrderBy(jtSorting).Skip(jtStartIndex).Take(jtPageSize);

                //Return result to jTable
                return Json(new { Result = "OK", Records = output, TotalRecordCount = TotalRecord });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

    }
}
