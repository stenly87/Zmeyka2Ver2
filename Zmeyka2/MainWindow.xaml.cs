using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Linq;


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
