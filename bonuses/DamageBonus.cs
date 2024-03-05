using System.Windows;
using System.Windows.Controls;

namespace graNaZtp.Models.bonuses
{
    internal class DamageBonus : Bonus
    {
        private int additionalDamage;

        public DamageBonus(Image image, int additionalDamage) : base(image)
        {
            this.additionalDamage = additionalDamage;
        }

        public int getAdditionalDamage()
        {
            return additionalDamage;
        }
    }
}
