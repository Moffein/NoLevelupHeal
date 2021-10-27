using BepInEx;
using RoR2;
using System;
using UnityEngine;

namespace NoLevelupHeal
{
    [BepInPlugin("com.Moffein.NoLevelupHeal", "No Levelup Heal", "1.0.3")]
    public class NoLevelupHeal : BaseUnityPlugin
    {
        public void Awake()
        {
            On.RoR2.CharacterBody.RecalculateStats += (orig, self) =>
            {
                float oldLevel = self.level;
                float oldHP = self.healthComponent.health;
                float oldShield = self.healthComponent.shield;
                orig(self);
                if (self.level > oldLevel)
                {
                    if (self.teamComponent.teamIndex == TeamIndex.Monster && self.healthComponent.combinedHealthFraction < 1f)
                    {
                        self.healthComponent.health = oldHP;
                        if (self.baseNameToken != "SUPERROBOBALLBOSS_BODY_NAME")
                        {
                            self.healthComponent.shield = oldShield;
                        }
                    }
                }
            };
        }
    }
}

namespace R2API.Utils
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class ManualNetworkRegistrationAttribute : Attribute
    {
    }
}

namespace EnigmaticThunder
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class ManualNetworkRegistrationAttribute : Attribute
    {
    }
}
