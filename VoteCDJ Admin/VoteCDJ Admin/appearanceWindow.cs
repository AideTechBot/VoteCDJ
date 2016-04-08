using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using System.IO;

namespace VoteCDJ_Admin
{
    public partial class appearanceWindow : Form
    {
        public string chosenFilePath = "";
        public string chosenFileName = "";

        public appearanceWindow()
        {
            InitializeComponent();
        }

        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }

        private void getFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Selectionner";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    chosenFilePath = openFileDialog.FileName;
                    chosenFileName = openFileDialog.SafeFileName;
                    Image img = GetCopyImage(chosenFilePath);
                    if (img.Height == 400 && img.Width == 400 && replaceName.SelectedItem.ToString() == "Logo")
                    {
                        pictureBox.Image = img;
                        fileLabel.Text = openFileDialog.SafeFileName.ToString();
                    }
                    else if (img.Height == 837 && img.Width == 1000 && replaceName.SelectedItem.ToString() == "Arrière plan")
                    {
                        pictureBox.Image = img;
                        fileLabel.Text = openFileDialog.SafeFileName.ToString();
                    }
                    else
                    {
                        MessageBox.Show("L'image est pas correctement formaté");
                        chosenFilePath = "";
                    }
                }
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            var mainWindow = Application.OpenForms.OfType<MainWindow>().Single();

            string username = userBox.Text;
            string password = passwordBox.Text;
            string workingdirectory = pathBox.Text;

            Console.WriteLine("Creating client and connecting");
            using (var client = new SftpClient(mainWindow.HOST_IP, 22, username, password))
            {
                client.Connect();
                Console.WriteLine("Connected to {0}", mainWindow.HOST_IP);

                client.ChangeDirectory(workingdirectory);
                Console.WriteLine("Changed directory to {0}", workingdirectory);

                var listDirectory = client.ListDirectory(workingdirectory);
                Console.WriteLine("Listing directory:");
                foreach (var fi in listDirectory)
                {
                    Console.WriteLine(" - " + fi.Name);
                }

                using (var fileStream = new FileStream(chosenFilePath, FileMode.Open))
                {
                    Console.WriteLine("Uploading {0} ({1:N0} bytes)",
                                        chosenFilePath, fileStream.Length);
                    client.BufferSize = 4 * 1024; // bypass Payload error large files
                    if (replaceName.SelectedItem.ToString() == "Logo")
                    {
                        client.UploadFile(fileStream, Path.GetFileName(chosenFilePath.Replace(chosenFileName, "") + "cdj.png"));
                    }
                    else
                    {
                        client.UploadFile(fileStream, Path.GetFileName(chosenFilePath.Replace(chosenFileName, "") + "bg_logo.jpg"));
                    }
                }
            }
            this.Close();
        }

    }
}
