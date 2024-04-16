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
        public MenuManager(){
            iniciar = false;
            _bg = new Background();
            _start = new Button(Globals.Content.Load<Texture2D>("start"),new Vector2(10,20));
            _start.OnClick += Comecar;
        }
        public void Draw(){
            _bg.Draw();
            _start.Draw();
        }
        public void Comecar(object sender, EventArgs e){
            iniciar = !iniciar;
        }
    }
}