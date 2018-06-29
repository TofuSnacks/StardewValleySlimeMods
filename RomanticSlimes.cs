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


namespace RomanticSlimes
{
    public class ModEntry : Mod
    {
        public Random rand = new Random();


        public override void Entry(IModHelper helper)
        {
            MenuEvents.MenuChanged += this.MenuEvents_MenuChanged;
            GameEvents.UpdateTick += this.GameEvents_OnUpdateTick;
            ControlEvents.KeyPressed += this.ControlEvents_KeyPressed;
            PlayerEvents.InventoryChanged += this.PlayerEvents_InventoryChanged;
            TimeEvents.AfterDayStarted += this.TimeEvents_AfterDayStarted;
            SaveEvents.AfterCreate += this.SaveEvents_AfterCreate;
            SaveEvents.AfterLoad += this.SaveEvents_AfterLoad;
            SaveEvents.BeforeSave += this.SaveEvents_BeforeSave;
            LocationEvents.CurrentLocationChanged += LocationEvents_CurrentLocationChanged;

        }

        private void LocationEvents_CurrentLocationChanged(object sender, EventArgsCurrentLocationChanged e)
        {
          //  if (Game1.currentLocation is SlimeHutch)
          //  {
          //      var smeHutch = Game1.currentLocation as SlimeHutch;
          //      var slimeHutch = new SlimeHutch();
          //      slimeHutch.add
          //      foreach (GreenSlime Slime in smeHutch.characters)
          //      {
         //           
          //      }
         //    }
        }

        private void SaveEvents_BeforeSave(object sender, EventArgs e)
        {

        }

        private void SaveEvents_AfterLoad(object sender, EventArgs e)
        {
            
        }

        private void SaveEvents_AfterCreate(object sender, EventArgs e)
        {
        }

        private void TimeEvents_AfterDayStarted(object sender, EventArgs e)
        {
        }

        private void PlayerEvents_InventoryChanged(object sender, EventArgsInventoryChanged e)
        {
        }

        private void ControlEvents_KeyPressed(object sender, EventArgsKeyPressed e)
        {
        }

        private void GameEvents_OnUpdateTick(object sender, EventArgs e)
        {
            if (Game1.currentLocation is SlimeHutch)
            {
                //Prevents the slimed debuff
                if (Game1.player.addedSpeed < 0)
                {
                    Game1.player.addedSpeed = 0;
                }

                var smeHutch = Game1.currentLocation as SlimeHutch;
                //Prevents the player's hp from falling
                Game1.player.health = Game1.player.maxHealth;




                foreach (GreenSlime Slime in smeHutch.characters)
                {

                    //Prevents the slimes from agroing the player, if it fails, it will prevent the slimes from jumping to the player
                    Slime.IsWalkingTowardPlayer = false;
                    Slime.timeSinceLastJump = -9999999;

                    //Allows the player to pass through slimes
                    Slime.farmerPassesThrough = true;
                    //Allows all slimes to be fully grown when spawned (Needs testing, works sometimes???)
                    //Slime.ageUntilFullGrown = -1;

                      
                    //this.Monitor.Log(((int)(Game1.player.Position - Slime.Position).LengthSquared()).ToString());

                    //Slimes will now greet the player
                    if (rand.Next((int)(Game1.player.Position - Slime.Position).LengthSquared()) < 5 && Game1.timeOfDay <1200)
                    {
                        Slime.facePlayer(Game1.player);
                        Slime.sayHiTo(Game1.player);
                        Slime.shedChunks(4,.4F);
                    }
                }
            }
        }



        private void MenuEvents_MenuChanged(object sender, EventArgsClickableMenuChanged e)
        {
        }
    }
}




