using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp
{
    public class Entity
    {
        public string Text;

        public BitmapImage Image
        {
            set
            {
                if (value.UriSource != new Uri("", UriKind.Relative))
                {
                    _image = new BitmapImage();
                    _image.BeginInit();
                    _image.UriSource = value.UriSource;
                    _image.CacheOption = BitmapCacheOption.OnLoad;
                    _image.EndInit();
                }
                else
                {
                    _image = null;
                }
            }
            get { return _image; }
        }

        BitmapImage _image;

        public Entity()
        {
            Image = new BitmapImage();
            Text = "";
        }

        public Entity(string text, BitmapImage image)
        {
            Text = text;
            Image = image;
        }
    }
}
