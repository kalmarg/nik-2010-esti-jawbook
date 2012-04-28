using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JawBook;

namespace WebSite.Admins
{
    public partial class Upload : System.Web.UI.Page
    {
        private Db db = new Db();

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            lMsg.Visible = false;
            try
            {
                var RaceId = Guid.Parse(ddlRace.SelectedValue);
                db.Jaws.Add(new Jaw()
                {
                    JawId = Guid.NewGuid(),
                    Name = tbName.Text,
                    Age = tbAge.Text,
                    Race = db.Races.First(x => x.RaceId == RaceId),
                    Price = int.Parse(tbPrice.Text),
                    Picture = fuImg.FileBytes
                });
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                lMsg.Text = ex.Message;
                lMsg.Visible = true;
            }
        }
    }
}