using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Login
{
    public partial class ContractForm : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-HM3JBK0\\SQLEXPRESS;Initial Catalog=PPL;Integrated Security=True");
        string Pin;
        protected void Page_Load(object sender, EventArgs e)
        {


            //string strValue = Request.QueryString("SelectedCellValue").ToString()
            txtDepartment.Text = Session["deptName"].ToString();
            txtName.Text = Session["Name"].ToString();
            txtPermernentAddress.Text = Session["permanentAddress"].ToString();
             Pin = Session["pin"].ToString();
            //Session.Remove("deptName");
            //Session.Remove("Name");
            //Session.Remove("permanentAddress");
            txtwriteDetails.Enabled = false;

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
            StringBuilder sbUserChoices = new StringBuilder();
            if (chkWaking.Checked)
            {
                sbUserChoices.Append(chkWaking.Text);
            }
            if (chkBus.Checked)
            {
                sbUserChoices.Append("  " + chkBus.Text);
            }
            if (chkBike.Checked)
            {
                sbUserChoices.Append("  " + chkBike.Text);
            }

            if (cheOfficeCar.Checked)
            {
                sbUserChoices.Append("  " + cheOfficeCar.Text);
            }
            if (chkCng.Checked)
            {
                sbUserChoices.Append("  " + chkCng.Text);
            }
            
            if (rbtnCoronaInfo.Text == "No")
            {
                txtwriteDetails.Text = String.Empty;
            }

            using (SqlCommand command = con.CreateCommand())
            {
                command.CommandText = "INSERT INTO  dbo.CoronaInfo (Dept, Name, HouseType,WaytoComeOffice,Coronasymptom,CoronasymptomDetails,pin,PresentAddress,comment1) VALUES (@Dept, @Name,@HouseType,@WaytoComeOffice,@Coronasymptom,@CoronasymptomDetails,@pin,@PresentAddress,@comment1)";

                command.Parameters.AddWithValue("@Dept", txtDepartment.Text.Trim());
                command.Parameters.AddWithValue("@Name", txtName.Text);
                command.Parameters.AddWithValue("@HouseType",drpHouseType.SelectedItem.Text);
                command.Parameters.AddWithValue("@WaytoComeOffice", sbUserChoices.ToString());
                command.Parameters.AddWithValue("@Coronasymptom", rbtnCoronaInfo.Text);
                command.Parameters.AddWithValue("@CoronasymptomDetails", txtwriteDetails.Text);
                command.Parameters.AddWithValue("@pin", Pin);
                command.Parameters.AddWithValue("@PresentAddress",txtAddress.Text);
                command.Parameters.AddWithValue("@comment1", txtCommnet1.Text);




                con.Open();
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {

                    Response.Write("<script>alert('Save Successfully');</script>");
              
                  

                }
                con.Close();

            }
        }
    }
}