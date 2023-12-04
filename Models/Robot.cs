using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTIC_Cloud_ExoSup.Enums;

namespace TFTIC_Cloud_ExoSup.Models
{
    //public delegate void RobotAction();
    internal class Robot
    {
        #region Champs
        private int _positionX;
        private int _positionY;
        //private RobotAction _mouvement;
        private Action _mouvement;
        #endregion

        #region Propriétés
        public int PositionX
        {
            get { return _positionX; }
            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(PositionX));
                if (value >= Grille.Width) throw new ArgumentOutOfRangeException(nameof(PositionX));
                _positionX = value;
            }
        }
        public int PositionY
        {
            get { return _positionY; }
            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(PositionY));
                if (value >= Grille.Height) throw new ArgumentOutOfRangeException(nameof(PositionY));
                _positionY = value;
            }
        }
        public Direction Direction { get; private set; }
        public Grille Grille { get; private set; }
        #endregion

        #region Constructeur
        public Robot(int positionX, int positionY, Grille grille)
        {
            Grille = grille;
            PositionX = positionX;
            PositionY = positionY;
            Direction = Direction.Nord;
        }
        #endregion

        #region Méthodes
        public void Avancer()
        {
            switch (Direction)
            {
                case Direction.Nord:
                    PositionY++;
                    break;
                case Direction.Sud:
                    PositionY--;
                    break;
                case Direction.Ouest:
                    PositionX--;
                    break;
                case Direction.Est:
                    PositionX++;
                    break;
            }
        }

        public void TournerGauche()
        {
            int direction = (int)Direction;
            direction = (direction == 0)? 3 : direction-1;
            Direction = (Direction)direction;
        }

        public void TournerDroite()
        {
            int direction = (int)Direction;
            direction = (direction+1) % 4 ; //Modulo : reprend toujours une valeur compris entre 0 et le diviseur-1
            Direction = (Direction)direction;
        }

        public void EnregistrerOrdre(OrdreRobot ordre)
        {
            switch(ordre)
            {
                case OrdreRobot.Avancer:
                    _mouvement += Avancer;
                    break;
                case OrdreRobot.Gauche:
                    _mouvement += TournerGauche;
                    break;
                case OrdreRobot.Droite:
                    _mouvement += TournerDroite;
                    break;
            }
        }

        public void Executer()
        {
            if (_mouvement is null) throw new NullReferenceException("Pas d'ordre enregistré...");
            _mouvement();
        }
        #endregion
    }
}
