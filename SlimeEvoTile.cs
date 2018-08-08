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

namespace SlimeEvoTile
{
    public class SlimeEvoTile : Mod
    {
        public override void Entry(IModHelper helper)
        {

            SaveEvents.AfterLoad += AfterSaveLoaded;
            
        }

        private void AfterSaveLoaded(object sender, EventArgs args)
        {
            var smeHutch = Game1.currentLocation as SlimeHutch;
            foreach (GreenSlime Slime in smeHutch.characters)
            {
                //This needs to check if the color is the same as the location, if it isn't, then we remove the slime
                if(Slime.currentLocation != null)
                {
                    Slime.shedChunks(4, .4F);
                    // smeHutch.characters.Remove(Slime);
                }
            }

         }
    }
}
