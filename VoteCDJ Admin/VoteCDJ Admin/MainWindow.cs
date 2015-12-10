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
using System.IO;

namespace VoteCDJ_Admin
{
    public partial class MainWindow : Form
    {
        
        public MySqlConnection SQLConn;
        public List<Tuple<string, int>> tupleList = new List<Tuple<string, int>> { };
        public bool voteStarted = false;
        public int voteCount = 0;
        public MemoryStream chartSave = new MemoryStream();

        public MainWindow()
        {
            InitializeComponent();
        }

        //COUNT ALL THE CANDIDATES VOTES
        private int getNumVotes(int candidateID)
        {
            string query = "SELECT * FROM voteHistory WHERE candidateID = " + candidateID.ToString();

            MySqlCommand cmd = new MySqlCommand(query, this.SQLConn);
            MySqlDataReader reader = cmd.ExecuteReader();

            int numVotes = 0;
            while (reader.Read())
            {
                numVotes = numVotes + 1;
            }

            reader.Close();

            return numVotes;
        }

        //COUNT ALL THE VOTES
        private int getTotalVotes(int postID)
        {
            string query = "SELECT * FROM voteHistory WHERE  postID = " + postID.ToString();

            MySqlCommand cmd = new MySqlCommand(query, this.SQLConn);
            MySqlDataReader reader = cmd.ExecuteReader();

            int totalVotes = 0;
            while (reader.Read())
            {
                totalVotes = totalVotes + 1;
            }

            reader.Close();

            return totalVotes;
        }

        //GET ID FROM NAME
        private int getCandidateID(string name)
        {
            string query = "SELECT id FROM candidates WHERE name = \"" + name + "\"";

            MySqlCommand cmd = new MySqlCommand(query, this.SQLConn);
            MySqlDataReader reader = cmd.ExecuteReader();

            int candidateID = 0;
            while (reader.Read())
            {
                candidateID = reader.GetInt32(0);
            }

            reader.Close();

            return candidateID;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            UIUpdater.Start();
        }

        public void confirmConnection(string ip, string port)
        {
            statusText.Text = "Actuellement connecté à: " + ip + ":" + port;
            connectionOptions.Visible = true;

            nouvelleConnexionToolStripMenuItem.Enabled = false;

            if (SQLConn.State == ConnectionState.Open)
            {
                string query = "SELECT * FROM post";

                MySqlCommand cmd = new MySqlCommand(query, this.SQLConn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string post = reader.GetString(1);
                    int id = reader.GetInt32(0);
                    tupleList.Add(Tuple.Create(post,id));
                    treeView.Nodes.Add(post);
                    comboBoxPost.Items.Add(post);
                }

                reader.Close();

                //QUERY NO 2 HERE WE GO
                foreach (Tuple<string, int> tuple in tupleList)
                {
                    query = "SELECT name FROM candidates WHERE postID =" + tuple.Item2;

                    cmd = new MySqlCommand(query, this.SQLConn);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        treeView.Nodes[tuple.Item2-1].Nodes.Add(name);
                        
                    }

                    reader.Close();
                }

            }
        }

        private void startVoteButton_Click(object sender, EventArgs e)
        {
            if (!voteStarted && voteTimeButton.Value != 0)
            {
                try
                {
                    if (SQLConn.State == ConnectionState.Open)
                    {
                        //disable stuff
                        voteTimeButton.Enabled = false;
                        startVoteButton.Enabled = false;
                        nouvelleConnexionToolStripMenuItem.Enabled = false;
                        déconnexionToolStripMenuItem.Enabled = false;
                        endVoteButton.Enabled = true;

                        voteTimeLeftLabel.Text = Math.Floor(voteTimeButton.Value).ToString() + ":" + Math.Round((voteTimeButton.Value - Math.Floor(voteTimeButton.Value)) * 60).ToString().PadLeft(2, '0');

                        string query = "UPDATE vars SET voteStarted = 1";
                        MySqlCommand cmd = new MySqlCommand(query, this.SQLConn);
                        cmd.ExecuteNonQuery();

                        voteCount = 0;
                        voteTimer.Start();
                        voteStarted = true;
                    }
                    else
                    {
                        MessageBox.Show("Auncune connexion de base de données.");
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Auncune connexion de base de données.");
                }
            }

        }

        private void endVoteButton_Click(object sender, EventArgs e)
        {
            if (voteStarted)
            {
                voteTimeButton.Enabled = true;
                startVoteButton.Enabled = true;
                nouvelleConnexionToolStripMenuItem.Enabled = true;
                déconnexionToolStripMenuItem.Enabled = true;
                endVoteButton.Enabled = false;

                voteTimeLeftLabel.Text = "0:00";

                voteTimer.Stop();

                string query = "UPDATE vars SET voteStarted = 0";
                MySqlCommand cmd = new MySqlCommand(query, this.SQLConn);
                cmd.ExecuteNonQuery();

                voteStarted = false;
            }
        }

        private void nouvelleConnexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionWindow connectionWindow = new ConnectionWindow();
            connectionWindow.ShowDialog();
        }

        private void déconnexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SQLConn.State == ConnectionState.Open)
            { 
                SQLConn.Close();
                treeView.Nodes.Clear();
                tupleList.Clear();
                connectionOptions.Visible = false;
                statusText.Text = "Déconnexion.";
                candidateLabel.Text = "N/A";
                candidateNumVotesLabel.Text = "Votes: N/A";
                candidatePercentVotesLabel.Text = "?% des votes";
                totalVotesLabel.Text = "- votes";

                nouvelleConnexionToolStripMenuItem.Enabled = true;
                histoChart.Series[0].Points.Clear();
                comboBoxPost.Items.Clear();
                comboBoxPost.ResetText();
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView.SelectedNode.Level != 0)
            {
                candidateLabel.Text = treeView.SelectedNode.Text;

                //This gets the post ID so we can get vote information
                string query = "SELECT id,postID FROM candidates WHERE name = \"" + treeView.SelectedNode.Text + "\"";

                MySqlCommand cmd = new MySqlCommand(query, this.SQLConn);
                MySqlDataReader reader = cmd.ExecuteReader();

                int id = 0;
                int postID = 0;
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    postID = reader.GetInt32(1);
                }
                
                reader.Close();

                //COUNT ALL THE CANDIDATES VOTES
                int numVotes = getNumVotes(id);
               
                //COUNT ALL THE VOTES
                int totalVotes = getTotalVotes(postID);

                candidateNumVotesLabel.Text = "Votes: " + numVotes.ToString();
                if (totalVotes != 0)
                    candidatePercentVotesLabel.Text = Math.Round((decimal)(((float)numVotes/(float)totalVotes) * 100.0),2).ToString() + "% des votes";
                else
                    candidatePercentVotesLabel.Text = "0% des votes";

                //GRAPH
                //TODO MAKE A SETTING FOR NUM OF PEOPLE AND MAKE GRAPH DYNAMIC
                candidateChart.Series[0].Points.Clear();

                DateTime now = DateTime.Now;
                candidateChart.ChartAreas[0].AxisX.Minimum = now.AddHours(-5).ToOADate();
                candidateChart.ChartAreas[0].AxisX.Maximum = now.AddHours(0).ToOADate();

                candidateChart.ChartAreas[0].AxisY.Maximum = 10;

                int candidateID = getCandidateID(treeView.SelectedNode.Text);
                query = "SELECT voteTime FROM voteHistory WHERE candidateID =\"" + candidateID.ToString() + "\"";

                cmd = new MySqlCommand(query, this.SQLConn);
                reader = cmd.ExecuteReader();

                candidateChart.Series[0].Points.AddXY(DateTime.Now.AddHours(-5).ToOADate(), 0);
                int voteNum = 0;
                while (reader.Read())
                {
                    voteNum = voteNum + 1;
                    DateTime date = reader.GetDateTime(0);
                    Console.WriteLine(voteNum.ToString() + " " + date.ToString());
                    candidateChart.Series[0].Points.AddXY(date.ToOADate(),voteNum);
                }

                reader.Close();
            }
        }

        private void voteTimer_Tick(object sender, EventArgs e)
        {
            voteCount++;
            double hoursleft = ((Convert.ToDouble(voteTimeButton.Value) * 60.0) - voteCount)/60.0;
            voteTimeLeftLabel.Text = Math.Floor(hoursleft).ToString() + ":" + Math.Round((hoursleft - Math.Floor(hoursleft)) * 60).ToString().PadLeft(2, '0');

            if (hoursleft < (1 / 60))
            {
                voteCount = 0;
                endVoteButton.PerformClick();
            }
        }

        private void UIUpdater_Tick(object sender, EventArgs e)
        {
            try
            {
                if (SQLConn.State == ConnectionState.Open)
                {
                    //GREEN TEXT UPDATER
                    int totalVotes = getTotalVotes(1);
                    totalVotesLabel.Text = totalVotes.ToString() + " votes au total";

                    string query = "SELECT * FROM voteHistory WHERE voteTime >= DATE_SUB(NOW(),INTERVAL 1 HOUR) AND postID = 1";

                    MySqlCommand cmd = new MySqlCommand(query, this.SQLConn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    int voteHour = 0;
                    while (reader.Read())
                    {
                        voteHour++;
                    }

                    reader.Close();

                    voteHourLabel.Text = voteHour.ToString() + " votes dans la dernière heure";

                    //TAB INTERFACE
                    if (tabControl1.SelectedTab.Text == "Histogramme")
                    {
                        //HISTOGRAM
                        #region histogram
                        //Find the id of the post selected
                        query = "SELECT id FROM post WHERE name =\"" + comboBoxPost.SelectedItem.ToString() + "\"";

                        cmd = new MySqlCommand(query, this.SQLConn);
                        reader = cmd.ExecuteReader();

                        int id = 0;
                        while (reader.Read())
                        {
                            id = reader.GetInt32(0);
                        }

                        reader.Close();

                        //Find the names and candidateID for each candidate with this postID
                        query = "SELECT name, id FROM candidates WHERE postID =" + id.ToString();

                        cmd = new MySqlCommand(query, this.SQLConn);
                        reader = cmd.ExecuteReader();

                        Dictionary<string, int> histoXLabels = new Dictionary<string, int>();

                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            int candidateID = reader.GetInt32(1);
                            histoXLabels.Add(name, candidateID);
                        }

                        reader.Close();  

                        histoChart.Series[0].Points.Clear();

                        foreach (KeyValuePair<string, int> item in histoXLabels)
                            histoChart.Series[0].Points.AddXY(item.Key, getNumVotes(item.Value));

                        //saving the chart
                        chartSave.SetLength(0);
                        histoChart.Serializer.Save(chartSave);
                        #endregion
                    }
                    else
                    {
                        //PI
                        #region pi
                        //Find the id of the post selected
                        query = "SELECT id FROM post WHERE name =\"" + comboBoxPost.SelectedItem.ToString() + "\"";

                        cmd = new MySqlCommand(query, this.SQLConn);
                        reader = cmd.ExecuteReader();

                        int id = 0;
                        while (reader.Read())
                        {
                            id = reader.GetInt32(0);
                        }

                        reader.Close();

                        //Find the names now
                        query = "SELECT name, id FROM candidates WHERE postID =" + id.ToString();

                        cmd = new MySqlCommand(query, this.SQLConn);
                        reader = cmd.ExecuteReader();

                        Dictionary<string, int> piXLabels = new Dictionary<string, int>();
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            int candidateID = reader.GetInt32(1); 
                            piXLabels.Add(name, candidateID);
                        }

                        reader.Close();

                        piChart.Series[0].Points.Clear();

                        foreach (KeyValuePair<string, int> item in piXLabels)
                            piChart.Series[0].Points.AddXY(item.Key, getNumVotes(item.Value));

                        //saving the chart
                        chartSave.SetLength(0);
                        piChart.Serializer.Save(chartSave);
                        #endregion
                    }


                }
            }
            catch (NullReferenceException)
            {
            }
       }

        private void comboBoxPost_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {          
                if (voteStarted)
                {
                    DialogResult dialogResult = MessageBox.Show("Le vote est en cours, voulez vous arrêter le vote?", "Erreur", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string query = "UPDATE vars SET voteStarted = 0";
                        MySqlCommand cmd = new MySqlCommand(query, this.SQLConn);
                        cmd.ExecuteNonQuery();

                        déconnexionToolStripMenuItem.PerformClick();

                        voteStarted = false;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        e.Cancel = true;
                    }

                }
                else
                {
                    déconnexionToolStripMenuItem.PerformClick();
                }
            }
            catch (NullReferenceException)
            {

            }
        }

        private void popOutButton_Click(object sender, EventArgs e)
        {
            popOutWindow popOut = new popOutWindow();
            popOut.ShowDialog();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            UIUpdater_Tick(sender,e);
        }

    }
}
