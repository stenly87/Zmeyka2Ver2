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
        public double GameWidth { get; private set; }
        public double GameHeight { get; private set; }
        public int CountRows { get; private set; }
        public int CountColumns { get; private set; }

        int _elementSize = 55;
        MainWindow window;
        Canvas mainCanvas;

        public event EventHandler OnGameFieldReady;
        public event EventHandler<int> OnKeyPressed;

        Dictionary<Point, Rectangle> elements = new Dictionary<Point, Rectangle>();

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
            GameWidth = mainCanvas.ActualWidth;
            GameHeight = mainCanvas.ActualHeight;
            CountColumns = (int)GameWidth / _elementSize;
            CountRows = (int)GameHeight / _elementSize;

            for (int i = 0; i < CountRows; i++)
            {
                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = 0;
                line.Y1 = i * _elementSize;
                line.X2 = GameWidth;
                line.Y2 = i * _elementSize;
                mainCanvas.Children.Add(line);
            }
            for (int i = 0; i < CountColumns; i++)
            {
                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = i * _elementSize;
                line.Y1 = 0;
                line.X2 = i * _elementSize;
                line.Y2 = GameHeight;
                mainCanvas.Children.Add(line);
            }
        }

        public void ViewMessage(string message)
        {
            MessageBox.Show(message);
        }

        public bool CheckCollisionBorders(Point headPosition)
        {
            return headPosition.X > GameWidth - _elementSize ||
                headPosition.X < 0 || headPosition.Y < 0 ||
                headPosition.Y > GameHeight - _elementSize;
        }

        public void Clear()
        {
            mainCanvas.Children.Clear();
            DrawGame();
        }

        public void RemoveGameElement(Point e)
        {
            if (elements.ContainsKey(e))
            {
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
            Rectangle rect = new Rectangle();
            rect.Width = _elementSize;
            rect.Height = _elementSize;
            rect.Fill = color;

            elements.Add(position, rect);

            mainCanvas.Children.Add(rect);
            Canvas.SetLeft(rect, position.X * _elementSize);
            Canvas.SetTop(rect, position.Y * _elementSize);
        }
    }
}