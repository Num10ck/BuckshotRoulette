using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckshotRoulette
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "American Team"; // Заменить потом
        public override string Name => "Buckshot Roulette";
        public override Version Version => new Version(1, 0, 0);

        public override void OnEnabled()
        {

        }

        public override void OnDisabled()
        {

        }
    }
}
