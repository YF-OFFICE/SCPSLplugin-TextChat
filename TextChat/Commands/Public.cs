namespace TextChat.Commands
{
    using CommandSystem;
    using Exiled.API.Features;
    using TextChat;
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
            Collections.Message message = new Collections.Message($"<pos=-70%><size=30>[全体]{player.Nickname}:{arguments.AsEnumerable().Aggregate((a, b) => a + " " + b)}", player, DateTime.Now);
            foreach (var i in Player.List)
            {
                if (i == null) continue;
                var p = PlayerManager.GetPlayerInstance(i.ReferenceHub);
                p.SetMessage(message);
            }
            response = "发送成功";
            return true;
        }
    }
}
