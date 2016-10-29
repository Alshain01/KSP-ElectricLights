﻿using System.Text;
using UnityEngine;

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
