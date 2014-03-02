namespace ShowsCountDown
{
    partial class AddShowForm
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
            this.SelectShowFormLabel = new System.Windows.Forms.Label();
            this.showListForm = new System.Windows.Forms.ComboBox();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.AddShowFormButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectShowFormLabel
            // 
            this.SelectShowFormLabel.AutoSize = true;
            this.SelectShowFormLabel.Location = new System.Drawing.Point(44, 34);
            this.SelectShowFormLabel.Name = "SelectShowFormLabel";
            this.SelectShowFormLabel.Size = new System.Drawing.Size(68, 13);
            this.SelectShowFormLabel.TabIndex = 0;
            this.SelectShowFormLabel.Text = "Select show:";
            this.SelectShowFormLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // showListForm
            // 
            this.showListForm.FormattingEnabled = true;
            this.showListForm.Location = new System.Drawing.Point(118, 31);
            this.showListForm.Name = "showListForm";
            this.showListForm.Size = new System.Drawing.Size(314, 21);
            this.showListForm.TabIndex = 1;
            // 
            // CancelFormButton
            // 
            this.CancelFormButton.Location = new System.Drawing.Point(357, 87);
            this.CancelFormButton.Name = "CancelFormButton";
            this.CancelFormButton.Size = new System.Drawing.Size(75, 23);
            this.CancelFormButton.TabIndex = 2;
            this.CancelFormButton.Text = "Cancel";
            this.CancelFormButton.UseVisualStyleBackColor = true;
            this.CancelFormButton.Click += new System.EventHandler(this.CancelFormButton_Click);
            // 
            // AddShowFormButton
            // 
            this.AddShowFormButton.Location = new System.Drawing.Point(276, 87);
            this.AddShowFormButton.Name = "AddShowFormButton";
            this.AddShowFormButton.Size = new System.Drawing.Size(75, 23);
            this.AddShowFormButton.TabIndex = 3;
            this.AddShowFormButton.Text = "Add Show";
            this.AddShowFormButton.UseVisualStyleBackColor = true;
            this.AddShowFormButton.Click += new System.EventHandler(this.AddShowFormButton_Click);
            // 
            // AddShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 134);
            this.Controls.Add(this.AddShowFormButton);
            this.Controls.Add(this.CancelFormButton);
            this.Controls.Add(this.showListForm);
            this.Controls.Add(this.SelectShowFormLabel);
            this.Name = "AddShowForm";
            this.Text = "Add Show";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SelectShowFormLabel;
        private System.Windows.Forms.ComboBox showListForm;
        private System.Windows.Forms.Button CancelFormButton;
        private System.Windows.Forms.Button AddShowFormButton;
    }
}