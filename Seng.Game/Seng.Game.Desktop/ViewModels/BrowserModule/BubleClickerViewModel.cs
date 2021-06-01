using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Desktop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Threading;
using System.Linq;

namespace Seng.Game.Desktop.ViewModels
{
    public class BubleClickerViewModel : BaseViewModel, INavigationAware
    {
        DispatcherTimer gameTimer = new DispatcherTimer();

        List<Ellipse> removeElements = new List<Ellipse>();

        public int PosX { get; set; }
        public int PosY { get; set; }
        public int CurrentSpawnRate { get; set; }
        public int SpawnRate { get; set; } = 60;
        public int Score { get; set; } = 0;
        public int RequiredScore { get; set; } = 20;
        public double growRate { get; set; } = 0.6;
        public Brush Brush { get; set; }
        public int HP { get; set; } = 100;

        private Canvas MyCanvas { get; set; }
        private const int Damage = 10;
        private const int MaxCirleRadius = 70;
        private const double Multiplier = 3.5;

        public Random Rand => new Random();

        public DelegateCommand ReturnFromSearchingCommand { get; set; }

        public BubleClickerViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
            : base(regionManager, eventAggregator, gameState)
        {
            ReturnFromSearchingCommand = new DelegateCommand(ReturnFromSearchingCommandExecute);

            gameTimer.Tick += GameLoop;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();

            CurrentSpawnRate = SpawnRate;

        }

        private void GameLoop(object sender, EventArgs e)
        {
            if (MyCanvas != null)
                GameLoop2();
        }
        
        private void GameLoopBreaker()
        {
            gameTimer.Stop();
        }

        private void ReturnFromSearchingCommandExecute()
        {
            GameLoopBreaker();
            RegionManager.RequestNavigate(Regions.BrowserRegion, Regions.MinigameSelectionView);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => false;
        public void OnNavigatedTo(NavigationContext navigationContext) { }
        public void OnNavigatedFrom(NavigationContext navigationContext) { }

        private void GameLoop2()
        {
            ((Label) MyCanvas.Children[0]).Content = "Score: " + Score;
            ((Label) MyCanvas.Children[1]).Content = "Trashold: " + RequiredScore;

            SpawnRate -= 2;

            if (SpawnRate < 1)
                CreateNewBubble();

            foreach (var child in MyCanvas.Children.OfType<Ellipse>())
            {
                child.Height += growRate;
                child.Width += growRate;
                child.RenderTransformOrigin = new Point(0.5, 0.5);

                if (child.Width >= MaxCirleRadius)
                {
                    removeElements.Add(child);
                    HP -= Damage;
                }
            }

            if (HP > 1)
                ((Rectangle)MyCanvas.Children[2]).Width = HP * Multiplier;
            else
            {
                GameLoopBreaker();
                MessageBox.Show("You have died!!!");
            }

            foreach (var ellipse in removeElements)
                MyCanvas.Children.Remove(ellipse);
            
            
        }
        
        private void CreateNewBubble()
        {
            SpawnRate = CurrentSpawnRate;

            PosX = Rand.Next(MaxCirleRadius, (int) MyCanvas.ActualWidth - MaxCirleRadius);
            PosY = Rand.Next(MaxCirleRadius, (int) MyCanvas.ActualHeight - MaxCirleRadius);

            Ellipse circle = new Ellipse
            {
                Tag = "circle",
                Height = 10,
                Width = 10,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Fill = new SolidColorBrush(Color.FromRgb(
                    (byte) Rand.Next(1, 255),
                    (byte) Rand.Next(1, 255),
                    (byte) Rand.Next(1, 255)
                ))
            };

            Canvas.SetLeft(circle, PosX);
            Canvas.SetTop(circle, PosY);

            MyCanvas.Children.Add(circle);
        }

        public void OnLeftButtonClicked(object s, MouseButtonEventArgs e)
        {
            if (MyCanvas is null)
                MyCanvas = (Canvas)s;

            // MessageBox.Show($" => {s} ");

            if (e.OriginalSource is Ellipse)
            {
                Ellipse circle = (Ellipse)e.OriginalSource;

                ((Canvas)s).Children.Remove(circle);

                Score += 1;

                if (Score == RequiredScore)
                {
                    GameLoopBreaker();
                    MessageBox.Show("Congratulations, you have won! You can now leave from this app :)");
                }
            }
        }
    }
}
