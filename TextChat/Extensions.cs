using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChat
{
    using Exiled.API.Features;
    using Exiled.API.Enums;
    public static class Extensions
    {
        public static string Getcolor(this Player player)
        {
            switch (player.LeadingTeam)
            {
                case LeadingTeam.FacilityForces:
                    return "<color=##0000FF>";
                case LeadingTeam.ChaosInsurgency:
                    return "<color=#00CC00>";
                case LeadingTeam.Anomalies:
                    return "<color=#FF0000>";
                case LeadingTeam.Draw:
                    return "<color=#FFFFFF>";
                default:
                    return "";
            }
        }
    }
}
