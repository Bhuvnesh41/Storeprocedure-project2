using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;


namespace PracticeProject2
{
    public partial class Project2 : System.Web.UI.Page
    {
        SqlConnection con=new SqlConnection("Data source=BHUVNESH\\SQLEXPRESS;Initial Catalog=db3524; Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Display();
                Bindgender();
                BindCountry();
                BindState();
            }
        }
        public void Display()
        {
         con.Open();
         SqlCommand cmd = new SqlCommand("spGetData", con);
         cmd.CommandType = CommandType.StoredProcedure;
         SqlDataAdapter sda=new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
         sda.Fill(dt);
         gvPatient.DataSource = dt;
         gvPatient.DataBind();
         con.Close();
        }

        public void Bindgender()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spGetGenderData", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            rblGender.DataSource = dt;
            rblGender.DataTextField = "GName";
            rblGender.DataValueField = "Gid";
            rblGender.DataBind();
        }

        public void BindCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spGetCountryData", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddlCountry.DataSource = dt;
            ddlCountry.DataValueField = "Cid";
            ddlCountry.DataTextField = "CName";
            ddlCountry.DataBind();
        }

        public void BindState()
        {
            con.Open();
            string Cid = ddlCountry.SelectedValue;
            SqlCommand cmd = new SqlCommand("spGetStateData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cid", Cid);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddlState.DataSource = dt;
            ddlState.DataValueField = "Sid";
            ddlState.DataTextField = "SName";
            ddlState.DataBind();

        }
            public void Clear()
            {
             txtname.Text = "";
             txtage.Text = "";
             txtHomeAddress.Text = "";
             rblGender.SelectedIndex = 0;
             ddlCountry.SelectedIndex= 0;
             ddlState.SelectedIndex = 0;
             
            }

        protected void btnSave_Click(object sender, EventArgs e)
        {
          if (btnSave.Text == "Save")
          {
            con.Open();
            SqlCommand cmd = new SqlCommand("spSaveData ", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", txtname.Text);
            cmd.Parameters.AddWithValue("@Age", txtage.Text);
            cmd.Parameters.AddWithValue("@Gender", rblGender.SelectedValue);
            cmd.Parameters.AddWithValue("@HomeAddress", txtHomeAddress.Text);
            cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
            cmd.Parameters.AddWithValue("@State", ddlState.SelectedValue);
         
            cmd.ExecuteNonQuery();
            con.Close();
            Clear();
            Display();

          }
            else if (btnSave.Text == "Update")
            {
                con.Open();
                int patientid = Convert.ToInt32(ViewState["IDD"]);
                SqlCommand cmd = new SqlCommand("spUpdateData", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Patientid", patientid);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Age", txtage.Text);
                cmd.Parameters.AddWithValue("@Gender", rblGender.SelectedValue);
                cmd.Parameters.AddWithValue("@HomeAddress", txtHomeAddress.Text);
                cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@State", ddlState.SelectedValue);


                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                Display();

            }
        }

        protected void gvPatient_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                int delete = Convert.ToInt32(e.CommandArgument);
                SqlCommand cmd = new SqlCommand("spDeleteData ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@delete",delete);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
            }
            else if (e.CommandName == "") 
            {
                con.Open();
                int edit = Convert.ToInt32(e.CommandArgument);
                SqlCommand cmd = new SqlCommand("spEditData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@edit", edit);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt= new DataTable();
                sda.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["Name"].ToString();
                txtage.Text = dt.Rows[0]["Age"].ToString();
                txtHomeAddress.Text = dt.Rows[0]["HomeAddress"].ToString();
                rblGender.SelectedValue = dt.Rows[0]["Gender"].ToString() ;
                ddlCountry.SelectedValue = dt.Rows[0]["Country"].ToString();
                BindState();
                ddlState.SelectedValue = dt.Rows[0]["State"].ToString();
                ViewState["IDD"] = e.CommandArgument;
                btnSave.Text = "Update";
                

            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindState();
        }
    }
}