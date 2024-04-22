using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Project002;

namespace TopDownShooter._Managers
{
    public class MenuManager
    {
        private readonly Background _bg;  
        public bool iniciar; 
        private Button _start;
        private GameManager Game;
        private SpriteFont fonte;
        public MenuManager(GameManager game){
            iniciar = false;
            _bg = new Background();
            _start = new Button(Globals.Content.Load<Texture2D>("start"),Comecar);
            Game = game;
            fonte = Globals.Content.Load<SpriteFont>("font");
        }
        public void Initialize(){
            
            _start.Position = new Point((Globals.Bounds.X / 2) - _start.Bounds.Width/2, (Globals.Bounds.Y / 2)-_start.Bounds.Height/2);
        }
        public void Draw(){
            _bg.Draw();
            _start.Draw(Globals.SpriteBatch);
            Globals.SpriteBatch.DrawString(fonte, "Top Down Shooter", new Vector2((Globals.Bounds.X / 2)-250,0),Color.Black);
        }
        public void Update(){
            _start.Update((int)Globals.TotalSeconds);
        }
        public void Comecar(){
            iniciar = true;
            Game.Restart();
        }
    }
}