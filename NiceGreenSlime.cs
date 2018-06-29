
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
    class NiceGreenSlime : GreenSlime
    {
        public GreenSlime slime;

        public NiceGreenSlime(GreenSlime sli)
        {
            slime = sli;
        }

        public override void behaviorAtGameTick(GameTime time)
        {
            
            base.behaviorAtGameTick(time);
             
        }

        public override int takeDamage(int damage, int xTrajectory, int yTrajectory, bool isBomb, double addedPrecision)
        {
            return 0;
        }
    }
}
