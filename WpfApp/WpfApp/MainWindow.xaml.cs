using Microsoft.Win32;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Entity entity = new Entity(Txt.Text, new BitmapImage(new Uri(PhotoTxt.Text, UriKind.Relative)));

                Panel.Children.Add(new MyUserControl(entity));
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SelectPhotoClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Images(*.JPG;*.GIF;*.PNG)|*.JPG;*.GIF;*.PNG" + "|All files (*.*)|*.* ";
            dialog.CheckFileExists = true;

            if (dialog.ShowDialog() == true)
            {
                PhotoTxt.Text = dialog.FileName;
            }
        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            System.Collections.IList items = Panel.Children;

            for (int i = 0; i < items.Count; i++)
            {
                MyUserControl item = (MyUserControl)items[i];

                if (item.ReadyToRemove)
                {
                    Panel.Children.Remove(item);
                }
            }
        }
    }
}
