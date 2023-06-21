namespace TextChat.Commands
{
    using CommandSystem;
    using Exiled.API.Features;
    using System;
    using System.Linq;

    [CommandHandler(typeof(ClientCommandHandler))]
    public class Team : ICommand
    {
        public static Team Instance { get; } = new Team();

        public string Description { get; }="Team chat";

        public string Command { get; } = "c";

        public string[] Aliases { get; } = new string[] { "team","c" };
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            if (player == null)
            {
                response = "命令出错，请重新尝试";
                return false;
            }
            if(arguments.Count==0)
            {
                response = "无法发送空内容，请重新尝试";
                return false;
            }
            if (arguments.Count > Plugin.Instance.Config.MaxMessage)
            {
                response = $"消息过长，最大长度为{Plugin.Instance.Config.MaxMessage}";
                return false;
            }
            Collections.Message message =new Collections.Message($"<pos=-70%><size=30>[{player.Getcolor()}{player.Getteam()}</color>]{player.Nickname}:{arguments.AsEnumerable().Aggregate((a, b) => a + " " + b)}",player,DateTime.Now);
            foreach(Player i in Player.List.Where(p => p.LeadingTeam == player.LeadingTeam))
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
