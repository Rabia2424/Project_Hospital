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
    public partial class FormPatientLogin : Form
    {
        public FormPatientLogin()
        {
            InitializeComponent();
        }

        sqlconnection sqlconnection = new sqlconnection();

        private void LnkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormSignUp fr = new FormSignUp();
            fr.Show();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * from Tbl_Patients where patientTC=@p1 and patientPassword=@p2", sqlconnection.connection());
            command.Parameters.AddWithValue("@p1", MskTC.Text);
            command.Parameters.AddWithValue("@p2", TxtPassword.Text);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                FormPatientDetails fr = new FormPatientDetails();
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
