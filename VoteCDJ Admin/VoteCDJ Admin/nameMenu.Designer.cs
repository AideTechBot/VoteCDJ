namespace VoteCDJ_Admin
{
    partial class nameMenu
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.gradeBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gradeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom:";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(15, 25);
            this.nameBox.MaxLength = 255;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(251, 20);
            this.nameBox.TabIndex = 1;
            // 
            // gradeBox
            // 
            this.gradeBox.Location = new System.Drawing.Point(273, 24);
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
            this.gradeBox.Size = new System.Drawing.Size(60, 20);
            this.gradeBox.TabIndex = 2;
            this.gradeBox.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Grade:";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(255, 51);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(78, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // nameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 81);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gradeBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(360, 120);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 120);
            this.Name = "nameMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajouter";
            ((System.ComponentModel.ISupportInitialize)(this.gradeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.NumericUpDown gradeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button okButton;
    }
}