namespace TextChat.Commands
{
    using CommandSystem;
    using Exiled.API.Features;
    using System;
    using System.Collections.Generic;
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
            Broadcast broadcast=new Broadcast($"[{player.Getcolor()}{player.LeadingTeam}</color>]"+player.Nickname + ":" + arguments.AsEnumerable().Aggregate((a, b) => a + " " + b), Plugin.Instance.Config.Showtime);
            foreach(Player p in Player.List.Where(p => p.LeadingTeam == player.LeadingTeam))
            {
                if (p == null) continue;
                p.Broadcast(broadcast);
            }
            response = "发送成功";
            return true;
        }
    }
}
