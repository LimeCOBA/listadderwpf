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

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MyUserControl.xaml
    /// </summary>

    public partial class MyUserControl : UserControl
    {
        Brush old;
        Brush oldOfRTR;
        public bool ReadyToRemove = false;

        public MyUserControl()
        {
            InitializeComponent();
        }

        public MyUserControl(Entity e) : this()
        {
            ImageView.Source = e.Image;
            Description.Content = e.Text;
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!ReadyToRemove)
            {
                old = ColorRect.Fill;
                ColorRect.Fill = new SolidColorBrush(Color.FromRgb(224, 224, 224));
            }
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!ReadyToRemove)
                ColorRect.Fill = old;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!ReadyToRemove)
            {
                ReadyToRemove = !ReadyToRemove;
                oldOfRTR = ColorRect.Fill;
                ColorRect.Fill = new SolidColorBrush(Color.FromRgb(208, 208, 208));
            }
            else
            {
                ReadyToRemove = !ReadyToRemove;
                ColorRect.Fill = oldOfRTR;
            }
        }
    }
}
