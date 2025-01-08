using LtAmpDotNet.Lib;
using LtAmpDotNet.Lib.Device;

namespace WinFormsAmpGui
{
    public partial class FormMain : Form
    {
        private LtAmplifier _amplifier;
        public FormMain()
        {
            InitializeComponent();
            // Initialize the amplifier with a USB device
        //    _amplifier = new LtAmplifier(new UsbAmpDevice());

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
    }
}
