using LtAmpDotNet.Gui.ViewModels;
using LtAmpDotNet.Lib;
using LtAmpDotNet.Lib.Device;
using LtAmpDotNet.Lib.Model.Preset;
using LtAmpDotNet.Lib.Models.Protobuf;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LtAmpDotNet.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ILtAmplifier? _amp;
        private Preset? _referencePreset;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await ConnectToAmplifier();
        }

        private async Task ConnectToAmplifier()
        {
            await Task.Run(async () =>
            {
                while (_amp == null || !_amp.IsDeviceOpen)
                {
                    try
                    {
                        await Dispatcher.InvokeAsync(() => {
                            ConnectionStatusText.Text = "Searching for amplifier...";
                        });

                        _amp = new LtAmplifier(new UsbAmpDevice());
                        await _amp.OpenAsync();

                        if (_amp.IsDeviceOpen)
                        {
                            await Dispatcher.InvokeAsync(() => {
                                ConnectionStatusText.Text = "Amplifier connected.";
                            });
                            _amp.CurrentLoadedPresetIndexStatusMessageReceived += Amp_CurrentLoadedPresetIndexStatusMessageReceived;
                            _amp.DspUnitParameterStatusMessageReceived += Amp_DspUnitParameterStatusMessageReceived;
                            await _amp.GetCurrentPresetAsync();
                        }
                    }
                    catch (Exception)
                    {
                        _amp?.Dispose();
                        _amp = null;
                        await Dispatcher.InvokeAsync(() => {
                            ConnectionStatusText.Text = "Amplifier not found. Retrying in 5 seconds...";
                        });
                        await Task.Delay(5000);
                    }
                }
            });
        }

        private async void Amp_CurrentLoadedPresetIndexStatusMessageReceived(object? sender, Lib.Events.FenderMessageEventArgs e)
        {
            if (e.Message is CurrentLoadedPresetIndexStatus presetIndex)
            {
                var preset = Preset.FromString((await _amp!.GetPresetAsync(presetIndex.PresetIndex)).Data);
                if (preset != null)
                {
                    _referencePreset = JsonConvert.DeserializeObject<Preset>(JsonConvert.SerializeObject(preset));

                    await Dispatcher.InvokeAsync(() =>
                    {
                        PresetNumberText.Text = presetIndex.PresetIndex.ToString();
                        PresetNameText.Text = preset.Info.DisplayNameRaw;

                        var ampNode = preset.AudioGraph.Nodes.SingleOrDefault(x => x.NodeId == NodeIdType.amp);
                        var refAmpNode = _referencePreset.AudioGraph.Nodes.SingleOrDefault(x => x.NodeId == NodeIdType.amp);
                        if (ampNode != null && refAmpNode != null)
                            AmplifierControlView.DataContext = new NodeViewModel(ampNode, refAmpNode);

                        var stompNode = preset.AudioGraph.Nodes.SingleOrDefault(x => x.NodeId == NodeIdType.stomp);
                        var refStompNode = _referencePreset.AudioGraph.Nodes.SingleOrDefault(x => x.NodeId == NodeIdType.stomp);
                        if (stompNode != null && refStompNode != null)
                            StompControlView.DataContext = new NodeViewModel(stompNode, refStompNode);

                        var modNode = preset.AudioGraph.Nodes.SingleOrDefault(x => x.NodeId == NodeIdType.mod);
                        var refModNode = _referencePreset.AudioGraph.Nodes.SingleOrDefault(x => x.NodeId == NodeIdType.mod);
                        if (modNode != null && refModNode != null)
                            ModulationControlView.DataContext = new NodeViewModel(modNode, refModNode);

                        var delayNode = preset.AudioGraph.Nodes.SingleOrDefault(x => x.NodeId == NodeIdType.delay);
                        var refDelayNode = _referencePreset.AudioGraph.Nodes.SingleOrDefault(x => x.NodeId == NodeIdType.delay);
                        if (delayNode != null && refDelayNode != null)
                            DelayControlView.DataContext = new NodeViewModel(delayNode, refDelayNode);

                        var reverbNode = preset.AudioGraph.Nodes.SingleOrDefault(x => x.NodeId == NodeIdType.reverb);
                        var refReverbNode = _referencePreset.AudioGraph.Nodes.SingleOrDefault(x => x.NodeId == NodeIdType.reverb);
                        if (reverbNode != null && refReverbNode != null)
                            ReverbControlView.DataContext = new NodeViewModel(reverbNode, refReverbNode);
                    });
                }
            }
        }

        private void Amp_DspUnitParameterStatusMessageReceived(object? sender, Lib.Events.FenderMessageEventArgs e)
        {
            if (e.Message is DspUnitParameterStatus status)
            {
                Dispatcher.InvokeAsync(() =>
                {
                    var nodeVms = new[] { AmplifierControlView.DataContext as NodeViewModel, StompControlView.DataContext as NodeViewModel, ModulationControlView.DataContext as NodeViewModel, DelayControlView.DataContext as NodeViewModel, ReverbControlView.DataContext as NodeViewModel };

                    if (Enum.TryParse<NodeIdType>(status.NodeId, true, out var nodeId))
                    {
                        var nodeVm = nodeVms.FirstOrDefault(vm => vm != null && vm.NodeId == nodeId);
                        if (nodeVm != null)
                        {
                            var paramVm = nodeVm.Parameters.FirstOrDefault(p => p.ControlId == status.ParameterId);
                            if (paramVm != null)
                            {
                                object newValue = status.TypeCase switch
                                {
                                    DspUnitParameterStatus.TypeOneofCase.FloatParameter => status.FloatParameter,
                                    DspUnitParameterStatus.TypeOneofCase.StringParameter => status.StringParameter,
                                    DspUnitParameterStatus.TypeOneofCase.Sint32Parameter => status.Sint32Parameter,
                                    DspUnitParameterStatus.TypeOneofCase.BoolParameter => status.BoolParameter,
                                    _ => paramVm.CurrentValue
                                };
                                paramVm.CurrentValue = newValue;
                            }
                        }
                    }
                });
            }
        }
    }
}
