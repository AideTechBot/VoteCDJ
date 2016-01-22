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
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VoteCDJ_Admin
{
    public partial class userAddWindow : Form
    {
        public userAddWindow()
        {
            InitializeComponent();
        }

        private void userAddWindow_Load(object sender, EventArgs e)
        {
            updateUI();
        }

        private void updateUI()
        {
            listBox.Items.Clear();
            var mainWindow = Application.OpenForms.OfType<MainWindow>().Single();

            string query = "SELECT username FROM members";

            MySqlCommand cmd = new MySqlCommand(query, mainWindow.SQLConn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string user = reader.GetString(0);
                listBox.Items.Add(user);
            }

            reader.Close();
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

        private void addButton_Click(object sender, EventArgs e)
        {
            loginWindow login = new loginWindow();
            login.ShowDialog();
        }

        public void addUser(string username, string password, int grade)
        {
            var mainWindow = Application.OpenForms.OfType<MainWindow>().Single();
            mainWindow.UIUpdater.Stop();

            //check if the user is already in the database
            string query = "SELECT * FROM members WHERE username = \"" + username + "\"";

            MySqlCommand cmd = new MySqlCommand(query, mainWindow.SQLConn);
            MySqlDataReader reader = cmd.ExecuteReader();

            int already = 0;
            while (reader.Read())
            {
                //MessageBox.Show("User already in database skipping...");
                already = 1;
            }
            reader.Close();
            if (already == 0)
            {
                //add the user to the database by hashing his passwords
                var request = (HttpWebRequest)WebRequest.Create("http://192.168.2.21/salt.php");

                var postData = "pass=" + password;
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                JObject o = JObject.Parse(responseString);
                Console.WriteLine(o["salt"]);
                Console.WriteLine(o["password"]);

                query = "INSERT INTO members (username, password, salt,  hasvoted, grade) VALUES (\"" + username + "\", \"" + o["password"] + "\", \"" + o["salt"] + "\", 0, " + grade.ToString() + ")";
                cmd = new MySqlCommand(query, mainWindow.SQLConn);
                cmd.ExecuteNonQuery();

                updateUI();
                mainWindow.UIUpdater.Start();
            }
            else
            {
                MessageBox.Show("Utilisateur est déjà dans la liste");
                mainWindow.UIUpdater.Start();
            }
        }

        private void importButton_Click(object sender, EventArgs e)

        {
            var mainWindow = Application.OpenForms.OfType<MainWindow>().Single();
            mainWindow.UIUpdater.Stop();

            openFileDialog.Filter = "Execl files (*.xls)|*.xls";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Importer";
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //open the excel file and read the credentials
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Range range;

                int rCnt = 0;
                int cCnt = 0;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(this.openFileDialog.FileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                range = xlWorkSheet.UsedRange;

                for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
                {
                    string username = "";
                    string password = "";
                    int grade = 12;
                    for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                    {
                        var value = (range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                        if (cCnt == 1)
                        {
                            username = (string)value;
                        }
                        else if (cCnt == 2)
                        {
                            password = (string)value;
                        }
                        else if (cCnt == 3)
                        {
                            grade = Convert.ToInt32(value);
                        }

                    }

                    //check if the user is already in the database
                    string query = "SELECT * FROM members WHERE username = \"" + username + "\"";

                    MySqlCommand cmd = new MySqlCommand(query, mainWindow.SQLConn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    int already = 0;
                    while (reader.Read())
                    {
                        //MessageBox.Show("User already in database skipping...");
                        already = 1;
                    }
                    if (already == 1)
                    {
                        reader.Close();
                        continue;
                    }
                    reader.Close();


                    //add the user to the database by hashing his passwords
                    var request = (HttpWebRequest)WebRequest.Create("http://192.168.2.21/salt.php");

                    var postData = "pass=" + password;
                    var data = Encoding.ASCII.GetBytes(postData);

                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    var response = (HttpWebResponse)request.GetResponse();

                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    JObject o = JObject.Parse(responseString);
                    Console.WriteLine(o["salt"]);
                    Console.WriteLine(o["password"]);

                    query = "INSERT INTO members (username, password, salt,  hasvoted, grade) VALUES (\"" + username + "\", \"" + o["password"] + "\", \"" + o["salt"] + "\", 0, " + grade.ToString() + ")";
                    cmd = new MySqlCommand(query, mainWindow.SQLConn);
                    cmd.ExecuteNonQuery();
                }

                xlWorkBook.Close(true, null, null);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                updateUI();

                mainWindow.UIUpdater.Start();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                if (listBox.SelectedItem.ToString() != "test_user")
                {
                    var mainWindow = Application.OpenForms.OfType<MainWindow>().Single();

                    int selected = listBox.SelectedIndex;

                    string query = "DELETE FROM members WHERE username = \"" + listBox.SelectedItem.ToString() + "\"";
                    MySqlCommand cmd = new MySqlCommand(query, mainWindow.SQLConn);
                    cmd.ExecuteNonQuery();

                    updateUI();
                    listBox.SelectedIndex = selected - 1;
                }
                else
                {
                    MessageBox.Show("Vous ne pouvez pas supprimer l'utilisateur de test.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox.SelectedItem != null)
            {
                //check if the user is already in the database
                var mainWindow = Application.OpenForms.OfType<MainWindow>().Single();
                string query = "SELECT grade FROM members WHERE username = \"" + listBox.SelectedItem.ToString() + "\"";

                MySqlCommand cmd = new MySqlCommand(query, mainWindow.SQLConn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    gradeLabel.Text = "Grade: " + reader.GetInt32(0).ToString();
                }
                reader.Close();
            }
        }

    }
}
