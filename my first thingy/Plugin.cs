using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Core.Plugins;
using Rocket.Core.Logging;

namespace AdminTools
{
    class Plugin : RocketPlugin<Config>
    {
        protected override void Load()
        {
            Logger.Log("Plugin has loaded!");
        }

        protected override void Unload()
        {
            Logger.Log("Plugin has unloaded!");
        }
    }
}
