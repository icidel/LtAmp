using NUnit.Framework;
using LtAmpDotNet.Lib.Models.Protobuf;
using LtAmpDotNet.Lib.Model.Preset;
using LtAmpDotNet.Gui.ViewModels;
using System.Linq;

namespace LtAmpDotNet.Gui.Tests
{
    public class RealtimeUpdateTests
    {
        [Test]
        public void ParameterViewModel_Updates_On_Status_Message()
        {
            // Arrange
            var preset = Preset.Create();
            var referencePreset = Preset.Create();
            var ampNode = preset.AudioGraph.Nodes.Single(n => n.NodeId == NodeIdType.amp);
            var refAmpNode = referencePreset.AudioGraph.Nodes.Single(n => n.NodeId == NodeIdType.amp);

            var nodeVm = new NodeViewModel(ampNode, refAmpNode);
            var gainParamVm = nodeVm.Parameters.Single(p => p.ControlId == "gain");
            var initialValue = gainParamVm.CurrentValue;

            var status = new DspUnitParameterStatus
            {
                NodeId = "amp",
                ParameterId = "gain",
                FloatParameter = 0.75f
            };

            // Act
            object newValue = status.TypeCase switch
            {
                DspUnitParameterStatus.TypeOneofCase.FloatParameter => status.FloatParameter,
                DspUnitParameterStatus.TypeOneofCase.StringParameter => status.StringParameter,
                DspUnitParameterStatus.TypeOneofCase.Sint32Parameter => status.Sint32Parameter,
                DspUnitParameterStatus.TypeOneofCase.BoolParameter => status.BoolParameter,
                _ => gainParamVm.CurrentValue
            };
            gainParamVm.CurrentValue = newValue;


            // Assert
            Assert.That(gainParamVm.CurrentValue, Is.Not.EqualTo(initialValue));
            Assert.That(gainParamVm.CurrentValue, Is.EqualTo(0.75f));
        }
    }
}
