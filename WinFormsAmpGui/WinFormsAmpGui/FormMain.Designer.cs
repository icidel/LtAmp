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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            buttonLoad = new Button();
            listBoxPresets = new ListBox();
            buttonSelectPreset = new Button();
            buttonAmpConnect = new Button();
            buttonAmpDisconnect = new Button();
            labelConnectionInfo = new Label();
            SuspendLayout();
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(218, 12);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(200, 23);
            buttonLoad.TabIndex = 0;
            buttonLoad.Text = "Charger les presets locaux";
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
            buttonSelectPreset.Enabled = false;
            buttonSelectPreset.Text = "Aucun preset sélectionné";
            buttonSelectPreset.UseVisualStyleBackColor = true;
            buttonSelectPreset.Click += buttonSelectPreset_Click;
            // 
            // buttonAmpConnect
            // 
            buttonAmpConnect.Location = new Point(12, 12);
            buttonAmpConnect.Name = "buttonAmpConnect";
            buttonAmpConnect.Size = new Size(150, 23);
            buttonAmpConnect.TabIndex = 0;
            buttonAmpConnect.Text = "Connecter";
            buttonAmpConnect.UseVisualStyleBackColor = true;
            buttonAmpConnect.Click += buttonAmpConnect_Click;
            // 
            // buttonAmpDisconnect
            // 
            buttonAmpDisconnect.Location = new Point(12, 41);
            buttonAmpDisconnect.Name = "buttonAmpDisconnect";
            buttonAmpDisconnect.Size = new Size(150, 23);
            buttonAmpDisconnect.TabIndex = 0;
            buttonAmpDisconnect.Text = "Déconnecter";
            buttonAmpDisconnect.UseVisualStyleBackColor = true;
            buttonAmpDisconnect.Click += buttonAmpDisconnect_Click;
            // 
            // labelConnectionInfo
            // 
            labelConnectionInfo.AutoSize = true;
            labelConnectionInfo.Location = new Point(12, 67);
            labelConnectionInfo.MaximumSize = new Size(150, 0);
            labelConnectionInfo.Name = "labelConnectionInfo";
            labelConnectionInfo.Size = new Size(86, 15);
            labelConnectionInfo.TabIndex = 3;
            labelConnectionInfo.Text = "Non connecté";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(784, 361);
            Controls.Add(labelConnectionInfo);
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
            PerformLayout();
        }

        private Button buttonLoad;
        private ListBox listBoxPresets;
        private Button buttonSelectPreset;
        private Button buttonAmpConnect;
        private Button buttonAmpDisconnect;
        private Label labelConnectionInfo;
    }
}
