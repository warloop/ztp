
using System.Windows.Controls;

namespace graNaZtp.Models
{
    internal class Board
    {
        private double width;
        private double height;
        private DifficultyLevelStrategy difficultyLevel;
        private Image image;
        public Board() { }

        public Board(Image image,double width, double height, DifficultyLevelStrategy difficultyLevel)
        {
            this.image = image;
            this.width = width;
            this.height = height;
            this.difficultyLevel = difficultyLevel;
        }

        public static BoardBuilder builder()
        {
            return new BoardBuilder();
        }

        public double getWidth()
        {
            return width;
        }

        public double getHeight()
        {
            return height;
        }

        public int getDifficulty()
        {
            return difficultyLevel.getDifficultyLevel();
        }

        public void setWidth(double width)
        {
            this.width = width;
        }
        public void setImage(Image image)
        {
            this.image = image;
        }
        public void setHeight(double height)
        {
            this.height = height;
        }
        public void setDifficultyLevel(DifficultyLevelStrategy difficultyLevel)
        {
            this.difficultyLevel = difficultyLevel;
        }
    }
}