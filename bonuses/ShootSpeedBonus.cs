using System.Windows.Controls;

namespace graNaZtp.Models.bonuses
{
    internal class ShootSpeedBonus : Bonus
    {
        private int additionalShootSpeed;

        public ShootSpeedBonus(Image image, int additionalShootSpeed) : base(image)
        {
            this.additionalShootSpeed = additionalShootSpeed;
        }

        public virtual int getAdditionalShootSpeed()
        {
            return additionalShootSpeed;
        }
    }
}
