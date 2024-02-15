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
    public partial class FormBranchPanel : Form
    {
        public FormBranchPanel()
        {
            InitializeComponent();
        }

        sqlconnection sqlconnection = new sqlconnection();

        private void FormBranchPanel_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branches", sqlconnection.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Branches (branchName) values (@p1)", sqlconnection.connection());
            cmd.Parameters.AddWithValue("@p1", TxtBranch.Text);
            cmd.ExecuteNonQuery();
            sqlconnection.connection().Close();
            MessageBox.Show("Branch Added", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            TxtId.Text = dataGridView1.Rows[selected].Cells[0].Value.ToString();
            TxtBranch.Text = dataGridView1.Rows[selected].Cells[1].Value.ToString();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Tbl_Branches where branchId=@p1", sqlconnection.connection());
            cmd.Parameters.AddWithValue("@p1",TxtId.Text);
            cmd.ExecuteNonQuery();
            sqlconnection.connection().Close();
            MessageBox.Show("Branch Deleted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Tbl_Branches set branchName=@p1 where branchId=@p2",sqlconnection.connection());
            cmd.Parameters.AddWithValue("@p1", TxtBranch.Text);
            cmd.Parameters.AddWithValue("@p2", TxtId.Text);
            cmd.ExecuteNonQuery();
            sqlconnection.connection().Close();
            MessageBox.Show("Branch Updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
