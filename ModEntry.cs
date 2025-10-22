using System;
using System.Collections.Generic;
using StardewModdingAPI;
using StardewValley;
using Microsoft.Xna.Framework;

namespace MyChildrenMod
{
    public class ModEntry : Mod
    {
        private List<Vector2> outsidePositions = new List<Vector2>();
        private Random random = new Random();

        public override void Entry(IModHelper helper)
        {
            outsidePositions.Add(new Vector2(10, 15)); // varanda
            outsidePositions.Add(new Vector2(11, 15));
            outsidePositions.Add(new Vector2(12, 15));
            outsidePositions.Add(new Vector2(15, 20)); // lagoa
            outsidePositions.Add(new Vector2(16, 20));
            outsidePositions.Add(new Vector2(17, 20));

            helper.Events.GameLoop.DayStarted += OnDayStarted;
        }

        private void OnDayStarted(object sender, EventArgs e)
        {
            var farm = Game1.getFarm();

            foreach (var child in Game1.getAllFarmChildren())
            {
                if (random.NextDouble() < 0.5)
                {
                    Vector2 pos = outsidePositions[random.Next(outsidePositions.Count)];
                    child.Position = new Vector2(pos.X * Game1.tileSize, pos.Y * Game1.tileSize);
                    child.FacingDirection = 2; // sentado
                    child.CurrentDialogue.Clear();
                    child.freezePause = 0;
                }
            }
        }
    }
}