using System;

namespace Zmeyka2
{
    internal class GameCore : IGameCore
    {
        private IGameControl gameControl;
        private IGameUI gameUI;
        private IGameTimer gameTimer;
        private ISnakeController snakeController;
        private IAppleController appleController;
        private IGameField gameField;
      
        public GameCore(IGameControl gameControl, IGameField gameField, IGameUI gameUI, IGameTimer gameTimer, ISnakeController snakeController, IAppleController appleController)
        {
            this.gameControl = gameControl;
            this.gameField = gameField;
            this.gameUI = gameUI;
            this.gameTimer = gameTimer;
            this.snakeController = snakeController;
            this.appleController = appleController;

            gameUI.OnKeyPressed += GameUI_OnKeyPressed;
            gameUI.OnGameFieldReady += GameUI_OnGameFieldReady;
            gameControl.OnDirectionChanged += GameControl_OnDirectionChanged;

            appleController.OnAppleSpawn += AppleController_OnAppleSpawn;
            appleController.OnAppleRemove += GameUI_OnRemoveElement;

            snakeController.OnAddCell += SnakeController_OnAddCell;
            snakeController.OnCleanCell += GameUI_OnRemoveElement;
            snakeController.OnCollision += SnakeController_OnCollision;
        }

        private void SnakeController_OnCollision(object sender, EventArgs e)
        {
            GameOver();
        }

        private void SnakeController_OnAddCell(object sender, Point e)
        {
            gameUI.DrawSnakeHead(e);
        }

        private void GameUI_OnRemoveElement(object sender, Point e)
        {
            gameUI.RemoveGameElement(e);
        }

        private void AppleController_OnAppleSpawn(object sender, Point e)
        {
            gameUI.DrawApple(e);
        }

        private void GameControl_OnDirectionChanged(object sender, Direction newDirection)
        {
            snakeController.ChangeDirection(newDirection);
        }

        private void GameUI_OnKeyPressed(object sender, int e)
        {
            gameControl.KeyPress(e);
        }

        private void GameUI_OnGameFieldReady(object sender, System.EventArgs e)
        {
            gameTimer.Init(MainGameLoop);
            appleController.Init(gameField.CountRows, gameField.CountColumns);
            snakeController.Init(gameField.CountRows, gameField.CountColumns);
        }

        private void MainGameLoop()
        {
            Point headPosition = snakeController.MoveSnake();
            CheckCollision(headPosition);
            gameUI.DrawSnakeHead(headPosition);
        }

        private void CheckCollision(Point headPosition)
        {
            if (gameField.CheckCollisionBorders(headPosition))
            {
                GameOver();
                return;
            }
            if (appleController.Collision(headPosition))
            {
                snakeController.Increase();
                gameTimer.IncreaseSpeed();
            }
        }

        private void GameOver()
        {
            gameUI.ViewMessage("Игра окончена! Заново?");
            ResetGame();
        }

        private void ResetGame()
        {
            gameUI.Clear();
            appleController.Init(gameField.CountRows, gameField.CountColumns);
            snakeController.Init(gameField.CountRows, gameField.CountColumns);
        }

        public void Start()
        {
            gameUI.Init();
        }
    }
}