using System;
using System.Collections.Generic;
using System.Linq;
using AutoEvent.API.Enums;
using MEC;
using PlayerRoles;
using UnityEngine;
using AutoEvent.API;
using AutoEvent.Events.Handlers;
using AutoEvent.Games.Infection;
using AutoEvent.Interfaces;
using Event = AutoEvent.Interfaces.Event;
using Exiled.API.Features;
using Player = Exiled.API.Features.Player;
using AutoEvent;

namespace BuckshotRoulette
{
    public class BuckshotRouletteEvent : Event, IEventMap, IEventSound, IExiledEvent
    {
        public override string Name { get; set; } = "Buckshot Roulette";
        public override string Description { get; set; } = "Description";
        public override string Author { get; set; } = "American Team";
        public override string CommandName { get; set; } = "br";
        public override Version Version { get; set; } = new Version(1, 0, 0);
        public SoundInfo SoundInfo { get; set; } = new SoundInfo()
        {
            SoundName = "",
            Volume = 10,
            Loop = false,
            StartAutomatically = true
        };
        public MapInfo MapInfo { get; set; } = new MapInfo()
        {
            MapName = "",
            Position = new Vector3(),
            MapRotation = new Quaternion(),
            Scale = new Vector3(1, 1, 1),
            SpawnAutomatically = true
        };

        protected override void OnStart()
        {
            for (int i = 0; i < Player.List.Count; i++)
            {
                Player.List.ElementAt(i).Role.Set((i % 2 == 0) ? RoleTypeId.Scientist : RoleTypeId.ClassD);
                i++;
            }

        }

        protected override IEnumerator<float> BroadcastStartCountdown()
        {
            for (int i = 0; i < 10; i++)
            {
                Map.Broadcast(1, $"{i}");
                yield return Timing.WaitForSeconds(1);
            }
        }

        protected override void CountdownFinished()
        {
            Arena.BringToArena();
        }

        protected override bool IsRoundDone()
        {
            return Player.List.Where(p => p.IsAlive).Any();
        }

        protected override void ProcessFrame()
        {
            
        }

        protected override void OnFinished()
        {
            if (Player.List.Where(p => !p.IsAlive && p.Role == RoleTypeId.ClassD).Any())
            {
                Map.Broadcast(5, "Scientists wins");
            }
            else
            {
                Map.Broadcast(5, "Class-D wins");
            }
        }
    }
}
