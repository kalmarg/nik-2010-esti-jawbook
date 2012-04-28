using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JawBook;

namespace WebSite.Admins
{
    public partial class Races1 : System.Web.UI.Page
    {
        Db db = new Db();

        protected void btnNew_Click(object sender, EventArgs e)
        {
            db.Races.Add(new Race() { RaceId = Guid.NewGuid(), Name = "" });
            db.SaveChanges();
            gv.DataBind();
        }

        protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var RaceId = (Guid)e.Keys[0];
            var RaceToUpdate = db.Races.Where(x => x.RaceId == RaceId).FirstOrDefault();
            if (RaceToUpdate != null)
            {
                RaceToUpdate.Name = e.NewValues["Name"].ToString();
                db.SaveChanges();
                gv.EditIndex = -1;
            }

        }
        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var RaceId = (Guid)e.Keys[0];
            var RaceToDelete = db.Races.Where(x => x.RaceId == RaceId).FirstOrDefault();
            if (RaceToDelete != null)
            {
                db.Races.Remove(RaceToDelete);
                db.SaveChanges();
            }
        }
    }
}