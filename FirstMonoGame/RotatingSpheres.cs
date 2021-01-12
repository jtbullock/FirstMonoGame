using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstMonoGame
{
    public class RotatingSpheres
    {
        private Texture2D blue;
        private Texture2D green;
        private Texture2D red;

        private float blueAngle = 0;
        private float greenAngle = 0;
        private float redAngle = 0;

        private float blueSpeed = -0.025f;
        private float greenSpeed = 0.017f;
        private float redSpeed = 0.022f;

        private float distance = 100;

        public void Load(ContentManager contentManager)
        {
            blue = contentManager.Load<Texture2D>("blue");
            green = contentManager.Load<Texture2D>("green");
            red = contentManager.Load<Texture2D>("red");
        }

        public void Update()
        {
            blueAngle += blueSpeed;
            greenAngle += greenSpeed;
            redAngle += redSpeed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Wow, trig was a long time ago...
            // sin = opposite / hypotenuse 
            // so sin * distance (or hypotenuse) = opposite, or y
            // cos = adjacent / hypotenuse
            // (tan = opposite / adjacent)

            Vector2 bluePosition = new Vector2(
                (float)Math.Cos(blueAngle) * distance,
                (float)Math.Sin(blueAngle) * distance);
            Vector2 greenPosition = new Vector2(
                (float)Math.Cos(greenAngle) * distance,
                (float)Math.Sin(greenAngle) * distance);
            Vector2 redPosition = new Vector2(
                (float)Math.Cos(redAngle) * distance,
                (float)Math.Sin(redAngle) * distance);

            Vector2 center = new Vector2(300, 140);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            spriteBatch.Draw(blue, center + bluePosition, Color.White);
            spriteBatch.Draw(green, center + greenPosition, Color.White);
            spriteBatch.Draw(red, center + redPosition, Color.White);
            spriteBatch.End();
        }
    }
}
