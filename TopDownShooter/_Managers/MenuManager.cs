using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Project002;

namespace TopDownShooter._Managers
{
    public class MenuManager
    {
        private readonly Background _bg;  
        public bool iniciar; 
        public MenuManager(){
            iniciar = false;
            _bg = new Background();
        }
        public void Draw(){
            _bg.Draw();
        }
    }
}