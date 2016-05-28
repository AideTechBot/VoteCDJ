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
using System.Net.NetworkInformation;

namespace VoteCDJ_Admin
{
    public partial class ConnectionWindow : Form
    {
        public ConnectionWindow()
        {
            InitializeComponent();
        }

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return pingable;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (PingHost(ipBox.Text))
            {
                string connetionString = "SERVER = " + ipBox.Text + "; PORT = " + portBox.Value.ToString() + "; DATABASE = marqueri_vote; User ID = marqueri_vote; PASSWORD = BB&7y?6t%5r$4ePP";

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
