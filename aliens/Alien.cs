using System.Windows;
using System.Windows.Controls;

namespace graNaZtp.Models.aliens
{
    public abstract class Alien
    {
        private Image image;
        private double speed;
        private double x;
        private double y;
        private double startX;
        private double startY;

        public Alien()
        {
        }

        public Alien(double speed)
        {
            this.speed = speed;
        }

        public Alien(Image image, double speed, double startX, double startY)
        {
            this.image = image;
            this.speed = speed;
            this.x = getX();
            this.y = getY();
            this.startX = startX;
            this.startY = startY;
            image.Visibility = Visibility.Visible;
            Canvas.SetLeft(image, startX);
            Canvas.SetTop(image, startY);
        }

        public double getSpeed() { return speed; }
        public void setSpeed(double speed)
        {
            this.speed = speed;
        }

        public Image getImage()
        {
            return image;
        }
        public void setImage(Image image)
        {
            this.image = image;
        }

        public double getX()
        {
            return Canvas.GetLeft(getImage());
        }

        public double getY()
        {
            return Canvas.GetTop(getImage());
        }

        public double getStartX()
        {
            return startX;
        }

        public double getStartY()
        {
            return startY;
        }

        public void setX(double x)
        {
            this.x = x;
            Canvas.SetLeft(getImage(), x);
        }

        public void setY(double y)
        {
            this.y = y;
            Canvas.SetTop(getImage(), y);
        }

        public bool isVisible()
        {
            return image.Visibility == Visibility.Visible;
        }

        public bool isHidden()
        {
            return !isVisible();
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

        public void setStartX(double startX)
        {
            this.startX = startX;
        }
        public void setStartY(double startY)
        {
            this.startY = startY;
        }

        public abstract Alien clone();
        public abstract void move();
        public abstract int CalculatePoints();

    }

}
