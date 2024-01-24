using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckshotRoulette
{
    public static class Shotgun
    {
        public static List<bool> Ammo { get; set; }
        public static void InitAmmo()
        {
            Ammo = new List<bool>(UnityEngine.Random.Range(2, 8));

            for (int i = 0; i < Ammo.Count(); i++)
            {
                Ammo[i] = UnityEngine.Random.Range(1, 2) == 1;
            }
        }
        public static void Shuffle()
        {
            Ammo.ShuffleList();
        }
        public static void Shoot(bool isSelf)
        {
            Player other;
            if (Arena.CurrentPlayer == Arena.ClassD)
            {
                other = Arena.ClassD;
            }
            else
            {
                other = Arena.Scientist;
            }

            if (isSelf)
            {
                if (Ammo[0] == true)
                {
                    other.Kill(DamageType.Shotgun);
                }
            }
            else
            {
                if (Ammo[0] == true)
                {
                    Arena.CurrentPlayer.Kill(DamageType.Shotgun);
                }
                else
                {
                    Arena.HandOverTo(other);
                }
            }

            Ammo.Remove(Ammo[0]);
        }

        public static void DisplayAmmo()
        {
            int blanks = 0;
            for (int i = 0; i < Ammo.Count(); i++)
            {
                if (Ammo[i] == false)
                {
                    blanks++;
                }
            }

            foreach (Player ply in Arena.GetPlayers())
            {
                ply.Broadcast(5, $"Loaded: {Ammo.Count() - blanks} \n Blank: {blanks}");
            }
        }
    }
}
