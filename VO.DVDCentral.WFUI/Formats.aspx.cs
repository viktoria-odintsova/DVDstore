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
    public partial class Formats : System.Web.UI.Page
    {
        List<Format> formats;
        Format format;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                formats = FormatManager.Load();
                Rebind();

                Session["formats"] = formats;

                ddlFormats_SelectedIndexChanged(sender, e);
            }
            else
            {
                formats = (List<Format>)Session["formats"];
            }
        }

        private void Rebind()
        {
            ddlFormats.DataSource = null;

            ddlFormats.DataSource = formats;

            ddlFormats.DataTextField = "Description";

            ddlFormats.DataValueField = "Id";

            ddlFormats.DataBind();

            txtDescription.Text = string.Empty;
        }

        protected void ddlFormats_SelectedIndexChanged(object sender, EventArgs e)
        {
            format = formats[ddlFormats.SelectedIndex];
            txtDescription.Text = format.Description;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                format = new Format();

                format.Description = txtDescription.Text;

                int results = FormatManager.Insert(format);

                formats.Add(format);

                Response.Write("Inserted " + results.ToString() + " rows...");
                Rebind();

                ddlFormats.SelectedIndex = formats.Count - 1;
                ddlFormats_SelectedIndexChanged(sender, e);
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
                int index = ddlFormats.SelectedIndex;

                format = formats[ddlFormats.SelectedIndex];
                format.Description = txtDescription.Text;

                int results = FormatManager.Update(format);

                Response.Write("Updated " + results.ToString() + " rows...");
                Rebind();

                ddlFormats.SelectedIndex = index;
                ddlFormats_SelectedIndexChanged(sender, e);
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
                format = formats[ddlFormats.SelectedIndex];

                int results = FormatManager.Delete(format.Id);

                formats.Remove(format);

                Response.Write("Deleted " + results.ToString() + " rows...");
                Rebind();


                ddlFormats.SelectedIndex = 0;
                ddlFormats_SelectedIndexChanged(sender, e);

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }
    }
}