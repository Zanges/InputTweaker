using JetBrains.Annotations;
using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets;

namespace InputTweaker.Logic.Initialisation
{
    public class ViGEmWrapper
    {
        public static readonly ViGEmWrapper Instance = new ViGEmWrapper(); // Singleton

        private readonly ViGEmClient _client;
        private readonly IXbox360Controller _controller;

        private ViGEmWrapper()
        {
            _client = new ViGEmClient();
            _controller = _client.CreateXbox360Controller();
            _controller.Connect();
        }

        public IXbox360Controller GetController()
        {
            return _controller;
        }
    }
}