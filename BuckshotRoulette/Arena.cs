using Exiled.API.Features;
using Exiled.API.Features.Items;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckshotRoulette
{
    public static class Arena
    {
        private static Player classD;
        public static Player ClassD
        {
            get
            {
                return classD;
            }

            private set
            {
                classD = value;
                BringToArena(classD);
            }
        }


        private static Player scientist;
        public static Player Scientist
        {
            get
            {
                return scientist;
            }

            private set
            {
                scientist = value;
                BringToArena(scientist);
            }
        }


        private static Player currentPlayer;
        public static Player CurrentPlayer
        {
            get
            {
                return currentPlayer;
            }

            private set
            {
                currentPlayer = value;

            }
        }
        public static Player[] GetPlayers()
        {
            return new Player[] { ClassD, Scientist };
        }

        public static void HandOverTo(Player player)
        {
            CurrentPlayer = player;
        }

        public static void BringToArena(Player ply)
        {
            if (currentPlayer == null)
            {
                currentPlayer = ply;
            }

            if (ply.Role == RoleTypeId.ClassD)
            {
                // Teleport to classd
            }
            else if (ply.Role == RoleTypeId.Scientist)
            {
                // Tp to sci
            }
        }

        public static void ShotgunControl()
        {
            CurrentPlayer.CurrentItem = null;
            CurrentPlayer.AddItem(new ItemType[] { ItemType.KeycardZoneManager, ItemType.KeycardFacilityManager });
        }
    }
}
