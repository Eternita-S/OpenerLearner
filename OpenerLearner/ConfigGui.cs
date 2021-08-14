using Dalamud.Game.Internal.Gui.Toast;
using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenerHelper
{
    class ConfigGui : IDisposable
    {
        internal bool open = false;
        OpenerHelper p;
        internal ConfigGui(OpenerHelper p)
        {
            this.p = p;
            p.pi.UiBuilder.OnBuildUi += Draw;
        }

        public void Dispose()
        {
            p.pi.UiBuilder.OnBuildUi -= Draw;
        }

        internal void Draw()
        {
            if (!open) return;
            if (ImGui.Begin("OpenerHelper configuration", ref open))
            {
                foreach (var e in p.cfg.openerDic.Keys)
                {
                    if (ImGui.CollapsingHeader(p.pi.Data.GetExcelSheet<Lumina.Excel.GeneratedSheets.ClassJob>().GetRow(e).Name))
                    {
                        var text = string.Join(",", p.cfg.openerDic[e]) ;
                        ImGui.InputText("##opener" + e, ref text, 10000);
                        try
                        {
                            p.cfg.openerDic[e] = text.Split(',').Select(a => uint.Parse(a.Trim())).ToArray();
                        }
                        catch (Exception) { }
                    }
                }
            }
            ImGui.End();
            if (!open)
            {
                p.cfg.Save();
                p.pi.Framework.Gui.Toast.ShowQuest("Configuration saved", new QuestToastOptions() { DisplayCheckmark = true, PlaySound = true });
            }
        }
    }
}
