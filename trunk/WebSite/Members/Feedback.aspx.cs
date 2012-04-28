using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JawBook;
using Resources;

namespace WebSite.Members
{
    public partial class Feedback : System.Web.UI.Page
    {
        private Db db = new Db();
        private Guid RentId;
        private JawBook.Rent rent;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Guid.TryParse(Request.Params["Id"], out RentId) && ((rent = db.Rents.Include("Jaw").FirstOrDefault(x => x.RentId == RentId)) != null))
            {
                l.Text = string.Format(Res.Feedback, rent.Jaw.Name, rent.Start, rent.End.Subtract(rent.Start).Days, rent.End.Subtract(rent.Start).Days * rent.Jaw.Price);
                img.ImageUrl = string.Format("../getPic.ashx?Id={0}", rent.Jaw.JawId);
            }
            else
            {
                Response.Redirect("~/Members/Browse.aspx");
            }
        }
    }
}