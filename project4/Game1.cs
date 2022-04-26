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
        Vector2 penguinPosition = new Vector2(300, 200);
        Vector2 penguinHastighet = new Vector2(2, 3);
        Rectangle penguinHitbox;

        KeyboardState tangentbord = Keyboard.GetState();

        int updatesTillNyTräff = 60;


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
            penguinHitbox = new Rectangle(300, 200, 20, 20);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            penguinHitbox.X = (int)penguinPosition.X;
            penguinHitbox.Y = (int)penguinPosition.Y;
            penguinPosition += penguinHastighet;

            if (penguinPosition.Y < 0 || penguinPosition.Y > 460)
            {
                penguinHastighet.Y *= -1;
                
            }
           
            tangentbord = Keyboard.GetState();

            if (tangentbord.IsKeyDown(Keys.Up))
            {
                rekt2.Y -= 5;
            }

            if(tangentbord.IsKeyDown(Keys.Down))
            {
                rekt2.Y += 5;
            }

            if (tangentbord.IsKeyDown(Keys.W))
            {
                rekt1.Y -= 5;
            }

            if (tangentbord.IsKeyDown(Keys.S))
            {
                rekt1.Y += 5;
            }


            updatesTillNyTräff--;

            if (penguinHitbox.Intersects(rekt1) && updatesTillNyTräff <= 30 || penguinHitbox.Intersects(rekt2) && updatesTillNyTräff <= 30)
            {
                penguinHastighet.X *= -1;
                updatesTillNyTräff = 60;
            }

            NyBoll();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.HotPink);

            spriteBatch.Begin();

            spriteBatch.Draw(paddleBild, rekt1, Color.White);
            spriteBatch.Draw(paddleBild, rekt2, Color.White);
            spriteBatch.Draw(penguinBild, penguinHitbox, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        void NyBoll()
        {
            if (penguinPosition.X < 0 || penguinPosition.X > 800)
            {
                penguinPosition.X = 300;
                penguinPosition.Y = 200;
            }
        }
    }
}
