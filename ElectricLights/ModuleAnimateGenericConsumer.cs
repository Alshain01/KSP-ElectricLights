using System.Text;
using UnityEngine;

namespace ElectricLights
{
    class ModuleAnimateGenericConsumer : ModuleAnimateGeneric, IModuleInfo
    {
        const float resourceRate = 1.0F;
        const string resourceType = "ElectricCharge";

        [KSPField]
        public double resourceAmount = 0.02;

        bool shutdown = false;

        public override void OnUpdate()
        {
            if (HighLogic.LoadedSceneIsFlight)
            {
                double ecRequested = resourceAmount * resourceRate * TimeWarp.deltaTime;
                if (!shutdown && Progress != 0)
                {
                    if (part.RequestResource(resourceType, ecRequested) <= 0)
                    {
                        Toggle();
                        shutdown = true;
                    }
                }
                else if (shutdown)
                {
                    if (part.RequestResource(resourceType, ecRequested) >= ecRequested)
                    {
                        Toggle();
                        shutdown = false;
                    }
                    else if (Progress != 0 && !IsMoving())
                    {
                        Toggle();
                    }
                }
            }
            base.OnUpdate();
        }

        public override string GetInfo()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine("<color=#FF8C00>Requires:</color>");
            info.Append("-Electric Charge: ").Append(resourceRate * 60 * resourceAmount).AppendLine("/min");
            return info.ToString();
        }

        public string GetModuleTitle()
        {
            return "Light";
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
