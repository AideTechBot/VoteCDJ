namespace VoteCDJ_Admin
{
    partial class loginWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userBox = new System.Windows.Forms.TextBox();
            this.passBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gradeBox = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gradeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom d\'utilisateur";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mot de passe";
            // 
            // userBox
            // 
            this.userBox.Location = new System.Drawing.Point(103, 12);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(100, 20);
            this.userBox.TabIndex = 2;
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(103, 38);
            this.passBox.Name = "passBox";
            this.passBox.Size = new System.Drawing.Size(100, 20);
            this.passBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Grade";
            // 
            // gradeBox
            // 
            this.gradeBox.Location = new System.Drawing.Point(103, 64);
            this.gradeBox.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.gradeBox.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.gradeBox.Name = "gradeBox";
            this.gradeBox.Size = new System.Drawing.Size(100, 20);
            this.gradeBox.TabIndex = 5;
            this.gradeBox.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // loginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 123);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gradeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passBox);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(225, 162);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(225, 162);
            this.Name = "loginWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajouter un utilisateur";
            ((System.ComponentModel.ISupportInitialize)(this.gradeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown gradeBox;
        private System.Windows.Forms.Button button1;
    }
}