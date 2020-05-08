using System.Text;

namespace Refactoring
{
    public class RemoteController
    {
        private readonly OptionsIndicator optionsIndicator;
        private const int MinValue = 0;
        private const int MaxValue = 100;
        private const int Step = 10;
        private int volume = 20;
        private int brightness = 20;
        private int contrast = 20;

        public int Volume
        {
            get => volume;
            set
            {
                if (value >= MinValue && value <= MaxValue)
                {
                    volume = value;
                }
            }
        }
        public int Brightness
        {
            get => brightness;
            set
            {
                if (value >= MinValue && value <= MaxValue)
                {
                    brightness = value;
                }
            }
        }
        public int Contrast
        {
            get => contrast;
            set
            {
                if (value >= MinValue && value <= MaxValue)
                {
                    contrast = value;
                }
            }
        }
        public bool IsOnline { get; set; }

        public RemoteController()
        {
            optionsIndicator = new OptionsIndicator(this);
        }

        public string Call(string command)
        {
            string subCommand = null;
            const string startCommand = "Options change";

            if (command.StartsWith(startCommand))
            {
                subCommand = command.Substring(14).Trim();
                command = startCommand;
            }

            switch (command)
            {
                case "Tv On":
                    IsOnline = true;
                    break;
                case "Tv Off":
                    IsOnline = false;
                    break;
                case "Volume Up":
                    Volume += Step;
                    break;
                case "Volume Down":
                    Volume -= Step;
                    break;
                case "Options change":
                    SwitchOptions(subCommand);
                    break;
                case "Options show":
                    return optionsIndicator.ShowOptions();
            }

            return "";
        }

        private void SwitchOptions(string command)
        {
            switch (command)
            {
                case "brightness up":
                    Brightness += Step;
                    break;
                case "brightness down":
                    Brightness -= Step;
                    break;
                case "contrast up":
                    Contrast += Step;
                    break;
                case "contrast down":
                    Contrast -= Step;
                    break;
            }
        }
    }

    public class OptionsIndicator
    {
        private readonly RemoteController remoteController;

        public OptionsIndicator(RemoteController remoteController)
        {
            this.remoteController = remoteController;
        }

        public string ShowOptions()
        {
            var listOfOptions = new StringBuilder();

            listOfOptions.AppendLine("Options:");
            listOfOptions.AppendLine($"Volume {remoteController.Volume}");
            listOfOptions.AppendLine($"IsOnline {remoteController.IsOnline}");
            listOfOptions.AppendLine($"Brightness {remoteController.Brightness}");
            listOfOptions.AppendLine($"Contrast {remoteController.Contrast}");

            return listOfOptions.ToString();
        }
    }
}