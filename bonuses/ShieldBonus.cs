using System.Windows.Controls;

namespace graNaZtp.Models.bonuses
{
    internal class ShieldBonus : Bonus
    {
        private double additionalArmor;

        public ShieldBonus(Image image, double additionalArmor) : base(image)
        {
            this.additionalArmor = additionalArmor;
        }

        public double getAdditionalArmor()
        {
            return additionalArmor;
        }
    }
}
