using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO.DVDCentral.BL;
using VO.DVDCentral.BL.Models;

namespace VO.DVDCentral.WFUI
{
    public partial class Ratings : System.Web.UI.Page
    {
        List<Rating> ratings;
        Rating rating;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ratings = RatingManager.Load();
                Rebind();

                Session["ratings"] = ratings;

                ddlRatings_SelectedIndexChanged(sender, e);
            }
            else
            {
                ratings = (List<Rating>)Session["ratings"];
            }
        }

        private void Rebind()
        {
            ddlRatings.DataSource = null;

            ddlRatings.DataSource = ratings;

            ddlRatings.DataTextField = "Description";

            ddlRatings.DataValueField = "Id";

            ddlRatings.DataBind();

            txtDescription.Text = string.Empty;
        }

        protected void ddlRatings_SelectedIndexChanged(object sender, EventArgs e)
        {
            rating = ratings[ddlRatings.SelectedIndex];
            txtDescription.Text = rating.Description;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                rating = new Rating();

                rating.Description = txtDescription.Text;

                int results = RatingManager.Insert(rating);

                ratings.Add(rating);

                Response.Write("Inserted " + results.ToString() + " rows...");
                Rebind();

                ddlRatings.SelectedIndex = ratings.Count - 1;
                ddlRatings_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int index = ddlRatings.SelectedIndex;

                rating = ratings[ddlRatings.SelectedIndex];
                rating.Description = txtDescription.Text;

                int results = RatingManager.Update(rating);

                Response.Write("Updated " + results.ToString() + " rows...");
                Rebind();

                ddlRatings.SelectedIndex = index;
                ddlRatings_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                rating = ratings[ddlRatings.SelectedIndex];

                int results = RatingManager.Delete(rating.Id);

                ratings.Remove(rating);

                Response.Write("Deleted " + results.ToString() + " rows...");
                Rebind();


                ddlRatings.SelectedIndex = 0;
                ddlRatings_SelectedIndexChanged(sender, e);

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }
    }
}