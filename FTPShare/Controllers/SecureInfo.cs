using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FTPShare.Controllers
{
    public class SecureInfo : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += OnPreSendRequestHeaders;
        }

        public void Dispose() { }

        void OnPreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Headers.Set("Info", "Server don't know 555"); 
            //ใส่ข้อความถึง hacker
        }
    }
}