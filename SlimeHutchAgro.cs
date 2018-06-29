using System;

using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Tools;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using StardewValley.Monsters;
using StardewValley.Characters;
using StardewValley.Objects;


namespace SlimeHutchAgro
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            GameEvents.UpdateTick += this.GameEvents_OnUpdateTick;
        }

        private void GameEvents_OnUpdateTick(object sender, EventArgs e)
        {
            if (Game1.currentLocation is SlimeHutch)
            {
                //Prevents the slimed debuff from slowing the player down, if the player has move speed buffs, it will preserve them 
                if (Game1.player.addedSpeed < 0)
                {
                    Game1.player.addedSpeed = 0;
                }

                //Prevents the player's hp from falling while in the hutch
                Game1.player.health = Game1.player.maxHealth;

                               
                foreach (GreenSlime Slime in Game1.currentLocation.characters)
                {
                    //Prevents the slimes from agroing the player, if it fails, it will prevent the slimes from jumping to the player 
                    Slime.IsWalkingTowardPlayer = false;
                    Slime.timeSinceLastJump = -9999999;

                    //Allows the player to pass through slimes
                    Slime.farmerPassesThrough = true;
                }
            }
        }
    }
}


