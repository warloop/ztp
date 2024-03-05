using System.Windows;
using System.Windows.Controls;

namespace graNaZtp.Models.bonuses
{
    public abstract class Bonus
    {
        private Image image;
        private DateTime startTime;

        public Bonus(Image image)
        {
            this.image = image;
            this.startTime = DateTime.Now;
        }

        public Image getImage()
        {
            return image;
        }

        public DateTime getStartTime()
        {
            return startTime;
        }

        public void setStartTimeNow()
        {
            startTime = DateTime.Now;
        }

        public void setVisible(bool value)
        {
            if (value)
            {
                image.Visibility = Visibility.Visible;
            }
            else
            {
                image.Visibility = Visibility.Hidden;
            }
        }

        public bool isVisible()
        {
            return image.Visibility == Visibility.Visible;
        }

        public void setRandomPosition(double omitShipX, double omitShipY)
        {
            int randomX, randomY;
            while (true)
            {
                randomX = new Random().Next(100, 600);
                randomY = new Random().Next(100, 500);
                if (Math.Abs(randomX - omitShipX) > 30 && 
                    Math.Abs(randomY - omitShipY) > 30) break;
            }
            
            Canvas.SetLeft(image, randomX);
            Canvas.SetTop(image, randomY);
        }

        public double getX()
        {
            return Canvas.GetLeft(image);
        }

        public double getY()
        {
            return Canvas.GetTop(image);
        }
    }
}
