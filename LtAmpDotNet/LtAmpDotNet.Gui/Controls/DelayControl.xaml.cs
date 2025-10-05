using LtAmpDotNet.Gui.ViewModels;
using LtAmpDotNet.Lib;
using LtAmpDotNet.Lib.Model.Preset;
using LtAmpDotNet.Lib.Models.Protobuf;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LtAmpDotNet.Gui.Controls
{
    /// <summary>
    /// Interaction logic for DelayControl.xaml
    /// </summary>
    public partial class DelayControl : UserControl
    {
        public ILtAmplifier Amp { get; set; }

        public DelayControl()
        {
            InitializeComponent();
        }

        private void ChangeEffect_Click(object sender, RoutedEventArgs e)
        {
            var availableEffects = LtAmplifier.DspUnitDefinitions?.Where(x => x.Info?.SubCategory == "delay");
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
