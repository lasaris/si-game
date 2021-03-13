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

        private Canvas MyCanvas { get; set; }

        public Random Rand => new Random();

        public DelegateCommand ReturnFromSearchingCommand { get; set; }
        public DelegateCommand ClickOnCanvas { get; set; }

        public BubleClickerViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
            : base(regionManager, eventAggregator, gameState)
        {
            ReturnFromSearchingCommand = new DelegateCommand(ReturnFromSearchingCommandExecute);
            ClickOnCanvas = new DelegateCommand(ClickOnCanvasExecute);

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

        private void ReturnFromSearchingCommandExecute()
        {
            RegionManager.RequestNavigate(Regions.BrowserRegion, Regions.MinigameSelectionView);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => false;
        public void OnNavigatedTo(NavigationContext navigationContext) { }
        public void OnNavigatedFrom(NavigationContext navigationContext) { }

        public void ClickOnCanvasExecute()
        {
            MessageBox.Show("Hello, world!");
        }

        private void GameLoop2()
        {
            ((Label) MyCanvas.Children[0]).Content = "Score: " + Score;
            ((Label) MyCanvas.Children[1]).Content = "Trashold: " + RequiredScore;

            SpawnRate -= 2;

            if (SpawnRate < 1)
            {
                SpawnRate = CurrentSpawnRate;

                PosX = Rand.Next(50, (int) MyCanvas.ActualWidth - 50);
                PosY = Rand.Next(50, (int) MyCanvas.ActualHeight - 50);

                Ellipse circle = new Ellipse
                {
                    Tag = "circle",
                    Height = 10,
                    Width = 10,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                    Fill = new SolidColorBrush(Color.FromRgb(
                        (byte)Rand.Next(1, 255),
                        (byte)Rand.Next(1, 255),
                        (byte)Rand.Next(1, 255)
                    ))
                };

                Canvas.SetLeft(circle, PosX);
                Canvas.SetTop(circle, PosY);

                MyCanvas.Children.Add(circle);
            }
        }

        public void OnLeftButtonClicked(object s, MouseButtonEventArgs e)
        {
            if (MyCanvas is null)
                MyCanvas = (Canvas)s;
            // MessageBox.Show($" => {s} ");
            if (e.OriginalSource is Ellipse)
            {
                // var sa mu nepaci viac ako toto :whatcat: ....
                Ellipse circle = (Ellipse)e.OriginalSource;

                ((Canvas)s).Children.Remove(circle);

                Score += 1;

                // GameLoop((Canvas)s);
            }
            // GameLoop2();
        }
    }
}
