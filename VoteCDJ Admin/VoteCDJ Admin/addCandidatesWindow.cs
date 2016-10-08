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
    public partial class addCandidatesWindow : Form
    {
        public addCandidatesWindow()
        {
            InitializeComponent();
        }

        private void addCandidates_Load(object sender, EventArgs e)
        {
            var mainWindow = Application.OpenForms.OfType<MainWindow>().Single();
            string query = "SELECT name FROM post";

            MySqlCommand cmd = new MySqlCommand(query, mainWindow.SQLConn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string post = reader.GetString(0);
                postComboBox.Items.Add(post);
            }

            reader.Close();
        }

        private void postComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //clear items before adding new ones
            candidateListBox.Items.Clear();

            var mainWindow = Application.OpenForms.OfType<MainWindow>().Single();
            string query = "SELECT name FROM candidates WHERE postID IN (Select id FROM post WHERE name =\"" + postComboBox.SelectedItem.ToString() + "\")";

            MySqlCommand cmd = new MySqlCommand(query, mainWindow.SQLConn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string candidate = reader.GetString(0);
                candidateListBox.Items.Add(candidate);
            }

            reader.Close();
        }

        private void updateCandList(string name)
        {

            candidateListBox.Items.Clear();
            var mainWindow = Application.OpenForms.OfType<MainWindow>().Single();
            string query = "SELECT name FROM candidates WHERE postID IN (Select id FROM post WHERE name =\"" + name + "\")";

            MySqlCommand cmd = new MySqlCommand(query, mainWindow.SQLConn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string candidate = reader.GetString(0);
                candidateListBox.Items.Add(candidate);
            }

            reader.Close();
        }

        private void updatePostList()
        {
            postComboBox.Items.Clear();

            var mainWindow = Application.OpenForms.OfType<MainWindow>().Single();
            string query = "SELECT name FROM post";

            MySqlCommand cmd = new MySqlCommand(query, mainWindow.SQLConn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string post = reader.GetString(0);
                postComboBox.Items.Add(post);
            }

            reader.Close();

            //postComboBox.Text = "";
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void candidateListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (candidateListBox.SelectedItem != null)
            {
                var mainWindow = Application.OpenForms.OfType<MainWindow>().Single();
                string query = "SELECT grade FROM candidates WHERE name =\"" + candidateListBox.SelectedItem.ToString() + "\"";

                MySqlCommand cmd = new MySqlCommand(query, mainWindow.SQLConn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int grade = reader.GetInt32(0);
                    gradeLabel.Text = "Grade: " + grade.ToString();
                }

                reader.Close();
            }
        }

        public void returnNames(string name, decimal grade)
        {
            var mainWindow = Application.OpenForms.OfType<MainWindow>().Single();

            //check if the post is empty
            bool empty = true;
            string tempquery = "SELECT * FROM candidates WHERE postID = (SELECT id FROM post WHERE name = \'" + postComboBox.Text + "\')";

            MySqlCommand tempcmd = new MySqlCommand(tempquery, mainWindow.SQLConn);
            MySqlDataReader reader = tempcmd.ExecuteReader();

            while (reader.Read())
            {
                empty = false;
            }

            reader.Close();
            Console.WriteLine(tempquery);
            Console.WriteLine(empty);

            if (candidateListBox.SelectedItem == null && !empty)
            {

                string query = "INSERT INTO post (id, name, grade) VALUES ((SELECT MAX(id) + 1 FROM (SELECT * FROM post) AS something) ,\'" + MySqlHelper.EscapeString(name) + "\', \'" + MySqlHelper.EscapeString(grade.ToString()) + "\')";
                MySqlCommand cmd = new MySqlCommand(query, mainWindow.SQLConn);
                cmd.ExecuteNonQuery();

                this.updateCandList(name);
                this.updatePostList();
                mainWindow.updateTree();
  
            }
            else if (postComboBox.SelectedItem == null && empty)
            {
                string query = "INSERT INTO post (id, name, grade) VALUES ((SELECT MAX(id) + 1 FROM (SELECT * FROM post) AS something) ,\'" + MySqlHelper.EscapeString(name) + "\', \'" + MySqlHelper.EscapeString(grade.ToString()) + "\')";
                MySqlCommand cmd = new MySqlCommand(query, mainWindow.SQLConn);
                cmd.ExecuteNonQuery();

                this.updateCandList(name);
                this.updatePostList();
                mainWindow.updateTree();
            }
            else
            {
                string query = "INSERT INTO candidates (id, postID, name, grade) VALUES ((SELECT MAX(id) + 1 FROM (SELECT * FROM candidates) AS something),(Select id FROM post WHERE name =\"" + postComboBox.Text + "\"), \'" + MySqlHelper.EscapeString(name) + "\', \'" + MySqlHelper.EscapeString(grade.ToString()) + "\')";
                MySqlCommand cmd = new MySqlCommand(query, mainWindow.SQLConn);
                cmd.ExecuteNonQuery();

                this.updateCandList(postComboBox.Text);
                this.updatePostList();
                try
                {
                    mainWindow.updateTree();
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            nameMenu namewindow = new nameMenu();
            namewindow.ShowDialog();
        }

        private void postComboBox_Enter(object sender, EventArgs e)
        {
            candidateListBox.ClearSelected();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var mainWindow = Application.OpenForms.OfType<MainWindow>().Single();

            if (candidateListBox.SelectedItem == null)
            {
                string query = "DELETE FROM post WHERE name = \'" + postComboBox.Text + "\'";
                MySqlCommand cmd = new MySqlCommand(query, mainWindow.SQLConn);
                cmd.ExecuteNonQuery();

                query = "DELETE FROM candidates WHERE postID = (SELECT postID FROM post WHERE name = \'" + postComboBox.Text + "\')";
                cmd = new MySqlCommand(query, mainWindow.SQLConn);
                cmd.ExecuteNonQuery();

                this.updateCandList("");
                this.updatePostList();
                mainWindow.updateTree();
            }
            else
            {
                string query = "DELETE FROM candidates WHERE name = \'" + candidateListBox.SelectedItem.ToString() + "\'";
                MySqlCommand cmd = new MySqlCommand(query, mainWindow.SQLConn);
                cmd.ExecuteNonQuery();

                this.updateCandList(postComboBox.Text);
                this.updatePostList();
                mainWindow.updateTree();
            }
        }
    }
}
