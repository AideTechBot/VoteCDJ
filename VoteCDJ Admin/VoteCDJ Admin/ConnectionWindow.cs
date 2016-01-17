using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;

namespace VoteCDJ_Admin
{
    public partial class ConnectionWindow : Form
    {
        public ConnectionWindow()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            IPAddress address;
            if (IPAddress.TryParse(ipBox.Text, out address))
            {
                string connetionString = "SERVER = " + ipBox.Text + "; PORT = " + portBox.Value.ToString() + "; DATABASE = Vote; User ID = sec_remote; PASSWORD = 6EUO1BE6ZRb";

                var mainWindow = Application.OpenForms.OfType<MainWindow>().Single();
                mainWindow.SQLConn = new MySqlConnection(connetionString);
                try
                {
                    mainWindow.SQLConn.Open();
                    mainWindow.confirmConnection(ipBox.Text, portBox.Value.ToString());
                    this.Close();  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("La connexion a échoué: " + ex.Message);
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Adresse IP invalide.");
            }
        }

        private void ipBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                connectButton.PerformClick();
            }
        }

    }
}
