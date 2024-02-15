using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project_Hospital
{
    public partial class FormSecretaryLogin : Form
    {
        public FormSecretaryLogin()
        {
            InitializeComponent();
        }

        sqlconnection sqlconnection = new sqlconnection();

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Secretary where secretaryTC=@p1 and secretaryPassword=@p2",sqlconnection.connection());
            cmd.Parameters.AddWithValue("@p1",MskTC.Text);
            cmd.Parameters.AddWithValue("@p2", TxtPassword.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FormSecretaryDetails fr = new FormSecretaryDetails();
                fr.tc = MskTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid TC & Password");
            }
            sqlconnection.connection().Close();
        }

      
    }
}
