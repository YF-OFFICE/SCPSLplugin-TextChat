namespace TextChat
{
    using Exiled.API.Interfaces;
    public class Config:IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public bool IsPublicChat { get; set; } = true;
        public ushort Showtime { get; set; } = 5;
        public ushort MaxMessage { get; set; } = 25;
    }
}
