using LtAmpDotNet.Lib;
using LtAmpDotNet.Lib.Device;
using LtAmpDotNet.Lib.Models.Protobuf;

namespace WinFormsAmpGui
{
    public partial class FormMain : Form
    {
        private LtAmplifier _amplifier;
        public FormMain()
        {
            InitializeComponent();
            _amplifier = new LtAmplifier(new UsbAmpDevice());
        }
        private void errorBoxDisplay(Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // Set the ListBox to not display items in multiple columns.
            listBoxPresets.MultiColumn = false;
            // Shutdown the painting of the ListBox as items are added.
            listBoxPresets.BeginUpdate();

            // _amplifier.GetAllPresetsAsync();
            // Loop through and add 50 items to the ListBox.
            for (int x = 1; x <= 50; x++)
            {
                listBoxPresets.Items.Add("Item " + x.ToString());
            }
            // Allow the ListBox to repaint and display the new items.
            listBoxPresets.EndUpdate();

            // Select first item from the ListBox.
            listBoxPresets.SetSelected(1, true);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSelectPreset_Click(object sender, EventArgs e)
        {

        }
        // MUST ASYNC OPENING AND CLOSING
        private void buttonAmpConnect_Click(object sender, EventArgs e)
        {
            _amplifier.Open(false);
        }

        private void buttonAmpDisconnect_Click(object sender, EventArgs e)
        {
            _amplifier.Close();
        }

        private async void buttonAmpConnectionInfo_Click(object sender, EventArgs e)
        {
            try
            {
                labelConnectionInfo.Text = _amplifier.IsOpen ? "Yes" : "No";
                FirmwareVersionStatus versionStatus = await _amplifier.GetFirmwareVersionAsync();
                labelConnectionInfo.Text = $"Firmware Version: {versionStatus.Version}";
            }
            catch (Exception ex)
            {
                errorBoxDisplay(ex);
            }
        }
    }
}
