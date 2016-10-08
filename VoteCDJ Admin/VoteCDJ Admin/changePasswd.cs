using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoteCDJ_Admin
{
    public partial class changePasswd : Form
    {
        public string username;

        public changePasswd()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if(textBox.Text == "")
            {
                var userAdd = Application.OpenForms.OfType<userAddWindow>().Single();
                userAdd.change_Passwd(textBox.Text, username);
                this.Close();
            }
            {
                MessageBox.Show("Mot de passe invalide.");
            }
        }
    }
}
