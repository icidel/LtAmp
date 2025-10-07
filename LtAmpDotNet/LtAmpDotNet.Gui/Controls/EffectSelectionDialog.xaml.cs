using LtAmpDotNet.Lib.Model.Profile;
using System.Windows;

namespace LtAmpDotNet.Gui.Controls
{
    public partial class EffectSelectionDialog : Window
    {
        public DspUnitDefinition SelectedEffect { get; private set; }

        private string lastEffectFenderId;

        public EffectSelectionDialog(IEnumerable<DspUnitDefinition> effects, string fenderId)
        {
            InitializeComponent();
            EffectsListBox.ItemsSource = effects;
            EffectsListBox.SelectedItem = effects.Where(x => x.FenderId == fenderId).FirstOrDefault(effects.First());
            lastEffectFenderId = fenderId;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (EffectsListBox.SelectedItem is DspUnitDefinition selectedEffect)
            {
                SelectedEffect = selectedEffect;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please select an effect.", "No Effect Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
