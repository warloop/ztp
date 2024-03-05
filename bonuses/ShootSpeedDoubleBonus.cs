using System.Windows.Controls;

namespace graNaZtp.Models.bonuses
{
    internal class ShootSpeedDoubleBonus : ShootSpeedBonus
    {
        public ShootSpeedDoubleBonus(Image image, int additionalShootSpeed) : base(image, additionalShootSpeed)
        {
        }

        public override int getAdditionalShootSpeed()
        {
            return base.getAdditionalShootSpeed() * 2;
        }
    }
}
