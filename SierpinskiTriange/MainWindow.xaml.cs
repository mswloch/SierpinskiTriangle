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

namespace SierpinskiTriange
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private SolidColorBrush brush = new SolidColorBrush();
      
        public MainWindow()
        {
            InitializeComponent();
            brush.Color = Color.FromArgb(255, 255, 0, 0);

            Draw();
        }

        /// <summary>
        /// drawing triangle with lines
        /// </summary>
        /// <param name="t">triangle model</param>
        public void DrawTriangle(Triangle t)
        {            
            DrawLine(t.a, t.b);
            DrawLine(t.b, t.c);
            DrawLine(t.c, t.a);
        }

        /// <summary>
        /// Draw simulation on "canvas" grid panel
        /// </summary>
        public void Draw()
        {
            Triangle MainTriangle = new Triangle(new Point(0, 100), Canvas.Width);
            MainTriangle.Recurse(6);

            List<Triangle> list = MainTriangle.GetRecurseTriangles();

            list.ForEach(x => DrawTriangle(x));
        }

        /// <summary>
        /// simplifier for line drawing
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void DrawLine(Point a, Point b)
        {
            Line line = new Line();
            line.Fill = brush;
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 0.5;

            line.X1 = a.X;
            line.Y1 = Canvas.Width - a.Y;
            line.X2 = b.X;
            line.Y2 = Canvas.Width - b.Y;

            Canvas.Children.Add(line);
        }
    }
}
