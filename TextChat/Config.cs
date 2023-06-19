using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChat
{
    public class Config:IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public bool IsPublicChat { get; set; } = true;
        public ushort Showtime { get; set; } = 5;
    }
}
