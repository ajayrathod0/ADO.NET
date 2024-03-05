using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADONETWebApp
{
    public partial class TrainerDashbord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd = new SqlCommand("select * from trainer", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            //gvTrainers Id me table dikhenga browser par
            gvTrainers.DataSource = reader;

            gvTrainers.DataBind();
            //lbMassage Id hai label ki
            lbMasaage.Text = "Trainer Loaded From Databases";
            con.Close();
            

        }
    }
}