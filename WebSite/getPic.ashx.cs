using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JawBook;

namespace WebSite
{
    /// <summary>
    /// Summary description for getPic
    /// </summary>
    public class getPic : IHttpHandler
    {
        private Db db = new Db();

        public void ProcessRequest(HttpContext context)
        {
            var JawId = Guid.Empty;
            if (Guid.TryParse(context.Request["Id"], out JawId))
            {
                var Jaw = db.Jaws.FirstOrDefault(x => x.JawId == JawId);
                if (Jaw != null)
                {
                    context.Response.ContentType = "image/PNG";
                    context.Response.BinaryWrite(Jaw.Picture);
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}