using System.Text;
using UnityEngine;
using KSP.Localization;

namespace ElectricLights
{
    class ModuleColorChangerConsumer : ModuleColorChanger, IModuleInfo
    {
        const float resourceRate = 1.0F;
        const string resourceType = "ElectricCharge";

        [KSPField]
        public double resourceAmount = 0.02;

        public override void OnUpdate()
        {
            if (HighLogic.LoadedSceneIsFlight && animState && part.RequestResource(resourceType, resourceAmount * resourceRate * TimeWarp.deltaTime) <= 0)
                SetState(false);

            base.OnUpdate();
        }

        public override string GetInfo()
        {
            StringBuilder info = new StringBuilder(base.GetInfo());
            info.AppendLine(Localizer.Format("<color=#FF8C00><b><<1>></b></color>", Localizer.GetStringByTag("#autoLOC_244332")));
            info.Append(Localizer.Format(Localizer.GetStringByTag("#autoLOC_244201"), Localizer.GetStringByTag("#autoLOC_501004"), (resourceRate * 60 * resourceAmount).ToString()));
            return info.ToString();
        }

        public string GetModuleTitle()
        {
            return Localizer.GetStringByTag("#autoLOC_6003003");
        }

        public override string GetModuleDisplayName()
        {
            return Localizer.GetStringByTag("#autoLOC_6003003");
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
