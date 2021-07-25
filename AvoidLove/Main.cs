#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace AvoidLove
{
 
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatchs;
        int level = 0;
        Video Video, Video1;
        VideoPlayer VideoPlayer1;
        Texture2D VideoTexture1;
        Basic2d cursor;
        GamePlay gamePlay;
        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.HardwareModeSwitch = false;
        }

        protected override void Initialize()
        {
  
            Globals.screenWidth = 1920;
            Globals.screenHeight = 1080;
            graphics.PreferredBackBufferWidth = Globals.screenWidth;
            graphics.PreferredBackBufferHeight = Globals.screenHeight;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.content = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.mouse = new McMouseControl();
            Video1 = Content.Load<Video>("Start02");
            VideoPlayer1 = new VideoPlayer();
            if (level == 0) VideoPlayer1.Play(Video1);            
            Globals.SoundControl = new SoundControl();
            Globals.SoundControl.AddSong("AudioBackGround", "BackGroundMusic", 1.0f);
            Globals.SoundControl.AddSong("ting", "eatHeart", 1.0f);
            Globals.SoundControl.AddSong("endMusic", "GameOver", 1.0f);
            cursor = new Basic2d("aimCursor", new Vector2(0, 0), new Vector2(50,50));
            gamePlay = new GamePlay();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || World.ExitBtn.Update(World.offset))
                Exit();
           

            switch (level)
               
            {
                case 0:
                if (VideoPlayer1.State == MediaState.Stopped) 
                level =1;
                break;
                case 1:
                    break;
            }

            if (level == 1)
            {
                Globals.gameTime = gameTime;
                gamePlay.Update();
                Globals.mouse.Update();
                Globals.mouse.UpdateOld();
                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            if (VideoPlayer1.State != MediaState.Stopped)
            {
                VideoTexture1 = VideoPlayer1.GetTexture();
            }
            if (VideoTexture1 != null)
            Globals.spriteBatch.Draw(VideoTexture1, GraphicsDevice.Viewport.Bounds, Color.White);           
            if (level == 1)
            {
                gamePlay.Draw();
                cursor.Draw(new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), new Vector2(0, 0));
                base.Draw(gameTime);
            }
            //if (World.dead) Globals.SoundControl = new SoundControl("endMusic");
            Globals.spriteBatch.End(); 
            
        }
    }
#if WINDOWS || LINUX
   
    public static class Program
    {
       
        static void Main()
        {
            using (var game = new Main())
                game.Run();
        }
    }
#endif
}
