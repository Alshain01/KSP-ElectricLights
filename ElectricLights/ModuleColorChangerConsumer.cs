namespace ElectricLights
{
    public class ModuleColorChangerConsumer : ModuleColorChanger
    {
        [KSPField]
        public float resourceRate = 1.0F;
        [KSPField]
        public double resourceAmount = 0.02;
        [KSPField]
        public string resourceType = "ElectricCharge";

        public override void OnUpdate()
        {
            if (HighLogic.LoadedSceneIsFlight)
                {
                if (this.animState)
                {
                    if (this.part.RequestResource(resourceType, resourceAmount * resourceRate * TimeWarp.deltaTime) <= 0)
                    {
                        this.SetState(false);
                    }
                }
            }
            base.OnUpdate();
        }
    }
}
