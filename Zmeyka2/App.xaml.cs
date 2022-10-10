using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Zmeyka2
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IGameControl gameControl = new GameControl();
            IGameUI gameUI = new GameUI();
            ISnakeController snakeController = new SnakeController();
            IAppleController appleController = new AppleController();
            IGameTimer gameTimer = new GameTimer();

            IGameCore gameCore = new GameCore(gameControl, gameUI, gameTimer, snakeController, appleController);
            gameCore.Start();
        }
    }
}
