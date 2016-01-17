namespace VoteCDJ_Admin
{
    partial class addCandidatesWindow
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
            this.candidateListBox = new System.Windows.Forms.ListBox();
            this.postComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.gradeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // candidateListBox
            // 
            this.candidateListBox.FormattingEnabled = true;
            this.candidateListBox.Location = new System.Drawing.Point(12, 73);
            this.candidateListBox.Name = "candidateListBox";
            this.candidateListBox.Size = new System.Drawing.Size(377, 199);
            this.candidateListBox.TabIndex = 0;
            this.candidateListBox.SelectedIndexChanged += new System.EventHandler(this.candidateListBox_SelectedIndexChanged);
            // 
            // postComboBox
            // 
            this.postComboBox.FormattingEnabled = true;
            this.postComboBox.Location = new System.Drawing.Point(12, 34);
            this.postComboBox.Name = "postComboBox";
            this.postComboBox.Size = new System.Drawing.Size(377, 21);
            this.postComboBox.TabIndex = 1;
            this.postComboBox.SelectedValueChanged += new System.EventHandler(this.postComboBox_SelectedValueChanged);
            this.postComboBox.Enter += new System.EventHandler(this.postComboBox_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Candidats:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Postes:";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(395, 74);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(122, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Ajouter";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(395, 103);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(122, 23);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "Supprimer";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(395, 149);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(122, 23);
            this.changeButton.TabIndex = 6;
            this.changeButton.Text = "Changement de grade";
            this.changeButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(395, 249);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(122, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // gradeLabel
            // 
            this.gradeLabel.AutoSize = true;
            this.gradeLabel.Location = new System.Drawing.Point(395, 133);
            this.gradeLabel.Name = "gradeLabel";
            this.gradeLabel.Size = new System.Drawing.Size(45, 13);
            this.gradeLabel.TabIndex = 8;
            this.gradeLabel.Text = "Grade: -";
            // 
            // addCandidatesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 285);
            this.Controls.Add(this.gradeLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.postComboBox);
            this.Controls.Add(this.candidateListBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(537, 324);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(537, 324);
            this.Name = "addCandidatesWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajouter des candidats";
            this.Load += new System.EventHandler(this.addCandidates_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox candidateListBox;
        private System.Windows.Forms.ComboBox postComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label gradeLabel;
    }
}