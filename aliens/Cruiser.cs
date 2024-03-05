
using graNaZtp.Models.graNaZtp.Models;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace graNaZtp.Models.aliens
{
    public class Cruiser : Alien
    {
        

        public Cruiser(Image image, int speed, double startX, double startY) : base(image, speed, startX, startY)
        {
            
        }

        public Cruiser(Cruiser cruiser)
        {
            if (cruiser != null)
            {
                setImage(cruiser.getImage());
                setSpeed(cruiser.getSpeed() + 1);
                setX(cruiser.getStartX());
                setY(cruiser.getStartY());
            }
        }

        public override Alien clone()
        {
            return new Cruiser(this);
        }

        public override void move()
        {
            double currentPosition = Canvas.GetTop(getImage());

            if (currentPosition <= 150 || currentPosition >= 450)
            {
                setSpeed(getSpeed() * -1);
            }


            Canvas.SetTop(getImage(), currentPosition - getSpeed());
        }
        public void shoot()
        {
           
        }
        public Image GetImage() { return getImage(); }
        public override int CalculatePoints()
        {
            return 3; 
        }
    }
}
