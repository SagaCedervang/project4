using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace project4
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        SpriteBatch spriteBatch;

        Texture2D paddleBild;
        Rectangle rekt1 = new Rectangle(100, 200, 10, 80);
        Rectangle rekt2 = new Rectangle(685, 200, 10, 80);

        Texture2D penguinBild;
        Rectangle penguinrekt = new Rectangle(300, 200, 20, 20);



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
            spriteBatch = new SpriteBatch(GraphicsDevice);

            paddleBild = Content.Load<Texture2D>("paddle");
            penguinBild = Content.Load<Texture2D>("penguin");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            penguinrekt.X += 1;
            penguinrekt.Y += 2;

            if(penguinrekt.Y > 300 || penguinrekt.Y < 0)
            {
                penguinrekt.Y *= -1;
            }





            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.HotPink);

            spriteBatch.Begin();

            spriteBatch.Draw(paddleBild, rekt1, Color.White);
            spriteBatch.Draw(paddleBild, rekt2, Color.White);
            spriteBatch.Draw(penguinBild, penguinrekt, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
