using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Login
{
    public partial class ContractForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //string strValue = Request.QueryString("SelectedCellValue").ToString()
            txtDepartment.Text = Session["deptName"].ToString();
            txtName.Text = Session["Name"].ToString();
            txtPermernentAddress.Text = Session["permanentAddress"].ToString();
            //Session.Remove("deptName");
            //Session.Remove("Name");
            //Session.Remove("permanentAddress");

        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
           
            Session.Abandon();
            Session.Clear();
            Response.Cookies.Clear();
            Response.Redirect("Defualt.aspx");
        }
        public bool ValidateRadioButtonList()
        {
            bool rbchecked = false;
            for (int i = 0; i < rbtnCoronaInfo.Items.Count - 1; i++)
            {
                if (rbtnCoronaInfo.Items[i].Selected == true)
                {
                    rbchecked = true;
                }
            }
            if (rbchecked == true)
            {
                //lblError.Text = string.Empty;
                return true;
            }
            else
            {
                Response.Write("<script>alert('Yes or no ');</script>");
                rbtnCoronaInfo.Focus();
                return false;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
          //  ValidateRadioButtonList();
        }
    }
}