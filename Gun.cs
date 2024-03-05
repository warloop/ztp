
namespace graNaZtp.Models
{
    

    class Gun
    {
        private int currentDamage;

        public Gun()
        {
            currentDamage = 1;
        }

        public int getCurrentDamage()
        {
            return currentDamage;
        }

        public void update()
        {
            currentDamage = currentDamage + 1;
        }

    }
}
