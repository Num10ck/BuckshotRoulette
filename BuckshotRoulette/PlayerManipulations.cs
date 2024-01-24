using Exiled.API.Features;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;
using Exiled.API.Features.Roles;

namespace BuckshotRoulette
{
    public static class PlayerManipulations
    {
        public static void MoveToArena()
        {
            Player scientist = Player.List.Where(p => p.Role == RoleTypeId.Scientist).First();
            Player classD = Player.List.Where(p => p.Role == RoleTypeId.ClassD).First();

            
        }

        public static void ShotOther() 
        {

        }
    }
}
