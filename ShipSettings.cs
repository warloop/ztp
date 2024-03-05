using System;
using System.Reflection.Metadata;
using System.Windows.Automation;

namespace graNaZtp.Models
{
    internal class ShipSettings
    {
        private static ShipSettings instance;
        private String name;
        private int lifeCount;
        private int speed;
        private int maxDamage;
        private double startX, startY;
        private int shootFraquency;
        private int damage;
        private int endurance;
        private ShipSettings()
        {
            this.name = "Rival";
            this.lifeCount = 3;
            this.speed = 3;
            this.maxDamage = 4;
            this.shootFraquency = 10;
            this.damage = 3;
            this.endurance = 3;
            this.startX = 333;
            this.startY = 249;
        }

        public static ShipSettings getInstance()
        {
            if (instance == null)
            {
                instance = new ShipSettings();
            }

            return instance;
        }
        public int getSpeed() { return speed; }

        public int getMaxDamage()
        {
            return maxDamage;
        }
        public double getStartX()
        {
            return startX;
        }

        public double getStartY()
        {
            return startY;
        }

    }
}
