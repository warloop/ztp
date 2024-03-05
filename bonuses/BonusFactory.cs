
using System.Windows.Controls;

namespace graNaZtp.Models.bonuses
{
    internal class BonusFactory
    {
        public Bonus createRandomBonus(Image[] images)
        {
            int random = new Random().Next(0, 3);
            if(random == 0)
            {
                return new DamageBonus(images[random], 1);
            } else if(random == 1) {
                return new SpeedBonus(images[random], 1);
            }
            else if (random == 2)
            {
                return new ShootSpeedDoubleBonus(images[random], 1);
            }
            else {
                return new DamageBonus(images[0], 1);
            }
        }

        public DamageBonus creareDamageBonus(Image image, int additionalDamage)
        {
            return new DamageBonus(image, additionalDamage);
        }

        public LifeBonus creareLifeBonus(Image image, int additionalLifes)
        {
            return new LifeBonus(image, additionalLifes);
        }

        public ShieldBonus creareShieldBonus(Image image, int additionalArmor)
        {
            return new ShieldBonus(image, additionalArmor);
        }

        public ShootSpeedBonus creareShootSpeedBonus(Image image, int additionalShootSpeed)
        {
            return new ShootSpeedBonus(image, additionalShootSpeed);
        }

        public SpeedBonus creareSpeedBonus(Image image, int additionalSpeed)
        {
            return new SpeedBonus(image, additionalSpeed);
        }



    }
}
