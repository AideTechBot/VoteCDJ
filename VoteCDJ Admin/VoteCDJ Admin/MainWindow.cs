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
using Excel = Microsoft.Office.Interop.Excel;
using System.Security.Cryptography;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VoteCDJ_Admin
{
    public partial class MainWindow : Form
    {
        
        public MySqlConnection SQLConn;
        public List<Tuple<string, int>> tupleList = new List<Tuple<string, int>> { };
        public bool voteStarted = false;
        public int voteCount = 0;
        public MemoryStream chartSave = new MemoryStream();
        public DateTime voteStart;
        public string HOST_IP = "";
        public int HOST_PORT = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region functions;

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
            string query;
            if (postID != -1)
            {
                query = "SELECT * FROM voteHistory WHERE  postID = " + postID.ToString();
            }
            else
            {
                query = "SELECT * FROM members WHERE hasVoted=1";
            }

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

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        #endregion;

        private void MainWindow_Load(object sender, EventArgs e)
        {
            UIUpdater.Start();
        }

        public void confirmConnection(string ip, string port)
        {
            statusText.Text = "Actuellement connecté à: " + ip + ":" + port;
            connectionOptions.Visible = true;

            HOST_IP = ip;
            HOST_PORT = Convert.ToInt32(port);

            nouvelleConnexionToolStripMenuItem.Enabled = false;
            importPassToolStripMenuItem.Enabled = true;
            exportResultsToolStripMenuItem.Enabled = true;
            modifierLToolStripMenuItem.Enabled = true;


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
            DialogResult dialogResult = MessageBox.Show("Êtes-vous sûr que vous voulez effacer tous les résultats du vote et commencer un nouveau vote?", " ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (!voteStarted)
                {
                    try
                    {
                        if (SQLConn.State == ConnectionState.Open)
                        {
                            if (voteTimeButton.Value != Decimal.Zero)
                            {
                                //disable stuff
                                voteTimeButton.Enabled = false;
                                startVoteButton.Enabled = false;
                                déconnexionToolStripMenuItem.Enabled = false;
                                endVoteButton.Enabled = true;


                                voteTimeLeftLabel.Text = Math.Floor(voteTimeButton.Value).ToString() + ":" + Math.Round((voteTimeButton.Value - Math.Floor(voteTimeButton.Value)) * 60).ToString().PadLeft(2, '0');

                                //clear the has voted
                                string query = "UPDATE vars SET voteStarted = 1";
                                MySqlCommand cmd = new MySqlCommand(query, this.SQLConn);
                                cmd.ExecuteNonQuery();

                                //delete the votes
                                query = "DELETE FROM voteHistory";
                                cmd = new MySqlCommand(query, this.SQLConn);
                                cmd.ExecuteNonQuery();

                                //give the people their right to vote
                                //by the people, for the people
                                //equality and justice for all
                                query = "UPDATE members SET hasvoted = 0";
                                cmd = new MySqlCommand(query, this.SQLConn);
                                cmd.ExecuteNonQuery();

                                voteCount = 0;
                                voteTimer.Start();
                                voteStarted = true;
                                voteStart = DateTime.Now;
                            }
                            else
                            {
                                MessageBox.Show("Paramètres invalides.");
                            }
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
        }

        private void endVoteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Êtes-vous sûr que vous voulez arrêter le vote?", " ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (voteStarted)
                {
                    //disable stuff
                    voteTimeButton.Enabled = true;
                    startVoteButton.Enabled = true;
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
                importPassToolStripMenuItem.Enabled = false;
                exportResultsToolStripMenuItem.Enabled = false;
                modifierLToolStripMenuItem.Enabled = false;

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

                candidateChart.ChartAreas[0].AxisX.Minimum = voteStart.ToOADate();
                candidateChart.ChartAreas[0].AxisX.Maximum = voteStart.AddHours((double)voteTimeButton.Value).ToOADate();

                candidateChart.ChartAreas[0].AxisY.Maximum = 10;

                int candidateID = getCandidateID(treeView.SelectedNode.Text);
                query = "SELECT voteTime FROM voteHistory WHERE candidateID =\"" + candidateID.ToString() + "\"";

                cmd = new MySqlCommand(query, this.SQLConn);
                reader = cmd.ExecuteReader();

                candidateChart.Series[0].Points.AddXY(voteStart.ToOADate(), 0);
                int voteNum = 0;
                while (reader.Read())
                {
                    voteNum = voteNum + 1;
                    DateTime date = reader.GetDateTime(0);
                    Console.WriteLine(voteNum.ToString() + " " + date.ToString());
                    candidateChart.Series[0].Points.AddXY(date.ToOADate(),voteNum);
                }
                double now = DateTime.Now.ToOADate();
                candidateChart.Series[0].Points.AddXY(now, voteNum);
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

                if (voteStarted)
                {
                    //disable stuff
                    voteTimeButton.Enabled = true;
                    startVoteButton.Enabled = true;
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
        }

        public void updateTree()
        {
            if (SQLConn.State == ConnectionState.Open)
            {
                treeView.Nodes.Clear();
                tupleList.Clear();
                comboBoxPost.Items.Clear();

                string query = "SELECT * FROM post";

                MySqlCommand cmd = new MySqlCommand(query, this.SQLConn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string post = reader.GetString(1);
                    int id = reader.GetInt32(0);
                    tupleList.Add(Tuple.Create(post, id));
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
                        treeView.Nodes[tuple.Item2 - 1].Nodes.Add(name);

                    }

                    reader.Close();
                }

            }
        }

        private void UIUpdater_Tick(object sender, EventArgs e)
        {
            try
            {
                if (SQLConn.State == ConnectionState.Open)
                {
                    //GREEN TEXT UPDATER
                    int totalVotes = getTotalVotes(-1);
                    totalVotesLabel.Text = totalVotes.ToString() + " votes au total";

                    string query = "SELECT * FROM voteHistory WHERE voteTime >= DATE_SUB(NOW(),INTERVAL 1 HOUR)";

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
                    else if (tabControl1.SelectedTab.Text == "Camembert")
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
                    else
                    {
                        //LINES
                        #region lines
                        //set chart max and min values

                        lineChart.ChartAreas[0].AxisX.Minimum = voteStart.ToOADate();
                        lineChart.ChartAreas[0].AxisX.Maximum = voteStart.AddHours((double)voteTimeButton.Value).ToOADate();

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

                        lineChart.Series.Clear();

                        Dictionary<string, int> lineXLabels = new Dictionary<string, int>();
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            int candidateID = reader.GetInt32(1);
                            Series series = lineChart.Series.Add(name);
                            series.YValueType = ChartValueType.Int32;
                            series.XValueType = ChartValueType.Time;
                            series.ChartType = SeriesChartType.Line;
                            series.BorderWidth = 3;  
 
                            lineXLabels.Add(name, candidateID);
                        }

                        reader.Close();

                        for (int k = this.lineChart.Series.Count - 1; k >= 0; k--)
                        {
                            lineChart.Series[k].Points.Clear();
                            lineChart.Series[k].Points.AddXY(voteStart.ToOADate(), 0);

                            //query the votes and add points
                            query = "SELECT voteTime FROM voteHistory WHERE candidateID =" + lineXLabels[lineChart.Series[k].Name].ToString();

                            cmd = new MySqlCommand(query, this.SQLConn);
                            reader = cmd.ExecuteReader();

                            int voteNum = 0;
                            while (reader.Read())
                            {
                                voteNum = voteNum + 1;
                                DateTime time = reader.GetDateTime(0);
                                lineChart.Series[k].Points.AddXY(time, voteNum);
                                Console.WriteLine(time);
                                Console.WriteLine(voteNum);
                                
                            }

                            reader.Close();

                            double now = DateTime.Now.ToOADate();
                            lineChart.Series[k].Points.AddXY(now, getTotalVotes(lineXLabels[lineChart.Series[k].Name]));
                        }

                        //saving the chart
                        chartSave.SetLength(0);
                        lineChart.Serializer.Save(chartSave);
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

        private void exportResultsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if( getTotalVotes(-1) > 0 && voteStarted == false)
            {

                saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.CreatePrompt = true;
                saveFileDialog.Title = "Exporter les résultats vers";
                if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Excel.Application xlApp = new Excel.Application();

                    if (xlApp == null)
                    {
                        MessageBox.Show("Excel n'est pas installé.");
                        return;
                    }


                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    //xlWorkSheet.Cells[1, 1] = "Sheet 1 content";

                    string query = "Select name,id FROM candidates ORDER by id";

                    MySqlCommand cmd = new MySqlCommand(query, this.SQLConn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    int x = 1;
                    int y = 1;
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        xlWorkSheet.Cells[x, y] = name;
                        x++;
                    }

                    reader.Close();

                    query = "SELECT candidateID,Count(*) as 'votes' FROM voteHistory GROUP BY candidateID;";

                    cmd = new MySqlCommand(query, this.SQLConn);
                    reader = cmd.ExecuteReader();

                    x = 1;
                    y = 2;
                    while (reader.Read())
                    {
                        int votes = reader.GetInt32(1);
                        xlWorkSheet.Cells[x, y] = votes;
                        x++;
                    }

                    reader.Close();
                    


                    xlWorkBook.SaveAs(this.saveFileDialog.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                }
            }
            else
            {
                MessageBox.Show("Aucun résultats disponibles.");
            }
        }

        private void addCandidatesButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (SQLConn.State == ConnectionState.Open)
                {
                    if (getTotalVotes(-1) == 0 && !voteStarted)
                    {
                        addCandidatesWindow addCandidatesWindow = new addCandidatesWindow();
                        addCandidatesWindow.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Vote en cours.");
                    }
                }
                else
                {
                    MessageBox.Show("Auncune connexion de base de données.");
                }
            }
            catch
            {
                MessageBox.Show("Auncune connexion de base de données.");
            }
        }

        private void importPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SQLConn.State == ConnectionState.Open)
            {
                if (!voteStarted)
                {
                    userAddWindow userAddWindow = new userAddWindow();
                    userAddWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vote en cours.");
                }
            }
            else
            {
                MessageBox.Show("Auncune connexion de base de données.");
            }
        }

        private void clearPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SQLConn.State == ConnectionState.Open)
            {
                if (getTotalVotes(-1) == 0 && !voteStarted)
                {
                    DialogResult dialogResult = MessageBox.Show("Êtes-vous sûr que vous voulez supprimer les mots de passe?", " ", MessageBoxButtons.YesNo);
                     if (dialogResult == DialogResult.Yes)
                     {
                         string query = "DELETE FROM members WHERE username != \"test_user\"";
                         MySqlCommand cmd = new MySqlCommand(query, this.SQLConn);
                         cmd.ExecuteNonQuery();
                         MessageBox.Show("Les mots de passe ont été supprimés avec succès");
                     }
                }
                else
                {
                    MessageBox.Show("Vote en cours.");
                }
            }
            else
            {
                MessageBox.Show("Auncune connexion de base de données.");
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://aidetechbot.github.io/VoteCDJ/");
        }

        private void modifierLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SQLConn.State == ConnectionState.Open)
            {
                appearanceWindow appearanceWindow = new appearanceWindow();
                appearanceWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Auncune connexion de base de données.");
            }
        }

    }
}
