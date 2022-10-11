using System;
using System.Windows;
using System.Windows.Input;


namespace Zmeyka2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event EventHandler OnContentRenderedEvent;
        public event EventHandler<Key> OnKeyPressed;

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            OnContentRenderedEvent?.Invoke(this, new EventArgs());
            base.OnContentRendered(e);
        }

        private void KeyWasReleased(object sender, KeyEventArgs e)
        {
            OnKeyPressed?.Invoke(this, e.Key);
        }
    }
}
