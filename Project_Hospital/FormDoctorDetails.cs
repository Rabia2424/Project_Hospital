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
    public partial class FormDoctorDetails : Form
    {
        public FormDoctorDetails()
        {
            InitializeComponent();
        }

        sqlconnection sqlconnection = new sqlconnection();

        public string tc;
        private void FormDoctorDetails_Load(object sender, EventArgs e)
        {
            LblTC.Text = tc;

            //Get Doctor Name Surname
            SqlCommand cmd = new SqlCommand("Select doctorName,doctorSurname from Tbl_Doctors where doctorTC=@p1 ", sqlconnection.connection());
            cmd.Parameters.AddWithValue("@p1",LblTC.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LblNameSurname.Text = dr[0] + " " + dr[1];
            }
            sqlconnection.connection().Close();

            //Appointment List
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Appointments where appointmentDoctor= '" + LblNameSurname.Text + "'", sqlconnection.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            FormDoktorInfoUpdate fr = new FormDoktorInfoUpdate();
            fr.tc = LblTC.Text;
            fr.Show();
            
        }

        private void BtnAnnouncement_Click(object sender, EventArgs e)
        {
            FormAnnouncement fr = new FormAnnouncement();
            fr.Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            RchComplaint.Text = dataGridView1.Rows[selected].Cells[7].Value.ToString();
        }
    }
}
