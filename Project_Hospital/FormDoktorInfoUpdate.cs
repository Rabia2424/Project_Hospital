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
    public partial class FormDoktorInfoUpdate : Form
    {
        public FormDoktorInfoUpdate()
        {
            InitializeComponent();
        }

        sqlconnection sqlconnection = new sqlconnection();
        public string tc;
        private void FormDoktorInfoUpdate_Load(object sender, EventArgs e)
        {
            MskTC.Text = tc;

            SqlCommand cmd = new SqlCommand("Select * from Tbl_Doctors where doctorTC=@p1", sqlconnection.connection());
            cmd.Parameters.AddWithValue("@p1", MskTC.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TxtName.Text = dr[1].ToString();
                TxtSurname.Text = dr[2].ToString();
                CmbBranch.Text = dr[3].ToString();
                TxtPassword.Text = dr[5].ToString();
            }
            sqlconnection.connection().Close();
        }

        private void BtnInfoUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Tbl_Doctors set doctorName=@p1,doctorSurname=@p2,doctorBranch=@p3,doctorPassword=@p4 where doctorTC=@p5", sqlconnection.connection());
            cmd.Parameters.AddWithValue("@p1", TxtName.Text);
            cmd.Parameters.AddWithValue("@p2", TxtSurname.Text);
            cmd.Parameters.AddWithValue("@p3", CmbBranch.Text);
            cmd.Parameters.AddWithValue("@p4", TxtPassword.Text);
            cmd.Parameters.AddWithValue("@p5", MskTC.Text);
            cmd.ExecuteNonQuery();
            sqlconnection.connection().Close();
            MessageBox.Show("Information Updated","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
