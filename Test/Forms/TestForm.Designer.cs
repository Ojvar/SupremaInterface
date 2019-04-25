namespace Test.Forms
{
    partial class TestForm
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
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.enrollButton = new System.Windows.Forms.Button();
            this.identityButton = new System.Windows.Forms.Button();
            this.devicesComboBox = new System.Windows.Forms.ComboBox();
            this.clientConnectButton = new System.Windows.Forms.Button();
            this.logListBox = new System.Windows.Forms.ListBox();
            this.clientDisconnectButton = new System.Windows.Forms.Button();
            this.readTemplateButton = new System.Windows.Forms.Button();
            this.enrollTemplateButton = new System.Windows.Forms.Button();
            this.userIdUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.identifyTemplateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userIdUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(26, 27);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(137, 43);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(169, 27);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(137, 43);
            this.stopButton.TabIndex = 0;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // enrollButton
            // 
            this.enrollButton.Location = new System.Drawing.Point(26, 292);
            this.enrollButton.Name = "enrollButton";
            this.enrollButton.Size = new System.Drawing.Size(137, 43);
            this.enrollButton.TabIndex = 0;
            this.enrollButton.Text = "Enroll";
            this.enrollButton.UseVisualStyleBackColor = true;
            // 
            // identityButton
            // 
            this.identityButton.Location = new System.Drawing.Point(169, 292);
            this.identityButton.Name = "identityButton";
            this.identityButton.Size = new System.Drawing.Size(137, 43);
            this.identityButton.TabIndex = 0;
            this.identityButton.Text = "Identify";
            this.identityButton.UseVisualStyleBackColor = true;
            // 
            // devicesComboBox
            // 
            this.devicesComboBox.FormattingEnabled = true;
            this.devicesComboBox.Location = new System.Drawing.Point(324, 243);
            this.devicesComboBox.Name = "devicesComboBox";
            this.devicesComboBox.Size = new System.Drawing.Size(281, 24);
            this.devicesComboBox.TabIndex = 1;
            // 
            // clientConnectButton
            // 
            this.clientConnectButton.Location = new System.Drawing.Point(26, 243);
            this.clientConnectButton.Name = "clientConnectButton";
            this.clientConnectButton.Size = new System.Drawing.Size(137, 43);
            this.clientConnectButton.TabIndex = 0;
            this.clientConnectButton.Text = "Client connect";
            this.clientConnectButton.UseVisualStyleBackColor = true;
            // 
            // logListBox
            // 
            this.logListBox.FormattingEnabled = true;
            this.logListBox.ItemHeight = 16;
            this.logListBox.Location = new System.Drawing.Point(26, 128);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(579, 84);
            this.logListBox.TabIndex = 2;
            // 
            // clientDisconnectButton
            // 
            this.clientDisconnectButton.Location = new System.Drawing.Point(169, 243);
            this.clientDisconnectButton.Name = "clientDisconnectButton";
            this.clientDisconnectButton.Size = new System.Drawing.Size(137, 43);
            this.clientDisconnectButton.TabIndex = 0;
            this.clientDisconnectButton.Text = "Client DisConnect";
            this.clientDisconnectButton.UseVisualStyleBackColor = true;
            // 
            // readTemplateButton
            // 
            this.readTemplateButton.Location = new System.Drawing.Point(324, 292);
            this.readTemplateButton.Name = "readTemplateButton";
            this.readTemplateButton.Size = new System.Drawing.Size(137, 43);
            this.readTemplateButton.TabIndex = 0;
            this.readTemplateButton.Text = "Read Template";
            this.readTemplateButton.UseVisualStyleBackColor = true;
            // 
            // enrollTemplateButton
            // 
            this.enrollTemplateButton.Location = new System.Drawing.Point(324, 341);
            this.enrollTemplateButton.Name = "enrollTemplateButton";
            this.enrollTemplateButton.Size = new System.Drawing.Size(137, 43);
            this.enrollTemplateButton.TabIndex = 0;
            this.enrollTemplateButton.Text = "Enroll Template";
            this.enrollTemplateButton.UseVisualStyleBackColor = true;
            // 
            // userIdUpDown
            // 
            this.userIdUpDown.Location = new System.Drawing.Point(485, 38);
            this.userIdUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.userIdUpDown.Name = "userIdUpDown";
            this.userIdUpDown.Size = new System.Drawing.Size(120, 22);
            this.userIdUpDown.TabIndex = 3;
            this.userIdUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(426, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "User id";
            // 
            // identifyTemplateButton
            // 
            this.identifyTemplateButton.Location = new System.Drawing.Point(467, 341);
            this.identifyTemplateButton.Name = "identifyTemplateButton";
            this.identifyTemplateButton.Size = new System.Drawing.Size(137, 43);
            this.identifyTemplateButton.TabIndex = 0;
            this.identifyTemplateButton.Text = "Identiy Template";
            this.identifyTemplateButton.UseVisualStyleBackColor = true;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 455);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userIdUpDown);
            this.Controls.Add(this.logListBox);
            this.Controls.Add(this.devicesComboBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.identifyTemplateButton);
            this.Controls.Add(this.enrollTemplateButton);
            this.Controls.Add(this.readTemplateButton);
            this.Controls.Add(this.identityButton);
            this.Controls.Add(this.enrollButton);
            this.Controls.Add(this.clientDisconnectButton);
            this.Controls.Add(this.clientConnectButton);
            this.Controls.Add(this.startButton);
            this.Name = "TestForm";
            this.Text = "TestForm";
            ((System.ComponentModel.ISupportInitialize)(this.userIdUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button enrollButton;
        private System.Windows.Forms.Button identityButton;
        private System.Windows.Forms.ComboBox devicesComboBox;
        private System.Windows.Forms.Button clientConnectButton;
        private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.Button clientDisconnectButton;
        private System.Windows.Forms.Button readTemplateButton;
        private System.Windows.Forms.Button enrollTemplateButton;
        private System.Windows.Forms.NumericUpDown userIdUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button identifyTemplateButton;
    }
}