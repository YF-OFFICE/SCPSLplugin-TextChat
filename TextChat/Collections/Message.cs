namespace TextChat.Collections
{
    using Exiled.API.Enums;
    using System;
    public class Message
    {
        public Message() { }
        public Message(string text, Exiled.API.Features.Player messageSender, DateTime timestamp)
        {
            Text = text;
            NickName = messageSender.Nickname;
            LeadingTeam = messageSender.LeadingTeam;
            Timestamp = timestamp;
        }
        public string Text { get; private set; }
        public string NickName { get; private set;}
        public LeadingTeam LeadingTeam { get; private set; }
        public DateTime Timestamp { get; private set; }
        public bool IsOnline()
        {
            if(DateTime.Now>Timestamp.AddSeconds(Plugin.Instance.Config.Showtime)) return false;
            else return true;
        }
    }
}
