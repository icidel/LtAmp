using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using LtAmpDotNet.Lib;
using LtAmpDotNet.Lib.Device;
using LtAmpDotNet.Lib.Model.Preset;
using LtAmpDotNet.Lib.Models.Protobuf;
using Newtonsoft.Json;

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
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPresets.SelectedIndex >= 0)
            {
                buttonSelectPreset.Enabled = true;
                buttonSelectPreset.Text = "Activer " + listBoxPresets.Items[listBoxPresets.SelectedIndex];
            }
            else
            {
                buttonSelectPreset.Enabled = false;
                buttonSelectPreset.Text = "Aucun preset sélectionné";
            }
        }

        private void buttonSelectPreset_Click(object sender, EventArgs e)
        {
            buttonSelectPreset.Text = "Activer le preset {}";
            if (listBoxPresets.SelectedIndex >= 0)
            {
                _amplifier.LoadPreset(listBoxPresets.SelectedIndex);
            }
        }
        private async void buttonAmpConnect_Click(object sender, EventArgs e)
        {
            await _amplifier.OpenAsync(false);
            AmpConnectionInfo();
            AmpPresetInfo();
        }

        private void buttonAmpDisconnect_Click(object sender, EventArgs e)
        {
            _amplifier.Close();
            AmpConnectionInfo();
            AmpPresetInfo();
        }

        private async void AmpConnectionInfo()
        {
            try
            {
                labelConnectionInfo.Text = _amplifier.IsOpen ? "Oui" : "Non";
                FirmwareVersionStatus versionStatus = await _amplifier.GetFirmwareVersionAsync();
                labelConnectionInfo.Text = $"Version du micrologiciel: {versionStatus.Version}";
            }
            catch (Exception ex)
            {
                errorBoxDisplay(ex);
            }
        }

        private async void AmpPresetInfo()
        {
            try
            {
                if (!_amplifier.IsOpen)
                {
                    return;
                }
                List<PresetJSONMessage> allPreset = await _amplifier.GetAllPresetsAsync();
                foreach (PresetJSONMessage presetMsg in allPreset)
                {
                    int slotIndex = presetMsg.SlotIndex;
                    Preset preset = JsonConvert.DeserializeObject<Preset>(presetMsg.Data);
                    int nodeId = int.Parse(preset.NodeId);
                    String label = String.Join("\t", preset.DisplayName);
                    if (nodeId < listBoxPresets.Items.Count)
                    {
                        listBoxPresets.Items[nodeId] = label;
                    }
                }

                CurrentPresetStatus currPresetStatus = await _amplifier.GetCurrentPresetAsync();
                if (currPresetStatus.HasCurrentPresetData && currPresetStatus.CurrentPresetData != null)
                {
                    Preset? currPreset = Preset.FromString(currPresetStatus.CurrentPresetData);
                    if (currPreset != null)
                    {
                        bool factoryDefault = currPreset.Info.IsFactoryDefault ?? true;
                        int nodeId = int.Parse(currPreset.NodeId);
                        String[] name = currPreset.DisplayName;
                        String displayName = String.Join("\t", name);
                        if (nodeId < listBoxPresets.Items.Count)
                        {
                            listBoxPresets.ClearSelected();
                            listBoxPresets.SetSelected(nodeId, true);
                        } 
                    }
                }
            }
            catch (Exception ex)
            {
                errorBoxDisplay(ex);
            }
        }
    }
}
