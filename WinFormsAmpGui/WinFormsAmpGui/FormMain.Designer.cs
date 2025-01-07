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
            SuspendLayout();
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(28, 122);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(121, 23);
            buttonLoad.TabIndex = 0;
            buttonLoad.Text = "Load local presets";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(784, 361);
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
    }
}
