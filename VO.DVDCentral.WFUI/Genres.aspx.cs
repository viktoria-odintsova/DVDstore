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

    public partial class Genres : System.Web.UI.Page
    {
        List<Genre> genres;
        Genre genre;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                genres = GenreManager.Load();
                Rebind();

                Session["genres"] = genres;

                ddlGenres_SelectedIndexChanged(sender, e);
            }
            else
            {
                genres = (List<Genre>)Session["genres"];
            }
        }

        private void Rebind()
        {
            ddlGenres.DataSource = null;

            ddlGenres.DataSource = genres;

            ddlGenres.DataTextField = "Description";

            ddlGenres.DataValueField = "Id";

            ddlGenres.DataBind();

            txtDescription.Text = string.Empty;
        }

        protected void ddlGenres_SelectedIndexChanged(object sender, EventArgs e)
        {
            genre = genres[ddlGenres.SelectedIndex];
            txtDescription.Text = genre.Description;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                genre = new Genre();

                genre.Description = txtDescription.Text;

                int results = GenreManager.Insert(genre);

                genres.Add(genre);

                Response.Write("Inserted " + results.ToString() + " rows...");
                Rebind();

                ddlGenres.SelectedIndex = genres.Count - 1;
                ddlGenres_SelectedIndexChanged(sender, e);
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
                int index = ddlGenres.SelectedIndex;

                genre = genres[ddlGenres.SelectedIndex];
                genre.Description = txtDescription.Text;

                int results = GenreManager.Update(genre);

                Response.Write("Updated " + results.ToString() + " rows...");
                Rebind();

                ddlGenres.SelectedIndex = index;
                ddlGenres_SelectedIndexChanged(sender, e);
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
                genre = genres[ddlGenres.SelectedIndex];

                int results = GenreManager.Delete(genre.Id);

                genres.Remove(genre);

                Response.Write("Deleted " + results.ToString() + " rows...");
                Rebind();


                ddlGenres.SelectedIndex = 0;
                ddlGenres_SelectedIndexChanged(sender, e);

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }
    }
}