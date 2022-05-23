using Dalamud.Configuration;
using Dalamud.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenerHelper
{
    [Serializable]
    class Configuration : IPluginConfiguration
    {
        public int Version { get; set; } = 1;

        public Dictionary<byte, uint[]> openerDic = new Dictionary<byte, uint[]>();
        public Dictionary<byte, uint[]> rotationDic = new Dictionary<byte, uint[]>();


        public void Save()
        {
            Svc.PluginInterface.SavePluginConfig(this);
        }

    }
}
