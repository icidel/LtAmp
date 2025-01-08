namespace WinFormsAmpGui
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            buttonLoad = new Button();
            listBoxPresets = new ListBox();
            buttonSelectPreset = new Button();
            buttonAmpConnect = new Button();
            buttonAmpDisconnect = new Button();
            richTextBoxAmpConnection = new RichTextBox();
            SuspendLayout();
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(218, 12);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(200, 23);
            buttonLoad.TabIndex = 0;
            buttonLoad.Text = "Load local presets";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // listBoxPresets
            // 
            listBoxPresets.Font = new Font("Segoe UI", 10F);
            listBoxPresets.FormattingEnabled = true;
            listBoxPresets.ItemHeight = 17;
            listBoxPresets.Location = new Point(218, 41);
            listBoxPresets.Name = "listBoxPresets";
            listBoxPresets.Size = new Size(200, 259);
            listBoxPresets.TabIndex = 1;
            listBoxPresets.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // buttonSelectPreset
            // 
            buttonSelectPreset.Location = new Point(218, 306);
            buttonSelectPreset.Name = "buttonSelectPreset";
            buttonSelectPreset.Size = new Size(200, 23);
            buttonSelectPreset.TabIndex = 2;
            buttonSelectPreset.Text = "Select preset";
            buttonSelectPreset.UseVisualStyleBackColor = true;
            buttonSelectPreset.Click += buttonSelectPreset_Click;
            // 
            // buttonAmpConnect
            // 
            buttonAmpConnect.Location = new Point(12, 12);
            buttonAmpConnect.Name = "buttonAmpConnect";
            buttonAmpConnect.Size = new Size(158, 23);
            buttonAmpConnect.TabIndex = 0;
            buttonAmpConnect.Text = "Connect";
            buttonAmpConnect.UseVisualStyleBackColor = true;
            // 
            // buttonAmpDisconnect
            // 
            buttonAmpDisconnect.Location = new Point(12, 41);
            buttonAmpDisconnect.Name = "buttonAmpDisconnect";
            buttonAmpDisconnect.Size = new Size(158, 23);
            buttonAmpDisconnect.TabIndex = 0;
            buttonAmpDisconnect.Text = "Disconnect";
            buttonAmpDisconnect.UseVisualStyleBackColor = true;
            // 
            // richTextBoxAmpConnection
            // 
            richTextBoxAmpConnection.Location = new Point(12, 70);
            richTextBoxAmpConnection.Name = "richTextBoxAmpConnection";
            richTextBoxAmpConnection.ReadOnly = true;
            richTextBoxAmpConnection.Size = new Size(158, 96);
            richTextBoxAmpConnection.TabIndex = 3;
            richTextBoxAmpConnection.Text = "";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(784, 361);
            Controls.Add(richTextBoxAmpConnection);
            Controls.Add(buttonSelectPreset);
            Controls.Add(listBoxPresets);
            Controls.Add(buttonAmpDisconnect);
            Controls.Add(buttonAmpConnect);
            Controls.Add(buttonLoad);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(800, 400);
            MinimumSize = new Size(800, 400);
            Name = "FormMain";
            StartPosition = FormStartPosition.WindowsDefaultBounds;
            Text = "LtAmpGui";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonLoad;
        private ListBox listBoxPresets;
        private Button buttonSelectPreset;
        private Button buttonAmpConnect;
        private Button buttonAmpDisconnect;
        private RichTextBox richTextBoxAmpConnection;
    }
}
