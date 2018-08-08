using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using xTile;
using StardewValley.Monsters;
using Microsoft.Xna.Framework.Graphics;
using Netcode;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;


namespace SlimeMap
{
    public class SlimeMap : Mod
    {
        public Random rand = new Random();
        public NetColor colorer = new NetColor();

        public override void Entry(IModHelper helper)
        {
            // the game clears locations when loading the save, so do it after the save loads
            //SaveEvents.AfterLoad += AfterSaveLoaded;
            GameEvents.UpdateTick += this.GameEvents_OnUpdateTick;
        }
        /*private void AfterSaveLoaded(object sender, EventArgs args)
        {
            // load a map.tbin file from your mod's folder.
            Map map = this.Helper.Content.Load<Map>("SlimeHutch.tbin", ContentSource.ModFolder);
            
            // create a map asset key 
            string mapAssetKey = this.Helper.Content.GetActualAssetKey("SlimeHutch.xnb", ContentSource.ModFolder);

            // add the new location
            GameLocation location = new GameLocation(map, "SlimeHutch") { IsOutdoors = true, IsFarm = true };
            Game1.locations.Add(location);
            
        }*/

            //---------------------------------------------------------SLIME CODE BELOW------------------------------------------------------------------------------

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

                    Slime.startGlowing(Color.Cyan, false, 0.15f);
                    //this.Monitor.Log(((int)(Game1.player.Position - Slime.Position).LengthSquared()).ToString());

                    //Slimes will now greet the player
                    if (rand.Next((int)(Game1.player.Position - Slime.Position).LengthSquared()) < 5 )
                    {
                        Slime.facePlayer(Game1.player);
                        //Slime.sayHiTo(Game1.player); //Will be replaced by slimeTalkToPlayer()
                        slimeTalkToPlayer(Slime); //Will be replaced by slimeTalkToPlayer()
                        Slime.shedChunks(4, .4F);
                    }

                    


                }
            }
        }

        public void slimeTalkToPlayer(GreenSlime Slime)
        {
            String[] smart = { "All slime activities are equivalent… and… all are on principle doomed to failure.", "Nothingness lies coiled at the heart of being like a slime", "I exist, that is all, and I find it nauseating", "We the Slimes of the Slime Hutch...",
                               "The opposite of love is not hate; it’s indifference", "Life is like a bocolate of choxes", "The journey of a thousand miles begins with one step", "Once I overcome my fear of the sun, I will become the ultimate lifeform!", "I think, therfore I am",
                               "What lies beyond the horizon?", "Slimes die when they are killed", "He who fights with monsters should look to it that he himself does not become a monster. And if you gaze long into an abyss, the abyss also gazes into you"};
                                
            String[] average = { "Good day to you farmer!", "This slime hutch is very comfortable!", "I wonder what the outside world looks like!", "Do you ever wonder why where here?", "Wow the water quality is great today!", "I love being a slime!" };
            String[] dumb = {"I'm hungryyy", "The slime hutch is flat", "Where is my food" };

            /*if (Slime.maxHealth > 30)
            {
                if (Game1.timeOfDay < 1200)
                {
                    Slime.sayHiTo(Game1.player);
                }
                else if (Game1.timeOfDay < 1900)
                {
                    Slime.showTextAboveHead("Good Afternoon!", -1, 2, 3000, 0);
                }
                else
                {
                    Slime.showTextAboveHead("Good Night!", -1, 2, 3000, 0);
                }
            }
            else if(Slime.maxHealth > 20)
            {
                if (Game1.timeOfDay < 1200)
                {
                    Slime.showTextAboveHead("Foooodd", -1, 2, 3000, 0); //This should play something from the dumb list
                }  
            }
            else
            {   
                Slime.showTextAboveHead("Yes", -1, 2, 3000, 0); //This should play something from the dumb list
            } */

            var num = rand.NextDouble();

            if(num<.25)
            {
                if (Game1.timeOfDay < 1200)
                {
                    Slime.sayHiTo(Game1.player);
                }
                else if (Game1.timeOfDay < 1900)
                {
                    Slime.showTextAboveHead("Good Afternoon!", -1, 2, 3000, 0);
                }
                else
                {
                    Slime.showTextAboveHead("Good Night!", -1, 2, 3000, 0);
                }
            }
            else
            {
                //Have the slimes talk depending on hp
                //If there are 2 slimes, have them do a dialog
                Slime.showTextAboveHead("Scheme is the best programming language!", -1, 2, 3000, 0);
            }

        }

    }
}
