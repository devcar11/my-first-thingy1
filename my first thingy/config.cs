using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;

namespace AdminTools
{
    public class Config : IRocketPluginConfiguration
    {
        public string example;
        public void LoadDefaults()
        {
            example = "example";             
        }
    }
}
