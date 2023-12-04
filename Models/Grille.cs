using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTIC_Cloud_ExoSup.Models
{
    internal class Grille
    {
        #region Champs
        private int _width;
        private int _height;

        private int _finalX;
        private int _finalY;

        private Robot _robot;

        private Random _rng;
        #endregion

        #region Propriétés
        public int Width
        {
            get { return _width; }
            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(Width));
                _width = value;
            }
        }
        public int Height
        {
            get { return _height; }
            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(Height));
                _height = value;
            }
        }

        public int FinalX
        {
            get { return _finalX; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(FinalX));
                if (value >= Width) throw new ArgumentOutOfRangeException(nameof(FinalX));
                _finalX = value;
            }
        }
        public int FinalY
        {
            get { return _finalY; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(FinalY));
                if (value >= Height) throw new ArgumentOutOfRangeException(nameof(FinalY));
                _finalY = value;
            }
        }

        public Robot Robot { 
            get { 
                return _robot; 
            }
            private set {
                if(value is null) throw new ArgumentNullException(nameof(Robot));
                _robot = value;
            } 
        }
        #endregion

        #region Constructeur
        public Grille(int width, int height)
        {
            _rng = new Random();
            Width = width;
            Height = height;
        }
        #endregion

        #region Méthodes
        public void InitGame()
        {
            Robot = new Robot(0, 0, this);
            FinalX = _rng.Next(Width);
            FinalY = _rng.Next(Height);
        }
        #endregion
    }
}
