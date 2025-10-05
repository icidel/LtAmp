using LtAmpDotNet.Gui.ViewModels;
using LtAmpDotNet.Lib;
using LtAmpDotNet.Lib.Model.Preset;
using LtAmpDotNet.Lib.Models.Protobuf;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LtAmpDotNet.Gui.Controls
{
    /// <summary>
    /// Interaction logic for StompControl.xaml
    /// </summary>
    public partial class StompControl : UserControl
    {
        public ILtAmplifier Amp { get; set; }

        public StompControl()
        {
            InitializeComponent();
        }

        private void ChangeEffect_Click(object sender, RoutedEventArgs e)
        {
            var availableEffects = LtAmplifier.DspUnitDefinitions?.Where(x => x.Info?.SubCategory == "stomp");
            if (availableEffects is null) return;

            NodeViewModel node = DataContext as NodeViewModel;

            var dialog = new EffectSelectionDialog(availableEffects, node?.FenderId)
            {
                Owner = Window.GetWindow(this)
            };

            if (dialog.ShowDialog() == true)
            {
                Amp.ReplaceNode(NodeIdType.delay, dialog.SelectedEffect.FenderId);
            }
        }
    }
}
