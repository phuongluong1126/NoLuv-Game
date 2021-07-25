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
    public class World
    {
        //khai bao
        #region 
        public static Vector2 offset;
        public mainChar mainChar;
        public backGround backGround, backGroundEndGame, GameOver01, GameOver02, GameOver03;
        public Basic2d power, power01, power02, power03, power04, powerfull01, powerfull02, powerfull03, powerfull04,
                        score00, score01, score02, score03, score04, score05, score06, score07, score08, score09,
                        score052nd, score002nd, score003rd,  score013rd, score023rd, score033rd, score043rd, score053rd, score063rd, score073rd, score083rd, score093rd,
                        score014th;
        public Basic2d scoreE00, scoreE05, scoreE10, scoreE11, scoreE12, scoreE13, scoreE14, scoreE15, scoreE16, scoreE17, scoreE18, scoreE19,
                       scoreE30, scoreE31, scoreE32, scoreE33, scoreE34, scoreE35, scoreE36, scoreE37, scoreE38, scoreE39,
                       scoreE20, scoreE21, scoreE22, scoreE23, scoreE24, scoreE25, scoreE26, scoreE27, scoreE28, scoreE29,
                       scoreE41;
        public static MobTop MobTops;
        public static MobDown MobDowns;
        public static MobLeft MobLefts;
        public static MobRight MobRights;       
        public List<Projectile2d> Projectile2Ds = new List<Projectile2d>();
        public List<Projectile2dforMainChar> projectile2DforMainChars = new List<Projectile2dforMainChar>();
        public SpriteFont tester;
        public HealthBar TopBar, DownBar, LeftBar, RightBar ;
        PassObject ResetWorld;
        public Basic2d ResetScript, ExitScript;
        public static Button2d ResetBtn, ExitBtn; 
        public float maincharCycle, powerCycle;
        public static bool isPower;
        bool flat = false;
        public static bool dead = false;
        int textCycle = 0;
        int E0 = 0;
        int E1 = 0;
        int E2 = 0;
        int E3 = 0;
        #endregion

        //world
        #region 
        public World(PassObject RESETWORLD)
        {
            ResetWorld = RESETWORLD;
            Random rand = new Random();
            offset = new Vector2(0, 0);
            ResetBtn = new Button2d("ResetButton", new Vector2(450, 750),new Vector2(200,200),ResetWorld, null);
            ExitBtn = new Button2d("ExitButton", new Vector2(1480, 750), new Vector2(200, 200), ResetWorld, null);
            ResetScript = new Basic2d("ResetScript", new Vector2(500, 850), new Vector2(400, 200));
            ExitScript = new Basic2d("ExitScript", new Vector2(1450, 850), new Vector2(400, 200));
            mainChar = new mainChar("mainChar", new Vector2(Globals.screenWidth/2,Globals.screenHeight/2), new Vector2(400, 400));
            backGround = new backGround("BackGround", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2), new Vector2(Globals.screenWidth, Globals.screenHeight));          
            GameGlobals.ShootBulletTop = ShootBulletTop;
            MobTops = new MobTop("MobTop", new Vector2(rand.Next(400,1500), 110), new Vector2(300, 300));             
            GameGlobals.ShootBulletDown = ShootBulletDown;            
            MobDowns = new MobDown("MobDown", new Vector2(rand.Next(400,1500), 1000), new Vector2(400, 400));
            GameGlobals.ShootBulletLeft = ShootBulletLeft;
            MobLefts = new MobLeft("MobLeft", new Vector2(250, rand.Next(350, 800)), new Vector2(400, 400));
            GameGlobals.ShootBulletRight = ShootBulletRight;
            MobRights = new MobRight("MobRight", new Vector2(1700, rand.Next(350, 800)), new Vector2(400, 400));
            TopBar = new HealthBar("TopBar", new Vector2(0, 0), new Vector2(400, 175));
            DownBar = new HealthBar("DownBar", new Vector2(0, 0), new Vector2(400, 175));
            LeftBar = new HealthBar("LeftBar", new Vector2(0, 0), new Vector2(400, 175));
            RightBar = new HealthBar("RightBar", new Vector2(0, 0), new Vector2(400, 175));
            GameGlobals.ShootBulletMainChar = ShootBulletMainChar;
            tester = Globals.content.Load<SpriteFont>("MyFont");
            power = new Basic2d("power", new Vector2(100, 100), new Vector2(250, 250));
            power01 = new Basic2d("power01", new Vector2(100, 100), new Vector2(250, 250));
            power02 = new Basic2d("power02", new Vector2(100, 100), new Vector2(250, 250));
            power03 = new Basic2d("power03", new Vector2(100, 100), new Vector2(250, 250));
            power04 = new Basic2d("power04", new Vector2(100, 100), new Vector2(250, 250));
            powerfull01 = new Basic2d("powerfull01", new Vector2(100, 100), new Vector2(250, 250));
            powerfull02 = new Basic2d("powerfull02", new Vector2(100, 100), new Vector2(250, 250));
            powerfull03 = new Basic2d("powerfull03", new Vector2(100, 100), new Vector2(250, 250));
            powerfull04 = new Basic2d("powerfull04", new Vector2(100, 100), new Vector2(250, 250));
            backGroundEndGame = new backGround("BackGroundEndGame", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2), new Vector2(Globals.screenWidth, Globals.screenHeight));
            GameOver01 = new backGround("GameOver01", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2), new Vector2(Globals.screenWidth, Globals.screenHeight));
            GameOver02 = new backGround("GameOver02", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2), new Vector2(Globals.screenWidth, Globals.screenHeight));
            GameOver03 = new backGround("GameOver03", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2), new Vector2(Globals.screenWidth, Globals.screenHeight));
            score00 = new Basic2d("00",new Vector2(1860, 80), new Vector2(100,100));
            score002nd = new Basic2d("00", new Vector2(1800, 80), new Vector2(100, 100));
            score003rd = new Basic2d("00", new Vector2(1740, 80), new Vector2(100, 100));
            score01 = new Basic2d("01", new Vector2(1800, 80), new Vector2(100, 100));
            score02 = new Basic2d("02", new Vector2(1800, 80), new Vector2(100, 100));
            score03 = new Basic2d("03", new Vector2(1800, 80), new Vector2(100, 100));
            score04 = new Basic2d("04", new Vector2(1800, 80), new Vector2(100, 100));
            score05 = new Basic2d("05", new Vector2(1860, 80), new Vector2(100, 100));
            score052nd = new Basic2d("05", new Vector2(1800, 80), new Vector2(100, 100));
            score06 = new Basic2d("06", new Vector2(1800, 80), new Vector2(100, 100));
            score07 = new Basic2d("07", new Vector2(1800, 80), new Vector2(100, 100));
            score08 = new Basic2d("08", new Vector2(1800, 80), new Vector2(100, 100));
            score09 = new Basic2d("09", new Vector2(1800, 80), new Vector2(100, 100));
            score013rd = new Basic2d("01", new Vector2(1740, 80), new Vector2(100, 100));
            score023rd = new Basic2d("02", new Vector2(1740, 80), new Vector2(100, 100));
            score033rd = new Basic2d("03", new Vector2(1740, 80), new Vector2(100, 100));
            score043rd = new Basic2d("04", new Vector2(1740, 80), new Vector2(100, 100));
            score053rd = new Basic2d("05", new Vector2(1740, 80), new Vector2(100, 100));
            score063rd = new Basic2d("06", new Vector2(1740, 80), new Vector2(100, 100));
            score073rd = new Basic2d("07", new Vector2(1740, 80), new Vector2(100, 100));
            score083rd = new Basic2d("08", new Vector2(1740, 80), new Vector2(100, 100));
            score093rd = new Basic2d("09", new Vector2(1740, 80), new Vector2(100, 100));
            score014th = new Basic2d("01", new Vector2(1680, 80), new Vector2(100, 100));

            // score end
            scoreE00 = new Basic2d("00", new Vector2(1080, 150),new Vector2(200, 200));
            scoreE05 = new Basic2d("05", new Vector2(1080, 150), new Vector2(200, 200));
            scoreE10 = new Basic2d("00", new Vector2(960, 150), new Vector2(200, 200));
            scoreE11 = new Basic2d("01", new Vector2(960, 150), new Vector2(200, 200));
            scoreE12 = new Basic2d("02", new Vector2(960, 150), new Vector2(200, 200));
            scoreE13 = new Basic2d("03", new Vector2(960, 150), new Vector2(200, 200));
            scoreE14 = new Basic2d("04", new Vector2(960, 150), new Vector2(200, 200));
            scoreE15 = new Basic2d("05", new Vector2(960, 150), new Vector2(200, 200));
            scoreE16 = new Basic2d("06", new Vector2(960, 150), new Vector2(200, 200));
            scoreE17 = new Basic2d("07", new Vector2(960, 150), new Vector2(200, 200));
            scoreE18 = new Basic2d("08", new Vector2(960, 150), new Vector2(200, 200));
            scoreE19 = new Basic2d("09", new Vector2(960, 150), new Vector2(200, 200));
            scoreE20 = new Basic2d("00", new Vector2(840, 150), new Vector2(200, 200));
            scoreE21 = new Basic2d("01", new Vector2(840, 150), new Vector2(200, 200));
            scoreE22 = new Basic2d("02", new Vector2(840, 150), new Vector2(200, 200));
            scoreE23 = new Basic2d("03", new Vector2(840, 150), new Vector2(200, 200));
            scoreE24 = new Basic2d("04", new Vector2(840, 150), new Vector2(200, 200));
            scoreE25 = new Basic2d("05", new Vector2(840, 150), new Vector2(200, 200));
            scoreE26 = new Basic2d("06", new Vector2(840, 150), new Vector2(200, 200));
            scoreE27 = new Basic2d("07", new Vector2(840, 150), new Vector2(200, 200));
            scoreE28 = new Basic2d("08", new Vector2(840, 150), new Vector2(200, 200));
            scoreE29 = new Basic2d("09", new Vector2(840, 150), new Vector2(200, 200));
            scoreE31 = new Basic2d("00", new Vector2(840, 150), new Vector2(200, 200));
           
            maincharCycle = 0;
            powerCycle = 0;
            isPower=false;

        }
        #endregion

        //ShootBullet
        #region 
        public virtual void ShootBulletTop(object i)
        {
            if (MobTops.bulletDelay > 0)
                MobTops.bulletDelay--;
            if (MobTops.bulletDelay <= 0)
            {
                Projectile2Ds.Add((Projectile2d)i);
            }
            if (MobTops.bulletDelay == 0)
                MobTops.bulletDelay = 80;
        }

        public virtual void ShootBulletDown(object i)
        {
            if (MobDowns.bulletDelay > 0)
                MobDowns.bulletDelay--;
            if (MobDowns.bulletDelay <= 0)
            {
                Projectile2Ds.Add((Projectile2d)i);
            }
            if (MobDowns.bulletDelay == 0)
                MobDowns.bulletDelay = 80;
        }

        public virtual void ShootBulletLeft(object i)
        {
            if (MobLefts.bulletDelay > 0)
                MobLefts.bulletDelay--;
            if (MobLefts.bulletDelay <= 0)
            {
                Projectile2Ds.Add((Projectile2d)i);
            }
            if (MobLefts.bulletDelay == 0)
                MobLefts.bulletDelay = 80;
        }

        public virtual void ShootBulletRight(object i)
        {
            if (MobRights.bulletDelay > 0)
                MobRights.bulletDelay--;
            if (MobRights.bulletDelay <= 0)
            {
                Projectile2Ds.Add((Projectile2d)i);
            }
            if (MobRights.bulletDelay == 0)
                MobRights.bulletDelay = 80;
        }
        public virtual void ShootBulletMainChar(object i)
        {
            if (mainChar.bulletDelay > 0)
                mainChar.bulletDelay--;
            if (mainChar.bulletDelay <= 0)
            {
                projectile2DforMainChars.Add((Projectile2dforMainChar)i);
            }
            if (mainChar.bulletDelay == 0)
                mainChar.bulletDelay = 10;
        }
        #endregion

        public virtual void Update()
        {
            Globals.SoundControl.PlaySong("BackGroundMusic");
            mainChar.Update();           
            GameGlobals.gameTimePassed++;
            maincharCycle++;
            powerCycle++;

            //Mob xuat hien
            MobTops.Update();
            if (GameGlobals.gameTimePassed >= 1000)
                MobDowns.Update();
            if (GameGlobals.gameTimePassed >= 1500)
                MobLefts.Update();
            if (GameGlobals.gameTimePassed >= 2200)
                MobRights.Update();
            TopBar.Update(MobTops.Current, MobTops.Full);
            DownBar.Update(MobDowns.Current, MobDowns.Full);
            LeftBar.Update(MobLefts.Current, MobLefts.Full);
            RightBar.Update(MobRights.Current, MobRights.Full);
            if (MobDowns.Current < 42 && MobTops.Current < 42 && MobLefts.Current < 42 && MobRights.Current < 42)
            {
                for (int i = 0; i < Projectile2Ds.Count; i++)
                {
                    Projectile2Ds[i].Update(offset, mainChar, MobTops, MobDowns, MobLefts, MobRights);
                    if (Projectile2Ds[i].done)
                    {
                        Projectile2Ds.RemoveAt(i);
                        i--;
                    }
                }
                if (isPower)
                for (int i = 0; i < projectile2DforMainChars.Count; i++)
                {
                    projectile2DforMainChars[i].Update(offset, MobTops, MobDowns, MobLefts, MobRights);
                    if (projectile2DforMainChars[i].done)
                    {
                        projectile2DforMainChars.RemoveAt(i);
                        i--;
                    }
                }
            }
            if (MobDowns.Current >= 42 || MobTops.Current >= 42 || MobLefts.Current >= 42 || MobRights.Current >= 42)
            {               
                KeyboardState keyboardState = Keyboard.GetState();
                dead = true;
                Globals.SoundControl.StopSong("BackGroundMusic");
                Globals.SoundControl.PlaySong("GameOver");
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    GameGlobals.gameTimePassed = 0;
                    GameGlobals.score = 0;
                    ResetWorld(null);
                }
                if (ResetBtn.Update(offset))
                {
                    GameGlobals.gameTimePassed = 0;
                    GameGlobals.score = 0;
                    ResetWorld(null);
                }               
            }
          

            // animation for mainChar
            #region 
            if (maincharCycle <= 20)
                mainChar.myModel = Globals.content.Load<Texture2D>("mainCharOpenEye");
            if (maincharCycle > 20 && maincharCycle <= 40)
                mainChar.myModel = Globals.content.Load<Texture2D>("mainChar04");
            if (maincharCycle > 40 && maincharCycle <= 50)
                mainChar.myModel = Globals.content.Load<Texture2D>("mainCharOpenEye");
            if (maincharCycle > 50 && maincharCycle <= 60)
                mainChar.myModel = Globals.content.Load<Texture2D>("mainChar");
            if (maincharCycle > 60 && maincharCycle <= 70)
            {
                mainChar.myModel = Globals.content.Load<Texture2D>("mainChar02");
                //powerfull01.myModel = Globals.content.Load<Texture2D>("powerfull01");
            }
                if (maincharCycle > 70 && maincharCycle <= 80)
            {
                mainChar.myModel = Globals.content.Load<Texture2D>("mainChar");               
                if (maincharCycle == 80) maincharCycle = 0;
            }
            #endregion

            CountScore();
        }
        public void CountScore()
        {
            if ((GameGlobals.gameTimePassed % 50 == 0) && (MobDowns.Current < 42 && MobTops.Current < 42 && MobLefts.Current < 42 && MobRights.Current < 42))
                GameGlobals.score += 5;
        }
        public virtual void Draw(Vector2 OFFSET)
        {

            if (MobDowns.Current < 42 && MobTops.Current < 42 && MobLefts.Current < 42 && MobRights.Current < 42)
            {
                backGround.Draw(OFFSET);
                mainChar.Draw(OFFSET);

                // power
                #region 
                power.Draw(OFFSET);
                if (powerCycle >= 500)
                {
                    power01.Draw(OFFSET);
                }
                if (powerCycle >= 700)
                {
                    power02.Draw(OFFSET);
                }
                if (powerCycle >= 900)
                {
                    power03.Draw(OFFSET);
                }
                if (powerCycle >= 1100)
                {
                    power04.Draw(OFFSET);
                }
                if (powerCycle == 1300) flat = true;
                if (flat)
                {
                    if (powerCycle >= 1300)
                    {
                        powerfull01.Draw(OFFSET);
                    }
                    if (powerCycle >= 1320)
                    {
                        powerfull02.Draw(OFFSET);
                    }
                    if (powerCycle >= 1340)
                    {
                        powerfull03.Draw(OFFSET);
                    }
                    if (powerCycle >= 1360)
                    {
                        powerfull04.Draw(OFFSET);
                        isPower = true;
                        powerCycle = 1320;
                    }
                }
                if (GameGlobals.gameTimePassed % 1670 == 0 && powerCycle > 1300) { isPower = false; powerCycle = 0; }
                    if (GameGlobals.gameTimePassed % 1700 ==0 && powerCycle >1300)
                { flat = false; }
                #endregion

                // draw Mobs
                MobTops.Draw(OFFSET);
                TopBar.Draw(new Vector2(MobTops.pos.X - 70, MobTops.pos.Y - 160));
                if (GameGlobals.gameTimePassed >= 1000)
                {
                    MobDowns.Draw(OFFSET);
                    DownBar.Draw(new Vector2(MobDowns.pos.X - 100, MobDowns.pos.Y - 200));

                    if (GameGlobals.gameTimePassed >= 1500)
                    {
                        MobLefts.Draw(OFFSET);
                        LeftBar.Draw(new Vector2(MobLefts.pos.X - 70, MobLefts.pos.Y - 190));
                    }

                    if (GameGlobals.gameTimePassed >= 2200)
                    {
                        MobRights.Draw(OFFSET);
                        RightBar.Draw(new Vector2(MobRights.pos.X - 70, MobRights.pos.Y - 165));
                    } 
                }

                //draw projectile
                for (int i = 0; i < Projectile2Ds.Count; i++)
                    Projectile2Ds[i].Draw(OFFSET);
                if (isPower)
                    for (int i = 0; i < projectile2DforMainChars.Count; i++)
                    projectile2DforMainChars[i].Draw(OFFSET);
            }
            else
            {
                //GameGlobals.score = GameGlobals.score + 5;
                if (textCycle >= 0)
                {
                    backGroundEndGame.Draw(OFFSET);
                    textCycle++;
                }
                if (textCycle >= 25)
                {
                    GameOver01.Draw(OFFSET);
                    textCycle++;
                }
                if (textCycle >= 50)
                {
                    GameOver02.Draw(OFFSET);
                    textCycle++;
                }
                if (textCycle >= 75)
                {
                    GameOver03.Draw(OFFSET);
                    textCycle ++;
                }
                if (textCycle >= 90) textCycle = 0;
                ResetBtn.Draw(OFFSET);
                ExitBtn.Draw(OFFSET);
                if (GameGlobals.score != 0)
                {
                    E0 = GameGlobals.score % 10;
                    GameGlobals.score = GameGlobals.score / 10;
                    E1 = GameGlobals.score % 10;
                    GameGlobals.score = GameGlobals.score / 10;
                    E2 = GameGlobals.score % 10;
                    GameGlobals.score = GameGlobals.score / 10;
                    E3 = GameGlobals.score % 10;
                    GameGlobals.score = GameGlobals.score / 10;
                }
                if (E0 == 5) scoreE00.Draw(OFFSET);
                if (E0 == 0) scoreE00.Draw(OFFSET);
                if (E1 == 0) scoreE10.Draw(OFFSET);
                if (E1 == 1) scoreE11.Draw(OFFSET);
                if (E1 == 2) scoreE12.Draw(OFFSET);
                if (E1 == 3) scoreE13.Draw(OFFSET);
                if (E1 == 4) scoreE14.Draw(OFFSET);
                if (E1 == 5) scoreE15.Draw(OFFSET);
                if (E1 == 6) scoreE16.Draw(OFFSET);
                if (E1 == 7) scoreE17.Draw(OFFSET);
                if (E1 == 8) scoreE18.Draw(OFFSET);
                if (E1 == 9) scoreE19.Draw(OFFSET);
                if (E2 == 0) scoreE20.Draw(OFFSET);
                if (E2 == 1) scoreE21.Draw(OFFSET);
                if (E2 == 2) scoreE22.Draw(OFFSET);
                if (E2 == 3) scoreE23.Draw(OFFSET);
                if (E2 == 4) scoreE24.Draw(OFFSET);
                if (E2 == 5) scoreE25.Draw(OFFSET);
                if (E2 == 6) scoreE26.Draw(OFFSET);
                if (E2 == 7) scoreE27.Draw(OFFSET);
                if (E2 == 8) scoreE28.Draw(OFFSET);
                if (E2 == 9) scoreE29.Draw(OFFSET);
                //ResetScript.Draw(OFFSET);
                //ExitScript.Draw(OFFSET);
                //if (GameGlobals.score % 10 == 0) score00.Draw(OFFSET); else score05.Draw(OFFSET);
            }
            Globals.spriteBatch.DrawString(tester, GameGlobals.score.ToString(), new Vector2(1000, 1000), Color.Red, 0, OFFSET, 2, new SpriteEffects(), 0);
           
            // countscore
            #region 
            if (GameGlobals.score!=0 && MobDowns.Current < 42 && MobTops.Current < 42 && MobLefts.Current < 42 && MobRights.Current < 42)
            {

                if (GameGlobals.score % 5 == 0)  score05.Draw(OFFSET);
                if (GameGlobals.score % 10 == 0) score00.Draw(OFFSET);
                if (GameGlobals.score >= 10) score01.Draw(OFFSET);
                if (GameGlobals.score >= 20) score02.Draw(OFFSET);
                if (GameGlobals.score >= 30) score03.Draw(OFFSET);
                if (GameGlobals.score >= 40) score04.Draw(OFFSET);
                if (GameGlobals.score >= 50) score052nd.Draw(OFFSET);
                if (GameGlobals.score >= 60) score06.Draw(OFFSET);
                if (GameGlobals.score >= 70) score07.Draw(OFFSET);
                if (GameGlobals.score >= 80) score08.Draw(OFFSET);
                if (GameGlobals.score >= 90) score09.Draw(OFFSET);
                if (GameGlobals.score >= 100)
                {
                    score013rd.Draw(OFFSET);
                    if (GameGlobals.score <110) score002nd.Draw(OFFSET);
                    if (GameGlobals.score >= 110) score01.Draw(OFFSET);
                    if (GameGlobals.score >= 120) score02.Draw(OFFSET);
                    if (GameGlobals.score >= 130) score03.Draw(OFFSET);
                    if (GameGlobals.score >= 140) score04.Draw(OFFSET);
                    if (GameGlobals.score >= 150) score052nd.Draw(OFFSET);
                    if (GameGlobals.score >= 160) score06.Draw(OFFSET);
                    if (GameGlobals.score >= 170) score07.Draw(OFFSET);
                    if (GameGlobals.score >= 180) score08.Draw(OFFSET);
                    if (GameGlobals.score >= 190) score09.Draw(OFFSET);                  
                }
                if (GameGlobals.score >= 200)
                {
                    score023rd.Draw(OFFSET);
                    if (GameGlobals.score < 210) score002nd.Draw(OFFSET);
                    if (GameGlobals.score >= 210) score01.Draw(OFFSET);
                    if (GameGlobals.score >= 220) score02.Draw(OFFSET);
                    if (GameGlobals.score >= 230) score03.Draw(OFFSET);
                    if (GameGlobals.score >= 240) score04.Draw(OFFSET);
                    if (GameGlobals.score >= 250) score052nd.Draw(OFFSET);
                    if (GameGlobals.score >= 260) score06.Draw(OFFSET);
                    if (GameGlobals.score >= 270) score07.Draw(OFFSET);
                    if (GameGlobals.score >= 280) score08.Draw(OFFSET);
                    if (GameGlobals.score >= 290) score09.Draw(OFFSET);
                }
                if (GameGlobals.score >= 300)
                {
                    score033rd.Draw(OFFSET);
                    if (GameGlobals.score < 310) score002nd.Draw(OFFSET);
                    if (GameGlobals.score >= 310) score01.Draw(OFFSET);
                    if (GameGlobals.score >= 320) score02.Draw(OFFSET);
                    if (GameGlobals.score >= 330) score03.Draw(OFFSET);
                    if (GameGlobals.score >= 340) score04.Draw(OFFSET);
                    if (GameGlobals.score >= 350) score052nd.Draw(OFFSET);
                    if (GameGlobals.score >= 360) score06.Draw(OFFSET);
                    if (GameGlobals.score >= 370) score07.Draw(OFFSET);
                    if (GameGlobals.score >= 380) score08.Draw(OFFSET);
                    if (GameGlobals.score >= 390) score09.Draw(OFFSET);
                }

                if (GameGlobals.score >= 400)
                {
                    score043rd.Draw(OFFSET);
                    if (GameGlobals.score < 410) score002nd.Draw(OFFSET);
                    if (GameGlobals.score >= 410) score01.Draw(OFFSET);
                    if (GameGlobals.score >= 420) score02.Draw(OFFSET);
                    if (GameGlobals.score >= 430) score03.Draw(OFFSET);
                    if (GameGlobals.score >= 440) score04.Draw(OFFSET);
                    if (GameGlobals.score >= 450) score052nd.Draw(OFFSET);
                    if (GameGlobals.score >= 460) score06.Draw(OFFSET);
                    if (GameGlobals.score >= 470) score07.Draw(OFFSET);
                    if (GameGlobals.score >= 480) score08.Draw(OFFSET);
                    if (GameGlobals.score >= 490) score09.Draw(OFFSET);
                }
                if (GameGlobals.score >= 500)
                {
                    score053rd.Draw(OFFSET);
                    if (GameGlobals.score < 510) score002nd.Draw(OFFSET);
                    if (GameGlobals.score >= 510) score01.Draw(OFFSET);
                    if (GameGlobals.score >= 520) score02.Draw(OFFSET);
                    if (GameGlobals.score >= 530) score03.Draw(OFFSET);
                    if (GameGlobals.score >= 540) score04.Draw(OFFSET);
                    if (GameGlobals.score >= 550) score052nd.Draw(OFFSET);
                    if (GameGlobals.score >= 560) score06.Draw(OFFSET);
                    if (GameGlobals.score >= 570) score07.Draw(OFFSET);
                    if (GameGlobals.score >= 580) score08.Draw(OFFSET);
                    if (GameGlobals.score >= 590) score09.Draw(OFFSET);
                }
                if (GameGlobals.score >= 600)
                {
                    score063rd.Draw(OFFSET);
                    if (GameGlobals.score < 610) score002nd.Draw(OFFSET);
                    if (GameGlobals.score >= 610) score01.Draw(OFFSET);
                    if (GameGlobals.score >= 620) score02.Draw(OFFSET);
                    if (GameGlobals.score >= 630) score03.Draw(OFFSET);
                    if (GameGlobals.score >= 640) score04.Draw(OFFSET);
                    if (GameGlobals.score >= 650) score052nd.Draw(OFFSET);
                    if (GameGlobals.score >= 660) score06.Draw(OFFSET);
                    if (GameGlobals.score >= 670) score07.Draw(OFFSET);
                    if (GameGlobals.score >= 680) score08.Draw(OFFSET);
                    if (GameGlobals.score >= 690) score09.Draw(OFFSET);
                }
                if (GameGlobals.score >= 700)
                {
                    score073rd.Draw(OFFSET);
                    if (GameGlobals.score < 710) score002nd.Draw(OFFSET);
                    if (GameGlobals.score >= 710) score01.Draw(OFFSET);
                    if (GameGlobals.score >= 720) score02.Draw(OFFSET);
                    if (GameGlobals.score >= 730) score03.Draw(OFFSET);
                    if (GameGlobals.score >= 740) score04.Draw(OFFSET);
                    if (GameGlobals.score >= 750) score052nd.Draw(OFFSET);
                    if (GameGlobals.score >= 760) score06.Draw(OFFSET);
                    if (GameGlobals.score >= 770) score07.Draw(OFFSET);
                    if (GameGlobals.score >= 780) score08.Draw(OFFSET);
                    if (GameGlobals.score >= 790) score09.Draw(OFFSET);
                }
                if (GameGlobals.score >= 800)
                {
                    score083rd.Draw(OFFSET);
                    if (GameGlobals.score < 810) score002nd.Draw(OFFSET);
                    if (GameGlobals.score >= 810) score01.Draw(OFFSET);
                    if (GameGlobals.score >= 820) score02.Draw(OFFSET);
                    if (GameGlobals.score >= 830) score03.Draw(OFFSET);
                    if (GameGlobals.score >= 840) score04.Draw(OFFSET);
                    if (GameGlobals.score >= 850) score052nd.Draw(OFFSET);
                    if (GameGlobals.score >= 860) score06.Draw(OFFSET);
                    if (GameGlobals.score >= 870) score07.Draw(OFFSET);
                    if (GameGlobals.score >= 880) score08.Draw(OFFSET);
                    if (GameGlobals.score >= 890) score09.Draw(OFFSET); 
                }
                if (GameGlobals.score >= 900)
                {
                    score093rd.Draw(OFFSET);
                    if (GameGlobals.score < 910) score002nd.Draw(OFFSET);
                    if (GameGlobals.score >= 910) score01.Draw(OFFSET);
                    if (GameGlobals.score >= 920) score02.Draw(OFFSET);
                    if (GameGlobals.score >= 930) score03.Draw(OFFSET);
                    if (GameGlobals.score >= 940) score04.Draw(OFFSET);
                    if (GameGlobals.score >= 950) score052nd.Draw(OFFSET);
                    if (GameGlobals.score >= 960) score06.Draw(OFFSET);
                    if (GameGlobals.score >= 970) score07.Draw(OFFSET);
                    if (GameGlobals.score >= 980) score08.Draw(OFFSET);
                    if (GameGlobals.score >= 990) score09.Draw(OFFSET);
                }
                if (GameGlobals.score >= 1000)
                {
                    if (GameGlobals.score < 1010) score002nd.Draw(OFFSET);
                    if (GameGlobals.score < 1100) score003rd.Draw(OFFSET);
                    score014th.Draw(OFFSET);
                }
            }
            #endregion
        }
    }
}

