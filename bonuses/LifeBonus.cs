using System.Windows.Controls;

namespace graNaZtp.Models.bonuses
{
    internal class LifeBonus : Bonus
    {
        public int additionalLifes;

        public LifeBonus(Image image, int additionalLifes) : base(image)
        {
            this.additionalLifes = additionalLifes;
        }

        public int getAdditionalLifes()
        {
            return additionalLifes;
        }
    }
}
