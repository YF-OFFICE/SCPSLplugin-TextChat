namespace TextChat
{
    using Exiled.API.Features;
    using ServerHandlers = Exiled.Events.Handlers.Server;
    public class Plugin : Plugin<Config>
    {
        private static readonly Plugin SingletonInstance = new Plugin();
        private Plugin() { }
        public static Plugin Instance => SingletonInstance;
        public override string Name { get; } = "TextChat";
        public override void OnEnabled()
        {
            EventHandlers eventHandlers = new EventHandlers();
            ServerHandlers.RoundStarted += eventHandlers.OnRoundstarted;
            ServerHandlers.RestartingRound += eventHandlers.RestartingRound;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            EventHandlers eventHandlers = new EventHandlers();
            ServerHandlers.RoundStarted -= eventHandlers.OnRoundstarted;
            ServerHandlers.RestartingRound -= eventHandlers.RestartingRound;
            base.OnDisabled();
        }
    }
}