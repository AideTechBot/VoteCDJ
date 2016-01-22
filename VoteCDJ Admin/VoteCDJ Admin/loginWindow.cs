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
    public partial class loginWindow : Form
    {
        public loginWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (userBox.Text.Replace(" ", string.Empty) == "" || passBox.Text.Replace(" ", string.Empty) == "")
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe invalide");
            }
            else
            {
                if (userBox.Text.Contains(" ") || passBox.Text.Contains(" "))
                {
                    MessageBox.Show("Nom d'utilisateur ou mot de passe invalide");
                }
                else
                {
                    var userAdd = Application.OpenForms.OfType<userAddWindow>().Single();
                    userAdd.addUser(userBox.Text, passBox.Text, (int)gradeBox.Value);
                    this.Close();
                }

            }
        }
    }
}
