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
    public partial class FormSignUp : Form
    {
        public FormSignUp()
        {
            InitializeComponent();
        }

        sqlconnection sqlconnection = new sqlconnection();


        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Tbl_Patients (patientName,patientSurname,patientTC,patientTel,patientPassword,patientGender) values (@p1,@p2,@p3,@p4,@p5,@p6)", sqlconnection.connection());
            command.Parameters.AddWithValue("@p1", TxtName.Text);
            command.Parameters.AddWithValue("@p2", TxtSurname.Text);
            command.Parameters.AddWithValue("@p3", MskTC.Text);
            command.Parameters.AddWithValue("@p4", MskTel.Text);
            command.Parameters.AddWithValue("@p5", TxtPassword.Text);   
            command.Parameters.AddWithValue("@p6", CmbCender.Text);
            command.ExecuteNonQuery();
            sqlconnection.connection().Close();
            MessageBox.Show("You are registered!", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        
    }
}
