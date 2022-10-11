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

            IGameField gameField = new GameField();
            IGameControl gameControl = new GameControl();
            IGameUI gameUI = new GameUI(gameField);
            ISnakeController snakeController = new SnakeController();
            IAppleController appleController = new AppleController();
            IGameTimer gameTimer = new GameTimer();

            IGameCore gameCore = new GameCore(gameControl,
                gameField,
                gameUI,
                gameTimer,
                snakeController,
                appleController);
            gameCore.Start();
        }
    }
}
