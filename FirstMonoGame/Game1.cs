using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace FirstMonoGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D background;
        private Texture2D shuttle;
        private Texture2D earth;
        private Texture2D boi;

        private AnimatedSprite animatedSprite;

        private SpriteFont font;
        private int score = 0;

        private float _angle = 0;

        private TimeSpan _lastTick = TimeSpan.FromSeconds(0);
        private Vector2 _boiLocation;
            
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("stars");
            shuttle = Content.Load<Texture2D>("shuttle");
            earth = Content.Load<Texture2D>("earth");
            boi = Content.Load<Texture2D>("boi_2");
            _boiLocation = new Vector2(boi.Width * -1, 240);

            font = Content.Load<SpriteFont>("Score");

            var texture = Content.Load<Texture2D>("smiley_walk");
            animatedSprite = new AnimatedSprite(texture, 4, 4);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (gameTime.TotalGameTime.TotalSeconds - _lastTick.TotalSeconds >= 1)
            {
                score++;
                _lastTick = gameTime.TotalGameTime;
            }

            animatedSprite.Update();


            _angle += 0.01f;
            _boiLocation.X += 1.0f;

            if(_boiLocation.X >= 800 + boi.Width)
            {
                _boiLocation.X = 0 - boi.Width;
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            _spriteBatch.Draw(earth, new Vector2(400, 240), Color.White);
            _spriteBatch.Draw(shuttle, new Vector2(450, 240), Color.White);
            _spriteBatch.End();

            _spriteBatch.Begin();
            _spriteBatch.DrawString(font, $"Score: {score}", new Vector2(100, 100), Color.White);
            _spriteBatch.End();

            animatedSprite.Draw(_spriteBatch, new Vector2(400, 200));

            _spriteBatch.Begin();
            Vector2 location = new Vector2(400, 240);
            Rectangle sourceRectangle = new Rectangle(0, 0, boi.Width, boi.Height);
            Vector2 origin = new Vector2(boi.Width / 2, boi.Height / 2);
            _spriteBatch.Draw(boi, _boiLocation, sourceRectangle, Color.White, _angle, origin, 1.0f, SpriteEffects.None, 1);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
