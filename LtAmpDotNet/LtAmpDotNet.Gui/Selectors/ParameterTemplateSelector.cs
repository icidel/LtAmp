using LtAmpDotNet.Gui.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace LtAmpDotNet.Gui.Selectors
{
    public class ParameterTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SliderTemplate { get; set; }
        public DataTemplate ComboBoxTemplate { get; set; }
        public DataTemplate CheckBoxTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ParameterViewModel vm)
            {
                switch (vm.ControlType)
                {
                    case "list":
                        return ComboBoxTemplate;
                    case "continuous":
                        return SliderTemplate;
                    case "listBool":
                        return CheckBoxTemplate;
                }
            }
            return base.SelectTemplate(item, container);
        }
    }
}
