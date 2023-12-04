using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTIC_Cloud_ExoSup.Models
{
    internal class Grille
    {
		private int _width;
        private int _height;
        private int _finalX;
        private int _finalY;


        public int Width
		{
			get { return _width; }
			set {
				if(value < 5) throw new ArgumentOutOfRangeException(nameof(Width));
				_width = value; 
			}
		}

        public int Height
        {
            get { return _height; }
            set
            {
                if (value < 5) throw new ArgumentOutOfRangeException(nameof(Height));
                _height = value;
            }
        }

        public int FinalX
        {
            get
            {
                return _finalX;
            }
            set
            {
                if (value < 0 || value > Width) throw new ArgumentOutOfRangeException(nameof(FinalX));
                _finalX = value;
            }
        }
        public int FinalY
        {
            get
            {
                return _finalY;
            }
            set
            {
                if (value < 0 || value > Height) throw new ArgumentOutOfRangeException(nameof(FinalY));
                _finalY = value;
            }
        }
        public Grille(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void InitGame()
        {

        }
    }
}
