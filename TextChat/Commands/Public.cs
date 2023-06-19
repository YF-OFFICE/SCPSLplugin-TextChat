namespace TextChat.Commands
{
    using CommandSystem;
    using Exiled.API.Features;
    using System;
    using System.Linq;

    [CommandHandler(typeof(ClientCommandHandler))]
    public class Public : ICommand
    {
        public static Public Instance { get; } = new Public();

        public string Description { get; } = "Public chat";

        public string Command { get; } = "bc";

        public string[] Aliases { get; } = new string[] { "public","bc" };
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            if (player == null)
            {
                response = "命令出错，请重新尝试";
                return false;
            }
            if (arguments.Count == 0)
            {
                response = "无法发送空内容，请重新尝试";
                return false;
            }
            Broadcast broadcast = new Broadcast("\n\n<pos=-40%><size=30>[全体]" + player.Nickname + ":" + arguments.AsEnumerable().Aggregate((a, b) => a + " " + b), Plugin.Instance.Config.Showtime);
            Map.Broadcast(broadcast);
            response = "发送成功";
            return true;
        }
    }
}
