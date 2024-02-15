using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Hospital
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnPatientLogin_Click(object sender, EventArgs e)
        {
            FormPatientLogin fr = new FormPatientLogin();
            fr.Show();
            this.Hide();
        }

        private void BtnDoctorLogin_Click(object sender, EventArgs e)
        {
            FormDoctorLogin fr = new FormDoctorLogin();
            fr.Show();
            this.Hide();
        }

        private void BtnSecretaryLogin_Click(object sender, EventArgs e)
        {
            FormSecretaryLogin fr = new FormSecretaryLogin();
            fr.Show();
            this.Hide();
        }
    }
}
