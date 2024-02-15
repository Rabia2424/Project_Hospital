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
    public partial class FormPatientDetails : Form
    {
        public FormPatientDetails()
        {
            InitializeComponent();
        }

        public string tc;

        sqlconnection sqlconnection = new sqlconnection();

        private void FormPatientDetails_Load(object sender, EventArgs e)
        {
            LblTC.Text = tc;

            //Get Name and Surname
            SqlCommand command = new SqlCommand("Select patientName, patientSurname from Tbl_Patients where patientTC=@p1", sqlconnection.connection());
            command.Parameters.AddWithValue("@p1", LblTC.Text);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                LblNameSurname.Text = dr[0] + " " + dr[1];
            }
            sqlconnection.connection().Close();

            //Appointment Past
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Appointments where patientTC= " + tc, sqlconnection.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Get Branches
            SqlCommand command2 = new SqlCommand("Select branchName from Tbl_Branches ",sqlconnection.connection());
            SqlDataReader dr2 = command2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBranch.Items.Add(dr2[0]);
            }
            sqlconnection.connection().Close();


        }

        private void CmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoctor.Items.Clear();

            SqlCommand command3 = new SqlCommand("Select doctorName, doctorSurname from Tbl_Doctors where doctorBranch=@p1", sqlconnection.connection());
            command3.Parameters.AddWithValue("@p1", CmbBranch.Text);
            SqlDataReader dr = command3.ExecuteReader();
            while (dr.Read())
            {
                CmbDoctor.Items.Add(dr[0] + " " + dr[1]);

            }
            sqlconnection.connection().Close();
        }

        private void CmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Appointments where appointmentBranch = '" + CmbBranch.Text + "'" + " and appointmentDoctor = '" + CmbDoctor.Text + "'and appointmentSituation=0 ", sqlconnection.connection());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void LnkInfoUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormInfoUpdate fr = new FormInfoUpdate();
            fr.TCno = LblTC.Text;
            fr.Show();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView2.SelectedCells[0].RowIndex;
            TxtId.Text = dataGridView2.Rows[selected].Cells[0].Value.ToString();
        }

        private void BtnGetAppointment_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Tbl_Appointments set appointmentSituation=1, patientTC=@p1, patientComplaint=@p2 where appointmentId=@p3",sqlconnection.connection());
            cmd.Parameters.AddWithValue("@p1", LblTC.Text);
            cmd.Parameters.AddWithValue("@p2", RchComplaint.Text);
            cmd.Parameters.AddWithValue("@p3", TxtId.Text);
            cmd.ExecuteNonQuery();
            sqlconnection.connection().Close();
            MessageBox.Show("Appointment Received","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

      
    }
}
