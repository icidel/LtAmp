using LtAmpDotNet.Gui.ViewModels;
using LtAmpDotNet.Lib;
using LtAmpDotNet.Lib.Model.Preset;
using System.Windows;
using System.Windows.Controls;

namespace LtAmpDotNet.Gui.Controls
{
    /// <summary>
    /// Interaction logic for AmplifierControl.xaml
    /// </summary>
    public partial class AmplifierControl : UserControl
    {
        public ILtAmplifier Amp { get; set; }

        public AmplifierControl()
        {
            InitializeComponent();
        }

        private void ChangeEffect_Click(object sender, RoutedEventArgs e)
        {
            var availableEffects = LtAmplifier.DspUnitDefinitions?.Where(x => x.Info?.SubCategory == "amp");
            if (availableEffects?.First() is null) return;

            NodeViewModel node = DataContext as NodeViewModel;

            var dialog = new EffectSelectionDialog(availableEffects, node?.FenderId)
            {
                Owner = Window.GetWindow(this)
            };

            if (dialog.ShowDialog() == true && dialog.SelectedEffect.FenderId != null)
            {
                Amp.ReplaceNode(NodeIdType.amp, dialog.SelectedEffect.FenderId);
            }
        }
    }
}
