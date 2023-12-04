using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTIC_Cloud_ExoSup.Enums;

namespace TFTIC_Cloud_ExoSup.Models
{
    delegate void RobotMouvement();
    internal class Robot
    {
        private int _positionX;
        private int _positionY;
        private Direction _direction;
        private RobotMouvement _mouvement;
        public int PositionX
        {
            get
            {
                return _positionX;
            }
            set
            {
                if (_positionX < 0) throw new ArgumentOutOfRangeException(nameof(PositionX));
                _positionX = value;
            }
        }
        public int PositionY
        {
            get
            {
                return _positionY;
            }
            set
            {
                if (_positionY < 0) throw new ArgumentOutOfRangeException(nameof(PositionY));
                _positionY = value;
            }
        }

        public Direction Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }
    
        private void TournerGauche()
        {
            int currentDirection = (int)Direction;
            currentDirection = (currentDirection == 0) ? Enum.GetValues<Direction>().Length-1 : currentDirection - 1;
            Direction = (Direction)currentDirection;
        }

        private void TournerDroite()
        {
            int currentDirection = (int)Direction;
            currentDirection++;
            Direction = (Direction)(currentDirection% Enum.GetValues<Direction>().Length);
        }

        private void Avancer()
        {
            switch (Direction)
            {
                case Direction.Nord:
                    PositionY++;
                    break;
                case Direction.Sud:
                    PositionY--;
                    break;
                case Direction.Est:
                    PositionX++;
                    break;
                case Direction.Ouest:
                    PositionX--;
                    break;
            }
        }

        public void EnregistrerOrdre(OrdreRobot ordre)
        {
            switch(ordre)
            {
                case OrdreRobot.Avancer:
                    _mouvement += Avancer;
                    break;
                case OrdreRobot.Droite:
                    _mouvement += TournerDroite;
                    break;
                case OrdreRobot.Gauche:
                    _mouvement += TournerGauche;
                    break;
            }
        }

        public void Executer()
        {
            _mouvement?.Invoke();
        }
    }
}
