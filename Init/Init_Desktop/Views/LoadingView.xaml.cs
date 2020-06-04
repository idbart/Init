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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes;

namespace Init_Desktop.Views
{
    /// <summary>
    /// Interaction logic for LoadingView.xaml
    /// </summary>
    public partial class LoadingView : UserControl
    {
        public LoadingView()
        {
            InitializeComponent();
            
            // set the loading graphic to spin forever
            loadingGraphic.Loaded += (s, e) => {
                // init new animation
                DoubleAnimation rotateAnim = new DoubleAnimation(0, 360, new Duration(new TimeSpan(0, 0, 1)));
                rotateAnim.RepeatBehavior = RepeatBehavior.Forever;

                // set the rendertransform on the element to a new rotatetransform
                RotateTransform transform = new RotateTransform();
                loadingGraphic.RenderTransform = transform;
                loadingGraphic.RenderTransformOrigin = new Point(0.5, 0.5);

                // apply the animation to the rotatetransform
                transform.BeginAnimation(RotateTransform.AngleProperty, rotateAnim);
            };
        }
    }
}
