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
        //IEnumerable<Race> races;


        protected void Page_Initializing(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //    gv.DataSource = db.Races.ToList();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //gv.DataSource = races.ToList();
            //gv.DataBind();
        }


        protected void btnNew_Click(object sender, EventArgs e)
        {
            db.Races.Add(new Race() { RaceId = Guid.NewGuid(), Name = "" });
            db.SaveChanges();
            gv.DataBind();
            //gv.DataSource = db.Races.ToList();
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //gv.PageIndex = e.NewPageIndex;
        }
        protected void GridView1_Sorted(object sender, EventArgs e)
        {
        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            //switch (e.SortExpression)
            //{
            //    case "Name":
            //        races = races.OrderBy(x => x.Name);
            //        break;
            //    default:
            //        break;
            //}
            //if (e.SortDirection == SortDirection.Descending)
            //    races = races.Reverse();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
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
        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var RaceId = (Guid)e.Keys[0];
            var RaceToDelete = db.Races.Where(x => x.RaceId == RaceId).FirstOrDefault();
            if (RaceToDelete != null)
            {
                db.Races.Remove(RaceToDelete);
                db.SaveChanges();
            }
        }
        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
        }
    }
}