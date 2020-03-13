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
    public partial class Directors : System.Web.UI.Page
    {
        List<Director> directors;
        Director director;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                directors = DirectorManager.Load();
                Rebind();

                Session["directors"] = directors;

                ddlDirectors_SelectedIndexChanged(sender, e);
            }
            else
            {
                directors = (List<Director>)Session["directors"];
            }
        }

        private void Rebind()
        {
            ddlDirectors.DataSource = null;
            ddlDirectors.DataSource = directors;

            ddlDirectors.DataTextField = "FullName";
            ddlDirectors.DataValueField = "Id";

            ddlDirectors.DataBind();

            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
        } 

        protected void ddlDirectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            director = directors[ddlDirectors.SelectedIndex];
            txtFirstName.Text = director.FirstName;
            txtLastName.Text = director.LastName;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                director = new Director();

                director.FirstName = txtFirstName.Text;
                director.LastName = txtLastName.Text;

                int results = DirectorManager.Insert(director);

                directors.Add(director);

                Response.Write("Inserted " + results + " rows.");
                Rebind();

                ddlDirectors.SelectedIndex = directors.Count - 1;
                ddlDirectors_SelectedIndexChanged(sender, e);
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
                int index = ddlDirectors.SelectedIndex;

                director = directors[index];

                director.FirstName = txtFirstName.Text;
                director.LastName = txtLastName.Text;

                int results = DirectorManager.Update(director);

                Response.Write("Updated " + results + " rows.");
                Rebind();

                ddlDirectors.SelectedIndex = index;
                ddlDirectors_SelectedIndexChanged(sender, e);
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
                director = directors[ddlDirectors.SelectedIndex];

                int results = DirectorManager.Delete(director.Id);

                directors.Remove(director);

                Response.Write("Deleted " + results + " rows.");
                Rebind();

                ddlDirectors.SelectedIndex = 0;
                ddlDirectors_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }
    }
}