using VoidManager.MPModChecks;

namespace LoadingScreenSkip
{
    public class VoidManagerPlugin : VoidManager.VoidPlugin
    {
        public override MultiplayerType MPType => MultiplayerType.Client;

        public override string Author => "18107, Dragon";

        public override string Description => "Skips various loading screens.";
    }
}
