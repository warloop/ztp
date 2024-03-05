
using System.Windows.Controls;

namespace graNaZtp.Models
{
    class BoardBuilder
    {
        private Board board = new Board();
        public BoardBuilder addImage(Image image)
        {
            board.setImage(image);
            return this;
        }
        public BoardBuilder addWidth(double width)
        {
            board.setWidth(width);
            return this;
        }

        public BoardBuilder addHeight(double height)
        {
            board.setHeight(height);
            return this;
        }

        public BoardBuilder addDifficultyLevel(DifficultyLevelStrategy difficultyLevel)
        {
            board.setDifficultyLevel(difficultyLevel);
            return this;
        }

        public Board build()
        {
            return board;
        }

    }
}
