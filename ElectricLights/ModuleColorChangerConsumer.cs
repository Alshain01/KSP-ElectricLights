using System.Text;
using UnityEngine;
using KSP.Localization;

namespace ElectricLights
{
    public class ModuleColorChangerConsumer : ModuleColorChanger, IModuleInfo
    {
        const float resourceRate = 1.0F;
        const string resourceType = "ElectricCharge";

        [KSPField]
        public double resourceAmount = 0.02;

        public override void OnUpdate()
        {
            if (HighLogic.LoadedSceneIsFlight)
                {
                if (animState)
                {
                    if (part.RequestResource(resourceType, resourceAmount * resourceRate * TimeWarp.deltaTime) <= 0)
                    {
                        SetState(false);
                    }
                }
            }
            base.OnUpdate();
        }

        public override string GetInfo()
        {
            StringBuilder info = new StringBuilder(base.GetInfo());
            info.AppendLine("<color=#FF8C00><b><<1>></b></color>").Replace("<<1>>", Localizer.GetStringByTag("#autoLOC_244332"));
            info.Append(Localizer.GetStringByTag("#autoLOC_244201"));
            info.Replace("<<1>>", Localizer.GetStringByTag("#autoLOC_501004"));
            info.Replace("<<2>>", (resourceRate * 60 * resourceAmount).ToString());
            return info.ToString();
        }

        public string GetModuleTitle()
        {
            return "#autoLOC_6003003";
        }

        public string GetPrimaryField()
        {
            return null;
        }

        public Callback<Rect> GetDrawModulePanelCallback()
        {
            return null;
        }
    }
}
