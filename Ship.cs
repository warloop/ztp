using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using graNaZtp.Models.bonuses;

namespace graNaZtp.Models
{
    internal class Ship
    {
        private ShipSettings settings;
        private Image image;
        private float speedX;
        private float speedY;
        private Bullet[] bullets;
        private Gun gun;
        private List<Bonus> bonuses;


        public Ship(Image shipImage, float speedX, float speedY, Bullet[] bullets)
        {
            image = shipImage;
            this.speedX = speedX;
            this.speedY = speedY;
            this.settings = ShipSettings.getInstance();
            this.bullets = bullets;
            setStartPosition();
            bonuses = new List<Bonus>();
            gun = new Gun();
        }

        public void setStartPosition()
        {
            Canvas.SetLeft(image, settings.getStartX());
            Canvas.SetTop(image, settings.getStartY());
        }
        public void move()
        {
            int additionalSpeed = getSpeedBonuses();
            Canvas.SetLeft(image, Canvas.GetLeft(image) + speedX);
            Canvas.SetTop(image, Canvas.GetTop(image) + speedY);
        }

        public void moveUp()
        {
            int additionalSpeed = getSpeedBonuses();
            this.speedX = 0;
            this.speedY = -1 * (settings.getSpeed() + additionalSpeed);
        }
        public void moveDown()
        {
            int additionalSpeed = getSpeedBonuses();
            this.speedX = 0;
            this.speedY = settings.getSpeed() + additionalSpeed;
        }
        public void moveLeft()
        {
            int additionalSpeed = getSpeedBonuses();
            this.speedX = -1 * (settings.getSpeed() + additionalSpeed);
            this.speedY = 0;
        }
        public void moveRight()
        {
            int additionalSpeed = getSpeedBonuses();
            this.speedX = settings.getSpeed() + additionalSpeed;
            this.speedY = 0;
        }

        public ShipSettings getSettings()
        {
            return settings;
        }

        public float getSpeedX()
        {
            return speedX;
        }
        public float getSpeedY()
        {
            return speedY;
        }

        public void addBonus(Bonus bonus)
        {
            bonuses.Add(bonus);
        }

        public int getDamageBonuses()
        {
            int result = 0;
            for(int i = 0; i < bonuses.Count; i++)
            {
                if (bonuses[i] is DamageBonus)
                {
                    result++;
                }
            }
            return result;
        }

        public int getSpeedBonuses()
        {
            int result = 0;
            for (int i = 0; i < bonuses.Count; i++)
            {
                if (bonuses[i] is SpeedBonus)
                {
                    result++;
                }
            }
            return result;
        }

        public int getShootSpeedBonuses()
        {
            int result = 0;
            for (int i = 0; i < bonuses.Count; i++)
            {
                if (bonuses[i] is ShootSpeedBonus)
                {
                    result++;
                }
            }
            return result;
        }
        
        public void shoot()
        {
            for (int i = 0; i < getCurrentDamage(); i++)
            {
                if (bullets[i].isHidden())
                {
                    bullets[i].setVisible(true);
                    bullets[i].setPosition(Canvas.GetLeft(image) + 20, Canvas.GetTop(image) - 35);
                    break;
                }
            }
        }
        public void shootChangeDirection()
        {
            for (int i = 0; i < getCurrentDamage(); i++)
            {
                if (bullets[i].isHidden())
                {
                    bullets[i].setVisible(true);
                    bullets[i].setPosition(Canvas.GetLeft(image) + 20, Canvas.GetTop(image) + 35);
                    break;
                }
            }
        }

        public void updateBullets()
        {
            int additionalShootSpeed = getShootSpeedBonuses();
            for (int i = 0; i < getCurrentDamage(); i++)
            {
                if (bullets[i].isVisible())
                {
                    bullets[i].move(additionalShootSpeed);
                }
                if (bullets[i].getY() <= 0)
                {
                    bullets[i].setVisible(false);
                }
            }
        }

        public Bullet getBullet(int i)
        {
            return bullets[i];
        }

        public int getBulletsCount() {
            return bullets.Length;
        }

        public int getCurrentDamage()
        {
            if (gun.getCurrentDamage() + getDamageBonuses() >= settings.getMaxDamage()) 
                return settings.getMaxDamage();

            return gun.getCurrentDamage() + getDamageBonuses();

        }

        public double getX()
        {
            return Canvas.GetLeft(image);
        }

        public double getY()
        {
            return Canvas.GetTop(image);
        }

        public Image getImage()
        {
            return image;
        }
        
    }
}
