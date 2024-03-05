
namespace graNaZtp.Models
{
    using global::graNaZtp.Models.aliens;
    using System.Windows;
    using System.Windows.Controls;

    namespace graNaZtp.Models
    {
        public class Destroyer : aliens.Alien
        {
            private static readonly int MAX_X = 600;
            private static readonly int MAX_Y = 550;
            private Random random = new Random();
            private double targetX = 0;
            private double targetY = 0;


            public Destroyer(Image image, int speed, double startX, double startY) : base(image, speed, startX, startY)
            {

            }

            public Destroyer(Destroyer destroyer)
            {
                if (destroyer != null)
                {
                    setImage(destroyer.getImage());
                    setSpeed(destroyer.getSpeed() + 1);
                    setX(destroyer.getStartX());
                    setY(destroyer.getStartY());
                }
            }

            public override Alien clone()
            {
                return new Destroyer(this);
            }

            public override void move()
            {
                double currentXPosition = Canvas.GetLeft(getImage());
                double currentYPosition = Canvas.GetTop(getImage());
                if (Math.Abs(targetX - currentXPosition) < getSpeed() && Math.Abs(targetY - currentYPosition) < getSpeed())
                {
                    targetX = random.NextDouble() * MAX_X;
                    targetY = random.NextDouble() * MAX_Y;
                }

                double directionX = targetX - currentXPosition;
                double directionY = targetY - currentYPosition;
                double distance = Math.Sqrt(directionX * directionX + directionY * directionY);
                if (distance > 0)
                {
                    directionX /= distance;
                    directionY /= distance;

                    currentXPosition += directionX * getSpeed();
                    currentYPosition += directionY * getSpeed();
                }

                Canvas.SetLeft(getImage(), currentXPosition);
                Canvas.SetTop(getImage(), currentYPosition);
            
                }
            public void shoot()
            {

            }
            public Image GetImage() { return getImage(); }
            public override int CalculatePoints()
            {
                return 6;
            }
        }

        }
    }
