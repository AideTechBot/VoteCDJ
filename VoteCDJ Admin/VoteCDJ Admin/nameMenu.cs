using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace VoteCDJ_Admin
{
    public partial class nameMenu : Form
    {
        public nameMenu()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            var candWindow = Application.OpenForms.OfType<addCandidatesWindow>().Single();
            candWindow.returnNames(nameBox.Text, gradeBox.Value);
            this.Close();
        }
    }
}
