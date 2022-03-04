using BepInEx;
using RoR2;
using System;
using UnityEngine;

namespace NoLevelupHeal
{
    [BepInPlugin("com.Moffein.NoLevelupHeal", "No Levelup Heal", "1.0.4")]
    public class NoLevelupHeal : BaseUnityPlugin
    {
        //public static BodyIndex SuperRoboBallBossBodyIndex;
        public void Awake()
        {
            /*On.RoR2.BodyCatalog.Init += (orig) =>
            {
                orig();
                SuperRoboBallBossBodyIndex = BodyCatalog.FindBodyIndex("SuperRoboBallBossBody");
            };*/

            On.RoR2.CharacterBody.RecalculateStats += (orig, self) =>
            {
                float oldLevel = self.level;
                float oldHP = self.healthComponent.health;
                float oldShield = self.healthComponent.shield;
                orig(self);
                if (self.level > oldLevel)
                {
                    if (self.teamComponent.teamIndex != TeamIndex.Player && self.healthComponent.combinedHealthFraction < 1f)
                    {
                        if (self.healthComponent.health > oldHP)
                        {
                            self.healthComponent.health = oldHP;
                        }

                        if (self.healthComponent.shield > oldShield)
                        {
                            self.healthComponent.shield = oldShield;
                        }

                        /*if (self.bodyIndex != SuperRoboBallBossBodyIndex)
                        {
                            self.healthComponent.shield = oldShield;
                        }*/
                    }
                }
            };
        }
    }
}
