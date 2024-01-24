using Exiled.Events.EventArgs.Player;
using PluginAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckshotRoulette
{
   public class ArenaEvents
    {
        BuckshotConfig config = new BuckshotConfig();
        public void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            if (ev.Player == Arena.CurrentPlayer)
            {
                Shotgun.Shoot(ev.Pickup.Type == config.ItemSelf);
            }
        }
    }
}
