using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using xTile;

namespace TestCustomMap 
{
    public class TestCustomMap : Mod
    {
        public override void Entry(IModHelper helper)
        {
            // the game clears locations when loading the save, so do it after the save loads
            SaveEvents.AfterLoad += AfterSaveLoaded;
        }
        private void AfterSaveLoaded(object sender, EventArgs args)
        {
            // load a map.tbin file from your mod's folder.
            Map map = this.Helper.Content.Load<Map>("Farm1.tbin", ContentSource.ModFolder);

            // create a map asset key 
            string mapAssetKey = this.Helper.Content.GetActualAssetKey("Farm1.xnb", ContentSource.ModFolder);

            // add the new location
            GameLocation location = new GameLocation(map, "Farm1") { IsOutdoors = true, IsFarm = true };
            Game1.locations.Add(location);
        }
    }
}
