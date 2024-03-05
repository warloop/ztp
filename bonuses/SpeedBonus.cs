using System.Windows.Controls;

namespace graNaZtp.Models.bonuses
{
    internal class SpeedBonus : Bonus
    {
        private double additionalSpeed;



        public SpeedBonus(Image image, double additionalSpeed) : base(image)
        {
            this.additionalSpeed = additionalSpeed;
        }

        public double getAdditionalSpeed()
        {
            return additionalSpeed;
        }
    }
}
