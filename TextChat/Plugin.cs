namespace TextChat
{
    using CommandSystem;
    using Exiled.API.Features;
    using TextChat.Commands;

    [CommandHandler(typeof(ClientCommandHandler))]
    public class Plugin : Plugin<Config>
    {
        private static readonly Plugin SingletonInstance = new Plugin();
        private Plugin() { }
        public static Plugin Instance => SingletonInstance;
        public override string Name { get; } = "TectChat";
        public override void OnEnabled()
        {
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
        }
    }
}