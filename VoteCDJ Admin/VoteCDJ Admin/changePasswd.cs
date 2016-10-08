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
                var window = Application.OpenForms.OfType<userAddWindow>().Single();
                window.change_Passwd(textBox.Text, username);
                this.Close();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button_Click(this, new EventArgs());
        }
    }
}
