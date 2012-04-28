using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JawBook;

namespace WebSite.Members
{
    public partial class SpecialOffer : System.Web.UI.Page
    {
        private Db db = new Db();

        protected void ddlTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            var r = new Random();
            ShowJaw1(db.Jaws.Include("Race").OrderBy(x => x.JawId).Skip(r.Next(db.Jaws.Count())).Take(1).ToList()[0]);
            ShowJaw2(db.Jaws.Include("Race").OrderBy(x => x.JawId).Skip(r.Next(db.Jaws.Count())).Take(1).ToList()[0]);
            ShowJaw3(db.Jaws.Include("Race").OrderBy(x => x.JawId).Skip(r.Next(db.Jaws.Count())).Take(1).ToList()[0]);
            p.Visible = true;
        }

        private void ShowJaw1(Jaw j)
        {
            lJ1Name.Text = j.Name;
            lJ1Age.Text = j.Age;
            lJ1Price.Text = string.Format("{0} EUR", j.Price);
            lJ1Race.Text = j.Race.Name;
            aJ1.NavigateUrl = string.Format("Rent.aspx?Id={0}", j.JawId);
            iJ1.ImageUrl = string.Format("~/getPic.ashx?Id={0}", j.JawId);
        }
        private void ShowJaw2(Jaw j)
        {
            lJ2Name.Text = j.Name;
            lJ2Age.Text = j.Age;
            lJ2Price.Text = string.Format("{0} EUR", j.Price);
            lJ2Race.Text = j.Race.Name;
            aJ2.NavigateUrl = string.Format("Rent.aspx?Id={0}", j.JawId);
            iJ2.ImageUrl = string.Format("~/getPic.ashx?Id={0}", j.JawId);
        }
        private void ShowJaw3(Jaw j)
        {
            lJ3Name.Text = j.Name;
            lJ3Age.Text = j.Age;
            lJ3Price.Text = string.Format("{0} EUR", j.Price);
            lJ3Race.Text = j.Race.Name;
            aJ3.NavigateUrl = string.Format("Rent.aspx?Id={0}", j.JawId);
            iJ3.ImageUrl = string.Format("~/getPic.ashx?Id={0}", j.JawId);
        }
    }
}