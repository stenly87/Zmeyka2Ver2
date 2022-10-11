using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Zmeyka2
{
    internal class GameUI : IGameUI
    {
        int _elementSize = 55;
        MainWindow window;
        Canvas mainCanvas;
        RectangleContainer rectangleContainer;

        public event EventHandler OnGameFieldReady;
        public event EventHandler<int> OnKeyPressed;

        Dictionary<Point, Rectangle> elements = new Dictionary<Point, Rectangle>();
        private IGameField gameField;

        public GameUI(IGameField gameField)
        {
            this.gameField = gameField;
            rectangleContainer = new RectangleContainer();
        }

        public void Init()
        {
            window = new MainWindow();
            window.OnContentRenderedEvent += Window_OnContentRenderedEvent;
            window.OnKeyPressed += Window_OnKeyPressed;
            window.Show();
        }

        private void Window_OnKeyPressed(object sender, Key e)
        {
            OnKeyPressed?.Invoke(this, (int)e);
        }

        private void Window_OnContentRenderedEvent(object sender, EventArgs e)
        {
            mainCanvas = window.Game;
            DrawGame();
            OnGameFieldReady?.Invoke(this, new EventArgs());
        }

        private void DrawGame()
        {
            gameField.Init(mainCanvas.ActualWidth / _elementSize, mainCanvas.ActualHeight / _elementSize);
            
            for (int i = 0; i < gameField.CountRows; i++)
            {
                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = 0;
                line.Y1 = i * _elementSize;
                line.X2 = gameField.GameWidth * _elementSize;
                line.Y2 = i * _elementSize;
                mainCanvas.Children.Add(line);
            }
            for (int i = 0; i < gameField.CountColumns; i++)
            {
                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = i * _elementSize;
                line.Y1 = 0;
                line.X2 = i * _elementSize;
                line.Y2 = gameField.GameHeight * _elementSize;
                mainCanvas.Children.Add(line);
            }
        }

        public void ViewMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void Clear()
        {
            mainCanvas.Children.Clear();
            elements.Clear();
            rectangleContainer.Clear();
            DrawGame();
        }

        public void RemoveGameElement(Point e)
        {
            if (elements.ContainsKey(e))
            {
                rectangleContainer.Store(elements[e]);
                mainCanvas.Children.Remove(elements[e]);
                elements.Remove(e);
            }
        }

        public void DrawApple(Point applePosition)
        {
            AddRectangle(applePosition, Brushes.Red);
        }

        public void DrawSnakeHead(Point headPosition)
        {
            AddRectangle(headPosition, Brushes.Green);
        }

        private void AddRectangle(Point position, SolidColorBrush color)
        {
            if (elements.ContainsKey(position))
                return;

            Rectangle rect = rectangleContainer.GetFreeRectangle(_elementSize);
            rect.Fill = color;

            elements.Add(position, rect);

            mainCanvas.Children.Add(rect);
            Canvas.SetLeft(rect, position.X * _elementSize);
            Canvas.SetTop(rect, position.Y * _elementSize);
        }
    }
}