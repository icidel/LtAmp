using LtAmpDotNet.Lib.Models.Protobuf;
using Newtonsoft.Json;
using System.Reflection;

namespace LtAmpDotNet.Lib.Device
{
public class MockDeviceState
{
    public List<string>? initializationStrings { get; set; }
    public string? firmwareVersion { get; set; }
    public string? productId { get; set; }
    public uint[]? qaSlots { get; set; }
    public float? usbGain { get; set; }
    public List<string>? Presets { get; set; }
    public ModalContext? modalContext { get; set; }

    public int CurrentPresetIndex { get; set; }

    public int CurrentLoadedPreset { set => CurrentPresetIndex = value; }
    public int CurrentDisplayedPreset { set => CurrentPresetIndex = value; }

    public static MockDeviceState Load(string productId = "mustang-lt-25")
    {
        string resourceName = "LtAmpDotNet.Lib.Tests.Device.mockAmpState-lt25.json";
        if (productId == "mustang-lt-50")
        {
            resourceName = "LtAmpDotNet.Lib.Tests.Device.mockAmpState-lt50.json";
        }
        using (Stream stream = Assembly.GetCallingAssembly().GetManifestResourceStream(resourceName)!)
        {
            using (StreamReader reader = new(stream))
            {
                string result = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<MockDeviceState>(result);
            }
        }
    }
}
}