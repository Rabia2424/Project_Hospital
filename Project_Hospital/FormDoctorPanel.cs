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
    public partial class FormDoctorPanel : Form
    {
        public FormDoctorPanel()
        {
            InitializeComponent();
        }

        sqlconnection sqlconnection = new sqlconnection();
        private void FormDoctorPanel_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Doctors ", sqlconnection.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            //Get Branches to ComboBox
            SqlCommand cmd = new SqlCommand("Select branchName from Tbl_Branches", sqlconnection.connection());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CmbBranch.Items.Add(dr[0]);
            }
            sqlconnection.connection().Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Doctors (doctorName, doctorSurname, doctorBranch, doctorTC, doctorPassword) values (@p1,@p2,@p3,@p4,@p5)", sqlconnection.connection());
            cmd.Parameters.AddWithValue("@p1", TxtName.Text);
            cmd.Parameters.AddWithValue("@p2", TxtSurname.Text);
            cmd.Parameters.AddWithValue("@p3", CmbBranch.Text);
            cmd.Parameters.AddWithValue("@p4", MskTC.Text);
            cmd.Parameters.AddWithValue("@p5", TxtPassword.Text);
            cmd.ExecuteNonQuery();
            sqlconnection.connection().Close();
            MessageBox.Show("Doctor Added","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            TxtName.Text = dataGridView1.Rows[selected].Cells[1].Value.ToString();
            TxtSurname.Text = dataGridView1.Rows[selected].Cells[2].Value.ToString();
            CmbBranch.Text = dataGridView1.Rows[selected].Cells[3].Value.ToString();
            MskTC.Text = dataGridView1.Rows[selected].Cells[4].Value.ToString();
            TxtPassword.Text = dataGridView1.Rows[selected].Cells[5].Value.ToString();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Tbl_Doctors where doctorTC=@p1", sqlconnection.connection()); 
            cmd.Parameters.AddWithValue("@p1", MskTC.Text);
            cmd.ExecuteNonQuery();
            sqlconnection.connection().Close();
            MessageBox.Show("Record Deleted","Info", MessageBoxButtons.OK,MessageBoxIcon.Hand);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Tbl_Doctors set doctorName=@p1, doctorSurname=@p2, doctorBranch=@p3, doctorPassword=@p5 where doctorTC=@p4 ",sqlconnection.connection());
            cmd.Parameters.AddWithValue("@p1", TxtName.Text);
            cmd.Parameters.AddWithValue("@p2", TxtSurname.Text);
            cmd.Parameters.AddWithValue("@p3", CmbBranch.Text);
            cmd.Parameters.AddWithValue("@p4", MskTC.Text);
            cmd.Parameters.AddWithValue("@p5", TxtPassword.Text);
            cmd.ExecuteNonQuery();
            sqlconnection.connection().Close();
            MessageBox.Show("Doctor Updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
    }
}
