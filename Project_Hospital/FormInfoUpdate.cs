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
    public partial class FormInfoUpdate : Form
    {
        public FormInfoUpdate()
        {
            InitializeComponent();
        }

        public string TCno;

        sqlconnection sqlconnection = new sqlconnection();
        private void FormInfoUpdate_Load(object sender, EventArgs e)
        {
            MskTC.Text = TCno;
            SqlCommand command = new SqlCommand("Select * From Tbl_Patients where patientTC = @p1", sqlconnection.connection());
            command.Parameters.AddWithValue("@p1", MskTC.Text);
            SqlDataReader dr = command.ExecuteReader();
            while(dr.Read())
            {
                TxtName.Text = dr[1].ToString();
                TxtSurname.Text = dr[2].ToString();
                MskTel.Text = dr[4].ToString(); 
                TxtPassword.Text = dr[5].ToString();    
                CmbGender.Text = dr[6].ToString();

            }
            sqlconnection.connection().Close();
        }

        private void BtnInfoUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand command2 = new SqlCommand("Update Tbl_Patients set patientName=@p1, patientSurname=@p2, patientTel=@p3, patientPassword=@p4, patientGender=@p5 where patientTC=@p6",sqlconnection.connection());
            command2.Parameters.AddWithValue("@p1", TxtName.Text);
            command2.Parameters.AddWithValue("@p2", TxtSurname.Text);
            command2.Parameters.AddWithValue("@p3", MskTel.Text);
            command2.Parameters.AddWithValue("@p4", TxtPassword.Text);
            command2.Parameters.AddWithValue("@p5", CmbGender.Text);
            command2.Parameters.AddWithValue("@p6", MskTC.Text);
            command2.ExecuteNonQuery();
            sqlconnection.connection().Close();
            MessageBox.Show("Informations Updated", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
