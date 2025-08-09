using LtAmpDotNet.Lib.Model.Preset;
using LtAmpDotNet.Lib.Model.Profile;
using System.ComponentModel;

namespace LtAmpDotNet.Gui.ViewModels
{
    public class ParameterViewModel : INotifyPropertyChanged
    {
        private readonly DspUnitParameter _currentParameter;
        private readonly DspUnitParameter _referenceParameter;
        private readonly DspUnitUiParameter _uiParameter;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name => _uiParameter.DisplayName;
        public string ControlId => _uiParameter.ControlId;
        public object CurrentValue
        {
            get => _currentParameter.Value;
            set
            {
                var oldValue = _currentParameter.Value;
                if (oldValue is not null && false == oldValue.Equals(value) || oldValue is null && value is null)
                {
                    _currentParameter.Value = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentValue)));
                }
            }
        }
        public object ReferenceValue => _referenceParameter.Value;
        public string ControlType => _uiParameter.ControlType.Value.ToString();
        public string[] ListItems => _uiParameter.ListItems.ToArray<string>();
        public double Min => _uiParameter.Min.Value;
        public double Max => _uiParameter.Max.Value;

        public ParameterViewModel(DspUnitParameter currentParameter, DspUnitParameter referenceParameter, DspUnitUiParameter uiParameter)
        {
            _currentParameter = currentParameter;
            _referenceParameter = referenceParameter;
            _uiParameter = uiParameter;
        }
    }
}
