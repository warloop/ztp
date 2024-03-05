using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using graNaZtp.Models;
using graNaZtp.Models.aliens;
using graNaZtp.Models.bonuses;
using graNaZtp.Models.graNaZtp.Models;
using NAudio;
using NAudio.Wave;

namespace graNaZtp
{
    public partial class MainWindow : Window
    {
        private IWavePlayer wavePlayer;
        private AudioFileReader audioFileReader;
        private AlienBullet[] alienBullets;
        private DispatcherTimer gameTimer;
        private DispatcherTimer shootingTimer;
        private Ship playerShip;
        private Alien[] aliens;
        private Alien[] clonedAliens;
        private Image[] bonusImages;
        private Board board;
        private BonusFactory bonusFactory = new BonusFactory();
        private Bonus bonus;
        private Points points;
        private DifficultyLevelStrategy difficultyLevelStrategy;
        private Ranking ranking = new Ranking();
        ChangeDirectionBullet changeBullet1;
        public void PlaySound(string filePath)
        {
            wavePlayer = new WaveOutEvent();
            audioFileReader = new AudioFileReader(filePath);
            wavePlayer.Init(audioFileReader);
            wavePlayer.Play();
        }
        public MainWindow()
        {
            var bitmapImage = new BitmapImage(new Uri("/Images/menuBackground.png", UriKind.RelativeOrAbsolute));
            var imageBrush = new ImageBrush(bitmapImage);
            alienBullets = new AlienBullet[3];
            InitializeComponent();
            showScreen(10);
            difficultyLevelStrategy = new DifficultyLevelHard();
            alienBullets[0] = new AlienBullet(alienbullet1);
            alienBullets[1] = new AlienBullet(alienbullet2);
            alienBullets[2] = new AlienBullet(alienbullet3);
            mediaPlayer.Source = new Uri("..\\..\\..\\..\\..\\graNaZtp\\graNaZtp\\1.mp3", UriKind.RelativeOrAbsolute);
            shipImage.Source = new BitmapImage(new Uri("/Images/ship.png", UriKind.RelativeOrAbsolute));
            bulletImage1.Source = new BitmapImage(new Uri("/Images/bullet.png", UriKind.RelativeOrAbsolute));
            bulletImage2.Source = new BitmapImage(new Uri("/Images/bullet.png", UriKind.RelativeOrAbsolute));
            bulletImage3.Source = new BitmapImage(new Uri("/Images/bullet.png", UriKind.RelativeOrAbsolute));
            bulletImage4.Source = new BitmapImage(new Uri("/Images/bullet.png", UriKind.RelativeOrAbsolute));
            bulletImage5.Source = new BitmapImage(new Uri("/Images/bullet.png", UriKind.RelativeOrAbsolute));
            bonusDamageImage.Source = new BitmapImage(new Uri("/Images/bonusDamage.png", UriKind.RelativeOrAbsolute));
            bonusSpeedImage.Source = new BitmapImage(new Uri("/Images/bonusSpeed.png", UriKind.RelativeOrAbsolute));
            bonusShootSpeedImage.Source = new BitmapImage(new Uri("/Images/bonusShootSpeed.png", UriKind.RelativeOrAbsolute));
            fighterImage.Source = new BitmapImage(new Uri("/Images/fighter.png", UriKind.RelativeOrAbsolute));
            cruiserImage.Source = new BitmapImage(new Uri("/Images/cruiser.png", UriKind.RelativeOrAbsolute));
            destroyerImage.Source = new BitmapImage(new Uri("/Images/destroyer.png", UriKind.RelativeOrAbsolute));
            bulletImage1.Source = new BitmapImage(new Uri("/Images/bullet.png", UriKind.RelativeOrAbsolute));
            alienbullet1.Source = new BitmapImage(new Uri("/Images/alienBullet.png", UriKind.RelativeOrAbsolute));
            alienbullet2.Source = new BitmapImage(new Uri("/Images/alienBullet2.png", UriKind.RelativeOrAbsolute));
            alienbullet3.Source = new BitmapImage(new Uri("/Images/alienBullet3.png", UriKind.RelativeOrAbsolute));
            alienbullet3.Source = new BitmapImage(new Uri("/Images/alienBullet3.png", UriKind.RelativeOrAbsolute));
            menuScreen.Source = new BitmapImage(new Uri("/Images/menuBackground.png", UriKind.RelativeOrAbsolute));
            newGameImage.Source = new BitmapImage(new Uri("/Images/newGame.gif", UriKind.RelativeOrAbsolute));
            rankingImage.Source = new BitmapImage(new Uri("/Images/ranking.gif", UriKind.RelativeOrAbsolute));
            settingImage.Source = new BitmapImage(new Uri("/Images/settings.gif", UriKind.RelativeOrAbsolute));
            endDameImage.Source = new BitmapImage(new Uri("/Images/endGame.gif", UriKind.RelativeOrAbsolute));
            menuScreen2.Source = new BitmapImage(new Uri("/Images/menuBackground.png", UriKind.RelativeOrAbsolute));
            rankingImage2.Source = new BitmapImage(new Uri("/Images/ranking.gif", UriKind.RelativeOrAbsolute));
            imageRank1.Source = new BitmapImage(new Uri("/Images/1.gif", UriKind.RelativeOrAbsolute));
            imageRank2.Source = new BitmapImage(new Uri("/Images/2.gif", UriKind.RelativeOrAbsolute));
            imageRank3.Source = new BitmapImage(new Uri("/Images/3.gif", UriKind.RelativeOrAbsolute));
            imageRank4.Source = new BitmapImage(new Uri("/Images/4.gif", UriKind.RelativeOrAbsolute));
            imageRank5.Source = new BitmapImage(new Uri("/Images/5.gif", UriKind.RelativeOrAbsolute));
            imageRank6.Source = new BitmapImage(new Uri("/Images/6.gif", UriKind.RelativeOrAbsolute));
            imageRank7.Source = new BitmapImage(new Uri("/Images/7.gif", UriKind.RelativeOrAbsolute));
            imageRank8.Source = new BitmapImage(new Uri("/Images/8.gif", UriKind.RelativeOrAbsolute));
            imageRank9.Source = new BitmapImage(new Uri("/Images/9.gif", UriKind.RelativeOrAbsolute));
            imageRank10.Source = new BitmapImage(new Uri("/Images/10.gif", UriKind.RelativeOrAbsolute));
            backMenu1.Source = new BitmapImage(new Uri("/Images/back.gif", UriKind.RelativeOrAbsolute));
            menuScreen3.Source = new BitmapImage(new Uri("/Images/menuBackground.png", UriKind.RelativeOrAbsolute));
            difficultyLevel.Source = new BitmapImage(new Uri("/Images/difficultyLevel.gif", UriKind.RelativeOrAbsolute));
            easyLevel.Source = new BitmapImage(new Uri("/Images/easy.gif", UriKind.RelativeOrAbsolute));
            mediumLevel.Source = new BitmapImage(new Uri("/Images/medium.gif", UriKind.RelativeOrAbsolute));
            hardLevel.Source = new BitmapImage(new Uri("/Images/hard.gif", UriKind.RelativeOrAbsolute));
            backMenu2.Source = new BitmapImage(new Uri("/Images/back.gif", UriKind.RelativeOrAbsolute));
            menuScreen4.Source = new BitmapImage(new Uri("/Images/menuBackground.png", UriKind.RelativeOrAbsolute));
            newPersonInRanking.Source = new BitmapImage(new Uri("/Images/newPersonInRanking.gif", UriKind.RelativeOrAbsolute));
            backMenu3.Source = new BitmapImage(new Uri("/Images/back.gif", UriKind.RelativeOrAbsolute));
            okButton.Source = new BitmapImage(new Uri("/Images/ok.gif", UriKind.RelativeOrAbsolute));
            boardImage.Source = new BitmapImage(new Uri("/Images/board.png", UriKind.RelativeOrAbsolute));
            changeBullet.Source = new BitmapImage(new Uri("/Images/changeDirection.png", UriKind.RelativeOrAbsolute));
            PlayMusic();
            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
            changeBullet1 = new ChangeDirectionBullet(changeBullet);
           
        }

        private void timer3(object? sender, EventArgs e)
        {
            changeBullet1.moveDown(2);

            if (Canvas.GetTop(changeBullet1.GetImage()) > 650)
            {
                changeBullet1.setVisible(false);
            }
        }

        private void PlayMusic()
        {
            mediaPlayer.Play();
        }
        private void createBonuses()
        {
            bonus = bonusFactory.creareDamageBonus(bonusDamageImage, 1);
            bonus.setVisible(true);
            bonusImages = new Image[3];
            bonusImages[0] = bonusDamageImage;
            bonusImages[1] = bonusSpeedImage;
            bonusImages[2] = bonusShootSpeedImage;
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            mediaPlayer.Position = TimeSpan.Zero; 
            mediaPlayer.Play(); 
        }

        private Bullet[] createBullets()
        {
            Bullet[] bullets = new Bullet[5];
            bullets[0] = new Bullet(bulletImage1);
            bullets[1] = new Bullet(bulletImage2);
            bullets[2] = new Bullet(bulletImage3);
            bullets[3] = new Bullet(bulletImage4);
            bullets[4] = new Bullet(bulletImage5);
            return bullets;
        }

        private void createAliens(int difficulty)
        {
            aliens = new Alien[difficulty];
            clonedAliens = new Alien[difficulty];

            Random rand = new Random(); 

   
            int playerX = 333;
            int playerY = 249;
            int shipWidth = 100;
            int shipHeight = 101;

      
            int safeZoneXMin = playerX - shipWidth;
            int safeZoneXMax = playerX + shipWidth;
            int safeZoneYMin = playerY - shipHeight;
            int safeZoneYMax = playerY + shipHeight;

            
            int[] GenerateRandomCoordinates()
            {
                int x, y;
                do
                {
                    x = rand.Next(200, 600); 
                    y = rand.Next(200, 400); 
                }
                while ((x >= safeZoneXMin && x <= safeZoneXMax) && (y >= safeZoneYMin && y <= safeZoneYMax)); 

                return new int[] { x, y };
            }

           
            int[] coordinates = GenerateRandomCoordinates();
            aliens[0] = new Fighter(fighterImage, 2, coordinates[0], coordinates[1]);
            clonedAliens[0] = aliens[0].clone();

            if (difficulty > 1)
            {
                coordinates = GenerateRandomCoordinates();
                aliens[1] = new Cruiser(cruiserImage, 2, coordinates[0], coordinates[1]);
                clonedAliens[1] = aliens[1].clone();
            }
            else
            {
                cruiserImage.Visibility = Visibility.Hidden;
            }

            if (difficulty > 2)
            {
                coordinates = GenerateRandomCoordinates();
                aliens[2] = new Destroyer(destroyerImage, 2, coordinates[0], coordinates[1]);
                clonedAliens[2] = aliens[2].clone();
            }
            else
            {
                destroyerImage.Visibility = Visibility.Hidden;
            }
        }


        private void refresh(object sender, EventArgs e)
        {
            if(MenuScreen.Visibility == Visibility.Visible)
            {
                return;
            }

            moveAndRefreshAliens();
            playerShip.move();
            playerShip.updateBullets();

            if (checkBonusGiven())
            {
                playerShip.addBonus(bonus);
                bonus.setStartTimeNow();
                bonus.setVisible(false);
            }

            checkToAddNextBonus();
            checkAlienShooted();
            checkAlienShooted1();
        }

        private void checkToAddNextBonus()
        {
            DateTime now = DateTime.Now;
            if (!bonus.isVisible())
            {
                var diffInSeconds = (now - bonus.getStartTime()).TotalSeconds;
                if (diffInSeconds > 6)
                {
                    bonus = bonusFactory.createRandomBonus(bonusImages);
                    bonus.setRandomPosition(playerShip.getX(), playerShip.getY());
                    bonus.setVisible(true);
                }
            }
            
        }

        private bool checkBonusGiven()
        {
            if (!bonus.isVisible())
            {
                return false;
            }

            return checkImagesAreInTheSamePosition(playerShip.getImage(), bonus.getImage());
        }

        private bool checkImagesAreInTheSamePosition(Image a, Image b)
        {
            int minDistance = 23;
            return Math.Abs(Canvas.GetLeft(a) - Canvas.GetLeft(b)) < minDistance &&
                Math.Abs(Canvas.GetTop(a) - Canvas.GetTop(b)) < minDistance;
        }
       
        private void moveAndRefreshAliens()
        {
            bool isAnyAlienVisible = false;
            for (int i = 0; i < board.getDifficulty(); i++)
            {
                if (aliens[i].isVisible())
                {
                    aliens[i].move();
                    isAnyAlienVisible = true;
                }
            }
            if (!isAnyAlienVisible)
            {
                for (int i = 0; i < board.getDifficulty(); i++)
                {
                    aliens[i].setX(aliens[i].getStartX());
                    aliens[i].setY(aliens[i].getStartY());
                    aliens[i].setVisible(true);
                }
            }
            else
            {
                checkEndGameConditions();
            }
        }
       
        
        private void checkEndGameConditions()
        {
           
                bool anyAlienBulletVisible = false;
                for (int i = 0; i < alienBullets.Length; i++)
                {
                    if (alienBullets[i].isVisible())
                    {
                        anyAlienBulletVisible = true;
                        break;
                    }
                }

                if (!anyAlienBulletVisible)
                {
                
                    return;
                }

                for (int i = 0; i < board.getDifficulty(); i++)
                {
                    if (aliens[i].isVisible())
                    {
                        if (checkImagesAreInTheSamePosition(playerShip.getImage(), aliens[i].getImage()))
                        {
                          
                            gameTimer.Stop();
                            shootingTimer.Stop();
                            showScreen(4);
                            break;
                        }
                    }

                }
            for (int i = 0; i < alienBullets.Length; i++)
            {
                if (checkImagesAreInTheSamePosition(playerShip.getImage(), alienBullets[i].GetImage()))
                {
                    showScreen(4);
                    gameTimer.Stop();
                    shootingTimer.Stop();
                }

            }
        }

        

        private void checkAlienShooted() {
                for (int i = 0; i < aliens.Length; i++)
                {
                    if (aliens[i].isVisible())
                    {
                        for(int j=0; j < playerShip.getBulletsCount(); j++)
                        {
                            Bullet bullet = playerShip.getBullet(j);
                            if (bullet.isVisible() && Math.Abs(aliens[i].getX() - bullet.getX()) < 30 &&
                                    Math.Abs(aliens[i].getY() - bullet.getY()) < 30)
                            {
                                aliens[i].setVisible(false);
                                bullet.setVisible(false);
                            points.AddPointsForAlien(aliens[i]);

                                aliens[i] = clonedAliens[i].clone();
                            }
                        }
                    }
                }
            }
        private void checkAlienShooted1()
        {
            for (int i = 0; i < aliens.Length; i++)
            {
                if (aliens[i].isVisible())
                {
                 
    
                        
                        if (changeBullet1.isVisible() && Math.Abs(aliens[i].getX() - changeBullet1.getX()) < 30 &&
                                Math.Abs(aliens[i].getY() - changeBullet1.getY()) < 30)
                        {
                            aliens[i].setVisible(false);
                            changeBullet1.setVisible(false);
                            points.AddPointsForAlien(aliens[i]);

                            aliens[i] = clonedAliens[i].clone();
                        }
                    }
                }
          }
        
        private void onKeyDown(object sender, KeyEventArgs e) //poruszanie statku i strzelanie
        {
            switch (e.Key)
            {
                case Key.W:
                    playerShip.moveUp();
                    break;

                case Key.S:
                    playerShip.moveDown();
                    break;

                case Key.A:
                    playerShip.moveLeft();
                    break;

                case Key.D:
                    playerShip.moveRight();
                    break;
                case Key.Space:
                    playerShip.shoot();
                    e.Handled = true;
                    break;
                case Key.LeftShift:
                    setPosition1();
                    break;
            }
        }
        public void setPosition()
        {
           
            for (int i = 0; i < clonedAliens.Length; i++)
            {
                if (clonedAliens[i].isVisible() && alienBullets[i].isHidden())
                {
                    alienBullets[i].setVisible(true);
                    alienBullets[i].setPosition(Canvas.GetLeft(clonedAliens[i].getImage()) + 20, Canvas.GetTop(clonedAliens[i].getImage()) + 35);
                }
            }

         
            for (int i = 0; i < aliens.Length; i++)
            {
                if (aliens[i].isVisible() && alienBullets[i].isHidden())
                {
                    alienBullets[i].setVisible(true);
                    alienBullets[i].setPosition(Canvas.GetLeft(aliens[i].getImage()) + 20, Canvas.GetTop(aliens[i].getImage()) + 35);
                }
            }
        }
        public void setPosition1()
        {
        
                if (changeBullet1.isHidden())
                {
                    changeBullet1.setVisible(true);   
                    changeBullet1.setPosition(Canvas.GetLeft(playerShip.getImage()) + 20, Canvas.GetTop(playerShip.getImage()) + 60);
                }
            
        }
        private void newGameClicked(object sender, MouseButtonEventArgs e)
        {
            //PlayMusic();
            showScreen(1);
            GameScreen.Focus();
            gameTimer = new DispatcherTimer();
            shootingTimer = new DispatcherTimer();
            shootingTimer.Interval = TimeSpan.FromMilliseconds(10);
            shootingTimer.Tick += shootTimer;
            shootingTimer.Start();
            gameTimer.Interval = TimeSpan.FromMilliseconds(10);
            gameTimer.Tick += refresh;
            gameTimer.Start();
            KeyDown += onKeyDown;

            board = Board.builder().addImage(boardImage)
                .addWidth(GameScreen.ActualWidth)
                .addHeight(GameScreen.ActualHeight)
                .addDifficultyLevel(difficultyLevelStrategy).build();

            createAliens(board.getDifficulty());
            createBonuses();
            playerShip = new Ship(shipImage, 0, 0, createBullets());
            points = new Points(pointsLabel);
        }
        private void shootTimer(object sender, EventArgs e)
        {
            setPosition();
            for (int i = 0; i < alienBullets.Length; i++)
            {
                    alienBullets[i].moveDown(2);
               
                if (Canvas.GetTop(alienBullets[i].GetImage()) > 650)
                {
                    alienBullets[i].setVisible(false);
                }
                setPosition();
            }
            //setPosition1();
           changeBullet1.moveDown(2);
            if(Canvas.GetTop(changeBullet1.GetImage()) > 650){
                changeBullet1.setVisible(false);
            }
            //setPosition1();
        }
        private void rankingClicked(object sender, MouseButtonEventArgs e)
        {
            showScreen(2);
        }

        private void endGameClicked(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void showScreen(int option)
        {
            if(option == 1)  //new game
            {
                MenuScreen.Visibility = Visibility.Hidden;
                RankingScreen.Visibility = Visibility.Hidden;
                SettingsScreen.Visibility = Visibility.Hidden;
                GameScreen.Visibility = Visibility.Visible;
                EndGameScreen.Visibility = Visibility.Hidden;
                PlayerName.Text = "";
            } else if(option == 2)  //ranking
            {
                MenuScreen.Visibility = Visibility.Hidden;
                RankingScreen.Visibility = Visibility.Visible;
                SettingsScreen.Visibility = Visibility.Hidden;
                GameScreen.Visibility = Visibility.Hidden;
                EndGameScreen.Visibility = Visibility.Hidden;
            }
            else if (option == 3)  //settings
            {
                MenuScreen.Visibility = Visibility.Hidden;
                RankingScreen.Visibility = Visibility.Hidden;
                SettingsScreen.Visibility = Visibility.Visible;
                GameScreen.Visibility = Visibility.Hidden;
                EndGameScreen.Visibility = Visibility.Hidden;
            } else if(option == 4) //save new player to ranking
            {
                MenuScreen.Visibility = Visibility.Hidden;
                RankingScreen.Visibility = Visibility.Hidden;
                SettingsScreen.Visibility = Visibility.Hidden;
                GameScreen.Visibility = Visibility.Hidden;
                EndGameScreen.Visibility = Visibility.Visible;
            }
            else  //menu
            {
                MenuScreen.Visibility = Visibility.Visible;
                RankingScreen.Visibility = Visibility.Hidden;
                SettingsScreen.Visibility = Visibility.Hidden;
                GameScreen.Visibility = Visibility.Hidden;
                EndGameScreen.Visibility = Visibility.Hidden;
            }
            
        }
        
        private void backMenu(object sender, MouseButtonEventArgs e)
        {
            showScreen(10);
        }

        private void setLevelEasy(object sender, MouseButtonEventArgs e)
        {
            difficultyLevelStrategy = new DifficultyLevelEasy();
            showScreen(10);
        }
        private void setLevelMedium(object sender, MouseButtonEventArgs e)
        {
            difficultyLevelStrategy = new DifficultyLevelMedium();
            showScreen(10);
        }
        private void setLevelHard(object sender, MouseButtonEventArgs e)
        {
            difficultyLevelStrategy = new DifficultyLevelHard();
            showScreen(10);
        }


        private void settingIClicked(object sender, MouseButtonEventArgs e)
        {
            showScreen(3);
        }


        private void addPlayerToRankingOk(object sender, MouseButtonEventArgs e)
        {
            string playerName = PlayerName.Text;
            int playerPoints = points.getValue();
            points.setPlayerName(playerName);
            ranking.getPlayers().Add(points);

            for (int i = 1; i <= ranking.getPlayers().Count; i++)
            {
                Points p = ranking.getPlayers()[i-1];
                if (i==1) setRankingPointToScreen(player1Rank, p.getPlayerName(), p.getValue());
                else if(i==2) setRankingPointToScreen(player2Rank, p.getPlayerName(), p.getValue());
                else if (i == 3) setRankingPointToScreen(player3Rank, p.getPlayerName(), p.getValue());
                else if (i == 4) setRankingPointToScreen(player4Rank, p.getPlayerName(), p.getValue());
                else if (i == 5) setRankingPointToScreen(player5Rank, p.getPlayerName(), p.getValue());
                else if (i == 6) setRankingPointToScreen(player6Rank, p.getPlayerName(), p.getValue());
                else if (i == 7) setRankingPointToScreen(player7Rank, p.getPlayerName(), p.getValue());
                else if (i == 8) setRankingPointToScreen(player8Rank, p.getPlayerName(), p.getValue());
                else if (i == 9) setRankingPointToScreen(player9Rank, p.getPlayerName(), p.getValue());
                else if (i == 10) setRankingPointToScreen(player10Rank, p.getPlayerName(), p.getValue());
            }


            showScreen(10);
        }

        private void setRankingPointToScreen(Label label, string playerName, int playerPoints)
        {
            label.Content = playerName + " " + playerPoints;
            label.Visibility = Visibility.Visible;
        }
        
    }
}