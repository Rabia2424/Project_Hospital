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
    public partial class FormSecretaryDetails : Form
    {
        public FormSecretaryDetails()
        {
            InitializeComponent();
        }

        public string tc;

        sqlconnection sqlconnection = new sqlconnection();
        private void FormSecretaryDetails_Load(object sender, EventArgs e)
        {
            LblTC.Text = tc;

            //Get Name Surname
            SqlCommand cmd = new SqlCommand("Select secretaryNameSurname From Tbl_Secretary where secretaryTC=@p1", sqlconnection.connection());
            cmd.Parameters.AddWithValue("@p1", LblTC.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LblNameSurname.Text = dr[0].ToString();
            }
            sqlconnection.connection().Close();


            //Get Branches to Datagrid
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select branchName from Tbl_Branches", sqlconnection.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            //Get Doctors to Datagrid
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (doctorName + ' ' + doctorSurname) as 'Doctors', doctorBranch from Tbl_Doctors ", sqlconnection.connection());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;


            //Get Branches
            SqlCommand cmd2 = new SqlCommand("Select branchName from Tbl_Branches ",sqlconnection.connection());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBranch.Items.Add(dr2[0]);
            }
            sqlconnection.connection().Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("insert into Tbl_Appointments (appointmentDate,appointmentTime,appointmentBranch,appointmentDoctor) values (@r1,@r2,@r3,@r4)",sqlconnection.connection());
            cmd2.Parameters.AddWithValue("@r1", MskDate.Text);
            cmd2.Parameters.AddWithValue("@r2", MskTime.Text);
            cmd2.Parameters.AddWithValue("@r3", CmbBranch.Text);
            cmd2.Parameters.AddWithValue("@r4", CmbDoctor.Text);
            cmd2.ExecuteNonQuery();
            sqlconnection.connection().Close();
            MessageBox.Show("Appointment made");
        }

        private void CmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoctor.Items.Clear();

            SqlCommand cmd = new SqlCommand("Select doctorName,doctorSurname from Tbl_Doctors where doctorBranch=@p1",sqlconnection.connection());
            cmd.Parameters.AddWithValue("@p1", CmbBranch.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CmbDoctor.Items.Add(dr[0] + " " + dr[1]);
            }
            sqlconnection.connection().Close();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Announce (announce) values (@d1)", sqlconnection.connection());
            cmd.Parameters.AddWithValue("@d1",RchAnnouncement.Text);
            cmd.ExecuteNonQuery();
            sqlconnection.connection().Close();
            MessageBox.Show("Announcement Made");

        }

        private void BtnDoctorsPanel_Click(object sender, EventArgs e)
        {
            FormDoctorPanel fr = new FormDoctorPanel();
            fr.Show();
        }

        private void BtnBranchPanel_Click(object sender, EventArgs e)
        {
            FormBranchPanel fr = new FormBranchPanel();
            fr.Show();
        }

        private void BtnAppointmentList_Click(object sender, EventArgs e)
        {
            FormAppointmentList fr = new FormAppointmentList();
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAnnouncement fr = new FormAnnouncement();
            fr.Show();
        }
    }
}
