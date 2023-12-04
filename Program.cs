using TFTIC_Cloud_ExoSup.Models;

namespace TFTIC_Cloud_ExoSup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Grille grid = new Grille(6, 6);
                grid.InitGame();
                grid.Robot.EnregistrerOrdre(Enums.OrdreRobot.Avancer);
                grid.Robot.EnregistrerOrdre(Enums.OrdreRobot.Avancer);
                grid.Robot.EnregistrerOrdre(Enums.OrdreRobot.Avancer);
                grid.Robot.EnregistrerOrdre(Enums.OrdreRobot.Droite);
                grid.Robot.EnregistrerOrdre(Enums.OrdreRobot.Avancer);
                grid.Robot.EnregistrerOrdre(Enums.OrdreRobot.Avancer);
                grid.Robot.EnregistrerOrdre(Enums.OrdreRobot.Gauche);
                grid.Robot.EnregistrerOrdre(Enums.OrdreRobot.Avancer);
                grid.Robot.EnregistrerOrdre(Enums.OrdreRobot.Avancer);
                grid.Robot.Executer();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}