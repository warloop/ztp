using graNaZtp.Models.graNaZtp.Models;
using System.Windows;
using System.Windows.Controls;

namespace graNaZtp.Models.aliens
{
    public class Fighter : Alien
    {

        public Fighter(Image image, int speed, double startX, double startY) : base(image, speed, startX, startY)
        {
        }

        public Fighter(Fighter fighter)
        {
            if (fighter != null)
            {
                setImage(fighter.getImage());
                setSpeed(fighter.getSpeed() + 1);
                setX(fighter.getStartX());
                setY(fighter.getStartY());
                setStartX(fighter.getStartX());
                setStartY(fighter.getStartY());
            }
        }

        public override Alien clone()
        {
            return new Fighter(this);
        }

        public override void move()
        {
            double currentPosition = Canvas.GetLeft(getImage());

            if (currentPosition <= 50 || currentPosition >= 650)
            {
                setSpeed(getSpeed() * -1);
            }

            Canvas.SetLeft(getImage(), currentPosition - getSpeed());
        }
        public void shoot()
        {
            
        }
        public Image GetImage() {return getImage();}
        public override int CalculatePoints()
        {
            return 1;
        }
    }
}
