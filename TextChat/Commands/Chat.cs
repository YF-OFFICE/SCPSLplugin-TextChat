namespace TextChat.Commands
{
    using CommandSystem;
    using System;
    [CommandHandler(typeof(ClientCommandHandler))]
    internal class Chat: ParentCommand
    {
        public Chat() => LoadGeneratedCommands();

        public override string Command { get; }

        public override string[] Aliases { get; }

        public override string Description { get; }=string.Empty;

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(Public.Instance);
            RegisterCommand(Team.Instance);
        }
        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "c,bc";
            return false;
        }
    }
}
