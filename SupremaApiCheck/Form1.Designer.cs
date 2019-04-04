namespace SupremaApiCheck
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.enrollButton = new System.Windows.Forms.Button();
            this.identityButton = new System.Windows.Forms.Button();
            this.outputListBox = new System.Windows.Forms.ListBox();
            this.readTemplateButton = new System.Windows.Forms.Button();
            this.identityTemplateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deleteAllButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(12, 23);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "c";
            this.connectButton.UseVisualStyleBackColor = true;
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(93, 23);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 1;
            this.disconnectButton.Text = "dc";
            this.disconnectButton.UseVisualStyleBackColor = true;
            // 
            // enrollButton
            // 
            this.enrollButton.Location = new System.Drawing.Point(12, 87);
            this.enrollButton.Name = "enrollButton";
            this.enrollButton.Size = new System.Drawing.Size(75, 23);
            this.enrollButton.TabIndex = 2;
            this.enrollButton.Text = "en";
            this.enrollButton.UseVisualStyleBackColor = true;
            // 
            // identityButton
            // 
            this.identityButton.Location = new System.Drawing.Point(93, 87);
            this.identityButton.Name = "identityButton";
            this.identityButton.Size = new System.Drawing.Size(75, 23);
            this.identityButton.TabIndex = 2;
            this.identityButton.Text = "id";
            this.identityButton.UseVisualStyleBackColor = true;
            // 
            // outputListBox
            // 
            this.outputListBox.FormattingEnabled = true;
            this.outputListBox.ItemHeight = 16;
            this.outputListBox.Location = new System.Drawing.Point(185, 23);
            this.outputListBox.Name = "outputListBox";
            this.outputListBox.Size = new System.Drawing.Size(803, 180);
            this.outputListBox.TabIndex = 3;
            // 
            // readTemplateButton
            // 
            this.readTemplateButton.Location = new System.Drawing.Point(12, 150);
            this.readTemplateButton.Name = "readTemplateButton";
            this.readTemplateButton.Size = new System.Drawing.Size(75, 23);
            this.readTemplateButton.TabIndex = 4;
            this.readTemplateButton.Text = "r-t";
            this.readTemplateButton.UseVisualStyleBackColor = true;
            // 
            // identityTemplateButton
            // 
            this.identityTemplateButton.Location = new System.Drawing.Point(93, 150);
            this.identityTemplateButton.Name = "identityTemplateButton";
            this.identityTemplateButton.Size = new System.Drawing.Size(75, 23);
            this.identityTemplateButton.TabIndex = 5;
            this.identityTemplateButton.Text = "id-temp";
            this.identityTemplateButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(12, 197);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "d";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // deleteAllButton
            // 
            this.deleteAllButton.Location = new System.Drawing.Point(93, 197);
            this.deleteAllButton.Name = "deleteAllButton";
            this.deleteAllButton.Size = new System.Drawing.Size(75, 23);
            this.deleteAllButton.TabIndex = 6;
            this.deleteAllButton.Text = "d";
            this.deleteAllButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 232);
            this.Controls.Add(this.deleteAllButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.identityTemplateButton);
            this.Controls.Add(this.readTemplateButton);
            this.Controls.Add(this.outputListBox);
            this.Controls.Add(this.identityButton);
            this.Controls.Add(this.enrollButton);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button enrollButton;
        private System.Windows.Forms.Button identityButton;
        private System.Windows.Forms.ListBox outputListBox;
        private System.Windows.Forms.Button readTemplateButton;
        private System.Windows.Forms.Button identityTemplateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button deleteAllButton;
    }
}

