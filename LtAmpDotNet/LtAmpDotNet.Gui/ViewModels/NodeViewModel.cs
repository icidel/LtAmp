using LtAmpDotNet.Lib.Model.Preset;
using System.Collections.ObjectModel;
using System.Linq;

namespace LtAmpDotNet.Gui.ViewModels
{
    public class NodeViewModel
    {
        public NodeIdType NodeId { get; }
        public string DisplayName { get; }
        public ObservableCollection<ParameterViewModel> Parameters { get; }

        public NodeViewModel(Node currentNode, Node referenceNode)
        {
            NodeId = currentNode.NodeId;
            DisplayName = currentNode.Definition.DisplayName;
            Parameters = new ObservableCollection<ParameterViewModel>();

            if (currentNode.Definition.Ui.UiParameters != null)
            {
                foreach (var uiParam in currentNode.Definition.Ui.UiParameters)
                {
                    var currentParam = currentNode.DspUnitParameters.FirstOrDefault(p => p.Name == uiParam.ControlId);
                    var referenceParam = referenceNode.DspUnitParameters.FirstOrDefault(p => p.Name == uiParam.ControlId);

                    if (currentParam != null && referenceParam != null)
                    {
                        Parameters.Add(new ParameterViewModel(currentParam, referenceParam, uiParam));
                    }
                }
            }
        }
    }
}
