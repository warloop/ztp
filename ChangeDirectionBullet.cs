using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace graNaZtp.Models
{
    class ChangeDirectionBullet : Bullet
    {
        private Image image;
        public ChangeDirectionBullet(Image image): base(image)
        {
            this.image = image;
        }

        public double getX()
        {
            return Canvas.GetLeft(image);
        }
        public double getY()
        {
            return Canvas.GetTop(image);
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

        public void setPosition(double x, double y)
        {
            setX(x);
            setY(y);
        }

        public void setX(double x)
        {
            Canvas.SetLeft(image, x);
        }

        public void setY(double y)
        {
            Canvas.SetTop(image, y);
        }

        public void move(int additionalShootSpeed)
        {
            setY(getY() - (4 + additionalShootSpeed));
        }
        public void moveDown(double distance)
        {
            double currentY = Canvas.GetTop(image);
            setPosition(Canvas.GetLeft(image), currentY + distance);
        }
        public Image GetImage()
        {
            return image;
        }
    }
}

