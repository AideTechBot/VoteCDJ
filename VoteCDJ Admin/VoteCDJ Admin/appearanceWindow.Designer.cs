namespace VoteCDJ_Admin
{
    partial class appearanceWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.replaceName = new System.Windows.Forms.ComboBox();
            this.getFileButton = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.uploadButton = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(216, 216);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // replaceName
            // 
            this.replaceName.FormattingEnabled = true;
            this.replaceName.Items.AddRange(new object[] {
            "Arrière plan",
            "Logo"});
            this.replaceName.Location = new System.Drawing.Point(235, 12);
            this.replaceName.Name = "replaceName";
            this.replaceName.Size = new System.Drawing.Size(177, 21);
            this.replaceName.TabIndex = 1;
            this.replaceName.Text = "Logo";
            // 
            // getFileButton
            // 
            this.getFileButton.Location = new System.Drawing.Point(235, 40);
            this.getFileButton.Name = "getFileButton";
            this.getFileButton.Size = new System.Drawing.Size(91, 23);
            this.getFileButton.TabIndex = 2;
            this.getFileButton.Text = "Choisir le fichier";
            this.getFileButton.UseVisualStyleBackColor = true;
            this.getFileButton.Click += new System.EventHandler(this.getFileButton_Click);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(332, 45);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(10, 13);
            this.fileLabel.TabIndex = 3;
            this.fileLabel.Text = "-";
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(337, 205);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 4;
            this.uploadButton.Text = "Télécharger";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(238, 86);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(174, 20);
            this.pathBox.TabIndex = 5;
            this.pathBox.Text = "/var/www/images/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Chemin du fichier:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nom d\'utilisateur:";
            // 
            // userBox
            // 
            this.userBox.Location = new System.Drawing.Point(238, 126);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(174, 20);
            this.userBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Mot de passe:";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(238, 166);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(174, 20);
            this.passwordBox.TabIndex = 10;
            // 
            // appearanceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 241);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.getFileButton);
            this.Controls.Add(this.replaceName);
            this.Controls.Add(this.pictureBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(440, 280);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(440, 280);
            this.Name = "appearanceWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modifier l\'apparence du vote";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox replaceName;
        private System.Windows.Forms.Button getFileButton;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwordBox;
    }
}