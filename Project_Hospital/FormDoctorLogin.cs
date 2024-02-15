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
    public partial class FormDoctorLogin : Form
    {
        public FormDoctorLogin()
        {
            InitializeComponent();
        }

        sqlconnection sqlconnection = new sqlconnection();
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * from Tbl_Doctors where doctorTC=@p1 and doctorPassword=@p2",sqlconnection.connection());
            command.Parameters.AddWithValue("@p1",MskTC.Text);
            command.Parameters.AddWithValue("@p2",TxtPassword.Text);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                FormDoctorDetails fr = new FormDoctorDetails();
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
